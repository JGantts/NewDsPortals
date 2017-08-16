using Nework.Orchestration.Common;
using Nework.Orchestration.EngineHandlers;
using System.Collections.ObjectModel;

namespace Nework.Orchestration.Model
{
    internal class WorldModel : PropertyChangeSource, IWorldModel
    {
        public ObservableCollection<IPortalModel> IPortalModels { get; }
            = new ObservableCollection<IPortalModel>();

        public WorldModel(WorldHandler worldHandler)
        {
            BridgeBuilder.BuildBridge
                (worldHandler.PortalHandlers,
                this.IPortalModels,
                ph => new PortalModel(ph));
        }
    }
}
