using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using C1X.Game;

namespace C1X
{
    /// <summary>
    /// Game singleton class
    /// </summary>
    public class C1XGame : Microsoft.Xna.Framework.Game
    {
        public static C1XGame Instance { get; private set; }
        public static Viewport Viewport { get { return Instance.GraphicsDevice.Viewport; } }
        public static GameTime GameTime { get; private set; }
        public static List<Enemy> NodeList;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        /// <summary>
        /// Game singleton contructor
        /// </summary>
        public C1XGame()
        {
            Instance = this;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
        }

        /// <summary>
        /// Loads assets
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        /// <summary>
        /// Top update call, Updates all gameobjects and systems for the next draw call
        /// </summary>
        /// <param name="gameTime">Time elapsed since last update</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Top draw call, Draws all gameobjects
        /// </summary>
        /// <param name="gameTime">Time elapsed since last update</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
