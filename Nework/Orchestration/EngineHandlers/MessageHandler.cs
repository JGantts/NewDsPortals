using Nework.EngineApi;
using Nework.Orchestration.Exceptions;
using System.Linq;

namespace Nework.Orchestration.EngineHandlers
{
    internal class MessageHandler
    {
        WorldHandler m_WorldHandler { get; }

        internal MessageHandler(WorldHandler worldHandler)
        {
            m_WorldHandler = worldHandler;
        }

        internal void ReceivedMessageEvent(object sender, MessageEventArgs e)
        {
            m_WorldHandler.RecentMessages.Add($"{e.WorldTciks} {e.AgentId} {e.Type}");
            var senderAgent = m_WorldHandler.PortalHandlers.Where(x => x.AgentId == e.AgentId);
            if (senderAgent.Any())
            {
                senderAgent.Single().ReceivedMessageEvent(e);
            }
            else
            {
                switch (e.Type)
                {
                    case MessegeType.Portal_New:
                        m_WorldHandler.PortalHandlers.Add(new PortalHandler(m_WorldHandler, m_WorldHandler.m_engineConnection, e));
                        break;
                    case MessegeType.MessageHandler_New:
                    case MessegeType.CommandHandler_New:
                        //Don't actaully care about this, yet.
                        break;
                    default:
                        break;
                        //throw new OrchestrationException();
                }
            }
        }
    }
}
