using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Utilities;

namespace Inspection.InspectionMVVM.ViewModel
{
    class CommandViewModel : ViewModelBase
    {
        public CommandViewModel(string displayName, ICommand command)
        {
            if(command == null)
                throw new ArgumentNullException(nameof(command));
            base.DisplayName = displayName;
            this.command = command;
        }

        public ICommand command { get; private set; }
    }
}
