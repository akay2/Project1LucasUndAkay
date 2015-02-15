using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using XRpgLibrary;
using XRpgLibrary.Controls;

namespace HeatWarrior.GameScreens
{
    public class CharacterGeneratorScreen : BaseGameState
    {
        #region Field Region

        LeftRightSelector genderSelector;
        LeftRightSelector classSelector;
        PictureBox backgroundImage;
        PictureBox characterImage;
        Texture2D[,] characterImages;

        string[] genderItems = { "Male", "Female" };
        string[] classItems = { "Fighter", "Wizard", "Rogue", "Priest" };

        #endregion




        #region Properties Region

        public string SelectedGender
        {
            get { return genderSelector.SelectedItem; }
        }

        public string SelectedClass
        {
            get { return classSelector.SelectedItem; }
        }

        #endregion




        #region Constructor Region

        public CharacterGeneratorScreen(Game game, GameStateManager stateManager)
            : base(game, stateManager)
        {

        }

        #endregion




        #region XNA Method Region

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            LoadImages();
            CreateControls();
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

            ControlManager.Draw(GameRef.SpriteBatch);

            GameRef.SpriteBatch.End();
        }

        #endregion




        #region Method Region

        private void CreateControls()
        {
            Texture2D leftTexture = Game.Content.Load<Texture2D>(@"GUI\leftarrowUp");
            Texture2D rightTexture = Game.Content.Load<Texture2D>(@"GUI\rightarrowUp");
            Texture2D stopTexture = Game.Content.Load<Texture2D>(@"GUI\StopBar");

            backgroundImage = new PictureBox(
                Game.Content.Load<Texture2D>(@"Backgrounds\titlescreen"),
                GameRef.ScreenRectangle);
            ControlManager.Add(backgroundImage);

            Label label1 = new Label();

            label1.Text = "Who will search for the Eyes of the Dragon?";
            label1.Size = label1.SpriteFont.MeasureString(label1.Text);
            label1.Position = new Vector2((GameRef.Window.ClientBounds.Width - label1.Size.X)
                / 2 , 150);

            ControlManager.Add(label1);

            genderSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
            genderSelector.SetItems(genderItems, 125);
            genderSelector.Position = new Vector2(label1.Position.X, 200);
            genderSelector.SelectionChanged += new EventHandler(selecteionChanged);

            ControlManager.Add(genderSelector);

            classSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
            classSelector.SetItems(classItems, 125);
            classSelector.Position = new Vector2(label1.Position.X, 250);
            classSelector.SelectionChanged += new EventHandler(selecteionChanged);

            ControlManager.Add(classSelector);

            LinkLabel linkLabel1 = new LinkLabel();
            linkLabel1.Text = "Accept this character.";
            linkLabel1.Position = new Vector2(label1.Position.X, 300);
            linkLabel1.Selected += new EventHandler(linkLabel1_Selected);

            ControlManager.Add(linkLabel1);

            characterImage = new PictureBox(
                characterImages[0, 0],
                new Rectangle(500, 200, 96, 96),
                new Rectangle(0, 0, 32, 32)); 

            ControlManager.Add(characterImage);

            ControlManager.NextControl();
        }

        void linkLabel1_Selected(object sender, EventArgs e)
        {
            InputHandler.Flush();

            StateManager.PopState();
            StateManager.PushState(GameRef.GamePlayScreen);
        }

        private void LoadImages()
        {
            characterImages = new Texture2D[genderItems.Length, classItems.Length];
            

            for (int i = 0; i < genderItems.Length; i++)
            {
                for (int j = 0; j < classItems.Length; j++)
                {
                    characterImages[i, j] = Game.Content.Load<Texture2D>(@"PlayerSprites\"
                        + genderItems[i]
                        + classItems[j]);
                    
                }
            }
        }

        void selecteionChanged(object sender, EventArgs e)
        {
            characterImage.Image = characterImages[genderSelector.SelectedIndex,
                classSelector.SelectedIndex];
        }

        #endregion
    }
}
