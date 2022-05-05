using FEEDME.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FEEDME.Library.Processors
{
    public class FeaturedRecipeProcessor
    {
        

        public static async Task<List<FeaturedRecipeModel>> LoadFeaturedRecipe()
        {
            string url = "https://api.spoonacular.com/recipes/random?apiKey=1098597b52d84ade9f5daf6236c42ca8&number=1";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    FeaturedRecipeResultModel result = await response.Content.ReadAsAsync<FeaturedRecipeResultModel>();

                    return result.Recipes;
                }
                else 
                    throw new Exception(response.ReasonPhrase);
                
            }
        }
    }
}
