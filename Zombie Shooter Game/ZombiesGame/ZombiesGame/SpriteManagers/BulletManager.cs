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
    public class BulletManager : SpriteManager
    {
        public Color color;

        public bool bulletUpgraded;
        public float scale;
        public float timer;
        public int bulletDelay;
        public int damage;

        public BulletManager(Game1 game1)
            : base(game1)
        {
            bulletDelay = 100;
            color = Color.Black;
            damage = 1;
            scale = 0.5f;
            texture = game1.Content.Load<Texture2D>("Images/Other/Bullet");
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GamePlayer gamePlayer in game1.gamePlayerManager.spriteList)
            {
                foreach (PowerUp powerUp in game1.powerUpManager.spriteList)
                    if (gamePlayer == powerUp.gamePlayer)
                    {
                        switch (powerUp.powerUp)
                        {
                            case 0:
                                gamePlayer.bulletCount = 100;
                                gamePlayer.bulletCountMax = 100;
                                bulletDelay = 150;
                                color = Color.Red;
                                damage = 2;
                                scale = 1.0f;
                                break;

                            case 1:
                                gamePlayer.bulletCount = 80;
                                gamePlayer.bulletCountMax = 80;
                                bulletDelay = 200;
                                color = Color.Green;
                                damage = 3;
                                scale = 2.0f;
                                break;

                            case 2:
                                gamePlayer.bulletCount = 60;
                                gamePlayer.bulletCountMax = 60;
                                bulletDelay = 250;
                                color = Color.Blue;
                                damage = 4;
                                scale = 3.5f;
                                break;

                            case 3:
                                gamePlayer.bulletCount = 40;
                                gamePlayer.bulletCountMax = 40;
                                bulletDelay = 300;
                                color = Color.Yellow;
                                damage = 5;
                                scale = 5.5f;
                                break;

                            case 4:
                                gamePlayer.bulletCount = 20;
                                gamePlayer.bulletCountMax = 20;
                                bulletDelay = 350;
                                color = Color.Orange;
                                damage = 6;
                                scale = 8.0f;
                                break;
                        }

                        bulletUpgraded = true;
                    }

                if (bulletUpgraded)
                {
                    timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                    if (timer > 10.0f || gamePlayer.alive == false)
                    {
                        gamePlayer.bulletCount = 1200;
                        gamePlayer.bulletCountMax = 1200;
                        bulletDelay = 100;
                        color = Color.Black;
                        damage = 1;
                        scale = 0.5f;
                        bulletUpgraded = false;
                        timer = 0.0f;
                    }
                }

                if (gamePlayer.gamePadState.IsButtonDown(Buttons.RightTrigger)
                    && gameTime.TotalGameTime.Milliseconds % bulletDelay == 0
                    && gamePlayer.bulletCount > 0)
                {
                    spriteList.Add(new Bullet(game1)
                    {
                        alive = true,
                        color = color,
                        damage = damage,
                        delta = new Vector2((float)Math.Sin(gamePlayer.rotation) * 10.0f, -((float)Math.Cos(gamePlayer.rotation) * 10.0f)),
                        effects = SpriteEffects.None,
                        gamePlayer = gamePlayer,
                        layerDepth = 0.0f,
                        origin = new Vector2(texture.Width / 2, texture.Height / 2),
                        position = new Vector2(gamePlayer.position.X, gamePlayer.position.Y),
                        rotation = 0.0f,
                        scale = scale,
                        sourceRectangle = null,
                        texture = texture
                    });

                    gamePlayer.bulletCount--;
                }
            }

            foreach (Bullet bullet in spriteList)
                if (bullet.alive)
                    bullet.Update(gameTime);

                else
                {
                    spriteList.Remove(bullet);
                    break;
                }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (Bullet bullet in spriteList)
                if (bullet.alive)
                    bullet.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}
