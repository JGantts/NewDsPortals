using Nework.CommonLibrary;
using Nework.Orchestration.EngineHandlers;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Nework.Orchestration.Model
{
    internal class WorldModel : PropertyChangeSource, IWorldModel
    {
        public ObservableCollection<IPortalModel> IPortalModels { get; }
            = new ObservableCollection<IPortalModel>();

        //public IEnumerable<string> Messages { get; } = new List<string>();

        private Bridge m_IPortalModelsBridge = null;
        private Bridge m_RecentMessagesBridge = null;

        public ObservableCollection<string> RecentMessages { get; }
            = new ObservableCollection<string>();

        public WorldModel()
        { }

        public WorldModel(WorldHandler worldHandler)
        {
            ConnectToWorld(worldHandler);
        }

        internal void ConnectToWorld(WorldHandler worldHandler)
        {
            BridgeBuilder.BuildBridge(
                ref m_IPortalModelsBridge,
                worldHandler.PortalHandlers,
                this.IPortalModels,
                ph => new PortalModel(ph));

            BridgeBuilder.BuildBridge(
                ref m_RecentMessagesBridge,
                worldHandler.RecentMessages,
                this.RecentMessages,
                mess => mess);
        }
    }
}
