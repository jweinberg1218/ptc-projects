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
    public class Sprite
    {
        public Game1 game1;

        public Color color;
        public Rectangle collisionRectangle;
        public Rectangle? sourceRectangle;
        public SpriteEffects effects;
        public Texture2D texture;
        public Vector2 delta;
        public Vector2 origin;
        public Vector2 position;

        public bool alive;
        public float layerDepth;
        public float rotation;
        public float scale;

        public Sprite(Game1 game1)
        {
            this.game1 = game1;
        }

        public virtual void Update(GameTime gameTime)
        {
            position += delta;
        }

        public virtual void Draw(GameTime gameTime)
        {
            game1.spriteBatch.Draw(texture,
                position,
                sourceRectangle,
                color,
                rotation,
                origin,
                scale,
                effects,
                layerDepth);

            collisionRectangle = new Rectangle((int)(position.X - ((texture.Width * scale) / 4)), (int)(position.Y - ((texture.Height * scale) / 4)), (int)((texture.Width * scale) / 2), (int)((texture.Height * scale) / 2));
        }
    }
}
