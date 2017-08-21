using Nework.CommonLibrary;
using Nework.Gui.Common;
using Nework.Orchestration.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Windows.Input;

namespace Nework.Gui.ViewModels
{
    public class MainWindowViewModel
    {
        public ObservableCollection<string> RecentMessages { get; }
        = new ObservableCollection<string>();
        private Bridge m_RecentMessagesBridge = null;

        private MainModel m_MainModel { get; }

        public ICommand ConnectToWorld
            => m_ConnectToWorld ?? (m_ConnectToWorld = new CommandHandler(
            () =>
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.RootFolder = Environment.SpecialFolder.MyDocuments;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    m_MainModel.ConnectToWorld(new DirectoryInfo(dialog.SelectedPath));
                }
            },
            () => { return true; }));
        private ICommand m_ConnectToWorld;

        public MainWindowViewModel(MainModel mainModel)
        {
            Debug.Assert(mainModel != null);

            m_MainModel = mainModel;

            mainModel.PropertyChanged += MainModel_PropertyChanged;

            MainModel_PropertyChanged(null, new PropertyChangedEventArgs(nameof(MainModel.IWorldModel)));
        }

        private void MainModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(MainModel.IWorldModel):
                    var lowerCollection = m_MainModel?.IWorldModel?.RecentMessages;
                    if (lowerCollection != null)
                    {
                        BridgeBuilder.BuildBridge
                        (ref m_RecentMessagesBridge,
                        lowerCollection,
                        RecentMessages,
                        mess => mess);
                    }
                    break;
            }
        }
    }
}
