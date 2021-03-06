using Microsoft.Xna.Framework;
using game_project_0.StateManagement;

namespace game_project_0.Screens
{
    public class MainMenuScreen : MenuScreen
    {
        public MainMenuScreen() : base("Space Rush")
        {
            var playGameMenuEntry = new MenuButton("Play", new Vector2(0, 0), "Press [ENTER] or A to Play", -30, -16, -80, 0);
            //var settingsGameMenuEntry = new MenuButton("Settings", new Vector2(0,0), "Not Implemented", -60, -16, -15, 0);
            var quitGameMenuEntry = new MenuButton("Quit", new Vector2(0, 0), "Press [ENTER] or A to Quit", -30, -16, -15, 0);
            

            playGameMenuEntry.Selected += PlayGameMenuEntrySelected;
            //settingsGameMenuEntry.Selected += SettingsMenuEntrySelected;
            quitGameMenuEntry.Selected += OnCancel;

            MenuEntries.Add(playGameMenuEntry);
            //MenuEntries.Add(settingsGameMenuEntry);
            MenuEntries.Add(quitGameMenuEntry);
        }
        public override void Activate()
        {
            base.Activate();
        }
        private void PlayGameMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            LoadingScreen.Load(ScreenManager, true, e.PlayerIndex, new GameplayScreen());
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
