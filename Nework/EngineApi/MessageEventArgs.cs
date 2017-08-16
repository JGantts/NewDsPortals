using System;

namespace Nework.EngineApi
{
     public class MessageEventArgs : EventArgs
    {
        public int AgentId { get; }
        public int WorldTciks { get; }

        internal MessageEventArgs(int agentId, int worldTicks)
        {
            AgentId = agentId;
            WorldTciks = worldTicks;
        }
    }

    public class ParameterlessMessageEventArgs : MessageEventArgs
    {
        public ParameterlessMessegeType Type { get; }

        public ParameterlessMessageEventArgs(int agentId, int worldTicks, ParameterlessMessegeType type)
            : base(agentId, worldTicks)
        {
            Type = type;
        }
    }

    public class ParameteredMessageEventArgs : MessageEventArgs
    {
        public string Parameter { get; }
        public ParameteredMessegeType Type { get; }

        public ParameteredMessageEventArgs(int agentId, int worldTicks, ParameteredMessegeType type, string parameter)
            : base(agentId, worldTicks)
        {
            Type = type;
            Parameter = parameter;
        }
    }
}
