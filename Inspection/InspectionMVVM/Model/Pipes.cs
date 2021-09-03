using Autodesk.Revit.DB.Plumbing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.InspectionMVVM.Model
{
    public class Pipes
    {
        public string SourceStandard { get; set; }
        public string ElemsName { get; set; }
        public Collection<Pipe> SelectedElems { get;  set; }
    }
}
