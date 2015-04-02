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
    class DigitalGage : Sprite
    {
        public Rectangle fillerRectangle;
        public Rectangle gageRectangle;
        public Texture2D bezel;
        public Texture2D[] filler;
        public Zombie zombie;

        public float levelOfGage;
        public int colorIndex;

        public DigitalGage(Game1 game1)
            : base(game1) { }

        public override void Update(GameTime gameTime)
        {
            // test the functionality of the gage
            levelOfGage = (1.0f / 6.0f) * zombie.health;

            // deferming the fill color of the gage. I know ELSE IF... but is is quite efficient here.
            if (levelOfGage > .7f)
                colorIndex = 0;
            else
                if (levelOfGage > .35)
                    colorIndex = 1;
                else
                    colorIndex = 2;

            // adjust the size of the gage fill area  percentage (i.e. levelOfGage 0.0 -> 1.0f)
            fillerRectangle.Width = (int)(filler[colorIndex].Width * levelOfGage);

            position.Y = zombie.position.Y - 35;
            position.X = zombie.position.X;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            sourceRectangle = fillerRectangle;
            texture = filler[colorIndex];
            origin = new Vector2(texture.Width / 2, texture.Height / 2);

            base.Draw(gameTime);

            sourceRectangle = gageRectangle;
            texture = bezel;
            origin = new Vector2(texture.Width / 2, texture.Height / 2);

            base.Draw(gameTime);
        }
    }
}
