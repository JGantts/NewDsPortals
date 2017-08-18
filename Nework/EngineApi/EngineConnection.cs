using Nework.EngineApi.Exceptions;
using System;
using System.IO;

namespace Nework.EngineApi
{
    public class EngineConnection
    {
        private CommandWriter m_CommandWriter { get; }

        public EngineConnection(DirectoryInfo worldDir, EventHandler<MessageEventArgs> messageEventHandler)
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

            MessgeReader reader = new MessgeReader(journalDir, messageEventHandler);
            m_CommandWriter = new CommandWriter(journalDir);
        }

        public void SendCommand(int agentId, CommandType commandType)
            => m_CommandWriter.SendCommand(agentId, commandType);


        public void SendCommand(int agentId, CommandType commandType, string parameter)
            => m_CommandWriter.SendCommand(agentId, commandType, parameter);
        }
 }
