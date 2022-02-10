using System;


namespace game_project_0.StateManagement
{
    public interface IScreenFactory
    {
        GameScreen CreateScreen(Type screenType);
    }
}
