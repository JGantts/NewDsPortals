using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nework.EngineApi
{
    public delegate void MessageEventHandler(object sender, IMessageEventArgs a);

    public interface IMessageEventArgs
    {
        int AgentId { get; }
        int WorldTciks { get; }
    }

    public interface IParameterlessMessageEventArgs : IMessageEventArgs
    {
        ParameterlessMessegeType Type { get; }
    }


    public interface IParameteredMessageEventArgs : IMessageEventArgs
    {
        ParameteredMessegeType Type { get; }
        string Parameter { get; }
    }

    internal abstract class MessageEventArgs : IMessageEventArgs
    {
        public int AgentId { get; }
        public int WorldTciks { get; }

        internal MessageEventArgs(int agentId, int worldTicks)
        {
            AgentId = agentId;
            WorldTciks = worldTicks;
        }
    }

    internal class ParameterlessMessageEventArgs : MessageEventArgs, IParameterlessMessageEventArgs
    {
        public ParameterlessMessegeType Type { get; }

        public ParameterlessMessageEventArgs(int agentId, int worldTicks, ParameterlessMessegeType type)
            : base(agentId, worldTicks)
        {
            Type = type;
        }
    }

    internal class ParameteredMessageEventArgs : MessageEventArgs, IParameteredMessageEventArgs
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
