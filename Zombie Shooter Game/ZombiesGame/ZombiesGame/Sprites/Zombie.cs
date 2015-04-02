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
    public class Zombie : Sprite
    {
        public GamePlayer gamePlayer;

        public float deltaMultiplier;
        public int health;
        public int points;

        public Zombie(Game1 game1)
            : base(game1)
        {
            game1.digitalGageManager.SpawnDigitalGage(this);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Bullet bullet in game1.bulletManager.spriteList)
                if (collisionRectangle.Intersects(bullet.collisionRectangle))
                {
                    health -= bullet.damage;

                    if (health <= 0)
                    {
                        alive = false;
                        bullet.gamePlayer.score += points;
                        return;
                    }
                }

            foreach (Shield shield in game1.shieldManager.spriteList)
                if (collisionRectangle.Intersects(shield.collisionRectangle))
                {
                    alive = false;
                    shield.gamePlayer.score += points;
                    return;
                }

            foreach (GamePlayer gamePlayer in game1.gamePlayerManager.spriteList)
                if (this.gamePlayer == null)
                    this.gamePlayer = gamePlayer;

                else if (Math.Abs(position.X - gamePlayer.position.X) + Math.Abs(position.Y - gamePlayer.position.Y) < Math.Abs(position.X - this.gamePlayer.position.X) + Math.Abs(position.Y - this.gamePlayer.position.Y))
                    this.gamePlayer = gamePlayer;

            rotation = (float)Math.Atan2(this.gamePlayer.position.X - position.X, -(this.gamePlayer.position.Y - position.Y));

            delta = new Vector2((float)Math.Sin(rotation) * deltaMultiplier, -(float)Math.Cos(rotation) * deltaMultiplier);

            foreach (Background background in game1.backgroundManager.spriteList)
            {
                if (background.backgroundSourceRectangle.X > 0 &&
                    background.backgroundSourceRectangle.X < background.texture.Width / 2 &&
                    background.backgroundSourceRectangle.Y > 0 &&
                    background.backgroundSourceRectangle.Y < background.texture.Height / 2)
                {
                    delta -= background.backgroundDelta;
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
