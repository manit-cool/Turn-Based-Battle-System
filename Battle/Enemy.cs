using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Enemy
{
    //enemy rendering
    public Vector2 position;
    private Rectangle enemyRect;
    private Texture2D enemyTexture;
    private Rectangle enemyShadowRect;
    private Texture2D enemyShadowTexture;

    //enemy health bar
    private Texture2D enemyHealthBar;
    private Texture2D enemyHealthBarBox;
    private Rectangle enemyHealthBarRect;
    private Rectangle enemyHealthBarBoxRect;
    public static float health;

    //Dialogue + Menu + UI
    public static string dialogue;

    public void LoadContent(GraphicsDevice graphicsDevice)
    {
        //enemy rendering
        position = new Vector2(554, 50);
        enemyRect = new Rectangle((int)position.X,(int)position.Y, 50, 50);
        enemyShadowRect = new Rectangle(enemyRect.X - 25, (int)position.Y+25, 100, 50);
        enemyTexture = new Texture2D(graphicsDevice,1,1);
        enemyShadowTexture = new Texture2D(graphicsDevice,1,1);
        enemyTexture.SetData(new[]{Color.White});
        enemyShadowTexture.SetData(new[]{Color.White});
        //health bar rendering
        enemyHealthBar = new Texture2D(graphicsDevice, 1, 1);
        enemyHealthBarBox = new Texture2D(graphicsDevice,1,1);
        enemyHealthBar.SetData(new[]{Color.White});
        enemyHealthBarBox.SetData(new[]{Color.White});
        enemyHealthBarBoxRect = new Rectangle(12, 12, 610, 30);
        enemyHealthBarRect = new Rectangle(enemyHealthBarBoxRect.X + 10, 17, 590, 20);
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(enemyShadowTexture, enemyShadowRect, Color.MediumOrchid);
        spriteBatch.Draw(enemyTexture, enemyRect, Color.LightGoldenrodYellow);
        spriteBatch.Draw(enemyHealthBarBox, enemyHealthBarBoxRect, Color.DarkRed);
        spriteBatch.Draw(enemyHealthBarBox, enemyHealthBarRect, Color.IndianRed);
    }

    public void Update()
    {
        float width = (health/100) * 590;
        enemyHealthBarRect.Width = (int)width;
    }
}