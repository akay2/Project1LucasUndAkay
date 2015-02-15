using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XRpgLibrary.Controls
{
    public class Label : Control
    {
        #region Contructor Region

        public Label()
        {
            tabStop = false;
        }

        #endregion




        #region Abstract Methods

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.DrawString(SpriteFont, Text, Position, Color);
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {
            
        }

        #endregion
    }
}
