/*Brian Chaves
 * November 28,2012
 * Assinment 4
 * Ping pong game
 * Font class
 */
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


namespace BCAssinment4
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Font : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private SpriteBatch spriteBatch;

        public SpriteBatch SpriteBatch
        {
            get { return spriteBatch; }
            set { spriteBatch = value; }
        }
        private SpriteFont font;

        public SpriteFont Font1
        {
            get { return font; }
            set { font = value; }
        }
        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        private Vector2 position;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        private Color messageColor;

        public Color MessageColor
        {
            get { return messageColor; }
            set { messageColor = value; }
        }

        private bool hidden;

        public bool Hidden
        {
            get { return hidden; }
            set { hidden = value; }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="game">Game</param>
        /// <param name="spriteBatch">spriteBatch</param>
        /// <param name="font">Font type and style</param>
        /// <param name="message">Message to display</param>
        /// <param name="position">Location</param>
        /// <param name="messageColor">color of the message</param>
        /// <param name="hidden">is the message hidden or visible</param>
        public Font(Game game,
            SpriteBatch spriteBatch,
            SpriteFont font,
            string message,
            Vector2 position,
            Color messageColor,
            bool hidden = false)
            : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.font = font;
            this.message = message;
            this.position = position;
            this.messageColor = messageColor;
            this.hidden = hidden;
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (!hidden)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(font, message, position, messageColor);
                spriteBatch.End();
            }
            base.Draw(gameTime);
        }
    }
}
