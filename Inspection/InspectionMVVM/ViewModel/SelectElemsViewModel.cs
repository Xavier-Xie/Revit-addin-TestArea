using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Utilities;
using InspectionMVVM.View;
using Autodesk.Revit.DB.Plumbing;
using System.Collections.ObjectModel;
using RevitAPI;
using Inspection.InspectionMVVM.Model;

namespace Inspection.InspectionMVVM.ViewModel
{
    //此ViewModel为UI第一列的源
    public class SelectElemsViewModel : ViewModelBase
    {
        public string SourceStandard { get; set; }
        public string ElemsName { get; set; }
        public Collection<Pipe> SelectedElems { get; set; }
        //public Pipes Pipes { get; set; }
        private Document Doc { get; set; }
        private UIDocument UIDoc { get; set; }

        //数据属性（当前未绑定到UI）
        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set 
            {
                isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }

        
        //选择对应管道——命令属性
        public RelayCommand<object> SelectElemsCommand { get; set; }
        //选择对应管道——实现方法
        public void SelectElems(UIDocument uidoc)
        {
            UIDoc = uidoc;
            Doc = uidoc.Document;
            try
            {
                var currentView = Doc.ActiveView;
                if (currentView is View3D view3D)
                {
                    SelectedElems = ChooseAfterExecute.GetChosenElements(UIDoc);
                }
                else
                {
                    TaskDialog.Show("规范检查", "请打开3D视图");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }
    }
}
