using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HadaniCislaGameManager
{
    internal class GameStateManager
    {
        private static GameStateManager instance = new GameStateManager();

        public static GameStateManager Instance => instance;

        IGameState currentState;

        public IGameState gameOverState = new GameOverState();
        public PlayingState playingState = new PlayingState();
        public IGameState mainMenuState = new MainMenuState();

        public GameStateManager()
        {
            currentState = mainMenuState;
        }

        public void ChangeState(IGameState gameState)
        {
            currentState = gameState;
            currentState.Enter();
        }

        public void Update()
        {
            currentState.Update();
        }
    }
}
