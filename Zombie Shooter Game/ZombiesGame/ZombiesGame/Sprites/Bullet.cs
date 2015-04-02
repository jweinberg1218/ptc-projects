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
    class Bullet : Sprite
    {
        public GamePlayer gamePlayer;

        public int damage;

        public Bullet(Game1 game1)
            : base(game1) { }

        public override void Update(GameTime gameTime)
        {
            foreach (Zombie zombie in game1.zombieManager.spriteList)
            {
                if (collisionRectangle.Intersects(zombie.collisionRectangle))
                {
                    alive = false;
                    return;
                }
            }

            if (position.X < 0 || position.X > 800 || position.Y < 0 || position.Y > 600)
            {
                alive = false;
                return;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {


            base.Draw(gameTime);
        }
    }
}
