using Nework.CommonLibrary;
using System.IO;

namespace Nework.Orchestration.Model
{
    public class MainModel : PropertyChangeSource
    {
        public IWorldModel IWorldModel
        {
            get { return M_IWorldModel; }
            private set
            {
                M_IWorldModel = value;
                OnPropertyChanged(nameof(IWorldModel));
            }
        }
        private IWorldModel M_IWorldModel;


        public MainModel()
        {
            IWorldModel = new WorldModel();
        }

        public void ConnectToWorld(DirectoryInfo worldDirectory)
        {
            IWorldModel = new WorldModel(Orchestrator.ConnectToWorld(worldDirectory));
        }
    }
}
