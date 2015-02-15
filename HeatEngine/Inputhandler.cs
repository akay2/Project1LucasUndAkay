using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace HeatEngine
{
    public class InputHandler : Microsoft.Xna.Framework.GameComponent
    {
        #region Field Region

        //tastatur
        static KeyboardState keyboardState; //der status der Tastatur
        static KeyboardState lastKeyboardState; //der letzte status der Tastatur

        //gamePad
        static GamePadState[] gamePadState; //der status des Gamepads
        static GamePadState[] lastGamePadState; //der letzte status des GamePads

        #endregion




        #region Properties Region

        public static KeyboardState KeyboardState
        {
            get { return keyboardState; } // gibt den aktuellen wert der Tastatur wider
        }

        public static KeyboardState LastKeyboardState
        {
            get { return lastKeyboardState; } // gibt den letzten wert der tastatur wider
        }

        public static GamePadState[] GamePadState
        {
            get { return gamePadState; } //gibt den status des GamePads wider
        }

        public static GamePadState[] LastGamePadState
        {
            get { return lastGamePadState; } //gibt den letzten stand des GamePads wider
        }

        #endregion




        #region Constructor Region

        public InputHandler(Game game) //contructor mit einem argument
            : base(game)
        {
            keyboardState = Keyboard.GetState(); //setzt den keyboardwert für den aktuellen zustand fest

            gamePadState = new GamePadState[Enum.GetValues(typeof(PlayerIndex)).Length]; //setted alle möglichen spieler Index' fest

            foreach (PlayerIndex index in Enum.GetValues(typeof(PlayerIndex)))  //geht durch alle gefundenen Gamepads durch
                gamePadState[(int)index] = GamePad.GetState(index); //setzt den entsprechenden status dem entsprechenden gamePad zu
        }

        #endregion




        #region Standart Methods Region

        public override void Initialize()
        {
            base.Initialize();
        }   //initialisiert die Datei

        public override void Update(GameTime gameTime)
        {
            lastKeyboardState = keyboardState; //setzt den letzten keyboardstate auf den des aktuellen
            keyboardState = Keyboard.GetState(); //aktualisiert den akutellen zustand der tastatur

            lastGamePadState = (GamePadState[])gamePadState.Clone(); //Clont den aktuellen gamepadState und castet es auf das letzte gamepadState
            foreach (PlayerIndex index in Enum.GetValues(typeof(PlayerIndex)))  //geht durch alle gefundenen Gamepads durch
                gamePadState[(int)index] = GamePad.GetState(index); //setzt den entsprechenden status dem entsprechenden gamePad zu

            base.Update(gameTime);
        } //update wird einmal pro frame ausgeführt

        #endregion




        #region Methods Region

        public static void Flush()
        {
            lastKeyboardState = keyboardState; //löscht die tastaturänderung zum letzten frame
            //am besten beim übergang per tasatendruck anwenden
        }

        #endregion




        #region Keyboard Region

        public static bool KeyReleased(Keys key)
        {
            return keyboardState.IsKeyUp(key) && lastKeyboardState.IsKeyDown(key); //returns True wenn eine taste welche im letzten Frame gedrückt war nun losgelassen wurde
        }

        public static bool KeyPressed(Keys key)
        {
            return keyboardState.IsKeyDown(key) && lastKeyboardState.IsKeyUp(key); //returns True wenn eine taste gedrückt wird welche im letzten frame ungedrückt war
        }

        public static bool KeyDown(Keys key)
        {
            return keyboardState.IsKeyDown(key); //returns True wenn eine taste gedrückt wird
        }

        #endregion




        #region GamePad Region

        public static bool ButtonReleased(Buttons button, PlayerIndex index)
        {
            return gamePadState[(int)index].IsButtonDown(button) && lastGamePadState[(int)index].IsButtonUp(button); //returns True wenn eine taste logelassen wird welche gedrückt war
        }

        public static bool ButtonPressed(Buttons button, PlayerIndex index)
        {
            return gamePadState[(int)index].IsButtonUp(button) && lastGamePadState[(int)index].IsButtonDown(button);    //returns True wenn eine taste gedrückt wird welche noch nicht gedrückt war
        }

        public static bool ButtonDown(Buttons button, PlayerIndex index)
        {
            return gamePadState[(int)index].IsButtonDown(button); //returns true wenn taste gedrückt wird
        }

        #endregion
    }
}
