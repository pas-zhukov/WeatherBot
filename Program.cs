using Telegram.Bot;
using Telegram.Bot.Types;
using WeatherBot;
using Newtonsoft.Json;
using Telegram.Bot.Exceptions;

class Program
{
    static string KeyReader(string pathToFile)
    {
        using (StreamReader reader = new StreamReader(pathToFile))
        {
            string token = reader.ReadToEnd();
            return token;
        }
    }
    public static async Task Main(string[] args)
    {
        string pathToYaKey = "SensetiveData\\YaAPI.env";
        string YaKey = KeyReader(pathToYaKey);

        string pathToTGtoken = "SensetiveData\\Token.env";
        string TGtoken = KeyReader(pathToTGtoken);

        string pathToTGid = "SensetiveData\\UserID.env";
        string TGid = KeyReader(pathToTGid);

        string pathToTargetTime = "SensetiveData\\targetTime.env";
        string targetTime = KeyReader(pathToTargetTime);

        string pathToCityCoordinates = "SensetiveData\\lat-lon.env";
        string cityCoordinates = KeyReader(pathToCityCoordinates);

        string pathToURL = "SensetiveData\\URL.env";
        string URL = KeyReader(pathToURL);

        Console.WriteLine(YaKey);
        Console.WriteLine(URL);   


        HttpClient httpClient = new();
        httpClient.DefaultRequestHeaders.Add("X-Yandex-API-Key", YaKey);

        var bot = new TelegramBotClient(TGtoken);

        while (true)
        {
            string curTime = DateTime.Now.ToShortTimeString();
            if (targetTime == curTime)
            {

                using HttpResponseMessage response = await httpClient.GetAsync($"{URL}?{cityCoordinates}");
                try
                {
                    response.EnsureSuccessStatusCode();
                    string forecastSource = await response.Content.ReadAsStringAsync();
                    WeatherForecast forecast = JsonConvert.DeserializeObject<WeatherForecast>(forecastSource);
                    Message message = await bot.SendTextMessageAsync(TGid, $"Доброе утро, температура воздуха в СПб сейчас {forecast.fact.Temp}");
                    Thread.Sleep(60000);
                }
                catch (HttpRequestException e)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        Console.WriteLine("Неверно указаны координаты");
                    }
                    Console.WriteLine(e.Message);
                    Thread.Sleep(30000);
                }
                catch (ApiRequestException e)
                {
                    Console.WriteLine(e.Message);
                    Thread.Sleep(30000);
                }
            }
        }
    }
}


