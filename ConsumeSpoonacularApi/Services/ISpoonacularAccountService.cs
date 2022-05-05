namespace ConsumeSpoonacularApi.Services
{
    public interface ISpoonacularAccountService
    {
        Task<string> GetToken(string clientId, string clientSecret);

    }
}
