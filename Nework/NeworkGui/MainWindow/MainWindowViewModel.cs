using Nework.CommonLibrary;
using Nework.Orchestration.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Nework.Gui.ViewModels
{
    public class MainWindowViewModel
    {
        public ObservableCollection<string> RecentMessages { get; }
        = new ObservableCollection<string>();

        public MainWindowViewModel(MainModel mainModel)
        {
            Debug.Assert(mainModel != null);

            var lowerCollection = mainModel.IWorldModels[0]?.RecentMessages;
            BridgeBuilder.BuildBridge
                (lowerCollection,
                RecentMessages,
                mess => mess);
            }
    }
}
