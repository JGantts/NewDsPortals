using Nework.Orchestration.Common;
using System.Collections.ObjectModel;

namespace Nework.Orchestration.Model
{
    internal class World : PropertyChangeSource, IWorld
    {
        public ObservableCollection<IPortal> Portals { get; }

        public World()
        {
            Portals = new ObservableCollection<IPortal>()
            {
                new Portal("Portal"),
                new Portal("Portal 2"),
            };
        }
    }
    internal class Portal : PropertyChangeSource, IPortal
    {
        public PortalState Current
        {
            get { return _Current; }
            set
            {
                _Current = value;
                OnPropertyChanged(nameof(Current));
            }
        }
        private PortalState _Current;

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private string _Name = string.Empty;

        public Pigment Color
        {
            get { return m_Color; }
            set
            {
                m_Color = value;
                OnPropertyChanged(nameof(Color));
            }
        }
        private Pigment m_Color = new Pigment();

        public Portal(string name)
        {
            Name = name;
        }
    }
}
