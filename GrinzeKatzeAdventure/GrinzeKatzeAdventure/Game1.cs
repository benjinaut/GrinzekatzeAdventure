using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GrinzeKatzeAdventure
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        Enemy enemy1;
        Enemy enemy2;
        Enemy enemy3;
        Enemy enemy4;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            GameStuff.Instance.tilemap = new TileMap(new Texture2D[] { Content.Load<Texture2D>("fluff"), Content.Load<Texture2D>("night") } , Content.Load<Texture2D>("bitmap002"), 16);
            GameStuff.Instance.player = new Player(Content.Load<Texture2D>("player"), new Vector2(30, 30), 2.7f, 100);
            GameStuff.Instance.camera = new Camera(GraphicsDevice.Viewport);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


           /**
           enemy1 = new Enemy(Content.Load<Texture2D>("reds"), new Vector2(300, 300), 0.8f, player);
           enemy2 = new Enemy(Content.Load<Texture2D>("blues"), new Vector2(100, 300), 0.6f, player);
           enemy3 = new Enemy(Content.Load<Texture2D>("greys"), new Vector2(200, 300), 0.4f, player);
           enemy4 = new Enemy(Content.Load<Texture2D>("greens"), new Vector2(400, 300), 0.2f, player);
                **/
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            GameStuff.Instance.tilemap.Update(gameTime);
            GameStuff.Instance.player.Update(gameTime);/**
            enemy1.Update(tilemap);
            enemy2.Update(tilemap);
            enemy3.Update(tilemap);
            enemy4.Update(tilemap);
            **/
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here


            spriteBatch.Begin(transformMatrix: GameStuff.Instance.camera.GetViewMatrix() ); 

            GameStuff.Instance.tilemap.Draw(spriteBatch);

            GameStuff.Instance.player.Draw(spriteBatch);
           /** enemy1.Draw(spriteBatch);
            enemy2.Draw(spriteBatch);
            enemy3.Draw(spriteBatch);
            enemy4.Draw(spriteBatch);**/
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
