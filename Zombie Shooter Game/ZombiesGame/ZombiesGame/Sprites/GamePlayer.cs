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

namespace ZombiesGame
{
    public class GamePlayer : Sprite
    {
        public GamePadState gamePadState;
        public KeyboardState keyboardState;
        public PlayerIndex playerIndex;

        public bool deltaIncreased;
        public bool initialShield;
        public bool invincible;
        public float bulletCount;
        public float bulletCountMax;
        public float deltaMultiplier;
        public float lives;
        public float rotationMultiplier;
        public float score;
        public float timer;

        public GamePlayer(Game1 game1)
            : base(game1)
        {
            deltaIncreased = false;
            initialShield = true;
            invincible = true;

            bulletCount = 1200;
            bulletCountMax = 1200;
            lives = 3;
            score = 0;
        }

        public override void Update(GameTime gameTime)
        {
            if (lives <= 0)
            {
                game1.gameState = 3;
                return;
            }

            foreach (Zombie zombie in game1.zombieManager.spriteList)
            {
                if (collisionRectangle.Intersects(zombie.collisionRectangle) && invincible == false)
                {
                    alive = false;
                    return;
                }
            }

            foreach (PowerUp powerUp in game1.powerUpManager.spriteList)
                if (this == powerUp.gamePlayer)
                    switch (powerUp.powerUp)
                    {
                        case 5:
                            deltaMultiplier = 4.0f;
                            deltaIncreased = true;
                            break;

                        case 6:
                            if (lives < 9)
                                lives += 1.0f;
                            else
                                score += 100;

                            break;
                        
                        case 7:
                            game1.shieldManager.SpawnShield(this);
                            invincible = true;
                            break;

                    }

            if (deltaIncreased)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (timer > 10.0f)
                {
                    deltaMultiplier = 2.0f;
                    deltaIncreased = false;
                    timer = 0.0f;
                }
            }

            if (initialShield)
            {
                game1.shieldManager.SpawnShield(this);
                initialShield = false;
            }

            gamePadState = GamePad.GetState(playerIndex, GamePadDeadZone.Circular);
            keyboardState = Keyboard.GetState();

            if (gamePadState.ThumbSticks.Right != Vector2.Zero)
                rotation = (float)Math.Atan2(gamePadState.ThumbSticks.Right.X, gamePadState.ThumbSticks.Right.Y);

            if (gamePadState.ThumbSticks.Left != Vector2.Zero)
                delta = new Vector2(gamePadState.ThumbSticks.Left.X * deltaMultiplier,
                    -gamePadState.ThumbSticks.Left.Y * deltaMultiplier);

            else
                delta = Vector2.Zero;

            position.X = (int)MathHelper.Clamp(position.X, 0, game1.resolution.X);
            position.Y = (int)MathHelper.Clamp(position.Y, 0, game1.resolution.Y);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            switch (playerIndex)
            {
                case PlayerIndex.One:
                    game1.spriteBatch.DrawString(game1.arial, "Score: " + score, new Vector2(20, 20), Color.White);
                    game1.spriteBatch.DrawString(game1.arial, "Lives: " + lives, new Vector2(20, 40), Color.White);
                    game1.spriteBatch.DrawString(game1.arial, "Bullets: " + bulletCount + " / " + bulletCountMax, new Vector2(20, 60), Color.White);
                    break;

                case PlayerIndex.Two:
                    game1.spriteBatch.DrawString(game1.arial, "Score: " + score, new Vector2(220, 20), Color.White);
                    game1.spriteBatch.DrawString(game1.arial, "Lives: " + lives, new Vector2(220, 40), Color.White);
                    game1.spriteBatch.DrawString(game1.arial, "Bullets: " + bulletCount + " / " + bulletCountMax, new Vector2(220, 60), Color.White);
                    break;

                case PlayerIndex.Three:
                    game1.spriteBatch.DrawString(game1.arial, "Score: " + score, new Vector2(420, 20), Color.White);
                    game1.spriteBatch.DrawString(game1.arial, "Lives: " + lives, new Vector2(420, 40), Color.White);
                    game1.spriteBatch.DrawString(game1.arial, "Bullets: " + bulletCount + " / " + bulletCountMax, new Vector2(420, 60), Color.White);
                    break;

                case PlayerIndex.Four:
                    game1.spriteBatch.DrawString(game1.arial, "Score: " + score, new Vector2(620, 20), Color.White);
                    game1.spriteBatch.DrawString(game1.arial, "Lives: " + lives, new Vector2(620, 40), Color.White);
                    game1.spriteBatch.DrawString(game1.arial, "Bullets: " + bulletCount + " / " + bulletCountMax, new Vector2(620, 60), Color.White);
                    break;
            }

            base.Draw(gameTime);
        }
    }
}
