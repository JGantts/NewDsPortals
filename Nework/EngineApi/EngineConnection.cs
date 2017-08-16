using System;
using System.IO;

namespace Nework.EngineApi
{
    public class EngineConnection
    {
        public EventHandler<MessageEventArgs> MessageEvent;

        private CommandWriter m_CommandWriter { get; }

        public EngineConnection(DirectoryInfo worldDir)
        {
            if (worldDir == null)
            {
                throw new EngineApiException("Bad world directory.",
                    new ArgumentNullException(nameof(worldDir)));
            }
            if (!worldDir.Exists)
            {
                throw new EngineApiException($"Bad world directory.",
                    new DirectoryNotFoundException(worldDir.ToString()));
            }
            DirectoryInfo journalDir = new DirectoryInfo(Path.Combine(worldDir.FullName, "Journal"));
            if (!journalDir.Exists)
            {
                throw new EngineApiException($"Bad world directory.",
                    new DirectoryNotFoundException(journalDir.ToString()));
            }

            MessgeReader reader = new MessgeReader(journalDir, MessageEvent);
            m_CommandWriter = new CommandWriter(journalDir);
        }

        public void SendCommand(int agentId, ParamaterlessCommandType commandType)
            => m_CommandWriter.SendCommand(agentId, commandType);


        public void SendCommand(int agentId, ParamateredCommandType commandType, string parameter)
            => m_CommandWriter.SendCommand(agentId, commandType, parameter);
        }
 }
