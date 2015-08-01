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
    public class Hero
    {

        #region Properties
        Vector2 playerPosition;
         Texture2D player;
        ContentManager content;
        Level level;
        int windowWidth = 400;
        int windowHeight = 500;
        

        Animation idleAnimation;
        AnimationPlayer spritePlayer;
        #endregion

        public Hero (ContentManager content, Level level)
	    {
            this.content = content;
            this.level = level;
	    }

       

        public void LoadContent()
        {
            player = content.Load<Texture2D>("Hulk");
         
          

            idleAnimation = new Animation(player, 0.1f, true, 6);

            int positionX = (windowWidth / 4) - (player.Width / 8);
            int positionY = (windowHeight / 4) - (player.Height / 8);
            playerPosition = new Vector2((float)positionX, (float)positionY);

            spritePlayer.PlayAnimation(idleAnimation);
        }

       

        public void Update(GameTime gameTime)
        {
            if(level.mouseState.LeftButton == ButtonState.Pressed && 
                level.oldMouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released)
            {
                playerPosition.X++;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(player, playerPosition, null,
               // Color.White, 0.0f,
                //Vector2.Zero, 0.5f,
                //SpriteEffects.None, 0.0f);
                spritePlayer.Draw(gameTime, spriteBatch, playerPosition, SpriteEffects.None);

        }

    }
}
