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
    class PowerUp : Sprite
    {
        public GamePlayer gamePlayer;

        public float timer;
        public int powerUp;

        public PowerUp(Game1 game1)
            : base(game1) { }

        public override void Update(GameTime gameTime)
        {
            foreach (GamePlayer gamePlayer in game1.gamePlayerManager.spriteList)
                if (collisionRectangle.Intersects(gamePlayer.collisionRectangle))
                {
                    this.gamePlayer = gamePlayer;
                    alive = false;
                    return;
                }

            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer > 10.0f)
            {
                alive = false;
                timer = 0.0f;
                return;
            }

            delta = Vector2.Zero;

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
