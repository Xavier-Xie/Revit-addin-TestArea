using Autodesk.Revit.DB.Plumbing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.InspectionMVVM.Model
{
    class WrongPipe
    {
        public string SourceStandard { get; set; }
        public Pipe TargetPipe { get; set; }
    }
}
