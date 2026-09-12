using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class UImanager
{
    public UI.Dialogue dialogue;

    public void Initialize()
    {
        dialogue = new UI.Dialogue();
    }
    public void LoadContent(GraphicsDevice graphicsDevice, SpriteFont font)
    {
        dialogue.SetupDialogue(graphicsDevice, font);
        
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        dialogue.Draw(spriteBatch);
    }
}