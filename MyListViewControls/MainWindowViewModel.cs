using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyListViewControls
{
    class MainWindowViewModel : ViewModelBase
    {
        private Random _random = new Random();

        public ObservableCollection<SubClass> SubClassList { get; set; }

        public RelayCommand<object> ButtonShowFilter { get; private set; }

        /// <summary>
        /// Construktor
        /// </summary>
        public MainWindowViewModel()
        {
            ButtonShowFilter = new RelayCommand<object>(ButtonShowFilterCF);

            SubClassList = new ObservableCollection<SubClass>();
            FillList();
        }

        /******************************/
        /*       Button Events        */
        /******************************/
        #region Button Events

        /// <summary>
        /// ButtonShowFilterCF
        /// </summary>
        public void ButtonShowFilterCF(object obj)
        {
            var sc = obj as SubClass;
            Debug.WriteLine(String.Format("ButtonShowFilterCF Id={0} Aktiv={1} Comment={2}", sc.Id, sc.Aktiv,sc.Comment));
        }

        #endregion
        /******************************/
        /*      Menu Events          */
        /******************************/
        #region Menu Events

        #endregion
        /******************************/
        /*      Other Events          */
        /******************************/
        #region Other Events

        #endregion
        /******************************/
        /*      Other Functions       */
        /******************************/
        #region Other Functions

        /// <summary>
        /// FillList
        /// </summary>
        private void FillList()
        {
            for (int i = 1; i <= 10; i++)
                SubClassList.Add(new SubClass { Id = i, DValue = RandomDouble(10, 99), Aktiv = true ? 1 == RandomDouble(0, 1, 0) : false, Comment = String.Format("Comment #{0}", i) });
        }

        /// <summary>
        /// Get a random double betwen min and max
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private double RandomDouble(double min, double max, int digits = 3)
        {
            double F;
            F = Math.Round(_random.NextDouble() * (max - min) + min, digits);
            return F;
        }

        #endregion
    }

    #region Help Classes
    public class SubClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private long id;
        public long Id
        {
            get { return id; }
            set
            {
                if (value != Id)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        private double dvalue;
        public double DValue
        {
            get { return dvalue; }
            set
            {
                if (value != DValue)
                {
                    dvalue = value;
                    OnPropertyChanged("DValue");
                }
            }
        }
        private bool aktiv;
        public bool Aktiv
        {
            get { return aktiv; }
            set
            {
                if (value != Aktiv)
                {
                    aktiv = value;
                    OnPropertyChanged("Aktiv");
                }
            }
        }
        private string comment;
        public string Comment
        {
            get { return comment; }
            set
            {
                if (value != Comment)
                {
                    comment = value;
                    OnPropertyChanged("Comment");
                }
            }
        }
        private void OnPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
    }
    #endregion
}
