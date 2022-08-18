using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalculatorDemo
{
    public class Calculator :INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;


        private int result;
        public int Result
        {
            get { return result; }
            set
            {
                result = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Result"));
                }
            }
        }


        //private int result;
        //public int Result
        //{
        //    get { return result; }
        //}
        //public void OnPropertyChanged(int Result)
        //{
        //    if(PropertyChanged!=null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs("Result"));
        //    }
        //}
        private int firstnumber;
        public int FirstNumber
        {
            get { return firstnumber; }
            set { firstnumber = value;  }
        }

        private int secondnumber;
        public int SecondNumber
        {
            get { return secondnumber; }
            set { secondnumber = value; }
        }
       
        

        public void Addition(object obj)
        {
          Result = FirstNumber + SecondNumber;
        }

        public void Subtraction(object obj)
        {
            Result = FirstNumber - SecondNumber;
        }

        public void Multiplication(object obj)
        {
            Result = FirstNumber * SecondNumber;
        }

        public void Division(object obj)
        {
            Result = FirstNumber / SecondNumber;
        }

        public bool CanExecute(object parameter)
        {
            if (SecondNumber > 0 && firstnumber>=0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CanExecute1(object parameter)
        {
            if(FirstNumber >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private ICommand additioncommand;
        private ICommand subtractioncommand;
        private ICommand multiplycommand;
        private ICommand divisioncommand;

        public ICommand AdditionCommand
        {
            get { return additioncommand; }
        }

        public ICommand SubtractionCommand
        {
            get { return subtractioncommand; }
        }

        public ICommand MultiplyCommand
        {
            get { return multiplycommand; }
        }

        public ICommand DivisionCommand
        {
            get { return divisioncommand; }
        }

        public Calculator()
        {
            additioncommand = new RelayCommand(Addition,CanExecute1);
            subtractioncommand = new RelayCommand(Subtraction, CanExecute1);
            multiplycommand = new RelayCommand(Multiplication, CanExecute);
            divisioncommand = new RelayCommand(Division, CanExecute);
        }
    }
}
