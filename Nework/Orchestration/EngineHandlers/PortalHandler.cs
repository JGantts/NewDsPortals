using Nework.CommonLibrary;
using Nework.EngineApi;
using Nework.Orchestration.Exceptions;
using System;
using System.Diagnostics;
using System.Linq;

namespace Nework.Orchestration.EngineHandlers
{
    internal class PortalHandler : PropertyChangeSource
    {
        internal string Name { get; set; } = $"Hi (from {nameof(PortalHandler)})";//string.Empty;
        internal int AgentId { get; }
        internal int ExternalId { get; }
        
        private Action<int, CommandType, string> m_SendCommand;
        private WorldHandler m_WorldHandler { get; }

        public PortalHandler(WorldHandler worldHandler, EngineConnection engineConnection, MessageEventArgs eventArgs)
        {
            m_SendCommand = engineConnection.SendCommand;
            m_WorldHandler = worldHandler;

            m_SendCommand += SentCommandToEngine;

            AgentId = eventArgs.AgentId;

            switch (eventArgs.Type)
            {
                case MessegeType.Portal_New:
                    //Assumes the DS engine's ints are at least 16 bits.
                    //  Still gives low odds of id collisions.
                    ExternalId = RandomHelper.Rand.Next(Int16.MaxValue);
                    m_SendCommand(AgentId, CommandType.Portal_SetId, ExternalId.ToString());
                    break;
                case MessegeType.Portal_WorldLoaded:
                    if(!eventArgs.Parameters.Any())
                    {
                        Debug.Fail("No parameters found.");
                    }
                    int id;
                    if (Int32.TryParse(eventArgs.Parameters.First(), out id))
                    {
                        ExternalId = id;
                    }
                    else
                    {
                        throw new OrchestrationException($"Parameter should have been an int.");
                    }
                    break;
                default:
                    throw new Exceptions.OrchestrationException($"Type invalid: {eventArgs.Type}", new ArgumentException());
            }
        }

        public void TurnOn()
            => m_SendCommand(this.AgentId, CommandType.Portal_TurnOn, string.Empty);


        public void TurnOff()
            => m_SendCommand(this.AgentId, CommandType.Portal_TurnOff, string.Empty);


        internal void ReceivedMessageEvent(MessageEventArgs e)
        {
            switch (e.Type)
            {
                //case MessegeType.Portal_Closed:
                //    this.
            }
        }

        private void SentCommandToEngine(int agentId, CommandType command)
        {
            m_WorldHandler.RecentMessages.Add($"{agentId} {command}");
        }

        private void SentCommandToEngine(int agentId, CommandType command, string str)
        {
            m_WorldHandler.RecentMessages.Add($"{agentId} {command}");
        }
    }
}
