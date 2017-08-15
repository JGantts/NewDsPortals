﻿using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Nework.EngineApi
{
    public class EngineConnection
    {
        public MessageEventHandler MessageEvent;

        //private DirectoryInfo _WorldDir { get; }

        private CommandWriter _CommandWriter { get; }
        //private MessgeReader _MessageReader { get; }

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
            _CommandWriter = new CommandWriter(journalDir);
        }

        public void SendCommand(int agentId, ParamaterlessCommandType commandType)
            => _CommandWriter.SendCommand(agentId, commandType);


        public void SendCommand(int agentId, ParamateredCommandType commandType, string parameter)
            => _CommandWriter.SendCommand(agentId, commandType, parameter);
        }
 }