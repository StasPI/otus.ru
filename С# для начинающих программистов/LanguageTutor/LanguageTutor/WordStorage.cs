using System;
using System.Collections.Generic;
using System.IO;

namespace LanguageTutor
{
   class WordStorage
   {
      private const string _path = "wordStorage.txt";
      public Dictionary<string, string> GetAllWords()
      {
         Dictionary<string, string> dic = new Dictionary<string, string>();

         try
         {
            if (File.Exists(_path))
            {
               foreach (string line in File.ReadAllLines(_path))
               {
                  string[] words = line.Split('|');
                  if (words.Length == 2)
                  {
                     if (!dic.ContainsKey(words[0]))
                     {
                        dic.Add(words[0], words[1]);
                     }
                  }
               }
            }
            return dic;
         }
         catch (Exception ex)
         {
            Console.WriteLine("Не удалось считать словарь");
            return dic;
         }
         
      }

      public void AddWord(string eng, string rus)
      {
         try
         {
            using (StreamWriter write = new StreamWriter(_path, true))
            {
               write.WriteLine($"{eng}|{rus}");
            }
         }
         catch (Exception ex)
         {
            Console.WriteLine($"Не удалось добавить слово {eng} в словарь");
         }

      }
   }
}
