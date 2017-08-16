using System;
using System.ComponentModel;

namespace Nework.Orchestration.Model
{
    [Flags]
    public enum PortalState
    {
        On,
        Open
    }

    public interface IPortalModel : INotifyPropertyChanged
    {
        PortalState Current { get; set; }
        
        string Name { get; set; }
        
        Pigment Color { get; }

        void TurnOn();
        
        void TurnOff();
    }    
}
