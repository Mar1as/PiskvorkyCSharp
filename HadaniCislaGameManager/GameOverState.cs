using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HadaniCislaGameManager
{
    internal class GameOverState : IGameState
    {
        int hadaneCislo;
        int pocetPokusu;

        public void Enter()
        {
            Console.Clear();

            hadaneCislo = GameStateManager.Instance.playingState.hadaneCislo;
            pocetPokusu = GameStateManager.Instance.playingState.pocetPokusu;
        }

        public void Exit()
        {
            Console.WriteLine($"Výsledné číslo: {hadaneCislo}; Počet pokusů: {pocetPokusu}.");
            Console.WriteLine("1. Hrát znovu\r\n2. Návrat do hlavního menu\r\n3. Konec");
            string odpoved = Console.ReadLine();
            if (odpoved == "1")
            {
                GameStateManager.Instance.ChangeState(GameStateManager.Instance.playingState);

            }
            else if(odpoved == "3")
            {
                Environment.Exit(0);
            }
            else
            {
                GameStateManager.Instance.ChangeState(GameStateManager.Instance.mainMenuState);
            }

        }

        public void Render()
        {
        }

        public void Update()
        {
            Exit();
        }
    }
}
