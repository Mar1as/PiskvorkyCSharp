using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HadaniCislaGameManager
{
    internal class PlayingState : IGameState
    {
        Random rnd = new Random();
        public int hadaneCislo { get; private set;}
        public int pocetPokusu { get; private set;}

        List<Row> rows;

        public void Enter()
        {
            Console.Clear();
            hadaneCislo = rnd.Next(1, 100);
            pocetPokusu = 0;
            rows = new List<Row>();
            for (int i = 0; i < 3; i++)
            {
                rows.Add(new Row());
            }
        }

        public void Exit()
        {
            GameStateManager.Instance.ChangeState(GameStateManager.Instance.gameOverState);
        }

        public void Render()
        {
            Console.WriteLine();
            for (int i = 0; i < rows.Count; i++)
            {
                for (int j = 0; j < rows[i].misto.Count; j++)
                {
                    Console.Write(rows[i].misto[j].symbol);
                }
                Console.WriteLine();
            }
        }

        public void Update()
        {
            
            Ai();
            WinCondition("O");
            Render();

            Player();
            WinCondition("X");

            Render();
        }

        void Player()
        {
            Console.WriteLine("Napiš: 1,2,3,4,5,6,7,8,9");

            try
            {
                int hadaneCislo = int.Parse(Console.ReadLine());
                Game(hadaneCislo, "X", true);
            }
            catch (Exception)
            {
                Player();
            }
        }

        void Ai()
        {
            JeVolny();
            hadaneCislo = rnd.Next(1, 10);
            Game(hadaneCislo, "O", false);
        }

        void Game(int number, string symbol, bool player)
        {
            try
            {
                int hadaneCislo = number;

                int row = (hadaneCislo - 1) / 3;
                int column = (hadaneCislo - 1) % 3;

                if (rows[row].misto[column].obsazeno == true)
                {
                    if (player)
                    {
                        Console.WriteLine("Obsazeno");
                        Player();
                    }
                    else
                    {
                        Ai();
                    }
                }

                rows[row].misto[column].Symbol = symbol;
                
            }
            catch (Exception) { }
        }

        void WinCondition(string symbol)
        {
            int count = 0;
            for (int i = 0; i < rows.Count; i++)
            {
                for (int j = 0; j < rows[i].misto.Count; j++)
                {
                    if (rows[i].misto[j].symbol == symbol) count++;
                    else count = 0;
                    if (count == 3)
                    {
                        Console.WriteLine(symbol + " vyhrál");
                        Console.ReadKey();
                        Exit();
                    }
                }
                count = 0;
            }
            for (int i = 0; i < rows.Count; i++)
            {
                for (int j = 0; j < rows[i].misto.Count; j++)
                {
                    if (rows[j].misto[i].symbol == symbol) count++;
                    else count = 0;
                    if (count == 3)
                    {
                        Console.WriteLine(symbol + " vyhrál");
                        Console.ReadKey();
                        Exit();
                    }
                }
                count = 0;
            }
            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i].misto[i].symbol == symbol) count++;
                else count = 0;
                if (count == 3)
                {
                    Console.WriteLine(symbol + " vyhrál");
                    Console.ReadKey();
                    Exit();
                }
            }
            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i].misto[2 - i].symbol == symbol) count++;
                else count = 0;
                if (count == 3)
                {
                    Console.WriteLine(symbol + " vyhrál");
                    Console.ReadKey();
                    Exit();
                }
            }
        }
        void JeVolny()
        {
            bool volny = false;
            for (int i = 0; i < rows.Count; i++)
            {
                for (int j = 0; j < rows[i].misto.Count; j++)
                {
                    if(rows[i].misto[j].obsazeno == false)
                    {
                        volny = true;
                    }
                    
                }
            }
            if (volny == false) Exit();
        }
    }
}
