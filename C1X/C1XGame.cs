using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using C1X.Game;
using System;
using C1X.Network;

namespace C1X
{
    public class C1XGame : Microsoft.Xna.Framework.Game
    {
        public static C1XGame Instance { get; private set; }
        public static Viewport Viewport { get { return Instance.GraphicsDevice.Viewport; } }
        public static GameTime GameTime { get; private set; }
        public static List<Node> NodeList { get; private set; }
        public static PeerNetwork PeerNetwork { get; private set; }

        public Player Player { get; private set; }

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
            NodeList = new List<Node>();
            PeerNetwork = new PeerNetwork();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Player = new Player(Content.Load<Texture2D>("Sprites/Player"), new Vector2(0, 0));
            NodeList.Add(Player);

            //This is just for debugging
            for(int i = 0; i < 100; i++)
            {
                Random random = new Random();
                NodeList.Add(new Player(Content.Load<Texture2D>("Sprites/Player"), new Vector2(0, 0)));
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            foreach(Node node in NodeList)
            {
                node.Update(gameTime);
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
