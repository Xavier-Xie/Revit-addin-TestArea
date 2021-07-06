using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace RevitAddin_test1
{
    /// <summary>
    /// UI Events
    /// </summary>
    public partial class RevitAddin_test1UserControl : UserControl
    {
        public static RevitAddin_test1UserControl Instance;

        public ViewModel ViewModel;
        private ExternalEvent _event;

        public RevitAddin_test1UserControl(ExternalEvent exEvent)
        {
            InitializeComponent();

            Instance = this;
            ViewModel = new ViewModel();
            DataContext = ViewModel;
            _event = exEvent;
            _event.Raise();
        }
    }
}
