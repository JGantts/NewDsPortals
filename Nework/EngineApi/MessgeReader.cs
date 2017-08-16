using Nework.EngineApi.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace Nework.EngineApi
{
    class MessgeReader
    {
        private string m_EngineOutFilePath { get; }

        private object m_Lock = new object();

        private event EventHandler<MessageEventArgs> m_MessageEvent;

        internal MessgeReader(DirectoryInfo journalDir, EventHandler<MessageEventArgs> messageEvent)
        {
            Debug.Assert(journalDir != null);
            Debug.Assert(journalDir.Exists);
            
            m_EngineOutFilePath = Path.Combine(journalDir.FullName, "Nework-Engine-OutPipe.txt");

            m_MessageEvent = messageEvent;

            BackgroundWorker timer = new BackgroundWorker();
            timer.DoWork += (object sender, DoWorkEventArgs e) =>
            {
                //Thread.Sleep(millisecondsTimeout: 0);
                while (true)
                {
                    ReadMessages();
                    Thread.Sleep(millisecondsTimeout: 5000);
                }
            };
            timer.RunWorkerAsync();
        }

        /// <summary>
        ///     Reads ExInNet-PortalHandler-OutPipe file from world's Journal directory.
        ///     
        /// </summary>
        private void ReadMessages()
        {
            if (!File.Exists(m_EngineOutFilePath))
            {
                //There's still a race condition.
                //  (would be unlikely, but file may be deleted by some weird random process)
                //This is mainly for valid worlds w/o any portals
                return;
            }

            List<string> lines = new List<string>();

            FileStream fileStream;
            try
            {
                fileStream = new FileStream(
                    m_EngineOutFilePath, FileMode.OpenOrCreate,
                    FileAccess.ReadWrite, FileShare.None);
                StreamReader reader = new StreamReader(fileStream);

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
                lines = lines.Where(l => l.Length > 0).ToList<string>();
                if (lines.Any())
                {
                    //clear the file
                    fileStream.SetLength(0);
                }
            }
            catch (Exception)
            {

            }

            foreach (string line in lines)
            {
                //line in form "001 009 Portal_TurnedOn" meaning worldTick:1 agentId:9 portal turned on
                //or "078 040 Portal_Imported 001_blue-0493-.." meaning worldTick:78 agentId:009 imported norn x
                string[] chunks = line.Split(' ');
                if (chunks.Length == 3 || chunks.Length == 4)
                {
                    int worldTicks;
                    int agentId;
                    if (int.TryParse(chunks[0], out worldTicks) &&
                        int.TryParse(chunks[1], out agentId))
                    {
                        ParameterlessMessegeType lessType;
                        ParameteredMessegeType edType;
                        if (Enum.TryParse(chunks[2], out lessType))
                        {
                            Debug.Assert(chunks.Length == 3);
                            m_MessageEvent(this, new ParameterlessMessageEventArgs(agentId, worldTicks, lessType));
                        }
                        else if (Enum.TryParse(chunks[2], out edType))
                        {
                            Debug.Assert(chunks.Length == 4);
                            m_MessageEvent(this, new ParameteredMessageEventArgs(agentId, worldTicks, edType, chunks[4]));
                        }
                        else
                        {
                            throw new EngineApiException($"Bad Line. Can't parse message type. Line: {line}");
                        }
                    }
                    else
                    {
                        throw new EngineApiException($"Bad Line. Can't parse. Line: {line}");
                    }
                }
                else if (chunks.Length != 1 && chunks[0] != " ")
                {
                    throw new EngineApiException($"Bad Line. Can't parse. Line: {line}");
                }
            }
        }
    }
}
