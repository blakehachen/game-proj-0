using System;

namespace game_project_0
{
    public static class Program
    {
        /// <summary>
        /// Runs Game
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new GameProject0())
                game.Run();
        }
    }
}
