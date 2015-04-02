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
    public class ShieldManager : SpriteManager
    {
        public ShieldManager(Game1 game1)
            : base(game1)
        {
            texture = game1.Content.Load<Texture2D>("Images/Other/Shield");
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Shield shield in spriteList)
                if (shield.alive)
                    shield.Update(gameTime);

                else
                {
                    spriteList.Remove(shield);
                    break;
                }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (Shield shield in spriteList)
                if (shield.alive)
                    shield.Draw(gameTime);

            base.Draw(gameTime);
        }

        public void SpawnShield(GamePlayer gamePlayer)
        {
            spriteList.Add(new Shield(game1)
            {
                alive = true,
                color = Color.White,
                delta = Vector2.Zero,
                effects = SpriteEffects.None,
                gamePlayer = gamePlayer,
                layerDepth = 0.0f,
                origin = new Vector2(texture.Width / 2 + 9, texture.Height / 2),
                position = gamePlayer.position,
                rotation = 0.0f,
                scale = 1.0f,
                sourceRectangle = null,
                texture = texture
            });
        }
    }
}
