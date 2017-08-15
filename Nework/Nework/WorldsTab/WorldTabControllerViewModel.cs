using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nework.Gui.ViewModels
{
    class WorldTabControllerViewModel
    {
        public ObservableCollection<WorldTabViewModel> WorldTabs { get; }

        public WorldTabControllerViewModel()
        {
            WorldTabs = new ObservableCollection<WorldTabViewModel>()
            {
                new WorldTabViewModel(),
                new WorldTabViewModel(),
            };
        }
    }
}
