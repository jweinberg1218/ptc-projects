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
    public class PowerUpManager : SpriteManager
    {
        public Color color;
        public Texture2D firstAid, lightningBolt, star, shield;

        public int powerUp;

        public PowerUpManager(Game1 game1)
            : base(game1)
        {
            firstAid = game1.Content.Load<Texture2D>("Images/PowerUps/FirstAid");
            lightningBolt = game1.Content.Load<Texture2D>("Images/PowerUps/LightningBolt");
            star = game1.Content.Load<Texture2D>("Images/PowerUps/Star");
            shield = game1.Content.Load<Texture2D>("Images/PowerUps/Shield");
        }

        public override void Update(GameTime gameTime)
        {
            foreach (PowerUp powerUp in spriteList)
                if (powerUp.alive)
                    powerUp.Update(gameTime);

                else
                {
                    spriteList.Remove(powerUp);
                    break;
                }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (PowerUp powerUp in spriteList)
                if (powerUp.alive)
                    powerUp.Draw(gameTime);

            base.Draw(gameTime);
        }

        public void SpawnPowerUp(Vector2 position)
        {
            powerUp = game1.random.Next(0, 8);

            switch (powerUp)
            {
                case 0:
                    color = Color.Red;
                    texture = star;
                    break;

                case 1:
                    color = Color.Green;
                    texture = star;
                    break;

                case 2:
                    color = Color.Blue;
                    texture = star;
                    break;

                case 3:
                    color = Color.Yellow;
                    texture = star;
                    break;

                case 4:
                    color = Color.Orange;
                    texture = star;
                    break;

                case 5:
                    color = Color.White;
                    texture = lightningBolt;
                    break;

                case 6:
                    color = Color.White;
                    texture = firstAid;
                    break;

                case 7:
                    color = Color.White;
                    texture = shield;
                    break;
            }

            spriteList.Add(new PowerUp(game1)
            {
                alive = true,
                color = color,
                delta = Vector2.Zero,
                effects = SpriteEffects.None,
                layerDepth = 0.0f,
                origin = new Vector2(texture.Width / 2, texture.Height / 2),
                position = position,
                powerUp = powerUp,
                rotation = 0.0f,
                scale = 0.1f,
                sourceRectangle = null,
                texture = texture
            });
        }
    }
}
