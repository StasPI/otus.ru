using Abstraction;

namespace GuessTheNumber
{
   public class Game
   {
      private readonly IDataConsole _dataConsole;
      private IRandomNumber _randomNumber;

      private readonly int _numberOfAttempts;
      private readonly int _rangeStart;
      private readonly int _rangeEnd;

      private int _userNumber;

      public Game(ISettings settings, IRandomNumber randomNumber, IDataConsole dataConsole)
      {
         _numberOfAttempts = settings.NumberOfAttempts;
         _rangeStart = settings.RangeStart;
         _rangeEnd = settings.RangeEnd;

         _dataConsole = dataConsole;
         _randomNumber = randomNumber;
      }

      public void Execute()
      {
         while (true)
         {
            int rNumber = _randomNumber.GetNumber(_rangeStart, _rangeEnd);
            StartMonolog();
            for (int attempt = 0; attempt < _numberOfAttempts; attempt++)
            {
               EnterTheNumber(attempt + 1);
               _userNumber = GetAnswerInt();
               if (rNumber == _userNumber)
               {
                  Сongratulations();
                  break;
               }
               else if (attempt + 1 == _numberOfAttempts)
               {
                  Fail();
                  break;
               }
               else if (rNumber > _userNumber)
               {
                  More();
               }
               else if (rNumber < _userNumber)
               {
                  Smaller();
               }
            }
         }
      }

      public void StartMonolog()
      {
         _dataConsole.Write(new string('=', 80));
         _dataConsole.Write($"Я загадал число от {_rangeStart} до {_rangeEnd}, у вас {_numberOfAttempts} попыток.");
      }

      public void EnterTheNumber(int attempt)
      {
         _dataConsole.Write($"Попытка {attempt}, введите число: ");
      }

      public void Сongratulations()
      {
         _dataConsole.Write("Верно! Поздравляем!");
      }

      private void Fail()
      {
         _dataConsole.Write("Попытки кончились, Вы не угадали!");
      }

      public void More()
      {
         _dataConsole.Write("Попробуйте число побольше");
      }

      public void Smaller()
      {
         _dataConsole.Write("Попробуйте число поменьше");
      }

      public int GetAnswerInt()
      {
         return _dataConsole.ReadInt();
      }
   }
}