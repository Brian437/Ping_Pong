/*Brian Chaves
 * November 28,2012
 * Assinment 4
 * Ping pong game
 * Main Game class
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
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Bat leftBat;
        Bat rightBat;
        Ball ball;
        CollisionManager leftCM;
        CollisionManager rightCM;
        const int idLeftSide = 1;
        const int idRightSide = 2;
        SoundEffect sndClick;
        SoundEffect sndDing;
        SoundEffect sndFail;
        SoundEffect sndGameOver;
        Font player1_Status;
        Font player2_Status;
        SpriteFont font;
        Font pressEnterMessage;
        Font pressSpaceBarMessage;
        const int int_NUMBER_OF_POINTS_TO_WIN = 2;
        Texture2D batTex;
        Vector2 stage;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            batTex = Content.Load<Texture2D>("image/Sideways Bat");
            stage = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            sndClick = Content.Load<SoundEffect>("sound/click");
            sndDing = Content.Load<SoundEffect>("sound/ding");
            sndFail = Content.Load<SoundEffect>("sound/fail");
            sndGameOver = Content.Load<SoundEffect>("sound/gameOver");

            leftBat = new Bat(this, spriteBatch, batTex,
                new Vector2(0, (stage.Y - batTex.Height) / 2),
                new Vector2(0, 5),
                stage, Keys.A, Keys.Z);


            rightBat = new Bat(this, spriteBatch, batTex,
                new Vector2(stage.X - batTex.Width, (stage.Y - batTex.Height) / 2),
                new Vector2(0, -5),
                stage, Keys.Up, Keys.Down);


            Texture2D ballTex = Content.Load<Texture2D>("image/ball");
            ball = new Ball(this, spriteBatch, ballTex,
                new Vector2((stage.X - ballTex.Width) / 2, (stage.Y - ballTex.Height) / 2),
                new Vector2(5, 5), stage, 3, 9,int_NUMBER_OF_POINTS_TO_WIN, sndClick,sndFail,sndGameOver);


            leftCM = new CollisionManager(this, ball, leftBat, idLeftSide, sndDing);
            rightCM = new CollisionManager(this, ball, rightBat, idRightSide, sndDing);


            font = Content.Load<SpriteFont>("font/font");
            Color messageColor = Color.Black;

            player1_Status = new Font(this, spriteBatch, font, "Player 1",
                new Vector2(50, 10), messageColor);

            player2_Status = new Font(this, spriteBatch, font, "Player 2",
                new Vector2(550, 10), messageColor);

            pressEnterMessage=new Font(this,spriteBatch,font,"Press Enter to start",
                new Vector2(300,300),messageColor);

            pressSpaceBarMessage = new Font(this, spriteBatch, font, "GAME OVER! Press Space bar to start a new game",
                new Vector2(200, 300), messageColor, true);

            Components.Add(player1_Status);
            Components.Add(player2_Status);
            Components.Add(pressEnterMessage);
            Components.Add(pressSpaceBarMessage);
            Components.Add(ball);
            Components.Add(leftBat);
            Components.Add(rightBat);
            Components.Add(leftCM);
            Components.Add(rightCM);
            PlayerScore.GameInPlay = true;

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            player1_Status.Message = "Player1 Score: " + PlayerScore.Player1_Score.ToString();
            player2_Status.Message = "Player2 Score: " + PlayerScore.Player2_Score.ToString();

            if (PlayerScore.Player1_Score >= int_NUMBER_OF_POINTS_TO_WIN ||
                PlayerScore.Player2_Score >= int_NUMBER_OF_POINTS_TO_WIN)
            {
                PlayerScore.GameOver = true;
            }
            else
            {
                PlayerScore.GameOver = false;
            }

            pressSpaceBarMessage.Hidden = !PlayerScore.GameOver;
            pressEnterMessage.Hidden = ball.BallInPlay || PlayerScore.GameOver;

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            if (ks.IsKeyDown(Keys.Space) && PlayerScore.GameOver)
            {
                leftBat.Position = new Vector2(0, (stage.Y - batTex.Height) / 2);
                rightBat.Position = new Vector2(stage.X - batTex.Width, (stage.Y - batTex.Height) / 2);
                PlayerScore.ResetScore();
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
