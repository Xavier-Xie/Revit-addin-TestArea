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
            // 在构造函数中关联命令属性和对应方法
            CheckSlopeCommand = new RelayCommand<object>(p => true, p => CheckSlope());
            CheckDiameterCommand = new RelayCommand<object>(p => true, p => CheckDiameter());
            HorizontalBranchCommand = new RelayCommand<object>(p => true, p => SelectHorizontalBranch());
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
        //数据属性
        private bool isChecked;

        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                OnPropertyChanged(nameof(IsChecked));
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
                    HorizontalBranch = ChooseAfterExecute.GetChosenElements(UIDoc);



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
                    foreach(var horizontalBranch in HorizontalBranch)
                    {
                        
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

        //选择横支管 命令属性
        Collection<Pipe> HorizontalBranch = new Collection<Pipe>();

        public RelayCommand<object> HorizontalBranchCommand { get; set; }

        private void SelectHorizontalBranch()
        {
            //this.MainWindowView.Close();
            try
            {
                var currentView = Doc.ActiveView;
                if (currentView is View3D view3D)
                {
                    HorizontalBranch = ChooseAfterExecute.GetChosenElements(UIDoc);
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
