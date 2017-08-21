using Nework.CommonLibrary;
using Nework.Gui.Common;
using Nework.Orchestration.Model;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows.Input;

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
            get { return m_Current; }
            set { lock (m_Lock) { m_Current = value; } }
        }
        private State m_Current;

        public bool On
        {
            get { return (m_Current & State.On) == State.On; }
            set
            {
                lock (m_Lock)
                {
                    if (value)
                        m_Current |= State.On;
                    else
                        m_Current &= ~State.On;
                    OnPropertyChanged(nameof(On));
                }
            }
        }

        public bool Open
        {
            get { return (m_Current & State.Open) == State.Open; }
            set
            {
                lock (m_Lock)
                {
                    if (value)
                        m_Current |= State.Open;
                    else
                        m_Current &= ~State.Open;
                    OnPropertyChanged(nameof(Open));
                }
            }
        }

        public string Name
        {
            get { return _Name; }
            set
            {
                lock (m_Lock)
                {
                    _Name = value;
                    m_Portal.Name = _Name;
                    OnPropertyChanged(nameof(Name));
                }
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

        public ICommand TurnOnCommand
            => m_TurnOnCommand ?? (m_TurnOnCommand = new CommandHandler(
            () =>
            {
                m_Portal.TurnOn();
            },
            () => { return true; }));
        private ICommand m_TurnOnCommand;

        public ICommand TurnOffCommand
            => m_TurnOffCommand ?? (m_TurnOffCommand = new CommandHandler(
            () =>
            {
                m_Portal.TurnOff();
            },
            () => { return true; }));
        private ICommand m_TurnOffCommand;

        private object m_Lock = new object();

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
