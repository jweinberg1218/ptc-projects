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
    public class BackgroundManager : SpriteManager
    {
        public Rectangle backgroundSourceRectangle;
        public Texture2D background1, background2, background3, background4, background5, background6, background7, background8;

        public int backgroundIndex;
        public int previousLevel;

        public BackgroundManager(Game1 game1)
            : base(game1)
        {
            background1 = game1.Content.Load<Texture2D>("Images/Backgrounds/Background1");
            background2 = game1.Content.Load<Texture2D>("Images/Backgrounds/Background2");
            background3 = game1.Content.Load<Texture2D>("Images/Backgrounds/Background3");
            background4 = game1.Content.Load<Texture2D>("Images/Backgrounds/Background4");
            background5 = game1.Content.Load<Texture2D>("Images/Backgrounds/Background5");
            background6 = game1.Content.Load<Texture2D>("Images/Backgrounds/Background6");
            background7 = game1.Content.Load<Texture2D>("Images/Backgrounds/Background7");
            background8 = game1.Content.Load<Texture2D>("Images/Backgrounds/Background8");

            texture = background1;

            spriteList.Add(new Background(game1)
            {
                alive = true,
                color = Color.White,
                delta = Vector2.Zero,
                effects = SpriteEffects.None,
                layerDepth = 1.0f,
                origin = Vector2.Zero,
                position = Vector2.Zero,
                rotation = 0.0f,
                scale = 1.0f,
                backgroundSourceRectangle = new Rectangle(texture.Width / 4, texture.Height / 4, texture.Width / 2, texture.Height / 2),
                texture = texture
            });

            backgroundIndex = 1;
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Background background in spriteList)
                if (background.alive)
                    background.Update(gameTime);

                else
                {
                    backgroundSourceRectangle = background.backgroundSourceRectangle;

                    spriteList.Remove(background);
                    
                    backgroundIndex++;

                    if (backgroundIndex > 8)
                        backgroundIndex = 2;

                    switch (backgroundIndex)
                    {
                        case 1:
                            texture = background1;
                            break;

                        case 2:
                            texture = background2;
                            break;

                        case 3:
                            texture = background3;
                            break;

                        case 4:
                            texture = background4;
                            break;

                        case 5:
                            texture = background5;
                            break;

                        case 6:
                            texture = background6;
                            break;

                        case 7:
                            texture = background7;
                            break;

                        case 8:
                            texture = background8;
                            break;
                    }

                    spriteList.Add(new Background(game1)
                    {
                        alive = true,
                        color = Color.White,
                        delta = Vector2.Zero,
                        effects = SpriteEffects.None,
                        layerDepth = 1.0f,
                        origin = Vector2.Zero,
                        position = Vector2.Zero,
                        rotation = 0.0f,
                        scale = 1.0f,
                        backgroundSourceRectangle = backgroundSourceRectangle,
                        texture = texture
                    });

                    break;
                }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (Background background in spriteList)
                if (background.alive)
                    background.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}
