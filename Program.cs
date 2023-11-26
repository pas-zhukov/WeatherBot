using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bots.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;

string ReadToEnd("G:\Local repo\SensetiveData\Token.env")
var bot = new TelegramBotClient("6650477462:AAF9ZXvLjpOqN1Tnve1XkN8a2ECtJ05bPLo");
Message message = await bot.SendTextMessageAsync(384104267,"Здарова, бандиты");