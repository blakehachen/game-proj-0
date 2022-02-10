using System;
using Microsoft.Xna.Framework;

namespace game_project_0.Screens
{
    public class PlayerIndexEventArgs : EventArgs
    {
        public PlayerIndex PlayerIndex { get; }

        public PlayerIndexEventArgs(PlayerIndex playerIndex)
        {
            PlayerIndex = playerIndex;
        }
    }
}
