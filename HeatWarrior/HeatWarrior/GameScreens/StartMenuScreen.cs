using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

using XRpgLibrary;
using XRpgLibrary.Controls;

namespace HeatWarrior.GameScreens
{
    public class StartMenuScreen : BaseGameState
    {
        #region Field Region

        PictureBox backgroundImage;
        PictureBox arrowImage;
        PictureBox arrowImage2;
        LinkLabel startGame;
        LinkLabel loadGame;
        LinkLabel exitGame;
        float maxItemWidth = 0f;

        #endregion




        #region Properties Region
        #endregion




        #region Contructor Region

        public StartMenuScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {

        }

        #endregion




        #region XNA Methods Region

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            ContentManager Content = Game.Content;

            backgroundImage = new PictureBox(
                Content.Load<Texture2D>(@"Backgrounds\titlescreen"),
                GameRef.ScreenRectangle);
            ControlManager.Add(backgroundImage);

            Texture2D arrowTexture = Content.Load<Texture2D>(@"GUI\leftarrowUp");
            Texture2D arrowTexture2 = Content.Load<Texture2D>(@"GUI\rightarrowUp");

            arrowImage = new PictureBox(
                arrowTexture,
                new Rectangle(0, 0, arrowTexture.Width, arrowTexture.Height));
            ControlManager.Add(arrowImage);

            arrowImage2 = new PictureBox(
                arrowTexture2,
                new Rectangle(0, 0, arrowTexture2.Width, arrowTexture2.Height));
            ControlManager.Add(arrowImage2);

            startGame = new LinkLabel();
            startGame.Text = "New Game";
            startGame.Size = startGame.SpriteFont.MeasureString(startGame.Text);
            startGame.SelectedColor = Color.DarkGray;
            startGame.Selected += new EventHandler(menuItem_Selected);

            ControlManager.Add(startGame);

            loadGame = new LinkLabel();
            loadGame.Text = "Load Game";
            loadGame.Size = loadGame.SpriteFont.MeasureString(loadGame.Text);
            loadGame.SelectedColor = Color.DarkGray;
            loadGame.Selected += new EventHandler(menuItem_Selected);

            ControlManager.Add(loadGame);

            exitGame = new LinkLabel();
            exitGame.Text = "Exit Game";
            exitGame.Size = exitGame.SpriteFont.MeasureString(exitGame.Text);
            exitGame.SelectedColor = Color.DarkGray;
            exitGame.Selected += new EventHandler(menuItem_Selected);

            ControlManager.Add(exitGame);

            ControlManager.NextControl();

            ControlManager.FocusChanged += new EventHandler(ControlManager_FocusChanged);
            Vector2 position = new Vector2(0, 500);

            foreach (Control c in ControlManager)
            {
                position.X = 512;
                if (c is LinkLabel)
                {
                    if (c.Size.X > maxItemWidth)
                        maxItemWidth = c.Size.X;
                    position.X -= c.Size.X / 2;
                    c.Position = position;
                    position.Y += c.Size.Y + 5f;
                }
            }

            ControlManager_FocusChanged(startGame, null);
        }

        void ControlManager_FocusChanged(object sender, EventArgs e)
        {
            Control control = sender as Control;
            maxItemWidth = control.Size.X;
            Vector2 position = new Vector2(control.Position.X + maxItemWidth,
                control.Position.Y);
            Vector2 position2 = new Vector2(control.Position.X - arrowImage2.Image.Width, control.Position.Y);
            arrowImage.SetPosition(position);
            arrowImage2.SetPosition(position2);
        }

        private void menuItem_Selected(object sender, EventArgs e)
        {
            if (sender == startGame)
            {
                //StateManager.PushState(GameRef.CharacterGeneratorScreen);
            }

            if (sender == loadGame)
            {
                //StateManager.PushState(GameRef.GamePlayScreen);
            }

            if (sender == exitGame)
            {
                GameRef.Exit();
            }
        }

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime, playerIndexInControll);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin();

            base.Draw(gameTime);

            ControlManager.Draw(GameRef.SpriteBatch);

            GameRef.SpriteBatch.End();
        }

        #endregion




        #region Game State Method Region
        #endregion
    }
}
