using Microsoft.Xna.Framework;
using game_project_0.StateManagement;

namespace game_project_0.Screens
{
    public class MainMenuScreen : MenuScreen
    {
        public MainMenuScreen() : base("Main Menu")
        {
            var playGameMenuEntry = new MenuButton("Play", new Vector2(400, 250), "Not Implemented", -30, -16, -15, 0);
            var settingsGameMenuEntry = new MenuButton("Settings", new Vector2(400,310), "Not Implemented", -60, -16, -15, 0);
            var quitGameMenuEntry = new MenuButton("Quit", new Vector2(400, 370), "Press [ENTER] or A to Quit", -30, -16, -75, 0);

            playGameMenuEntry.Selected += PlayGameMenuEntrySelected;
            settingsGameMenuEntry.Selected += SettingsMenuEntrySelected;
            quitGameMenuEntry.Selected += OnCancel;

            MenuEntries.Add(playGameMenuEntry);
            MenuEntries.Add(settingsGameMenuEntry);
            MenuEntries.Add(quitGameMenuEntry);
        }

        private void PlayGameMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            
        }

        private void SettingsMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            
        }

        protected override void OnCancel(PlayerIndex playerIndex)
        {
            ScreenManager.Game.Exit();
        }
    }
}
