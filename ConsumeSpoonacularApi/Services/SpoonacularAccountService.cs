namespace ConsumeSpoonacularApi.Services
{
    public class SpoonacularAccountService : ISpoonacularAccountService
    {
        private readonly HttpClient _httpClient;

        public SpoonacularAccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<string> GetToken(string clientId, string clientSecret)
        {
            throw new NotImplementedException();
        }
    }
}
