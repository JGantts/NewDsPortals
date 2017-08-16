using Nework.Gui.Common;
using Nework.Orchestration.Model;
using System.Collections.ObjectModel;

namespace Nework.Gui.ViewModels
{
    class WorldTabControllerViewModel
    {
        public ObservableCollection<WorldTabViewModel> WorldTabViewModels { get; }
            = new ObservableCollection<WorldTabViewModel>();

        public WorldTabControllerViewModel()
        {
            var temp = new MainModel();

            BridgeBuilder.BuildBridge
                (temp.IWorldModels,
                WorldTabViewModels,
                wm => new WorldTabViewModel(wm));
        }
    }
}
