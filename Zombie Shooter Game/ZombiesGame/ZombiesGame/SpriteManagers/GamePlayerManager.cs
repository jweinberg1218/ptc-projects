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
    public class GamePlayerManager : SpriteManager
    {
        public GamePlayerManager(Game1 game1)
            : base(game1)
        {
            texture = game1.Content.Load<Texture2D>("Images/Other/GamePlayer");

            for (PlayerIndex playerIndex = PlayerIndex.One; playerIndex <= PlayerIndex.Four; playerIndex++)
            {
                if (GamePad.GetState(playerIndex).IsConnected)
                {
                    spriteList.Add(new GamePlayer(game1)
                    {
                        alive = true,
                        color = Color.White,
                        delta = new Vector2(0.0f, 0.0f),
                        deltaMultiplier = 2.0f,
                        effects = SpriteEffects.None,
                        layerDepth = 0.0f,
                        origin = new Vector2(texture.Width / 2 + 9, texture.Height / 2),
                        playerIndex = playerIndex,
                        position = new Vector2(game1.resolution.X / 2, game1.resolution.Y / 2),
                        rotation = 0.0f,
                        rotationMultiplier = 5.0f,
                        scale = 1.0f,
                        sourceRectangle = null,
                        texture = texture
                    });
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GamePlayer gamePlayer in spriteList)
                if (gamePlayer.alive)
                    gamePlayer.Update(gameTime);

                else
                {
                    gamePlayer.bulletCount = 1200;
                    gamePlayer.bulletCountMax = 1200;
                    gamePlayer.deltaMultiplier = 2.0f;
                    gamePlayer.lives--;
                    gamePlayer.position = new Vector2(game1.random.Next(0, (int)game1.resolution.X), game1.random.Next(0, (int)game1.resolution.Y));
                    gamePlayer.alive = true;
                }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (GamePlayer gamePlayer in spriteList)
                if (gamePlayer.alive)
                    gamePlayer.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}
