using game_project_0.StateManagement;
using Microsoft.Xna.Framework;

namespace game_project_0.Screens
{
    public class PauseMenuScreen : MenuScreen
    {
        public PauseMenuScreen() : base("Pause")
        {
            var resumeGameMenuEntry = new MenuButton("Resume", new Vector2(0, 0), "Continue playing", -50, -16, -15, 0);
            var quitGameMenuEntry = new MenuButton("Quit", new Vector2(0, 0), "Return to Main Menu", -25, -16, -35, 0);

            resumeGameMenuEntry.Selected += OnCancel;
            quitGameMenuEntry.Selected += QuitGameMenuEntrySelected;

            MenuEntries.Add(resumeGameMenuEntry);
            MenuEntries.Add(quitGameMenuEntry);
        }

        private void QuitGameMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            LoadingScreen.Load(ScreenManager, false, null, new BackgroundScreen(), new MainMenuScreen());
        }

    }
}
