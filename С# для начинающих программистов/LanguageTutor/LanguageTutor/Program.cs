using System;
using System.Collections.Generic;
using Telegram.Bot;

namespace LanguageTutor
{
   class Program
   {
      static TelegramBotClient Bot;
      static Tutor Tutor = new Tutor();
      static Dictionary<int, string> LastWord = new Dictionary<int, string>();
      const string COMMAND_LIST =
@"Список команд:
/add <eng> <rus> - добавление английского слова и его перевода в словарь
/get - получение случайного английского слова из словаря
/check <eng> <rus> - проверяем правильность перевода английского слова
";
      static void Main(string[] args)
      {
         Bot = new TelegramBotClient("");

         Bot.OnMessage += Bot_OnMessage;
         Bot.StartReceiving();
         Console.ReadLine();
         Bot.StopReceiving();

      }

      private static async void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
      {
         if (e == null || e.Message == null || e.Message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
            return;

         Console.WriteLine($"{e.Message.From.FirstName}: {e.Message.Text}");

         int userId = e.Message.From.Id;
         string[] msgArgs = e.Message.Text.Split(" ");
         string text;
         switch (msgArgs[0])
         {
            case "/start":
               text = COMMAND_LIST;
               break;
            case "/add":
               text = AddWords(msgArgs);
               break;
            case "/check":
               text = CheckWord(msgArgs);
               string newWord = GetRandomEngWord(userId);
               text = $"{text}\r\nСледующее слово: {newWord}";
               break;
            case "/get":
               text = GetRandomEngWord(userId);
               break;
            default:
               if (LastWord.ContainsKey(userId))
               {
                  text = CheckWord(LastWord[userId], msgArgs[0]);
                  newWord = GetRandomEngWord(userId);
                  text = $"{text}\r\nСледующее слово: {newWord}";
               }
               else
                  text = COMMAND_LIST;
               break;
         }
         await Bot.SendTextMessageAsync(e.Message.From.Id, text);
      }

      private static string GetRandomEngWord(int userId)
      {
         string text = Tutor.GetRandomEngWord();
         if (LastWord.ContainsKey(userId))
            LastWord[userId] = text;
         else
            LastWord.Add(userId, text);

         return text;
      }

      private static string CheckWord(string[] msgArgs)
      {
         if (msgArgs.Length != 3)
            return "Неправильное количество агрументов. Их должно быть 2";
         else
            return CheckWord(msgArgs[1], msgArgs[2]);
      }

      private static string CheckWord(string eng, string rus)
      {
         if (Tutor.CheckWord(eng, rus))
            return "Правильно";
         else
            return $"Не правильно, правильный перевод: {Tutor.Translate(eng)}";
      }

      private static string AddWords(string[] msgArgs)
      {
         if (msgArgs.Length != 3)
            return "Неправильное количество агрументов. Их должно быть 2";
         else
         {
            Tutor.AddWord(msgArgs[1], msgArgs[2]);
            return "Новое слово добавлено в словарь";
         }
      }
   }
}