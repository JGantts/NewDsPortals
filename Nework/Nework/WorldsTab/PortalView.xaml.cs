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

namespace Nework.Gui.Views
{
    /// <summary>
    /// Interaction logic for PortalView.xaml
    /// </summary>
    public partial class PortalView : UserControl
    {
        public PortalView()
        {
            this.DataContext = new PortalViewModel("hi");

            InitializeComponent();
        }

        public PortalView(PortalViewModel vm)
        {
            this.DataContext = vm;

            InitializeComponent();
        }
    }
}
