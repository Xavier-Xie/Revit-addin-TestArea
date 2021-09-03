using Autodesk.Revit.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using InspectionMVVM.ViewModel;

namespace RevitAPI
{
    [Transaction(TransactionMode.Manual)]
    public class Start : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var uidoc = commandData.Application.ActiveUIDocument;
            var mainWindowViewModel = new MainWindowViewModel(uidoc);
            mainWindowViewModel.MainWindowView.Show();
            return Result.Succeeded;
        }
    }
}
