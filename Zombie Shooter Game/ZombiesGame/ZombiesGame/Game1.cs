using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ZombiesGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager graphics;
        public Random random;
        public SpriteBatch spriteBatch;
        public SpriteFont arial;
        public Texture2D Load, Pause, gameOver, directions;
        public Timer timer;
        public Vector2 resolution;
        public Vector2 positionOfImage;

        public BackgroundManager backgroundManager;
        public BulletManager bulletManager;
        public DigitalGageManager digitalGageManager;
        public GamePlayerManager gamePlayerManager;
        public PowerUpManager powerUpManager;
        public ShieldManager shieldManager;
        public ZombieManager zombieManager;

        public GamePadState currentGamePadState, previousGamePadState;
        public KeyboardState currentKeyboardState, previousKeyboardState;

        public float scoreLimit;
        public int gameState;  // integer value representing mode of play
        public int level;

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
            resolution = new Vector2(800, 600);

            graphics.PreferredBackBufferWidth = (int)resolution.X;
            graphics.PreferredBackBufferHeight = (int)resolution.Y;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();

            random = new Random(DateTime.Now.Millisecond);

            positionOfImage = new Vector2(0, 0);

            level = 1;
            scoreLimit = 500;

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

            arial = Content.Load<SpriteFont>("Fonts/Arial");

            backgroundManager = new BackgroundManager(this);
            bulletManager = new BulletManager(this);
            digitalGageManager = new DigitalGageManager(this);
            gamePlayerManager = new GamePlayerManager(this);
            powerUpManager = new PowerUpManager(this);
            shieldManager = new ShieldManager(this);
            zombieManager = new ZombieManager(this);

            // load Screen
            gameState = 0;

            Load = Content.Load<Texture2D>("Images/GameStates/Loading");
            Pause = Content.Load<Texture2D>("Images/GameStates/Pausing");
            gameOver = Content.Load<Texture2D>("Images/GameStates/Game Over");
            directions = Content.Load<Texture2D>("Images/GameStates/Directions");

            // Create a timer with a ten second interval. This is used to demonistrate the load screen
            // normally this would toggle off after the load peocess
            timer = new System.Timers.Timer(10000);

            // Hook up the Elapsed event for the timer.
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

            // don't forget to turn it on;
            timer.Enabled = true;
        }

        /// <summary>
        /// Timer time out event handler. It's only use is to shift the gameState from the Load Screen
        /// into the directions screen
        /// </summary>
        /// <param name="source">the object that caused this event in the first place</param>
        /// <param name="e">any extra data that might be passed into an event handler</param>
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            // you only want to flow into the Direction screen from the loading gameState
            if (gameState == 0)
                gameState = 4;

            // release the resourse used by this timer
            timer.Close();
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
            foreach (GamePlayer gamePlayer in gamePlayerManager.spriteList)
            {
                currentGamePadState = GamePad.GetState(gamePlayer.playerIndex);
                currentKeyboardState = Keyboard.GetState();

                // look for user to switch game states
                #region Game State Switcher
                if (currentGamePadState.Buttons.B == ButtonState.Released && previousGamePadState.Buttons.B == ButtonState.Pressed ||
                    currentKeyboardState.IsKeyUp(Keys.B) && previousKeyboardState.IsKeyDown(Keys.B))
                {
                    gameState = 0;
                }

                // toggle between Pause & Play
                //if(currentKeyboardState.IsKeyUp(Keys.P) && previousKeyboardState.IsKeyDown(Keys.P))
                if (currentGamePadState.Buttons.Start == ButtonState.Released && previousGamePadState.Buttons.Start == ButtonState.Pressed ||
                    currentKeyboardState.IsKeyUp(Keys.Space) && previousKeyboardState.IsKeyDown(Keys.Space))
                {   // NOTE: this only works if play and pause are consecutive
                    gameState++;

                    if (gameState > 2)
                    {
                        Initialize();
                        gameState = 1;
                    }
                }


                // changes state to Credits
                if (currentGamePadState.Buttons.Back == ButtonState.Released && previousGamePadState.Buttons.Back == ButtonState.Pressed ||
                    currentKeyboardState.IsKeyUp(Keys.Escape) && previousKeyboardState.IsKeyDown(Keys.Escape))
                {
                    gameState = 3;
                }


                // directions 
                if (currentGamePadState.Buttons.A == ButtonState.Released && previousGamePadState.Buttons.A == ButtonState.Pressed ||
                    currentKeyboardState.IsKeyUp(Keys.D) && previousKeyboardState.IsKeyDown(Keys.D))
                {
                    gameState = 4;
                }

                #endregion

                previousGamePadState = currentGamePadState;
                previousKeyboardState = currentKeyboardState;
            }

            if (gameState == 1)
            {
                backgroundManager.Update(gameTime);
                bulletManager.Update(gameTime);
                digitalGageManager.Update(gameTime);
                gamePlayerManager.Update(gameTime);
                powerUpManager.Update(gameTime);
                shieldManager.Update(gameTime);
                zombieManager.Update(gameTime);

                foreach (GamePlayer gamePlayer in gamePlayerManager.spriteList)
                {
                    if (gamePlayer.score > scoreLimit)
                    {
                        level++;

                        scoreLimit += 500;
                    }
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            // only draw whats appropriate for the current gameState
            switch (gameState)
            {
                #region
                // Load State
                case 0:
                    spriteBatch.Draw(Load,
                        new Vector2(resolution.X / 2, resolution.Y / 2),
                        null,
                        Color.White,
                        0.0f,
                        new Vector2(Load.Width / 2, Load.Height / 2),
                        1.0f,
                        SpriteEffects.None,
                        1.0f);
                    break;

                // Play State
                case 1:
                    backgroundManager.Draw(gameTime);
                    bulletManager.Draw(gameTime);
                    digitalGageManager.Draw(gameTime);
                    gamePlayerManager.Draw(gameTime);
                    powerUpManager.Draw(gameTime);
                    shieldManager.Draw(gameTime);
                    zombieManager.Draw(gameTime);
                    spriteBatch.DrawString(arial, "Level: " + level, new Vector2(20, 540), Color.White);
                    spriteBatch.DrawString(arial, "Zombies: " + zombieManager.spriteList.Count, new Vector2(20, 560), Color.White);
                    break;

                // Pause State
                case 2:
                    spriteBatch.Draw(Pause,
                        new Vector2(resolution.X / 2, resolution.Y / 2),
                        null,
                        Color.White,
                        0.0f,
                        new Vector2(Pause.Width / 2, Pause.Height / 2),
                        1.0f,
                        SpriteEffects.None,
                        1.0f);
                    break;

                // Credits State
                case 3:
                    spriteBatch.Draw(gameOver,
                        new Vector2(resolution.X / 2, resolution.Y / 2),
                        null,
                        Color.White,
                        0.0f,
                        new Vector2(gameOver.Width / 2, gameOver.Height / 2),
                        1.0f,
                        SpriteEffects.None,
                        1.0f);
                    break;

                // directions
                case 4:
                    spriteBatch.Draw(directions,
                        new Vector2(resolution.X / 2, resolution.Y / 2),
                        null,
                        Color.White,
                        0.0f,
                        new Vector2(directions.Width / 2, directions.Height / 2),
                        1.0f,
                        SpriteEffects.None,
                        1.0f);
                    break;

                #endregion
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
