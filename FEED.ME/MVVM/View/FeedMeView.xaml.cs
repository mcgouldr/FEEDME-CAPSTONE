using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using AutoMapper;
using FEEDME.Library.Models;
using FEEDME.Library.Processors;
using FEEDME.MVVM.ViewModel;

namespace FEEDME.MVVM.View
{
    /// <summary>
    /// Interaction logic for FeedMeView.xaml
    /// </summary>
    public partial class FeedMeView : UserControl
    {

        FeedMeViewModel viewModel;


        //global properties
        public string RecipeUrl { get; set; }

        public FeedMeView()
        {
            viewModel = new FeedMeViewModel();
            InitializeComponent();

            this.DataContext = viewModel;
        }

        //This is the button that will send the parameters then hide the feeme controls and open new controls
        private void ButtonFeedMe_Click(object sender, RoutedEventArgs e)
        {
            //checking for null and updating query string
            if (viewModel.CuisineType != null)
            {
                viewModel.CuisineType = "&cuisine=" + viewModel.CuisineType;
            }
            else
                viewModel.CuisineType = "";

            if (viewModel.MealType != null)
            {
                viewModel.MealType = "&type=" + viewModel.MealType;
            }
            else
                viewModel.MealType = "";

            if (viewModel.DietType != null)
            {
                viewModel.DietType = "&diet=" + viewModel.DietType;
            }
            else
                viewModel.DietType = "";


            if (viewModel.Intolerance != null)
            {
                viewModel.Intolerance = "&intolerances=" + viewModel.Intolerance;
            }
            else
                viewModel.Intolerance = "";

            if (viewModel.MaxReadyTime != null)
            {
                viewModel.MaxReadyTime = "&maxReadyTime=" + viewModel.MaxReadyTime;
            }
            else
                viewModel.MaxReadyTime = "";

            //call results page to set query string equal to submitted values
            RecipeUrl = viewModel.CuisineType + viewModel.MealType + viewModel.DietType + viewModel.Intolerance + viewModel.MaxReadyTime;
            ShowRecipeResults = true;
            ShowResults();


            //figure out how to switch to a new user control when button is pressed

            //what disappers when button is pressed
            cuisinePanel.Visibility = Visibility.Collapsed;
            typePanel.Visibility = Visibility.Collapsed;
            intolerancePanel.Visibility = Visibility.Collapsed;
            dietPanel.Visibility = Visibility.Collapsed;
            feedMePanel.Visibility = Visibility.Collapsed;
            maxReadyTimePanel.Visibility = Visibility.Collapsed;

            //what loads after button presses
            resultPanel.Visibility = Visibility.Visible;
            backToFeedMePanel.Visibility = Visibility.Visible;
        }



        //New button is generated that you can select the recipes that load
        // back button also appears to undo last action
        //TODO: Add 2 buttons.. back button as well as result selection button

        //back to feedme page
        private void backToFeedMe_Click(object sender, RoutedEventArgs e)
        {

            //what disappers when button is pressed
            resultPanel.Visibility = Visibility.Collapsed;
            backToFeedMePanel.Visibility = Visibility.Collapsed;


            //what loads after button presses
            cuisinePanel.Visibility = Visibility.Visible;
            typePanel.Visibility = Visibility.Visible;
            intolerancePanel.Visibility = Visibility.Visible;
            dietPanel.Visibility = Visibility.Visible;
            feedMePanel.Visibility = Visibility.Visible;
            maxReadyTimePanel.Visibility= Visibility.Visible;
        }

        public bool ShowRecipeResults { get; set; } = false;

