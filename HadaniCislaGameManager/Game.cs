using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HadaniCislaGameManager
{
    internal class Game
    {
        public Game()
        {
            while (true)
            {
                GameStateManager.Instance.Update();
            }
        }
    }
}
