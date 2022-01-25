using System;

namespace game_project_0
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new GameProject0())
                game.Run();
        }
    }
}
