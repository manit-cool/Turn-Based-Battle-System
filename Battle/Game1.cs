using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Battle;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    //Player
    private Player player;
    // Player moves textures
    public static Texture2D beigleTexture;
    public static Texture2D seagullTexture;
    // UI
    private SpriteFont font;
    private UImanager uImanager;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth  = 640;
        _graphics.PreferredBackBufferHeight = 360;
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        player = new Player();
        uImanager = new UImanager();
        Player.health = 10;
        uImanager.Initialize();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        player.LoadContent(GraphicsDevice);
        font = Content.Load<SpriteFont>("font");

        beigleTexture = Content.Load<Texture2D>("pixil-frame-0");
        seagullTexture = Content.Load<Texture2D>("seagull");
        
        // TODO: use this.Content to load your game content here
        uImanager.LoadContent(GraphicsDevice, font);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape) || UI.Moves.fleeing == true)
            Exit();
        
        // TODO: Add your update logic here
        player.Update();
        uImanager.Update(gameTime);

        base.Update(gameTime);
    }
    public void QuitGame()
    {
        Exit();
    }
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        player.Draw(_spriteBatch);
        uImanager.Draw(_spriteBatch);
        _spriteBatch.End();
        base.Draw(gameTime);    
    }
}
