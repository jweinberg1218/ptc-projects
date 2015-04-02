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
    public class SpriteManager
    {
        public Game1 game1;

        public List<Sprite> spriteList;
        public Texture2D texture;

        public SpriteManager(Game1 game1)
        {
            this.game1 = game1;

            spriteList = new List<Sprite>();
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(GameTime gameTime)
        {
        }
    }
}
