using System.Collections.ObjectModel;
using Nework.Orchestration.Model;
using Nework.Orchestration;

namespace Nework.Gui.ViewModels
{
    public class WorldTabViewModel
    {
        public string Name { get; }

        public ObservableCollection<PortalViewModel> Portals { get; } 
            = new ObservableCollection<PortalViewModel>();

        public WorldTabViewModel()
        {
            IWorldModel world = Orchestrator.World;

            BridgeBuilder.BuildBridge
                (world.Portals,
                this.Portals,
                (model => new PortalViewModel(model)));

            Name = "Norntopia";
        }
    }
}
