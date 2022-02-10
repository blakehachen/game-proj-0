using System;
using game_project_0.StateManagement;

namespace game_project_0
{
   public class ScreenFactory : IScreenFactory
    {
        public GameScreen CreateScreen(Type screenType)
        {
            return Activator.CreateInstance(screenType) as GameScreen;
        }
    }
}
