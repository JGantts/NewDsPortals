using Nework.Gui.ViewModels;
using System.Windows.Controls;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Nework.Gui.Views
{
    public partial class WorldPanelView : Grid
    {
        private WorldPanelViewModel m_ViewModel => (DataContext as WorldPanelViewModel);

        public WorldPanelView()
        {
            this.DataContext = ViewModelHolder.WorldPanelViewModel;

            InitializeComponent();

            m_ViewModel.Portals.CollectionChanged += PortalViewModels_CollectionChanged;

            //initialize view list
            PortalViewModels_CollectionChanged(null, null);
        }

        private void PortalViewModels_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.Dispatcher.Invoke(
                () =>
            {
                PortalListView.Children.Clear();
                foreach (PortalViewModel vm in m_ViewModel.Portals)
                {
                    PortalListView.Children.Add(new PortalView(vm));
                }
            });
        }
    }
}
