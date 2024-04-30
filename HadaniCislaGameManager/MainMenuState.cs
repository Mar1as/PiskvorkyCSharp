using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HadaniCislaGameManager
{
    internal class MainMenuState : IGameState
    {
        public void Enter()
        {
            Console.Clear();
        }

        public void Exit()
        {
            GameStateManager.Instance.ChangeState(GameStateManager.Instance.playingState);
        }

        public void Render()
        {

        }

        public void Update()
        {
            Console.WriteLine("Vítejte v hře Hádej číslo!\r\n1. Hrát hru\r\n2. Pravidla\r\n3. Konec\r\n");
            string odpoved = Console.ReadLine();
            if (odpoved == "1")
            {
                Exit();
            }
            else if (odpoved == "2")
            {
                Console.WriteLine("Hra je o hádání čísla od 0 do 100. Po každém pokusu vám hra řekne, zda je hádané číslo menší nebo větší než vaše. Hra končí, když uhodnete číslo.");
                Console.WriteLine("Stiskněte libovolnou klávesu pro návrat do hlavního menu.");
                Console.ReadKey();
                Enter();
            }
            else if (odpoved == "3")
            {
                Environment.Exit(0);
            }
        }
    }
}
