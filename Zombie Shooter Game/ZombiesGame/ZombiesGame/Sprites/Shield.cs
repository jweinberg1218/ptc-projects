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
    class Shield : Sprite
    {
        public GamePlayer gamePlayer;

        public float timer;

        public Shield(Game1 game1)
            : base(game1)
        {
            timer = 0.0f;
        }

        public override void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer > 10.0f)
            {
                gamePlayer.invincible = false;
                alive = false;
                timer = 0.0f;
                return;
            }

            position = gamePlayer.position;

            foreach (Zombie zombie in game1.zombieManager.spriteList)
            {
                if (collisionRectangle.Intersects(zombie.collisionRectangle))
                {
                    gamePlayer.score += zombie.points;
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
