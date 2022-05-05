using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FEEDME.Library.Models;
using FEEDME.Library.Processors;
using FEEDME.MVVM.ViewModel;

namespace FEEDME.MVVM.View
{
    /// <summary>
    /// Interaction logic for RecipeView.xaml
    /// </summary>
    public partial class ResultsView : UserControl
    {
        //MainViewModel viewModel;
        public ResultsView()
        {
            //viewModel = new MainViewModel();

            InitializeComponent();

            //this.DataContext = viewModel;
        }

        //being called from feed me view to assign values to to this string to run query
        public string myStringProperty { get; set; }

        //private async void Results_Loaded(object sender, RoutedEventArgs e)
        //{
        //    //need to get this data passed as a string from Feed me user contol
        //    //may need to change this screen back to a window
        //    var recipeInfo = await RecipeProcessor.LoadRecipes(myStringProperty);

        //    //ResultList = new BindingList<RecipeModel>(recipeInfo.Results);

        //    foreach (var recipe in recipeInfo)
        //    {
        //        var uriSource = new Uri(recipe.Image, UriKind.Absolute);

        //        //still need wired up to form
        //        recipeImage.Source = new BitmapImage(uriSource);

        //        recipeResult.Text = recipe.Title;


        //    }
        //}
    }
}