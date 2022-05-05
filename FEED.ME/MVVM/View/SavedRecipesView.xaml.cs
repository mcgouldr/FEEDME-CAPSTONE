using System;
using System.Collections.Generic;
using System.IO;
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

namespace FEEDME.MVVM.View
{
    /// <summary>
    /// Interaction logic for SavedRecipesView.xaml
    /// </summary>
    public partial class SavedRecipesView : UserControl
    {
        public SavedRecipesView()
        {
            InitializeComponent();
        }

        private void backToSaved_Click(object sender, RoutedEventArgs e)
        {
            savedRecipesPanel.Visibility = Visibility.Visible;
            savedRecipeImage.Visibility = Visibility.Visible;

            backToSavedPanel.Visibility = Visibility.Collapsed;
            recipeViewPanel.Visibility = Visibility.Collapsed;
            stepsPanel.Visibility = Visibility.Collapsed;
        }

        private void recipe1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            savedRecipesPanel.Visibility = Visibility.Collapsed;
            savedRecipeImage.Visibility = Visibility.Collapsed;

            backToSavedPanel.Visibility = Visibility.Visible;
            recipeViewPanel.Visibility = Visibility.Visible;
            stepsPanel.Visibility = Visibility.Visible;

            recipeViewPanelText.Text = "Cranberry and Orange Juice Spareribs";

            var uriSource = new Uri("https://spoonacular.com/recipeImages/640349-556x370.jpg");
            recipeImage2.Source = new BitmapImage(uriSource);

            try
            {
                using (var sr = new StreamReader("Recipe1RecipeSteps.txt"))
                {
                    stepCount.Text = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException ex)
            {
                stepCount.Text = ex.Message;
            }


            try
            {
                using (var sr = new StreamReader("Recipe1Ingredients.txt"))
                {
                    ingredients.Text = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException ex)
            {
                ingredients.Text = ex.Message;
            }
        }

        private void recipe2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            savedRecipesPanel.Visibility = Visibility.Collapsed;
            savedRecipeImage.Visibility = Visibility.Collapsed;

            backToSavedPanel.Visibility = Visibility.Visible;
            recipeViewPanel.Visibility = Visibility.Visible;
            stepsPanel.Visibility = Visibility.Visible;

            recipeViewPanelText.Text = "Peppermint White Chocolate Fudge";

            var uriSource = new Uri("https://spoonacular.com/recipeImages/655687-556x370.jpg");
            recipeImage2.Source = new BitmapImage(uriSource);

            try
            {
                using (var sr = new StreamReader("Recipe2RecipeSteps.txt"))
                {
                    stepCount.Text = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException ex)
            {
                stepCount.Text = ex.Message;
            }


            try
            {
                using (var sr = new StreamReader("Recipe2Ingredients.txt"))
                {
                    ingredients.Text = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException ex)
            {
                ingredients.Text = ex.Message;
            }
        }

        private void recipe3_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            savedRecipesPanel.Visibility = Visibility.Collapsed;
            savedRecipeImage.Visibility = Visibility.Collapsed;

            backToSavedPanel.Visibility = Visibility.Visible;
            recipeViewPanel.Visibility = Visibility.Visible;
            stepsPanel.Visibility = Visibility.Visible;

            recipeViewPanelText.Text = "Salmon Eggs Benedict";

            var uriSource = new Uri("https://spoonacular.com/recipeImages/660368-556x370.jpg");
            recipeImage2.Source = new BitmapImage(uriSource);

            try
            {
                using (var sr = new StreamReader("Recipe3RecipeSteps.txt"))
                {
                    stepCount.Text = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException ex)
            {
                stepCount.Text = ex.Message;
            }


            try
            {
                using (var sr = new StreamReader("Recipe3Ingredients.txt"))
                {
                    ingredients.Text = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException ex)
            {
                ingredients.Text = ex.Message;
            }
        }

      
    }
}
