using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Nework.Orchestration.Model
{
    [Flags]
    public enum PortalState
    {
        On,
        Open
    }

    public interface IWorld
    {
        ObservableCollection<IPortal> Portals { get; }
    }

    public interface IPortal : INotifyPropertyChanged
    {
        PortalState Current { get; set; }
        
        string Name { get; set; }
        
        Pigment Color { get; }
    }

    public class Pigment
    {
        public byte Red { get; }
        public byte Green { get; }
        public byte Blue { get; }
        public byte Rotation { get; }
        public byte Swap { get; }

        public Pigment()
            : this(128, 128, 128)
        { }

        public Pigment(byte red, byte green, byte blue)
            : this(red, green, blue, 128, 128)
        { }

        public Pigment(byte red, byte green, byte blue, byte rotation, byte swap)
        {
            Red = red;
            Green = green;
            Blue = blue;
            Rotation = rotation;
            Swap = swap;
        }
    }
}
