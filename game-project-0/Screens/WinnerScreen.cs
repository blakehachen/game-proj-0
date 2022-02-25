using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace game_project_0.Screens
{
    public class WinnerScreen : MenuScreen
    {
        public WinnerScreen() : base("You Win!")
        {
            var retryGameMenuEntry = new MenuButton("Play Again", new Vector2(0, 0), "Wanna play again?", -75, -15, -15, 0);
            var quitGameMenuEntry = new MenuButton("Main Menu", new Vector2(0, 0), "Return to Main Menu.", -70, -16, -35, 0);

            retryGameMenuEntry.Selected += RetryGameMenuEntrySelected;
            quitGameMenuEntry.Selected += QuitGameMenuEntrySelected;

            MenuEntries.Add(retryGameMenuEntry);
            MenuEntries.Add(quitGameMenuEntry);
        }
        public override void Activate()
        {
            base.Activate();
        }
        private void QuitGameMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            LoadingScreen.Load(ScreenManager, false, null, new BackgroundScreen(), new MainMenuScreen());
        }

        private void RetryGameMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            LoadingScreen.Load(ScreenManager, false, ControllingPlayer, new GameplayScreen());
        }
    }
}

