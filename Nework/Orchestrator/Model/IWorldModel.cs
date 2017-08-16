using System.Collections.ObjectModel;

namespace Nework.Orchestration.Model
{
    public interface IWorldModel
    {
        ObservableCollection<IPortalModel> Portals { get; }
    }
}
