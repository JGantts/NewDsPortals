using System;

namespace Nework.EngineApi
{
     public class MessageEventArgs : EventArgs
    {
        public int AgentId { get; }
        public int WorldTciks { get; }
        public MessegeType Type { get; }

        internal MessageEventArgs(int agentId, int worldTicks, MessegeType type)
        {
            AgentId = agentId;
            WorldTciks = worldTicks;
            Type = type;
        }
    }

    public class ParameterlessMessageEventArgs : MessageEventArgs
    {

        public ParameterlessMessageEventArgs(int agentId, int worldTicks, MessegeType type)
            : base(agentId, worldTicks, type)
        {
        }
    }

    public class ParameteredMessageEventArgs : MessageEventArgs
    {
        public string Parameter { get; }

        public ParameteredMessageEventArgs(int agentId, int worldTicks, MessegeType type, string parameter)
            : base(agentId, worldTicks, type)
        {
            Parameter = parameter;
        }
    }
}
