using Nework.CommonLibrary;
using Nework.EngineApi;
using System;
using System.Diagnostics;

namespace Nework.Orchestration.EngineHandlers
{
    internal class PortalHandler : PropertyChangeSource
    {
        internal string Name { get; set; } = $"Hi (from {nameof(PortalHandler)})";//string.Empty;
        internal int AgentId { get; }
        internal int ExternalId { get; }

        private Action<int, CommandType> m_SendParameterlessCommand;
        private Action<int, CommandType, string> m_SendParameteredCommand;

        public PortalHandler(EngineConnection engineConnection, MessageEventArgs eventArgs)
        {
            m_SendParameteredCommand = engineConnection.SendCommand;
            m_SendParameterlessCommand = engineConnection.SendCommand;

            AgentId = eventArgs.AgentId;

            switch (eventArgs.Type)
            {
                case MessegeType.Portal_New:
                    //Assume the DS engine's ints are at least 16 bits.
                    //  Still gives low odds of id collisions.
                    ExternalId = RandomHelper.Rand.Next(Int16.MaxValue);
                    m_SendParameteredCommand(AgentId, CommandType.Portal_SetId, ExternalId.ToString());
                    break;
                case MessegeType.Portal_WorldLoaded:
                    string parameter = ((ParameteredMessageEventArgs)eventArgs).Parameter;
                    int id;
                    if (Int32.TryParse(parameter, out id))
                    {
                        ExternalId = id;
                    }
                    else
                    {
                        Debug.Fail($"{parameter} should have been an int.");
                    }
                    break;
                default:
                    throw new Exceptions.OrchestrationException($"Type invalid: {eventArgs.Type}", new ArgumentException());
            }
        }

        public void TurnOn()
            => m_SendParameterlessCommand(this.AgentId, CommandType.Portal_TurnOn);


        public void TurnOff()
            => m_SendParameterlessCommand(this.AgentId, CommandType.Portal_TurnOff);


        internal void ReceivedMessageEvent(MessageEventArgs e)
        {
            switch (e.Type)
            {
                //case MessegeType.Portal_Closed:
                //    this.
            }
        }
    }
}
