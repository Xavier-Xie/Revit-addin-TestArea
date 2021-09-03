using Autodesk.Revit.DB.Plumbing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Inspection.InspectionMVVM.ViewModel
{
    public class SelectPipeViewModel : ViewModelBase
    {
        public ICollection<Pipe> pipes {  get; set; }

        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set 
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

    }
}
