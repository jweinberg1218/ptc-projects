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
    class Background : Sprite
    {
        public Rectangle backgroundSourceRectangle;
        public Rectangle tempBackgroundSourceRectangle;

        public Vector2 backgroundDelta;

        public int currentLevel, previousLevel;

        public Background(Game1 game1)
            : base(game1)
        {
            currentLevel = game1.level;
            previousLevel = game1.level;
        }

        public override void Update(GameTime gameTime)
        {
            currentLevel = game1.level;

            if (currentLevel > previousLevel)
            {
                alive = false;
                return;
            }

            previousLevel = currentLevel;

            if (game1.gamePlayerManager.spriteList.Count == 1)
            {

                // this operates like a blind man walking. The blind mans walking stick is 'TemporyBackgroundSourceRectangle' and thats
                // what I advance for X and later Y. As long as the new X  and later the new Y is within the boundries of the background 
                // texture, I permit scrolling on the axis. Also note that if I scroll the background, I also scroll the piclups.
                tempBackgroundSourceRectangle = backgroundSourceRectangle;

                foreach (GamePlayer gamePlayer in game1.gamePlayerManager.spriteList)
                    backgroundDelta = gamePlayer.delta;

                backgroundSourceRectangle.X += (int)backgroundDelta.X;
                backgroundSourceRectangle.Y += (int)backgroundDelta.Y;

                backgroundSourceRectangle.X = (int)MathHelper.Clamp(backgroundSourceRectangle.X, 0, texture.Width / 2);
                backgroundSourceRectangle.Y = (int)MathHelper.Clamp(backgroundSourceRectangle.Y, 0, texture.Height / 2);

                sourceRectangle = backgroundSourceRectangle;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
