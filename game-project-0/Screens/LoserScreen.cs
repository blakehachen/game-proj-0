﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace game_project_0.Screens
{
    public class LoserScreen : MenuScreen
    {
        public LoserScreen() : base("Game Over")
        {
            var retryGameMenuEntry = new MenuButton("Retry", new Vector2(0, 0), "Wanna try again?", -40, -15, -15, 0);
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
