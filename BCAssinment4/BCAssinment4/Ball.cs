/*Brian Chaves
 * November 28,2012
 * Assinment 4
 * Ping pong game
 * Ball class
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
    public class Ball : Microsoft.Xna.Framework.DrawableGameComponent
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
            set { speed = value; }
        }
        private Vector2 stage;

        public Vector2 Stage
        {
            get { return stage; }
            set { stage = value; }
        }
        private float minSpeed;

        public float MinSpeed
        {
            get { return minSpeed; }
            set
            {
                //will change maxSpeed if its smaller then minSpeed
                minSpeed = value;
                if (maxSpeed < value)
                {
                    maxSpeed = value;
                }
            }
        }
        private float maxSpeed;

        public float MaxSpeed
        {
            get { return maxSpeed; }
            set
            {
                //Will change minSpeed if its bigger then maxSpeed 
                maxSpeed = value;
                if (minSpeed > value)
                {
                    minSpeed = value;
                }
            }
        }
        private SoundEffect sndClick;

        public SoundEffect SndClick
        {
            get { return sndClick; }
            set { sndClick = value; }
        }
        private SoundEffect sndFail;

        public SoundEffect SndFail
        {
            get { return sndFail; }
            set { sndFail = value; }
        }
        private bool ballInPlay;

        public bool BallInPlay
        {
            //Get only, setting is forbidden
            get { return ballInPlay; }
        }
        private int intNumberOfPointsToWin;

        public int IntNumberOfPointsToWin
        {
            get { return intNumberOfPointsToWin; }
            set { intNumberOfPointsToWin = value; }
        }
        private SoundEffect sndGameOver;

        public SoundEffect SndGameOver
        {
            get { return sndGameOver; }
            set { sndGameOver = value; }
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="game">Game</param>
        /// <param name="spriteBatch">SpriteBatch</param>
        /// <param name="tex">texture</param>
        /// <param name="position">location of ball</param>
        /// <param name="speed">speed of ball</param>
        /// <param name="stage">stage size</param>
        /// <param name="minSpeed">minimum speed allowed</param>
        /// <param name="maxSpeed">maximum speed allowed</param>
        /// <param name="intNumberOfPointsToWin">Number of points required to win</param>
        /// <param name="sndClick">Sound the ball will make if it hits a wall</param>
        /// <param name="sndFail">Sound the ball will make if it goes out of bounds</param>
        /// <param name="sndGameOver">Sound that will be played when the game ends</param>
        public Ball(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 position,
            Vector2 speed,
            Vector2 stage,
            float minSpeed,
            float maxSpeed,
            int intNumberOfPointsToWin,
            SoundEffect sndClick = null,
            SoundEffect sndFail = null,
            SoundEffect sndGameOver = null)
            : base(game)
        {
            // TODO: Construct any child components here
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.speed = speed;
            this.stage = stage;
            this.minSpeed = minSpeed;
            this.maxSpeed = maxSpeed;
            this.sndClick = sndClick;
            this.sndFail = sndFail;
            this.sndGameOver = sndGameOver;
            ballInPlay = false;
            this.intNumberOfPointsToWin = intNumberOfPointsToWin;

            if (maxSpeed < minSpeed)
            {
                float temp = this.maxSpeed;
                this.maxSpeed = this.minSpeed;
                this.minSpeed = temp;
            }
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
            if (ballInPlay)
            {
                position += speed;
                //Random random = new Random();

                if (position.Y < 0)
                {
                    speed.Y = Math.Abs(speed.Y);
                    if (sndClick != null)
                    {
                        sndClick.Play();
                    }
                }

                if (position.Y > stage.Y - tex.Width)
                {
                    speed.Y = Math.Abs(speed.Y) * -1;
                    if (sndClick != null)
                    {
                        sndClick.Play();
                    }
                }

                if (position.X < 0 - tex.Width)
                {
                    BallOut(1);
                }

                if (position.X > stage.X)
                {
                    BallOut(2);
                }


            }
            else
            {
                KeyboardState ks = Keyboard.GetState();
                if (ks.IsKeyDown(Keys.Enter) && !PlayerScore.GameOver)
                {
                    Random random = new Random();

                    speed = new Vector2
                        (random.Next((int)MinSpeed, (int)MaxSpeed + 1),
                        random.Next((int)MinSpeed, (int)MaxSpeed + 1));
                    ballInPlay = true;

                    if (random.Next(0, 2) == 1)
                    {
                        speed.X *= -1;
                    }
                    if (random.Next(0, 2) == 1)
                    {
                        speed.Y *= -1;
                    }
                }
            }

            base.Update(gameTime);
        }
        /// <summary>
        /// Draws the ball
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        /// <summary>
        /// Gets the boundary of the ball rectangle
        /// </summary>
        /// <returns>rectangle sorce</returns>
        public Rectangle GetBounds()
        {
            Rectangle rect = new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
            return rect;
        }

        /// <summary>
        /// the meathod that is called when the ball goes out
        /// this will reset ball position and give award the score
        /// </summary>
        /// <param name="idOutOn">which player the ball goes out on</param>
        private void BallOut(int idOutOn)
        {
            position = new Vector2((stage.X - tex.Width) / 2, (stage.Y - tex.Height) / 2);
            ballInPlay = false;

            if (idOutOn == 1)
            {
                PlayerScore.Player2_Score++;
            }
            if (idOutOn == 2)
            {
                PlayerScore.Player1_Score++;
            }
            if (sndFail != null)
            {
                if ((PlayerScore.Player1_Score == intNumberOfPointsToWin ||
                    PlayerScore.Player2_Score == intNumberOfPointsToWin) && sndGameOver != null)
                {
                    sndGameOver.Play();
                }
                else
                {
                    sndFail.Play();
                }

            }
        }
    }
}
