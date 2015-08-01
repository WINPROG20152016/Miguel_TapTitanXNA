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
    public class SupportHero2
    {

        #region Properties
        Vector2 Support_2;
        Texture2D Support2;

        ContentManager content;
        Level level;
        int windowWidth = 800;
        int windowHeight = 500;


        Animation idleAnimation;
        AnimationPlayer spritePlayer;
        #endregion

        public SupportHero2(ContentManager content, Level level)
        {
            this.content = content;
            this.level = level;
        }



        public void LoadContent()
        {
            Support2 = content.Load<Texture2D>("Gaara");



            idleAnimation = new Animation(Support2, 0.1f, true, 6);

            int positionX = (windowWidth / 4) - (Support2.Width / 8);
            int positionY = (windowHeight / 4) - (Support2.Height / 8);
            Support_2 = new Vector2((float)positionX, (float)positionY);

            spritePlayer.PlayAnimation(idleAnimation);
        }



        public void Update(GameTime gameTime)
        {
            if (level.mouseState.LeftButton == ButtonState.Pressed &&
                level.oldMouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released)
            {
                Support_2.X++;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(player, playerPosition, null,
            // Color.White, 0.0f,
            //Vector2.Zero, 0.5f,
            //SpriteEffects.None, 0.0f);
            spritePlayer.Draw(gameTime, spriteBatch, Support_2, SpriteEffects.None);

        }

    }
}
