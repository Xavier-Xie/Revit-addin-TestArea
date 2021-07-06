using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAddin_test1.MVVM.Model
{
    public class Column : Element
    {
        public XYZ LocationPoint { get; set; }
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
    }
}
