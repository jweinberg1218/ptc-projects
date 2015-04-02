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
    public class ZombieManager : SpriteManager
    {
        public Texture2D zombie1, zombie2, zombie3, zombie4;
        public Vector2 position;

        public int points;
        public int side;
        public int zombie;

        public int currentLevel, previousLevel;

        public ZombieManager(Game1 game1)
            : base(game1)
        {
            currentLevel = game1.level;
            previousLevel = game1.level;

            zombie1 = game1.Content.Load<Texture2D>("Images/Zombies/Zombie1");
            zombie2 = game1.Content.Load<Texture2D>("Images/Zombies/Zombie2");
            zombie3 = game1.Content.Load<Texture2D>("Images/Zombies/Zombie3");
            zombie4 = game1.Content.Load<Texture2D>("Images/Zombies/Zombie4");

            for (int i = 0; i < 10; i++)
            {
                side = game1.random.Next(0, 4);

                switch (side)
                {
                    case 0:
                        position = new Vector2(game1.random.Next(0, 800), game1.random.Next(-600, 0));
                        break;

                    case 1:
                        position = new Vector2(game1.random.Next(0, 800), game1.random.Next(600, 1200));
                        break;

                    case 2:
                        position = new Vector2(game1.random.Next(-800, 0), game1.random.Next(0, 600));
                        break;

                    case 3:
                        position = new Vector2(game1.random.Next(800, 1600), game1.random.Next(0, 600));
                        break;
                }

                zombie = game1.random.Next(0, 4);

                switch (zombie)
                {
                    case 0:
                        points = 5;
                        texture = zombie1;
                        break;

                    case 1:
                        points = 10;
                        texture = zombie2;
                        break;

                    case 2:
                        points = 15;
                        texture = zombie3;
                        break;

                    case 3:
                        points = 20;
                        texture = zombie4;
                        break;
                }

                spriteList.Add(new Zombie(game1)
                {
                    alive = true,
                    color = Color.White,
                    delta = Vector2.Zero,
                    deltaMultiplier = 1.0f,
                    effects = SpriteEffects.None,
                    health = 6,
                    layerDepth = 0.0f,
                    origin = new Vector2(texture.Width / 2, texture.Height / 2),
                    position = position,
                    rotation = 0.0f,
                    scale = 0.5f,
                    points = points,
                    sourceRectangle = null,
                    texture = texture
                });
            }
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Zombie zombie in spriteList)
                if (zombie.alive)
                    zombie.Update(gameTime);

                else
                {
                    if (game1.random.Next(0, 2) == 0)
                        game1.powerUpManager.SpawnPowerUp(zombie.position);

                    this.side = game1.random.Next(0, 4);

                    switch (this.side)
                    {
                        case 0:
                            zombie.position = new Vector2(game1.random.Next(0, 800), game1.random.Next(-600, 0));
                            break;

                        case 1:
                            zombie.position = new Vector2(game1.random.Next(0, 800), game1.random.Next(600, 1200));
                            break;

                        case 2:
                            zombie.position = new Vector2(game1.random.Next(-800, 0), game1.random.Next(0, 600));
                            break;

                        case 3:
                            zombie.position = new Vector2(game1.random.Next(800, 1600), game1.random.Next(0, 600));
                            break;
                    }

                    this.zombie = game1.random.Next(0, 4);

                    switch (this.zombie)
                    {
                        case 0:
                            zombie.texture = zombie1;
                            break;

                        case 1:
                            zombie.texture = zombie2;
                            break;

                        case 2:
                            zombie.texture = zombie3;
                            break;

                        case 3:
                            zombie.texture = zombie4;
                            break;
                    }

                    zombie.health = 6;
                    zombie.alive = true;
                }

            currentLevel = game1.level;

            if (currentLevel > previousLevel)
            {
                side = game1.random.Next(0, 4);

                switch (side)
                {
                    case 0:
                        position = new Vector2(game1.random.Next(0, 800), game1.random.Next(-600, 0));
                        break;

                    case 1:
                        position = new Vector2(game1.random.Next(0, 800), game1.random.Next(600, 1200));
                        break;

                    case 2:
                        position = new Vector2(game1.random.Next(-800, 0), game1.random.Next(0, 600));
                        break;

                    case 3:
                        position = new Vector2(game1.random.Next(800, 1600), game1.random.Next(0, 600));
                        break;
                }

                zombie = game1.random.Next(0, 4);

                switch (zombie)
                {
                    case 0:
                        texture = zombie1;
                        break;

                    case 1:
                        texture = zombie2;
                        break;

                    case 2:
                        texture = zombie3;
                        break;

                    case 3:
                        texture = zombie4;
                        break;
                }

                spriteList.Add(new Zombie(game1)
                {
                    alive = true,
                    color = Color.White,
                    delta = Vector2.Zero,
                    deltaMultiplier = 1.0f,
                    effects = SpriteEffects.None,
                    health = 6,
                    layerDepth = 0.0f,
                    origin = new Vector2(texture.Width / 2, texture.Height / 2),
                    position = position,
                    rotation = 0.0f,
                    scale = 0.5f,
                    sourceRectangle = null,
                    texture = texture
                });
            }

            previousLevel = currentLevel;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (Zombie zombie in spriteList)
                if (zombie.alive)
                    zombie.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}
