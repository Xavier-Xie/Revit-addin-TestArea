using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    //用于传输数据属性
    public class ViewModelBase : INotifyPropertyChanged
    {
        private string displayName;

        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            //PropertyChangedEventHandler handler = this.PropertyChanged;
            //if (handler != null)
            //{
            //    var e = new PropertyChangedEventArgs(propertyName);
            //    handler(this, e);
            //}
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
    }
}
