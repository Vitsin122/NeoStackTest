using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestFeatures.Models
{
    /// <summary>
    /// Enum, which is used to define the calculation formula
    /// </summary>
    public enum FuncType
    {
        Linear,
        Quadratic,
        ThirdDegree,
        FourthDegree,
        FifthDegree
    }
    /// <summary>
    /// Universal function class
    /// </summary>
    public class UniFunc : INotifyPropertyChanged
    {
        /// <summary>
        /// Coefficient A
        /// </summary>
        private int _a;
        /// <summary>
        /// Coefficient B
        /// </summary>
        private int _b;
        /// <summary>
        /// Coefficient C
        /// </summary>
        private int _c;
        /// <summary>
        /// variable X
        /// </summary>
        private double _x;
        /// <summary>
        /// Variable Y
        /// </summary>
        private double _y;
        /// <summary>
        /// Result value
        /// </summary>
        private double _result;
        /// <summary>
        /// Type of function
        /// </summary>
        private FuncType _funcType;

        /// <summary>
        /// FuncType property, which causes the calculation of a new result when the type changes
        /// </summary>
        public FuncType FuncType
        {
            get => _funcType;
            set
            {
                _funcType = value;
                Result = Calculate();
                OnPropertyChanged("FuncType");
            }
        }
        /// <summary>
        /// 'A' coeff property, which causes the calculation of a new result when the 'A' changes
        /// </summary>
        public int A
        {
            get => _a;
            set
            {
                _a = value;
                Result = Calculate();
                OnPropertyChanged("A");
            }
        }
        /// <summary>
        /// 'B' coeff property, which causes the calculation of a new result when the 'B' changes
        /// </summary>
        public int B
        {
            get => _b;
            set
            {
                _b = value;
                Result = Calculate();
                OnPropertyChanged("B");
            }
        }
        /// <summary>
        /// 'C' coeff property, which causes the calculation of a new result when the 'C' changes
        /// </summary>
        public int C
        {
            get => _c;
            set
            {
                _c = value;
                Result = Calculate();
                OnPropertyChanged("C");
            }
        }
        /// <summary>
        /// 'X' variable property, which causes the calculation of a new result when the 'X' changes
        /// </summary>
        public double X
        {
            get => _x;
            set
            {
                _x = value;
                Result = Calculate();
                OnPropertyChanged("X");
            }
        }
        /// <summary>
        /// 'Y' variable property, which causes the calculation of a new result when the 'Y' changes
        /// </summary>
        public double Y
        {
            get => _y;
            set
            {
                _y = value;
                Result = Calculate();
                OnPropertyChanged("Y");
            }
        }
        /// <summary>
        /// Result value property
        /// </summary>
        /// <remarks>Property changes when any other properties change</remarks>
        public double Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged("Result");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        /// <summary>
        /// Method for calling the INotifyPropertyChanged interface event
        /// </summary>
        /// <param name="prop">Changed property name</param>
        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        /// <summary>
        /// Calculates a value according to a certain formula based on all coefficients, function type and all variables
        /// </summary>
        /// <returns>Returns a double value</returns>
        public double Calculate()
        {
            switch (FuncType)
            {
                case FuncType.Linear:
                    return A * X + B + C;
                case FuncType.Quadratic:
                    return A * Math.Pow(X, 2) + B * Y + C;
                case FuncType.ThirdDegree:
                    return A * Math.Pow(X, 3) + B * Math.Pow(Y, 2) + C;
                case FuncType.FourthDegree:
                    return A * Math.Pow(X, 4) + B * Math.Pow(Y, 3) + C;
                case FuncType.FifthDegree:
                    return A * Math.Pow(X, 5) + B * Math.Pow(Y, 4) + C;
                default:
                    return 0;
            }
        }
    }
}
