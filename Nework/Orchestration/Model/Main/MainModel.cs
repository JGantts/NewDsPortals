using Nework.CommonLibrary;
using System.Collections.ObjectModel;

namespace Nework.Orchestration.Model
{
    public class MainModel
    {
        public ObservableCollection<IWorldModel> IWorldModels { get; } 
            = new ObservableCollection<IWorldModel>();


        public MainModel()
        {
            BridgeBuilder.BuildBridge
                (Orchestrator.WorldHandlers,
                this.IWorldModels,
                wh => new WorldModel(wh));
        }

        
    }
}
