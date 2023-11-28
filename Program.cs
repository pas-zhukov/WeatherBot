using Telegram.Bot;
using Telegram.Bot.Types;
using WeatherBot;
using Newtonsoft.Json;

string KeyReader(string pathToFile)
{
    StreamReader reader = new StreamReader(pathToFile);
    string token = reader.ReadToEnd();
    return token;
}
string pathToYaKey = "C:\\SensetiveData\\YaAPI.env";
string YaKey = KeyReader(pathToYaKey);

string pathToTGtoken = "C:\\SensetiveData\\Token.env";
string TGtoken = KeyReader(pathToTGtoken);

string pathToTGid = "C:\\SensetiveData\\UserID.env";
string TGid = KeyReader(pathToTGid);

string pathToTargetTime = "C:\\SensetiveData\\targetTime.env";
string targetTime = KeyReader(pathToTargetTime);

string pathToCityCoordinates = "C:\\SensetiveData\\lat-lon.env";
string cityCoordinates = KeyReader(pathToCityCoordinates);

string pathToURL = "C:\\SensetiveData\\URL.env";
string URL = KeyReader(pathToURL);

HttpClient httpClient = new();
httpClient.DefaultRequestHeaders.Add("X-Yandex-API-Key", YaKey);

var bot = new TelegramBotClient(TGtoken);

while (true)
{
    string curTime = DateTime.Now.ToShortTimeString(); 
    if (targetTime == curTime)
    {
        using HttpResponseMessage response = await httpClient.GetAsync($"{URL}?{cityCoordinates}");
        string content = await response.Content.ReadAsStringAsync();
        WeatherForecast forecast = JsonConvert.DeserializeObject<WeatherForecast>(content);
        Message message = await bot.SendTextMessageAsync(TGid, $"Доброе утро, температура воздуха в СПб сейчас {forecast.fact.Temp}");
        Thread.Sleep(60000);
    }
}


