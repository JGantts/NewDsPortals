using System;
using System.Linq.Expressions;
using System.Windows.Input;

namespace Nework.Gui.Common
{
    public class CommandHandler : ICommand
    {
        private Func<bool> m_CanExecute;
        private Action m_Execute;

        public event EventHandler CanExecuteChanged;

        private object m_Lock = new object();
        public CommandHandler(Action execute, Func<bool> canExecute)
        {
            m_Execute = execute;
            m_CanExecute = canExecute;
        }

        public bool CanExecute(object parameter)
            => m_CanExecute.Invoke();
        
        public void Execute(object parameter)
        {
            lock (m_Lock)
                if (m_CanExecute.Invoke())
                    m_Execute();
        }
    }
}
