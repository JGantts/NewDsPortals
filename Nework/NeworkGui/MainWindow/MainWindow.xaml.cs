using Nework.Gui.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nework.Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel Vm => (MainWindowViewModel)DataContext;

        public MainWindow()
        {
            this.DataContext = ViewModelHolder.MainWindowViewModel;

            InitializeComponent();

            Vm.RecentMessages.CollectionChanged += RecentMessages_CollectionChanged;
        }

        private void RecentMessages_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.Dispatcher.Invoke(
                () =>
                {
                    RecentMessages.Children.Clear();
                    foreach (string mess in Vm.RecentMessages)
                    {
                        TextBlock temp = new TextBlock();
                        temp.Text = mess;
                        RecentMessages.Children.Add(temp);
                    }
                });
        }
    }
}
