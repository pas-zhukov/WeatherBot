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
string pathToYaKey = "G:\\Local repo\\SensetiveData\\YaAPI.env";
string YaKey = KeyReader(pathToYaKey);
string pathToTGtoken = "G:\\Local repo\\SensetiveData\\Token.env";
string TGtoken = KeyReader(pathToTGtoken);
string pathToTGid = "G:\\Local repo\\SensetiveData\\UserID.env";
string TGid = KeyReader(pathToTGid);
HttpClient httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Add("X-Yandex-API-Key", YaKey);
var bot = new TelegramBotClient(TGtoken);
string targetTime = "9:00";
while (true)
{
    using HttpResponseMessage response = await httpClient.GetAsync("https://api.weather.yandex.ru/v2/informers?lat=59.938676&lon=30.314494");
    string content = await response.Content.ReadAsStringAsync();
    WeatherForecast forecast = JsonConvert.DeserializeObject<WeatherForecast>(content);
    string curTime = DateTime.Now.ToShortTimeString();
    if (targetTime == curTime)
    {
        Message message = await bot.SendTextMessageAsync(TGid, $"Доброе утро, температура воздуха в СПб сейчас{forecast.fact.Temp}");
        Thread.Sleep(86400000);
    }
}




