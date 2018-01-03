using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using C1X.Crypto;

namespace C1X.Game
{
    public class Node
    {
        public static readonly float Friction = 10f;

        public Texture2D Texture2D { get; private set; }
        public Vector2 Position { get; protected set; }
        public Vector2 Velocity {get; protected set;}
        public TcpClient TcpClient { get; private set; }
        public IPAddress IpAddress { get; private set; }
        public StreamWriter StreamWriter { get; private set; }
        public StreamReader StreamReader { get; private set; }
        public KeyPair KeyPair { get; private set; }

        public Node(TcpClient tcpClient)
        {
            
            this.TcpClient = tcpClient;
            this.StreamWriter = new StreamWriter(tcpClient.GetStream());
            this.StreamReader = new StreamReader(tcpClient.GetStream());
            this.IpAddress = IPAddress.Parse(((IPEndPoint)TcpClient.Client.RemoteEndPoint).Address.ToString());
            EstablishRelationship();
        }

        public Node(Texture2D texture2D, Vector2 position)
        {
            this.Texture2D = texture2D;
            this.Position = position;
        }

        public virtual void Update(GameTime gameTime)
        {
            this.Position += this.Velocity * (gameTime.ElapsedGameTime.Milliseconds / (1000f));
            if (this.Velocity.X > 0) this.Velocity -= new Vector2(Friction, 0);
            if (this.Velocity.X < 0) this.Velocity += new Vector2(Friction, 0);
            if (this.Velocity.Y > 0) this.Velocity -= new Vector2(0, Friction);
            if (this.Velocity.Y < 0) this.Velocity += new Vector2(0, Friction);
        }

        public void EstablishRelationship()
        {
            try
            {
                Send("What's your public address?");
            }
            catch (Exception e)
            {
                throw new Exception("Couldn't establish connection with peer.", e);
            }
        }

        public void Send(string message)
        {
            if (TcpClient.Connected)
            {
                Thread.Sleep(1);
                StreamWriter.WriteAsync(message);
            }
        }

        public void Recieve()
        {
            if (TcpClient.Connected)
            {
                StreamReader.Read();
            }
        }

        public void Destroy()
        {
            this.TcpClient.Close();
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
