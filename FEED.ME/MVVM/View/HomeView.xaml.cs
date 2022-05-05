using System;
using System.Collections.Generic;
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

namespace FEEDME.MVVM.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }


        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var recipeInfo = await FeaturedRecipeProcessor.LoadFeaturedRecipe();

            

            foreach (var recipe in recipeInfo)
            {
                var uriSource = new Uri(recipe.Image, UriKind.Absolute);

                recipeImage.Source = new BitmapImage(uriSource);

                recipeTitle.Text = recipe.Title;

                recipeSummary.Text = recipe.Summary;
                //recipeSummary.Text = recipe.Id.ToString();
            }
        }       

    }
}
