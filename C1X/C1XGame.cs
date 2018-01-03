﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using C1X.Game;
using System;
using System.Net.Sockets;

namespace C1X
{
    public class C1XGame : Microsoft.Xna.Framework.Game
    {
        public static C1XGame Instance { get; private set; }
        public static Viewport Viewport => Instance.GraphicsDevice.Viewport;
        public static GameTime GameTime;
        public static List<Node> NodeList { get; private set; }
        public static NodeNetwork NodeNetwork { get; private set; }

        public Player Player { get; private set; }

        private SpriteBatch _spriteBatch;

        public C1XGame()
        {
            Instance = this;
            var graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
        }

        protected override void Initialize()
        {
            NodeList = new List<Node>();
            NodeNetwork = new NodeNetwork();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Player = new Player(new TcpClient().Client);

            Node.Texture2D = Content.Load<Texture2D>("Sprites/Player");

            Utils.LoadPeerList();
            NodeList.Add(Player);
            
            for(var i = 0; i < 100; i++)
            {
                var random = new Random();
                NodeList.Add(Player);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            foreach(var node in NodeList)
            {
                node.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            foreach(var node in NodeList)
            {
                Console.Write(node);
                _spriteBatch.Draw(Node.Texture2D, node.Position, Color.White);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        protected override void UnloadContent()
        {
            Utils.SavePeerList();

            base.UnloadContent();
        }
    }
}
