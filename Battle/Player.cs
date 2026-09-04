using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Player
{
    public Vector2 position;
    private Rectangle playerRect;
    private Texture2D playerTexture;
    private Rectangle playerShadowRect;
    private Texture2D playerShadowTexture;
    private Texture2D playerHealthBar;
    private Texture2D playerHealthBarBox;
    private Rectangle playerHealthBarRect;
    private Rectangle playerHealthBarBoxRect;
    public static string dialogue;
    public static float health;

    public void LoadContent(GraphicsDevice graphicsDevice)
    {
        //player rendering
        position = new Vector2(70, 230);
        playerRect = new Rectangle((int)position.X,(int)position.Y, 50, 50);
        playerShadowRect = new Rectangle(playerRect.X - playerRect.X/4, (int)position.Y+25, 135, 50);
        playerTexture = new Texture2D(graphicsDevice,1,1);
        playerShadowTexture = new Texture2D(graphicsDevice,1,1);
        playerTexture.SetData(new[]{Color.White});
        playerShadowTexture.SetData(new[]{Color.White});
        //health bar rendering
        playerHealthBar = new Texture2D(graphicsDevice, 1, 1);
        playerHealthBarBox = new Texture2D(graphicsDevice,1,1);
        playerHealthBar.SetData(new[]{Color.White});
        playerHealthBarBox.SetData(new[]{Color.White});
        playerHealthBarBoxRect = new Rectangle(playerRect.X/4, 322, 610, 30);
        playerHealthBarRect = new Rectangle(playerHealthBarBoxRect.X + 10, 327, 590, 20);
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(playerShadowTexture, playerShadowRect, Color.MediumOrchid);
        spriteBatch.Draw(playerTexture, playerRect, Color.LightGoldenrodYellow);
        spriteBatch.Draw(playerHealthBarBox, playerHealthBarBoxRect, Color.DarkRed);
        spriteBatch.Draw(playerHealthBarBox, playerHealthBarRect, Color.IndianRed);
    }

    public void Update()
    {
        playerRect = new Rectangle((int)position.X, (int)position.Y, 50,50);
        playerShadowRect = new Rectangle(playerRect.X - playerRect.X/4 - 7, (int)position.Y+25, 100, 50);
        float width = (health/100) * 590;
        playerHealthBarRect.Width = (int)width;
    }
}