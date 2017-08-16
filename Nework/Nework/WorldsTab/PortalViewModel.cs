using Nework.Gui.Common;
using Nework.Orchestration.Model;
using System;
using System.ComponentModel;

namespace Nework.Gui.ViewModels
{

    public class PortalViewModel : PropertyChangeSource
    {
        [Flags]
        private enum State
        {
            OffAndClosed = 0,
            On = 1,
            Open = 2,
        }

        private State Current
        {
            get { return _Current; }
            set { _Current = value; }
        }
        private State _Current;

        public bool On
        {
            get { return (_Current & State.On) == State.On; }
            set
            {
                if (value)
                    _Current |= State.On;
                else
                    _Current &= ~State.On;
                OnPropertyChanged(nameof(On));
            }
        }

        public bool Open
        {
            get { return (_Current & State.Open) == State.Open; }
            set
            {
                if (value)
                    _Current |= State.Open;
                else
                    _Current &= ~State.Open;
                OnPropertyChanged(nameof(Open));
            }
        }

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                m_Portal.Name = _Name;
                OnPropertyChanged(nameof(Name));
                On = value.Length % 2 == 0;
                Open = value.Length % 3 == 0;
            }
        }
        private string _Name;

        public Pigment Color
        {
            get { return _Color; }
            set
            {
                _Color = value;
                OnPropertyChanged(nameof(Color));
            }
        }
        private Pigment _Color = new Pigment();

        public PortalViewModel(string name)
        {
            Name = name;
            Color = new Pigment();
            On = true;
            Open = false;
        }

        private IPortalModel m_Portal { get; }
        public PortalViewModel(IPortalModel portal)
        {
            m_Portal = portal;
            
            Name = m_Portal.Name;

            m_Portal.PropertyChanged += Portal_PropertyChanged;
        }

        private void Portal_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            m_Portal.PropertyChanged -= Portal_PropertyChanged;
            Name = m_Portal.Name;
            m_Portal.PropertyChanged += Portal_PropertyChanged;
        }
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
