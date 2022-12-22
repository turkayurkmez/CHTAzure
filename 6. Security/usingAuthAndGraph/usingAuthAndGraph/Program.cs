using Microsoft.Graph;
using Microsoft.Identity.Client;
using System.Net.Http.Headers;

string clientId = "24f3ef2c-dd9a-4de9-a8ea-4d941bf9deab";
string tenantId = "714700c6-10e2-4ca4-b315-06d7fe91ee94";

var app = PublicClientApplicationBuilder.Create(clientId)
                                        .WithAuthority(AzureCloudInstance.AzurePublic, tenantId)
                                        .WithRedirectUri("http://localhost")
                                        .Build();
string[] scopes = { "User.Read", "Calendars.ReadWrite" };

//AuthenticationResult result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();
//Console.WriteLine($"ID Token:\n {result.IdToken} ");
//Console.WriteLine($"Access Token:\n {result.AccessToken} ");

DelegateAuthenticationProvider authProvider = new DelegateAuthenticationProvider(async (request) =>
{
    try
    {
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await ObtainTokenAsync(app));
    }
    catch (Exception ex)
    {

        Console.WriteLine(ex.Message);
    }


});

var graphClient = new GraphServiceClient(authProvider);
var @event = new Event
{
    Subject = "Yılbaşı partisi",
    Body = new ItemBody
    {
        ContentType = BodyType.Html,
        Content = "Parti zamanı"
    },
    Start = new DateTimeTimeZone
    {
        DateTime = $"{DateTime.Now.AddMinutes(15).ToString()}",
        TimeZone = $"{TimeZoneInfo.Local.Id}"
    },
    End = new DateTimeTimeZone
    {
        DateTime = $"{DateTime.Now.AddMinutes(45).ToString()}",
        TimeZone = $"{TimeZoneInfo.Local.Id}"
    },
    Location = new Location
    {
        DisplayName = "Aydın"
    },
    TransactionId = $"{Guid.NewGuid()}"

};

var user = await graphClient.Me.Events.Request().AddAsync(@event);

Console.WriteLine($"Takvime olay işlendi.\nKonu:{@event.Subject}");




async Task<string> ObtainTokenAsync(IPublicClientApplication app)
{
    IEnumerable<IAccount>? accounts = await app.GetAccountsAsync();
    try
    {
        Console.WriteLine("cache'den alınıyor..");
        AuthenticationResult result = await app.AcquireTokenSilent(scopes, accounts.FirstOrDefault()).ExecuteAsync();
        Console.WriteLine("Token cacheden alındı....");
        return result.AccessToken;
    }
    catch (MsalUiRequiredException)
    {
        try
        {
            Console.WriteLine("Local cache'de token yok! interactive olarak talep edilecek");
            AuthenticationResult result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();
            Console.WriteLine("Token alındı");
            return result.AccessToken;
        }
        catch (MsalException)
        {
            Console.WriteLine("Token alınamadı");
            throw;
        }

    }
}