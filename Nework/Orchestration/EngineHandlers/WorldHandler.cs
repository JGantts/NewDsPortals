using Nework.EngineApi;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace Nework.Orchestration.EngineHandlers
{
    class WorldHandler
    {
        public EventHandler<MessageEventArgs> MessageEvent;

        public ObservableCollection<PortalHandler> PortalHandlers
            = new ObservableCollection<PortalHandler>();

        public WorldHandler(DirectoryInfo worldDir)
        {

        }

        public WorldHandler()
        {
            PortalHandlers.Add(new PortalHandler("Portal A"));
            PortalHandlers.Add(new PortalHandler("Portal B"));
        }
    }
}
