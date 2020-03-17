/*Brian Chaves
 * November 28,2012
 * Assinment 4
 * Ping pong game
 * Collision Manager class
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
    public class CollisionManager : Microsoft.Xna.Framework.GameComponent
    {

        private Ball ball;

        public Ball Ball
        {
            get { return ball; }
            set { ball = value; }
        }
        private Bat bat;

        public Bat Bat
        {
            get { return bat; }
            set { bat = value; }
        }
        private int side;

        public int Side
        {
            get { return side; }
            set { side = value; }
        }
        const int idLeftSide = 1;
        const int idRightSide = 2;
        private SoundEffect sndDing;
        private int delay;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="game">Game</param>
        /// <param name="ball">SpriteBatch</param>
        /// <param name="bat">Bat class</param>
        /// <param name="side">Left or right side in integer(1 is left,2 is right)</param>
        /// <param name="sndDing">Ding sound effect</param>
        public CollisionManager(Game game,
            Ball ball,
            Bat bat,
            int side,
            SoundEffect sndDing = null)
            : base(game)
        {
            this.ball = ball;
            this.bat = bat;
            this.side = side;
            this.sndDing = sndDing;
            delay = 0;
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
            Rectangle ballRect = ball.GetBounds();
            Rectangle batRect = bat.GetBounds();

            //Random random = new Random();
            if (delay > 0)
            {
                delay--;
            }

            if (ballRect.Intersects(batRect) && delay<=0)
            {
                ball.Speed = new Vector2(ball.Speed.X*-1, ball.Speed.Y);
                if (sndDing != null)
                {
                    sndDing.Play();
                }
                delay = 30;
            }
            base.Update(gameTime);
        }
    }
}
