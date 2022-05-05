using FEEDME.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FEEDME.Library.Processors
{
    public class RecipeProcessor
    {
        //public static async Task<List<RecipeModel>> LoadRecipes(string CuisineType = null, string MealType = null, string DietType = null, string Intolerances = null)
        public static async Task<List<RecipeModel>> LoadRecipes(string queryString)
        {
            

            string url = $"https://api.spoonacular.com/recipes/complexSearch?apiKey=1098597b52d84ade9f5daf6236c42ca8{ queryString }";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    RecipeResultModel result = await response.Content.ReadAsAsync<RecipeResultModel>();

                    return result.Results;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);               
                }
            }
        }
    }
}
