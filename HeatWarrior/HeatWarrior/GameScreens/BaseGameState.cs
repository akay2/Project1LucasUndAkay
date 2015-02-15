using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary;
using XRpgLibrary.Controls;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace HeatWarrior.GameScreens
{
    public abstract partial class BaseGameState : GameState
    {
        #region Field Region

        protected Game1 GameRef;

        protected ControlManager ControlManager;

        protected PlayerIndex playerIndexInControll;

        #endregion




        #region Properties Region
        #endregion




        #region Contructor Region

        public BaseGameState(Game game, GameStateManager manager)
            : base(game, manager)
        {
            GameRef = (Game1)game;
            playerIndexInControll = PlayerIndex.One;
        }

        #endregion




        #region XNA Methods Region

        protected override void LoadContent()
        {
            ContentManager Content = Game.Content;
            SpriteFont menuFont = Content.Load<SpriteFont>(@"Fonts\ControlFont");
            ControlManager = new ControlManager(menuFont);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        #endregion
    }
}