        private async Task ShowResults()
        {
            /////////////////////////////////////////////////////////////
            var recipeInfo = await RecipeProcessor.LoadRecipes(RecipeUrl);


            if (ShowRecipeResults == true)
            {
                foreach (var recipe in recipeInfo)
                {
                    var uriSource = new Uri(recipe.Image, UriKind.Absolute);

                    //still need wired up to form
                    recipeImage.Source = new BitmapImage(uriSource);

                    //image for recipe view
                    recipeImage2.Source = new BitmapImage(uriSource);

                    recipeResult.Text = recipe.Title;
                    RecipeText = recipe.Title;

                    RecipeId = recipe.Id;
                }
            }
            else { recipeResult.Text = "Error: No result Successfully loaded..."; }

            GetSteps = true;
            //else { RecipeText = "This is not working yet"; }

            ////////////////////////////////////////////////////////////////
            ///*create a list of recipes*/
            //var resultList = new List<RecipeResultModel>();

            //foreach (var recipe in recipeInfo)
            //{
            //    var uriSource = new Uri(recipe.Image, UriKind.Absolute);
            //    recipeResult.Text = recipe.Title;

            //    /*add the recipe to the list*/
            //    resultList.Add(RecipeResultModel);
            //}

            //return resultList; /*return the list of recipes*/

            //////////////////////////////////////////////////////////
            //var recipeInfo = await RecipeProcessor.LoadRecipes(RecipeUrl);


            //var recipeList = _mapper.Map<List<RecipeResultModel>>(recipeInfo);
            //ResultList = new BindingList<RecipeResultModel>(recipeList);
            //ResultList.ItemsSource = recipeList;
            //////////////////////////////////////////////////////////////////


        }


        public int RecipeId { get; set; }
        public string RecipeText { get; set; }

        public bool GetSteps { get; set; } = false;

        public string RecipeSteps
        {
            get; set;
        }

        private async Task GetRecipeSteps()
        {
            var recipeSteps = await RecipeStepProcessor.LoadSteps(RecipeId);
            RecipeSteps = recipeSteps.SourceUrl;
            
        }

        public bool ShowRecipeSteps { get; set; } = false;
        private void recipeResult_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            

            resultPanel.Visibility = Visibility.Collapsed;
            backToFeedMePanel.Visibility = Visibility.Collapsed;

            recipeViewPanelText.Text = RecipeText;
            recipeViewPanel.Visibility = Visibility.Visible;
            stepsPanel.Visibility = Visibility.Visible;
           
            backToResultPanel.Visibility = Visibility.Visible;

            GetSteps = true;
            ShowRecipeResults = false;
            ShowRecipeSteps = true;
            ShowRecipeView();
            GetRecipeSteps();


        }


        public int StepCount { get; set; } = 0;
        
        //need to fix. I am not sure api call is working
        private async Task ShowRecipeView()
        {
            //var recipeSteps = await RecipeStepProcessor.LoadSteps(RecipeId);
            //RecipeSteps = recipeSteps.ToString();
            


            if (ShowRecipeSteps == true)
            {
              

                try
                {
                    using (var sr = new StreamReader($"{RecipeId}RecipeSteps.txt"))
                    {
                        stepCount.Text = await sr.ReadToEndAsync();
                    }
                }
                catch (FileNotFoundException ex)
                {
                    stepCount.Text = "FEED ME! does not support this recipe yet. Try visting the link: " + RecipeSteps;
                }


                try
                {
                    using (var sr = new StreamReader($"{RecipeId}Ingredients.txt"))
                    {
                        ingredients.Text = await sr.ReadToEndAsync();
                    }
                }
                catch (FileNotFoundException ex)
                {
                    ingredients.Text = ex.Message;
                }
                //var recipeSteps = await RecipeStepProcessor.LoadSteps(RecipeId);
                //recipeSteps.ToString();
                //stepCount.Text = "Error: No steps Successfully loaded...";

                //foreach (var step in recipeSteps)
                //{
                //    StepCount = recipeSteps.Count;
                //}
                //foreach (var step in recipeSteps)
                //{
                //    stepCount.Text = step.Number.ToString();


            }
            //else //{ stepCount.Text = "Error: No result Successfully loaded..."; }
        }
        private void backToResults_Click(object sender, RoutedEventArgs e)
        {
            resultPanel.Visibility = Visibility.Visible;
            backToFeedMePanel.Visibility = Visibility.Visible;

            recipeViewPanelText.Text = RecipeText;
            recipeViewPanel.Visibility = Visibility.Collapsed;
            stepsPanel.Visibility = Visibility.Collapsed;
            
            backToResultPanel.Visibility = Visibility.Collapsed;

            ShowRecipeResults = true;
            ShowRecipeSteps = false;
            ShowResults();
        }

        //private void recipeResult_MouseMove(object sender, MouseEventArgs e)
        //{
        //    GetRecipeSteps();
        //}
    }

    //todo
    //Method below is the recip view after selection
    // back button also appears to undo last action
}

