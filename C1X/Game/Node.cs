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
        public static readonly float Friction = 0.001f;
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
                this.IpAddress = IPAddress.Parse(((IPEndPoint)socket.RemoteEndPoint).Address.ToString());
                EstablishRelationship(socket);
            }
            this.Position = new Vector2(0,0);
        }

        public virtual void Update(GameTime gameTime)
        {
            this.Position += this.Velocity * (gameTime.ElapsedGameTime.Milliseconds / (1000f));
            if (this.Velocity.X > 0) this.Velocity -= new Vector2(Friction, 0);
            if (this.Velocity.X < 0) this.Velocity += new Vector2(Friction, 0);
            if (this.Velocity.Y > 0) this.Velocity -= new Vector2(0, Friction);
            if (this.Velocity.Y < 0) this.Velocity += new Vector2(0, Friction);
        }

        public void EstablishRelationship(Socket socket)
        {
            var success = false;

            try
            {
                Send("Who?");
                success = true;
            }
            catch (Exception e)
            {
                throw new Exception("Couldn't establish connection with peer.", e);
            }

            if (!success)
            {
                Destroy();
            }
        }

        public void Send(string message)
        {
            if (Socket.Connected) Socket.Send(Encoding.ASCII.GetBytes(message));
        }

        public void Destroy()
        {
            C1XGame.NodeNetwork.ConnectedPeers.Remove(this);
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
