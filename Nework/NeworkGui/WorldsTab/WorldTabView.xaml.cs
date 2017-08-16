using Nework.Gui.ViewModels;
using System.Windows.Controls;
using System.Collections.Specialized;

namespace Nework.Gui.Views
{
    public partial class WorldTabView : TabItem
    {
        private WorldTabViewModel m_ViewModel => (DataContext as WorldTabViewModel);

        public WorldTabView(WorldTabViewModel vm)
        {
            this.DataContext =  vm;

            InitializeComponent();

            m_ViewModel.Portals.CollectionChanged += PortalViewModels_CollectionChanged;

            //initialize view list
            PortalViewModels_CollectionChanged(null, null);
        }

        private void PortalViewModels_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            PortalListView.Children.Clear();
            foreach (PortalViewModel vm in m_ViewModel.Portals)
            {
                PortalListView.Children.Add(new PortalView(vm));
            }
        }
    }
}
