using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class UImanager
{
    public UI.Dialogue dialogue;
    public UI.Moves moves;
    public void Initialize()
    {
        dialogue = new UI.Dialogue();
        moves = new UI.Moves();
        moves.Initialize();
    }
    public void LoadContent(GraphicsDevice graphicsDevice, SpriteFont font)
    {
        dialogue.SetupDialogue(graphicsDevice, font);
        moves.LoadContent(graphicsDevice, font);
    }
    public void Update(GameTime gameTime)
    {
        moves.Update(gameTime);
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        dialogue.Draw(spriteBatch);
        moves.Draw(spriteBatch);
    }
}