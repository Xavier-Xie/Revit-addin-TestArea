using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;

namespace RevitAddin_test1.MVVM.Model
{
    public class Class1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = commandData.Application.ActiveUIDocument.Document;

            FilteredElementCollector collector = new FilteredElementCollector(doc);

            collector.OfCategory(BuiltInCategory.OST_PipeCurves).OfClass(typeof(Pipe));


            return Result.Succeeded;
        }
    }
}
