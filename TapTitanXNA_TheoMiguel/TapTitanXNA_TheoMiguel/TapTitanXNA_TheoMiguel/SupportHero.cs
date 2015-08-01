using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace TapTitanXNA_TheoMiguel
{
    public class SupportHero
    {

        #region Properties
        Vector2 Support;
        Texture2D Support1;

        ContentManager content;
        Level level;
        int windowWidth = 400;
        int windowHeight = 500;


        Animation idleAnimation;
        AnimationPlayer spritePlayer;
        #endregion

        public SupportHero (ContentManager content, Level level)
        {
            this.content = content;
            this.level = level;
        }



        public void LoadContent()
        {
            Support1 = content.Load<Texture2D>("Girl");



            idleAnimation = new Animation(Support1, 0.1f, true, 8);

            int positionX = (windowWidth / 2) - (Support1.Width / 4);
            int positionY = (windowHeight / 2) - (Support1.Height / 4);
            Support = new Vector2((float)positionX, (float)positionY);

            spritePlayer.PlayAnimation(idleAnimation);
        }



        public void Update(GameTime gameTime)
        {
            if (level.mouseState.LeftButton == ButtonState.Pressed &&
                level.oldMouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released)
            {
                Support.X++;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(player, playerPosition, null,
            // Color.White, 0.0f,
            //Vector2.Zero, 0.5f,
            //SpriteEffects.None, 0.0f);
            spritePlayer.Draw(gameTime, spriteBatch, Support, SpriteEffects.None);

        }

    }
}
