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
    public class DigitalGageManager : SpriteManager
    {
        public Texture2D bezel;
        public Texture2D[] filler;

        public DigitalGageManager(Game1 game1)
            : base(game1)
        {
            bezel = game1.Content.Load<Texture2D>("Images/DigitalGage/Bezel");

            filler = new Texture2D[3];

            filler[0] = game1.Content.Load<Texture2D>("Images/DigitalGage/greenFiller");
            filler[1] = game1.Content.Load<Texture2D>("Images/DigitalGage/yellowFiller");
            filler[2] = game1.Content.Load<Texture2D>("Images/DigitalGage/redFiller");
        }

        public override void Update(GameTime gameTime)
        {
            foreach (DigitalGage digitalGage in spriteList)
                if (digitalGage.alive)
                    digitalGage.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (DigitalGage digitalGage in spriteList)
                if (digitalGage.alive)
                    digitalGage.Draw(gameTime);

            base.Draw(gameTime);
        }

        public void SpawnDigitalGage(Zombie zombie)
        {
            spriteList.Add(new DigitalGage(game1)
            {
                alive = true,
                bezel = bezel,
                color = Color.White,
                colorIndex = 0,
                delta = Vector2.Zero,
                effects = SpriteEffects.None,
                filler = filler,
                fillerRectangle = new Rectangle((int)zombie.position.X, (int)zombie.position.Y, bezel.Width, bezel.Height),
                gageRectangle = new Rectangle((int)zombie.position.X, (int)zombie.position.Y, bezel.Width, bezel.Height),
                layerDepth = 0.0f,
                levelOfGage = 1.0f,
                origin = Vector2.Zero,
                position = zombie.position,
                rotation = 0.0f,
                scale = 0.5f,
                sourceRectangle = null,
                zombie = zombie
            });
        }
    }
}
