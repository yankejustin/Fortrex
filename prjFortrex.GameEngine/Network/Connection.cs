using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Drawing;
using prjFortrex.GameEngine.GamePlay.Movement;
using prjFortrex.GameEngine.GamePlay.Entities;

namespace prjFortrex.GameEngine.Network
{
    public interface IEntityConnection : IDisposable
    {
        Action Command { get; set; }
        byte[] Buffer { get; set; }
        Socket ConnectionSocket { get; set; }
    }

    public abstract class EntityConnection : EntityBase, IEntityConnection
    {
        #region IDisposable Implementation

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                ConnectionSocket.Close();
                ConnectionSocket.Dispose();
            }
        }

        #endregion

        #region IEntityConnection Implementation

        public Action Command { get; set; }
        public byte[] Buffer { get; set; }
        public Socket ConnectionSocket { get; set; }

        #endregion

        public EntityConnection() : base()
        { }
    }

    public class PlayerConnection : EntityConnection
    {
        public PlayerConnection() : base()
        { }

        public override void MoveEntity(Direction EntityDirection, int amount)
        {
            base.MoveEntity(EntityDirection, amount);

            // Send a command to the server that states that we have moved.
        }
    }
}