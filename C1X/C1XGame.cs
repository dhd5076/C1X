using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using C1X.Game;
using System;

namespace C1X
{
    public class C1XGame : Microsoft.Xna.Framework.Game
    {
        public static C1XGame Instance { get; private set; }
        public static Viewport Viewport { get { return Instance.GraphicsDevice.Viewport; } }
        public static GameTime GameTime { get; private set; }
        public static List<Enemy> NodeList;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public C1XGame()
        {
            Instance = this;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
        }

        protected override void Initialize()
        {
            NodeList = new List<Enemy>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D texture = Content.Load<Texture2D>("Sprites/Player");
            Vector2 position = new Vector2(0, 0);
            Enemy test = new Enemy(texture, position);
            NodeList.Add(test);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            foreach(Node node in NodeList)
            {
                Console.Write(node);
                spriteBatch.Draw(node.Texture2D, node.Position, Color.White);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
