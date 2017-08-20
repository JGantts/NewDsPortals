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

        public ObservableCollection<string> RecentMessages { get; }
            = new ObservableCollection<string>();

        public WorldModel(WorldHandler worldHandler)
        {
            BridgeBuilder.BuildBridge
                (worldHandler.PortalHandlers,
                this.IPortalModels,
                ph => new PortalModel(ph));

            BridgeBuilder.BuildBridge
                (worldHandler.RecentMessages,
                this.RecentMessages,
                mess => mess);
        }
    }
}
