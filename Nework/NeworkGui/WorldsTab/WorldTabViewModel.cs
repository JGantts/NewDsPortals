using System.Collections.ObjectModel;
using Nework.Orchestration.Model;
using Nework.CommonLibrary;

namespace Nework.Gui.ViewModels
{
    public class WorldTabViewModel
    {
        private IWorldModel wm;

        public string Name { get; }

        public ObservableCollection<PortalViewModel> Portals { get; }
            = new ObservableCollection<PortalViewModel>();

        public WorldTabViewModel(IWorldModel worldModel)
        {
            BridgeBuilder.BuildBridge
                (worldModel.IPortalModels,
                this.Portals,
                (model => new PortalViewModel(model)));

            Name = "Norntopia";
        }
    }
}
