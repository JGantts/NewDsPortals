using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Nework.Orchestration.Model
{
    public interface IWorldModel : INotifyPropertyChanged
    {
        ObservableCollection<IPortalModel> IPortalModels { get; }

        //IEnumerable<string> Messages { get; }

        ObservableCollection<string> RecentMessages { get; }

    }
}
