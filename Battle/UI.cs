using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class UI
{
    //Dialogue UI for player and enemy!
    public class Dialogue
    {
        private Texture2D playerDialogueTexture;
        public Rectangle playerDialogueRectangle;
        private Texture2D enemyDialogueTexture;
        public Rectangle enemyDialogueRectangle;
        private SpriteFont font;

        public void SetupDialogue(GraphicsDevice graphicsDevice, SpriteFont Font)
        {
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
            String dia = "OKAY BUD, LET'S SEE YOU SURVIVE THIS!";
            spriteBatch.DrawString(font, dia, new Vector2(playerDialogueRectangle.X+10, playerDialogueRectangle.Y+30), Color.Black);
        }
    }
        
}