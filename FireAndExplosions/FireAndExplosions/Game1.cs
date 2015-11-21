using FireAndExplosions.Explosion;
using FireAndExplosions.Smoke;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FireAndExplosions
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Camera camera;

        Texture2D splitterTexture;
        Texture2D smokeTexture;
        Texture2D shockwaveTexture;
        Texture2D explosionTexture;

        SplitterSystem splitterSystem;
        SmokeSystem smokeSystem;
        Explosion2d explosion;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 900;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 900;
            graphics.ApplyChanges();
            camera = new Camera();

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

            splitterTexture = Content.Load<Texture2D>("spark");
            splitterSystem = new SplitterSystem(splitterTexture);

            smokeTexture = Content.Load<Texture2D>("particlesmokepng");
            smokeSystem = new SmokeSystem(smokeTexture);
            camera.setSizeOfField(graphics.GraphicsDevice.Viewport);
            //shockwaveTexture = Content.Load<Texture2D>("");
            explosionTexture = Content.Load<Texture2D>("ExplosionSprite");
            explosion = new Explosion2d(spriteBatch, explosionTexture, camera);
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
            float timeElapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            splitterSystem.Update(timeElapsedSeconds);
            smokeSystem.Update(timeElapsedSeconds);
            
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.FrontToBack);
            splitterSystem.Draw(spriteBatch, camera);
            smokeSystem.Draw(spriteBatch, camera);
            explosion.Draw((float)gameTime.ElapsedGameTime.TotalSeconds);
            // TODO: Add your drawing code here
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
