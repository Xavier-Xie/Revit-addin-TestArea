using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAddin_test1.MVVM.Model
{
    public class Wall : Element
    {
        public Wall(Curve tempcurve)
        {
            LocationCurve = tempcurve;
        }

        public List<Curve> Edges { get; set; }

        public Curve LocationCurve
        {
            get;
            private set;
        }

        public double TopHeigh
        {
            get;
            private set;
        }

        public double BottomHeigh
        {
            get;
            private set;
        }

        public double Width
        {
            get;
            private set;
        }

        public double GetVolume
        {
            get
            {
                return Width * LocationCurve.Length * (TopHeigh - BottomHeigh);
            }
        }
    }
}
