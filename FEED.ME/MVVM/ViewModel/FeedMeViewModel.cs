using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEEDME.Core;

namespace FEEDME.MVVM.ViewModel
{
    public class FeedMeViewModel : ObservableObject
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }



        string cuisineType;
        public string CuisineType
        {
            get
            {
                return cuisineType;
            }
            set
            {
                cuisineType = value; NotifyPropertyChanged("CuisineType");
            }
        }

        string mealType;
        public string MealType
        {
            get
            {
                return mealType;
            }
            set
            {
                mealType = value; NotifyPropertyChanged("MealType");
            }
        }

        string dietType;
        public string DietType
        {
            get
            {
                return dietType;
            }
            set
            {
                dietType = value; NotifyPropertyChanged("DietType");
            }
        }

        string intolerance;
        public string Intolerance
        {
            get
            {
                return intolerance;
            }
            set
            {
                intolerance = value; NotifyPropertyChanged("Intolerance");
            }
        }

        string maxReadyTime;
        public string MaxReadyTime
        {
            get
            {
                return maxReadyTime;
            }
            set
            {
                maxReadyTime = value; NotifyPropertyChanged("MaxReadyTime");
            }
        }


    }
}
