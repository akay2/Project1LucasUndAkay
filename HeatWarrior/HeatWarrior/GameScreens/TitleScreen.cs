using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using XRpgLibrary;
using XRpgLibrary.Controls;

namespace HeatWarrior.GameScreens
{
    public class TitleScreen : BaseGameState
    {
        #region Field Region

        Texture2D backgroundImage;
        LinkLabel startLabel;
       
        #endregion




        #region Contructor Region

        public TitleScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {

        }

        #endregion




        #region XNA Method Region

        protected override void LoadContent()
        {
            ContentManager Content = GameRef.Content;
            backgroundImage = Content.Load<Texture2D>(@"Backgrounds/titlescreen");

            base.LoadContent();

            startLabel = new LinkLabel();
            startLabel.Position = new Vector2(350, 500);
            startLabel.Text = "Press ENTER to begin";
            startLabel.Color = Color.White;
            startLabel.SelectedColor = Color.DarkGray;
            startLabel.TabStop = true;
            startLabel.HasFocus = true;
            startLabel.Selected += new EventHandler(startLabel_Selected);

            ControlManager.Add(startLabel);
        }

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime, PlayerIndex.One);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin();

            base.Draw(gameTime);

            GameRef.SpriteBatch.Draw(backgroundImage, GameRef.ScreenRectangle, Color.White);

            ControlManager.Draw(GameRef.SpriteBatch);
            
            GameRef.SpriteBatch.End();
        }

        #endregion




        #region Title Screen Methods

        private void startLabel_Selected(object sender, EventArgs e)
        {
            StateManager.PushState(GameRef.StartMenuScreen);
        }

        #endregion
    }
}
