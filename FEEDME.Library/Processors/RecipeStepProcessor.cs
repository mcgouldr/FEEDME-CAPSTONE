using FEEDME.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FEEDME.Library.Processors
{
    public class RecipeStepProcessor
    {
        
        public static async Task<StepModel> LoadSteps(int id)
        {


            
            string url = $"https://api.spoonacular.com/recipes/{ id }/information?apiKey=1098597b52d84ade9f5daf6236c42ca8";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    StepModel sourceUrl = await response.Content.ReadAsAsync<StepModel>();

                    

                    return sourceUrl;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
