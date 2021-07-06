#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;

#endregion

namespace RevitAddin_test1
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        private WpfWindowController _wpfWindowController = new WpfWindowController();

        /// <summary>
        /// External command mainline
        /// </summary>
        public Result Execute(
            ExternalCommandData commandData,
            ref string message,
            ElementSet elements)
        {
            try
            {
                // Display WPF Form
                _wpfWindowController.ShowForm(commandData.Application);

                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Failed;
            }
        }

    }

}
