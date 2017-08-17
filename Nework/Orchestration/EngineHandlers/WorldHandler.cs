using Nework.EngineApi;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Nework.Orchestration.EngineHandlers
{
    class WorldHandler
    {
        public EventHandler<MessageEventArgs> MessageEvent;

        public ObservableCollection<PortalHandler> PortalHandlers
            = new ObservableCollection<PortalHandler>();

        public EngineConnection m_engineConnection { get; }

        public WorldHandler(DirectoryInfo worldDir)
        {
            m_engineConnection = new EngineConnection(
                new MessageHandler(this).ReceivedMessageEvent, worldDir);

            //m_engineConnection.MessageEvent += new MessageHandler(this).ReceivedMessageEvent;
        }

        public WorldHandler()
            : this(new DirectoryInfo(
                @"C:\Program Files (x86)\Docking Station\My Worlds\DummyWorld"))
        { }

        internal void NewPortal(ParameterlessMessageEventArgs eventArgs)
        {
            Debug.Assert(eventArgs.Type == MessegeType.Portal_WorldLoaded);
            PortalHandlers.Add(new PortalHandler(m_engineConnection, eventArgs));
        }
    }
}
