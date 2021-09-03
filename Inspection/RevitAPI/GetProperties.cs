using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPI
{
    public class GetProperties
    {
        public string GetPipeSlope(Pipe pipe)
        {
            Parameter pipeSlope = pipe.get_Parameter(BuiltInParameter.RBS_PIPE_SLOPE);
            return pipeSlope.AsValueString();
        }

        public string GetPipeMaterial(Pipe pipe)
        {
            Parameter pipeMaterial = pipe.get_Parameter(BuiltInParameter.RBS_PIPE_MATERIAL_PARAM);
            return pipeMaterial.AsValueString();
        }

        public double GetPipeDiameter(Pipe pipe)
        {
            Parameter pipeDiameter = pipe.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM);
            double temp = pipeDiameter.AsDouble();
            return 304.8 * temp;
        }

    }
}
