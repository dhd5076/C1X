using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using C1X.Crypto;

namespace C1X.Game
{
    public class Node
    {
        public static readonly float Friction = 1f;
        public static Texture2D Texture2D { get; set; }

        public Vector2 Position { get; protected set; }
        public Vector2 Velocity {get; protected set;}
        public Socket Socket { get; protected set; }
        public IPAddress IpAddress { get; private set; }
        public KeyPair KeyPair { get; private set; }

        public Node(Socket socket, bool isPlayer)
        {
            this.Socket = socket;
            if (!isPlayer)
            {
                this.Velocity = new Vector2((float)C1XGame.Random.NextDouble() * 10, (float)C1XGame.Random.NextDouble() * 10);
                this.IpAddress = IPAddress.Parse(((IPEndPoint)socket.RemoteEndPoint).Address.ToString());
                EstablishRelationship(socket);
            }
            else
            {
                this.KeyPair = EcDsa.GenKeyPair();
            }
            this.Position = new Vector2(C1XGame.Random.Next(0, C1XGame.Viewport.Width), C1XGame.Random.Next(0, C1XGame.Viewport.Height));
        }

        public virtual void Update(GameTime gameTime)
        {
            this.Position += this.Velocity;

            if (!Socket.Connected && this.IpAddress != null) //TODO: Find a better way to check if we are player
            {
                this.Destroy();
            }
        }

        public void EstablishRelationship(Socket socket)
        {
                Send("Who?");
                var response = Receive(1024);
                Send(KeyPair.ConvertToBase64(C1XGame.Instance.Player.KeyPair.PrivateKey));
        }

        public string Receive(int length)
        {
            Socket.ReceiveTimeout = 4000;
            var buffer = new byte[length];
            Socket.Receive(buffer);
            return Encoding.ASCII.GetString(buffer);
        }

        public void Send(string message)
        {
            if (Socket.Connected) Socket.Send(Encoding.ASCII.GetBytes(message + "\r\n"));
        }

        public void Destroy()
        {
            //TODO: THIS IS TERRIBLE!
            this.Position = new Vector2(-128, -128);
        }

        protected void AddForce(Vector2 forceVector)
        {
            this.Velocity += forceVector;
        }

        private static Guid GenGuid()
        {
            return Guid.NewGuid();
        }
    }
}
