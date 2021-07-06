using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAddin_test1.MVVM.Model
{
    public class Curve
    {
        public Curve(XYZ xyz1, XYZ xyz2)
        {
            FirstXYZ = xyz1;
            SecondXYZ = xyz2;
        }

        public XYZ FirstXYZ
        {
            get;
            private set;
        }

        public XYZ SecondXYZ
        {
            get;
            private set;
        }

        public string Slope
        {
            get;
            private set;
        }

        public double Length
        {
            get
            {
                return Math.Sqrt(Math.Pow(FirstXYZ.X - SecondXYZ.X, 2) + Math.Pow(FirstXYZ.Y - SecondXYZ.Y, 2) + Math.Pow(FirstXYZ.Z - SecondXYZ.Z, 2));
            }
        }
    }
}
