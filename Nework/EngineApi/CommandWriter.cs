using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace Nework.EngineApi
{
    class CommandWriter
    {
        private string _EngineInFilePath { get; }
        
        private IList<string> _Commands = new List<string>();

        internal CommandWriter(DirectoryInfo journalDir)
        {
            Debug.Assert(journalDir != null);
            Debug.Assert(journalDir.Exists);

            _EngineInFilePath = Path.Combine(journalDir.FullName, "Nework-Engine-InPipe.txt");

            BackgroundWorker timer = new BackgroundWorker();
            timer.DoWork += (object sender, DoWorkEventArgs e) =>
            {
                Thread.Sleep(millisecondsTimeout: 2500);
                while (true)
                {
                    WriteCommands();
                    Thread.Sleep(millisecondsTimeout: 5000);
                }
            };
            timer.RunWorkerAsync();
        }

        internal void SendCommand(int agentId, ParamaterlessCommandType commandType)
        {
            SendCommand(agentId, commandType.ToString(), string.Empty);
        }


        internal void SendCommand(int agentId, ParamateredCommandType commandType, string parameter)
        {
            if (string.IsNullOrWhiteSpace(parameter))
            {
                throw new EngineApiException("Paremeter paremeter cannot be null, empty, or whitespace.");
            }

            SendCommand(agentId, commandType.ToString(), parameter);
        }

        private void SendCommand(int agentId, string commandType, string parameter)
        {
            string command = $"{agentId} {commandType} {parameter}";
            lock (_Commands)
            {
                _Commands.Add(command);
            }
        }

        private void WriteCommands()
        {
            if (_Commands.Any())
            {
                List<string> commands;
                lock (_Commands)
                {
                    commands = _Commands.ToList();
                    _Commands.Clear();
                }
                WriteCommandsToFile(commands);
            }
        }

        private void WriteCommandsToFile(IEnumerable<string> commands)
        {
            try
            {
                File.AppendAllLines(_EngineInFilePath, commands);
            }
            catch (Exception)
            {
                Thread.Sleep(500);
                WriteCommandsToFile(commands);
            }
        }
    }
}
