#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;

#endregion 

namespace RevitAddin_test1
{
    public static class Util
    {
        #region Revit Addin Info

        public const string AddinButtonText = "RevitAddin_test1\n Addin";
        public const string AddinButtonTooltip = "A New Addin";
        public static string ProjectName = "RevitAddin_test1";
        public const string AddinRibbonTabName = "Custom Addin Tab";
        public const string AddinRibbonPanel = "Addins Panel";

        public const string ApplicationWindowTitle = "Revit Addin";
        public const int ApplicationWindowHeight = 350;
        public const int ApplicationWindowWidth = 400;
        public const bool IsApplicationWindowTopMost = true;

        #endregion
    }
}

