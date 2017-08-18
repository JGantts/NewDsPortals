using Nework.CommonLibrary;
using Nework.Orchestration.Model;
using System.Collections.ObjectModel;

namespace Nework.Gui.ViewModels
{
    class WorldTabControllerViewModel
    {
        public ObservableCollection<WorldTabViewModel> WorldTabViewModels { get; }
            = new ObservableCollection<WorldTabViewModel>();

        public WorldTabControllerViewModel(MainModel mainModel)
        {
            BridgeBuilder.BuildBridge
                (mainModel.IWorldModels,
                WorldTabViewModels,
                wm => new WorldTabViewModel(wm));
        }
    }
}
