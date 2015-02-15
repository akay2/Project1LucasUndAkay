//system
using System;
using System.Collections.Generic;
using System.Linq;

//XNA
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

//Engine
using XRpgLibrary;
using HeatWarrior.GameScreens;

namespace HeatWarrior
{
    

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region Field Region

        GraphicsDeviceManager graphics;
        public SpriteBatch SpriteBatch;
        public readonly Rectangle ScreenRectangle;
        const int screenWidth = 1024;
        const int screenHeight = 768;

        #endregion

        #region GameScreen Region

        GameStateManager stateManager;
        public TitleScreen TitleScreen;
        public StartMenuScreen StartMenuScreen;
        public GamePlayScreen GamePlayScreen;
        public CharacterGeneratorScreen CharacterGeneratorScreen;

        #endregion


        #region Game State Region



        #endregion

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;

            stateManager = new GameStateManager(this);
            Content.RootDirectory = "Content";

            ScreenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);

            //Hier werden die Componenten Hinzugefügt
            Components.Add(new InputHandler(this)); //Dieses Komponent prüft dauerhaft auf eingaben der tastetur/GamePad
            Components.Add(stateManager); //dieses Komponent ist für die verschiedenen bildschirme dar.

            //alle bildschirme adden
            TitleScreen = new TitleScreen(this, stateManager);
            StartMenuScreen = new StartMenuScreen(this, stateManager);
            GamePlayScreen = new GamePlayScreen(this, stateManager);
            CharacterGeneratorScreen = new CharacterGeneratorScreen(this, stateManager);

            stateManager.ChangeState(TitleScreen);
        }

       
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

       
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

       
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

       
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
