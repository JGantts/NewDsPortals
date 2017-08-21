using Nework.EngineApi;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;

namespace Nework.Orchestration.EngineHandlers
{
    class WorldHandler
    {
        public EventHandler<MessageEventArgs> MessageEvent;

        public ObservableCollection<PortalHandler> PortalHandlers
            = new ObservableCollection<PortalHandler>();

        public ObservableCollection<string> RecentMessages { get; }
            = new ObservableCollection<string>();

        public EngineConnection m_engineConnection { get; }

        public WorldHandler(DirectoryInfo worldDir)
        {
            m_engineConnection = new EngineConnection(
                worldDir,
                (new MessageHandler(this)).ReceivedMessageEvent
            );
        }

        public WorldHandler()
            : this(new DirectoryInfo(
                @"C:\Users\jacob\Documents\Creatures\Docking Station\My Worlds\Nework Testing 1.0"))
        { }

        internal void NewPortal(MessageEventArgs eventArgs)
        {
            Debug.Assert(eventArgs.Type == MessegeType.Portal_WorldLoaded);
            PortalHandlers.Add(new PortalHandler(this, m_engineConnection, eventArgs));
        }
    }
}
