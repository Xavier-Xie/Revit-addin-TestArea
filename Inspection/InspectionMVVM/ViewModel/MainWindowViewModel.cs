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
using Inspection.DBhelper;
using Inspection.InspectionMVVM.Model;
using Inspection.InspectionMVVM.ViewModel;

namespace InspectionMVVM.ViewModel
{
    // ViewModel = Model For View
    // MainWindowView 抽象成命令属性和数据属性
    // 并在 MainWindowViewModel 中实现
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(UIDocument uidoc)
        {
            UIDoc = uidoc;
            Doc = uidoc.Document;
            LoadSelectElems();
            // 在构造函数中关联命令属性和对应方法
            CheckSlopeCommand = new RelayCommand<object>(p => true, p => CheckSlope());
            CheckDiameterCommand = new RelayCommand<object>(p => true, p => CheckDiameter());
            foreach (var item in SelectElems)
            {
                item.SelectElemsCommand = new RelayCommand<object>(p => true, p => item.SelectElems(UIDoc));
            }
        }

        private Document Doc { get; }
        private UIDocument UIDoc { get; }
        
        private MainWindowView mainWindowView;

        public MainWindowView MainWindowView
        {
            get
            {
                if (mainWindowView == null)
                {
                    mainWindowView = new MainWindowView() { DataContext = this };
                }
                return mainWindowView;
            }
            set
            {
                mainWindowView = value;
                OnPropertyChanged(nameof(MainWindowView));
            }
        }




        //检查坡度 命令属性
        public RelayCommand<object> CheckSlopeCommand { get; set; }

        private void CheckSlope()
        {
            // this.MainWindowView.Close();
            try
            {
                var currentView = Doc.ActiveView;
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

        //检查管径 命令属性
        public RelayCommand<object> CheckDiameterCommand { get; set; }

        private void CheckDiameter()
        {
            // this.MainWindowView.Close();
            try
            {
                var currentView = Doc.ActiveView;
                if (currentView is View3D view3D)
                {
                    foreach (var item in selectElems)
                    {
                        if (item.SelectedElems != null)
                        {
                            PipePropertyStandardDB propertyStandaed = new PipePropertyStandardDB();
                            var standardDiameter = propertyStandaed.GetDiameter(item.ElemsName);
                            GetProperties getProperties= new GetProperties();

                            foreach (var element in item.SelectedElems)
                            {
                                if (getProperties.GetPipeDiameter(element) > standardDiameter)
                                {
                                    TaskDialog.Show("RevitMessage", element.ToString());
                                }
                            }
                        }
                    }

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

        //SelectElems与窗口第一列的DataGrid绑定，
        private List<SelectElemsViewModel> selectElems;

        public List<SelectElemsViewModel> SelectElems
        {
            get { return selectElems; }
            set
            {
                selectElems = value; 
                OnPropertyChanged(nameof(SelectElems));
            }
        }
        //初始化集合SelectElems
        private void LoadSelectElems()
        {
            NeedSeletedPipes needSeletedPipes= new NeedSeletedPipes();
            SelectElems = new List<SelectElemsViewModel>();
            foreach (var Pipe in needSeletedPipes.PipeType)
            {
                SelectElemsViewModel item = new SelectElemsViewModel();
                item.ElemsName = Pipe;
                SelectElems.Add(item);
            }
        }

    }
}
