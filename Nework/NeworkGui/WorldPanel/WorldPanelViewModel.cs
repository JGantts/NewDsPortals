using System.Collections.ObjectModel;
using Nework.Orchestration.Model;
using Nework.CommonLibrary;

namespace Nework.Gui.ViewModels
{
    public class WorldPanelViewModel
    {
        private IWorldModel wm;

        public string Name { get; }

        public ObservableCollection<PortalViewModel> Portals { get; }
            = new ObservableCollection<PortalViewModel>();

        private IWorldModel m_IWorldModel { get; }

        public WorldPanelViewModel(MainModel worldModel)
        {
            m_IWorldModel = worldModel.IWorldModel;
            m_IWorldModel.PropertyChanged += WorldModel_PropertyChanged;
            BridgeBuilder.BuildBridge
                (worldModel.IWorldModel.IPortalModels,
                this.Portals,
                (model => new PortalViewModel(model)));

            Name = "Norntopia";
        }

        private Bridge m_PortalsBridge;
        private void WorldModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(MainModel.IWorldModel):
                    var lowerCollection = m_IWorldModel?.RecentMessages;
                    if (lowerCollection != null)
                    {
                        BridgeBuilder.BuildBridge(
                            ref m_PortalsBridge,
                            m_IWorldModel.IPortalModels,
                            this.Portals,
                            (model => new PortalViewModel(model)));
                    }
                    break;
            }
        }
    }
}
