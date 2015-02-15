using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace XRpgLibrary
{

    public class InputHandler : Microsoft.Xna.Framework.GameComponent
    {

        #region Keyboard Field Region

        static KeyboardState keyboardState;
        static KeyboardState lastKeyboardState;

        #endregion
        #region GamePad Field Region

        static GamePadState[] gamePadStates;
        static GamePadState[] lastGamePadStates;

        #endregion




        #region Keyboard Property Region

        public static KeyboardState KeyboardState
        {
            get { return keyboardState; }
        }

        public static KeyboardState LastKeyboardState
        {
            get { return lastKeyboardState; }
        }

        #endregion
        #region GamePad Property Region

        public static GamePadState[] GamePadState
        {
            get { return gamePadStates; }
        }

        public static GamePadState[] LastGamePadStates
        {
            get { return lastGamePadStates; }
        }

        #endregion




        #region Constructor Region

        public InputHandler(Game game)
            : base(game)
        {
            keyboardState = Keyboard.GetState();

            gamePadStates = new GamePadState[Enum.GetValues(typeof (PlayerIndex)).Length];
            foreach (PlayerIndex index in Enum.GetValues(typeof (PlayerIndex)))
            {
                gamePadStates[(int)index] = GamePad.GetState(index);
            }
        }

        #endregion




        #region XNA methods

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            lastGamePadStates = (GamePadState[])gamePadStates.Clone();
            foreach (PlayerIndex index in Enum.GetValues(typeof(PlayerIndex)))
            {
                gamePadStates[(int)index] = GamePad.GetState(index);
            }

            base.Update(gameTime);
        }

        #endregion




        #region General Method Region

        public static void Flush()
        {
            lastKeyboardState = keyboardState;
        }

        #endregion




        #region Keyboard Region

        public static bool KeyReleased(Keys key)
        {
            return keyboardState.IsKeyUp(key) && lastKeyboardState.IsKeyDown(key);
        }

        public static bool KeyPressed(Keys key)
        {
            return keyboardState.IsKeyDown(key) && lastKeyboardState.IsKeyUp(key);
        }

        public static bool KeyDown(Keys key)
        {
            return keyboardState.IsKeyDown(key);
        }

        #endregion




        #region Game Pad Region

        public static bool ButtonReleased(Buttons buttons, PlayerIndex index)
        {
            return gamePadStates[(int)index].IsButtonUp(buttons) &&
                lastGamePadStates[(int)index].IsButtonDown(buttons);
        }

        public static bool ButtonPressed(Buttons buttons, PlayerIndex index)
        {
            return gamePadStates[(int)index].IsButtonDown(buttons) &&
                lastGamePadStates[(int)index].IsButtonUp(buttons);
        }

        public static bool ButtonDown(Buttons buttons, PlayerIndex index)
        {
            return gamePadStates[(int)index].IsButtonDown(buttons);
        }

        #endregion
    }
}