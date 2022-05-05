using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEEDME.Core;

namespace FEEDME.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        //command model
        public RelayCommand HomeViewCommand{ get; set; }
        public RelayCommand FeedMeViewCommand { get; set; }
        public RelayCommand SavedRecipesViewCommand {get; set;}

        //View Model
        public HomeViewModel HomeVM { get; set; }
        public FeedMeViewModel FeedMeVM { get; set; }
        public SavedRecipesViewModel SavedRecipesVM { get; set; } 

        //set current view
        private object _currentView;
        public object CurrentView
        {
            get
            {
                return _currentView;
            }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        

        public MainViewModel()
        {
            //create an instance
            HomeVM = new HomeViewModel();
            FeedMeVM = new FeedMeViewModel();
            SavedRecipesVM = new SavedRecipesViewModel();
            
            //default page on load
            CurrentView = HomeVM;

            //Home Page
            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            //Feed Me Page
            FeedMeViewCommand = new RelayCommand(o =>
            {
                CurrentView = FeedMeVM;
            });

            //Saved Recipes Page
            SavedRecipesViewCommand = new RelayCommand(o =>
            {
                CurrentView = SavedRecipesVM;
            });
        }

    }
    
}
