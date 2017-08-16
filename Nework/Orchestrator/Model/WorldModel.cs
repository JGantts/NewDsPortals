using Nework.Orchestration.Common;
using System.Collections.ObjectModel;

namespace Nework.Orchestration.Model
{
    internal class WorldModel : PropertyChangeSource, IWorldModel
    {
        public ObservableCollection<IPortalModel> Portals { get; }

        public WorldModel()
        {
            Portals = new ObservableCollection<IPortalModel>()
            {
                new PortalModel("Portal"),
                new PortalModel("Portal 2"),
            };
        }
    }
}
