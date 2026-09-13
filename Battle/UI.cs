using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class UI
{
    //Dialogue UI for player and enemy!
    public class Dialogue
    {

        //General Setup
        private Texture2D playerDialogueTexture;
        public Rectangle playerDialogueRectangle;
        private Texture2D enemyDialogueTexture;
        public Rectangle enemyDialogueRectangle;
        private SpriteFont font;
        public List<String> dialogues = new List<string>();
        // see over here, things like options.Add("an option"); --> this isn't allowed for the sole reason that classes are meant to 
        // declare members, they aren't meant to have procedural code --> i mean this is what google says so:D  
        public void SetupDialogue(GraphicsDevice graphicsDevice, SpriteFont Font)
        {
            //Dialogue
            //start
            dialogues.Add("So we're playing the waiting game...");
            //attacks
            dialogues.Add("After months in the toaster, it's ready. BEIGEL GOD, I SUMMON YOU");
            // getting attacked/died
            dialogues.Add("Wow you hit me, I'm so scared");
            dialogues.Add("ig you win this time");

            //Player UI
            playerDialogueRectangle = new Rectangle(165, 230, 450, 80);
            playerDialogueTexture = new Texture2D(graphicsDevice, 1, 1);
            playerDialogueTexture.SetData(new[]{Color.White});
            //Enemy UI
            enemyDialogueRectangle = new Rectangle();
            enemyDialogueTexture = new Texture2D(graphicsDevice, 1,1);
            enemyDialogueTexture.SetData(new[] {Color.White});
            //Others
            font = Font;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(playerDialogueTexture, playerDialogueRectangle, Color.Gray);


            //TBD --> Moves CHANGE THE WAY THE DIALOGUE IS SETUP :D (VARIABLE NAME = Moves.option)
            String dia = "OKAY BUD, LET'S \nSEE YOU SURVIVE THIS!";
            spriteBatch.DrawString(font, dia, new Vector2(playerDialogueRectangle.X+10, playerDialogueRectangle.Y+font.MeasureString(dia).Y/2), Color.Black);
        }
    }
    public class Moves
    {
        public Rectangle selectionRect;
        public Texture2D selectionTexture;
        public static int option;
        private KeyboardState current;
        private KeyboardState previous;
        private SpriteFont font;
        public void Initialize()
        {
            selectionRect = new Rectangle(205,230,0,0);
        }
        public void LoadContent(GraphicsDevice graphicsDevice, SpriteFont Font)
        {
            selectionTexture = new Texture2D(graphicsDevice, 1, 1);
            selectionTexture.SetData(new[]{Color.White});
            previous = Keyboard.GetState();
            font = Font;
        }
        public void DrawRectangleOutline(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(selectionTexture, new Rectangle(selectionRect.X, selectionRect.Y, 15, 5), Color.RosyBrown);// horizontal
            spriteBatch.Draw(selectionTexture, new Rectangle(selectionRect.X, selectionRect.Height - 5, 15, 5), Color.RosyBrown); //horizontal bottom
            spriteBatch.Draw(selectionTexture, new Rectangle(selectionRect.X, selectionRect.Y, 5, 10), Color.RosyBrown);
            spriteBatch.Draw(selectionTexture, new Rectangle(selectionRect.X + 15, selectionRect.Y, 5, 10), Color.RosyBrown);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            DrawRectangleOutline(spriteBatch);
            
        }
        public void Update()
        {
            OptionSelection();
            if(option == 0) selectionRect.Y = 230;
            if(option == 1) selectionRect.Y = 255;
            if(option == 2) selectionRect.Y = 280;
        }

        public void OptionSelection()
        {
            current = Keyboard.GetState();

            if(current.IsKeyDown(Keys.Down))
            {
                if(previous.IsKeyUp(Keys.Down))
                {
                    option++;
                }
            }
            if(current.IsKeyDown(Keys.Up))
            {
                if(previous.IsKeyUp(Keys.Up))
                {
                    option--;
                }
            }
            if(option > 2 || option < 0)
            {
                option = 0;
            }
            
            previous = current;
        }
    }    
}   