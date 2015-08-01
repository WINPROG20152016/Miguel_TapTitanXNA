using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TapTitanXNA_TheoMiguel
{
    public class Level
    {
        public static int windowWidth = 400;
        public static int windowHeight = 500;


        #region Properties
        ContentManager content;
        Texture2D background;
        public MouseState oldMouseState;
        public MouseState mouseState;
        bool mpressed, prev_mpressed = false;
        int mouseX, mouseY;
        int damageNumber = 0;

        Hero hero;
        SupportHero Support;
        SupportHero2 Support2;
   

        SpriteFont damageStringfont;

        Button playButton;
        Button attackButton;
        #endregion

        public Level(ContentManager content)
        {
            this.content = content;

            hero = new Hero(content, this);
            Support = new SupportHero(content, this);
            Support2 = new SupportHero2(content, this);
           
          
        }

        public void LoadContent()
        {
            background = content.Load<Texture2D>("bg");

            hero.LoadContent();
            Support.LoadContent();
            Support2.LoadContent();
            damageStringfont = content.Load<SpriteFont>("SpriteFont1");
            playButton = new Button(content, "Button", new Vector2 (0,350));
        }

        public void Update(GameTime gameTime)
        {

            mouseState = Mouse.GetState();
            mouseX = mouseState.X;
            mouseY = mouseState.Y;
            prev_mpressed = mpressed;
            mpressed = mouseState.LeftButton == ButtonState.Pressed;


            hero.Update(gameTime);
            Support.Update(gameTime);

            
            oldMouseState = mouseState;
            if (playButton.Update(gameTime, mouseX, mouseY, mpressed, prev_mpressed))
            {
                damageNumber += 1;
            }

        }    

         public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
         {
             spriteBatch.Draw(background,
              Vector2.Zero,null,Color.White,0.0f,Vector2.Zero,0.5f, SpriteEffects.None,0.0f);
             hero.Draw(gameTime, spriteBatch);
             Support.Draw(gameTime,spriteBatch);
             Support2.Draw(gameTime, spriteBatch);
             spriteBatch.DrawString(damageStringfont, damageNumber + "0 Damage!", Vector2.Zero, Color.White);

             playButton.Draw(gameTime, spriteBatch);
         }
     }
}
