using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Utilities;
using InspectionMVVM.View;

namespace InspectionMVVM.ViewModel
{
    public class InspectionViewModel : ViewModelBase
    {
        private Document Doc { get; }
        private UIDocument UIDoc { get; }
        private InspectionView inspectionView;

        public RelayCommand<object> ButtonRun { get; set; }

        public InspectionViewModel(UIDocument uidoc)
        {
            UIDoc = uidoc;
            Doc = uidoc.Document;
            ButtonRun = new RelayCommand<object>(p => true, p => ButtonRunAction());
        }

        private void ButtonRunAction()
        {
            this.InspectionView.Close();
            try
            {
                //获取当前视图
                var currentView = Doc.ActiveView;

                //此插件仅在3D视图下工作
                if (currentView is View3D view3D)
                {



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

        private bool isElectrical;

        public bool IsElectrical
        {
            get { return isElectrical; }
            set 
            {
                isElectrical = value;
                OnPropertyChanged(nameof(IsElectrical));
            }
        }


        public InspectionView InspectionView
        {
            get { return inspectionView; }
            set { inspectionView = value; }
        }

    }
}
