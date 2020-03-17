/*Brian Chaves
 * November 28,2012
 * Assinment 4
 * Ping pong game
 * Bat class
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
    public class Bat : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private SpriteBatch spriteBatch;

        public SpriteBatch SpriteBatch
        {
            get { return spriteBatch; }
            set { spriteBatch = value; }
        }
        private Texture2D tex;

        public Texture2D Tex
        {
            get { return tex; }
            set { tex = value; }
        }
        private Vector2 position;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        private Vector2 speed;

        public Vector2 Speed
        {
            get { return speed; }
            set
            {
                //This code is to prevent negitive values to be enterd
                speed.Y= Math.Abs(speed.Y);
                speed = value;
            }
        }
        private Vector2 stage;

        public Vector2 Stage
        {
            get { return stage; }
            set { stage = value; }
        }
        private Keys upKey;

        public Keys UpKey
        {
            get { return upKey; }
            set { upKey = value; }
        }
        private Keys downKey;

        public Keys DownKey
        {
            get { return downKey; }
            set { downKey = value; }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="game">game</param>
        /// <param name="spriteBatch">spriteBatch</param>
        /// <param name="tex">image texure</param>
        /// <param name="position">location of the bat</param>
        /// <param name="speed">speed of the bat</param>
        /// <param name="stage">stage size</param>
        /// <param name="upKey">the key the move the bat up</param>
        /// <param name="downKey">the key that moves the bat down</param>
        public Bat(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 position,
            Vector2 speed,
            Vector2 stage,
            Keys upKey,
            Keys downKey)
            : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.speed = speed;
            this.stage = stage;
            this.upKey = upKey;
            this.downKey = downKey;

            this.speed.Y = Math.Abs(speed.Y);
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
            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(upKey))
            {
                position.Y -= speed.Y;

                if (position.Y < 0)
                {
                    position.Y = 0;
                }

            }

            if (ks.IsKeyDown(downKey))
            {
                position.Y += speed.Y;

                if (position.Y + tex.Height > stage.Y)
                {
                    position.Y = stage.Y - tex.Height;
                }
            }



            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public Rectangle GetBounds()
        {
            Rectangle rect = new Rectangle((int)position.X, (int)position.Y, (int)tex.Width, (int)tex.Height);
            return rect;
        }
    }
}
