using Nework.Gui.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Nework.Gui.Views
{
    public partial class WorldTabController : TabControl
    {
        private WorldTabControllerViewModel m_ViewModel => (DataContext as WorldTabControllerViewModel);

        public ObservableCollection<WorldTabView> m_WorldTabViews { get; } = new ObservableCollection<WorldTabView>();

        public WorldTabController()
        {
            this.DataContext = new WorldTabControllerViewModel();

            InitializeComponent();

            BridgeBuilder.BuildBridge
                (m_ViewModel.WorldTabs,
                m_WorldTabViews,
                vm => new WorldTabView(vm));
        }
    }
}
