using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using TestFeatures.Models;

namespace TestFeatures.ViewModel
{
    /// <summary>
    /// ViewModel class for MainWindow
    /// </summary>
    public class ViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Collection which is related to combobox
        /// </summary>
        private ObservableCollection<int> cList = new ObservableCollection<int>() { 1, 2, 3, 4, 5 };
        /// <summary>
        /// cList property
        /// </summary>
        public ObservableCollection<int> CList
        {
            get => cList;
            set
            {
                cList = value;
                OnPropertyChanged("CList");
            }
        }
        /// <summary>
        /// User selected function from list in DataGrid
        /// </summary>
        private UniFunc _selectedfunc = new UniFunc();
        /// <summary>
        /// User selected function property
        /// </summary>
        public UniFunc selectedFunc
        {
            get { return _selectedfunc; }
            set { _selectedfunc = value; OnPropertyChanged("selectedFunc"); }
        }
        /// <summary>
        /// The collection that is associated with the DataGrid. Contains UniFunc objects
        /// </summary>
        public ObservableCollection<UniFunc> FuncList { get; set; } = new ObservableCollection<UniFunc>();

        /// <summary>
        /// Selected item in the list of function types
        /// </summary>
        ///<remarks>Contains linear, quadratic and so on functions</remarks>
        private TextBlock? _selectedTB;
        /// <summary>
        /// Property of selected item in the list of functions type
        /// </summary>
        /// <remarks>When changing the function type, the list of C coefficients changes, 
        /// while the selected C coefficient becomes 0.
        /// The type of the selected function in the DataGrid list also automatically changes, 
        /// therefore, the function is recalculated with a new type.</remarks>
        public TextBlock? SelectedTB
        {
            get => _selectedTB;
            set
            {
                _selectedTB = value;
                OnPropertyChanged("SelectedTB");

                //I don't know why after rebuild cList combobox does not exist
                //And this solution just a temporary crutch
                if (value!.Text == "Линейная")
                {
                    cList[0] = 1;
                    cList[1] = 2;
                    cList[2] = 3;
                    cList[3] = 4;
                    cList[4] = 5;
                    selectedFunc.FuncType = FuncType.Linear;
                }
                else if (value!.Text == "Квадратичная")
                {
                    cList[0] = 10;
                    cList[1] = 20;
                    cList[2] = 30;
                    cList[3] = 40;
                    cList[4] = 50;
                    selectedFunc.FuncType = FuncType.Quadratic;
                }
                else if (value!.Text == "Кубическая")
                {
                    cList[0] = 100;
                    cList[1] = 200;
                    cList[2] = 300;
                    cList[3] = 400;
                    cList[4] = 500;
                    selectedFunc.FuncType = FuncType.ThirdDegree;
                }
                else if (value!.Text == "4-ой степени")
                {
                    cList[0] = 1000;
                    cList[1] = 2000;
                    cList[2] = 3000;
                    cList[3] = 4000;
                    cList[4] = 5000;
                    selectedFunc.FuncType = FuncType.FourthDegree;
                }
                else if (value!.Text == "5-ой степени")
                {
                    cList[0] = 10000;
                    cList[1] = 20000;
                    cList[2] = 30000;
                    cList[3] = 40000;
                    cList[4] = 50000;
                    selectedFunc.FuncType = FuncType.FifthDegree;
                }
            }
        }

        /// <summary>
        /// An event that notifies the binding sink that the data in the source has changed.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Invoke a data change event in the source
        /// </summary>
        /// <param name="prop">Name of edit property</param>
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
