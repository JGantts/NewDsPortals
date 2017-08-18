using Nework.Gui.ViewModels;
using Nework.Orchestration.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nework.Gui
{
    internal static class ViewModelHolder
    {
        internal static MainWindowViewModel MainWindowViewModel 
            => m_MainWindowViewModel ?? (m_MainWindowViewModel 
                = new MainWindowViewModel(mainModel));
        private static MainWindowViewModel m_MainWindowViewModel;

        internal static WorldTabControllerViewModel WorldTabControllerViewModel 
            => m_WorldTabControllerViewModel ?? (m_WorldTabControllerViewModel 
                = new WorldTabControllerViewModel(mainModel));
        private static WorldTabControllerViewModel m_WorldTabControllerViewModel;

        private static MainModel mainModel = new MainModel();
    }
}
