using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAddin_test1.MVVM.Model
{
    public class XYZ
    {
        public XYZ(double xx, double yy, double zz)
        {
            X = xx;
            Y = yy;
            Z = zz;
        }
        public double X
        {
            get; set;
        }

        public double Y
        {
            get; set;
        }

        public double Z
        {
            get; set;
        }

    }
}
