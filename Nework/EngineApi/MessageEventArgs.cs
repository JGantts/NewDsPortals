using Nework.EngineApi.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nework.EngineApi
{
    public class MessageEventArgs : EventArgs
    {
        public int AgentId { get; }
        public int WorldTciks { get; }
        public MessegeType Type { get; }
        public IEnumerable<string> Parameters { get; }

        internal MessageEventArgs(int agentId, int worldTicks, MessegeType type, IEnumerable<string> parameters)
        {
            AgentId = agentId;
            WorldTciks = worldTicks;
            Type = type;
            Parameters = parameters.ToList();
            if (!Parameters.Any())
            {
                throw new EngineApiException("No parameters found.");
            }
        }
    }
}
