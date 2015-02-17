using System;
using System.Net.Sockets;
using prjFortrex.GameEngine.GamePlay.Logic.Movement;
using prjFortrex.GameEngine.GamePlay.Objects.Entities;

namespace prjFortrex.GameEngine.Network
{
    /// <summary>
    /// Defines an EntityBase's base connection class.
    /// </summary>
    public interface IEntityConnection
    {
        /// <summary>
        /// The action, or command, the entity intends to use.
        /// </summary>
        Action Command { get; set; }
        /// <summary>
        /// The buffer that stores the information that is sent or received from interaction with the server.
        /// </summary>
        byte[] Buffer { get; set; }
        
    }

    /// <summary>
    /// Represents an EntityConnection that implements the base definition of an Entity.
    /// </summary>
    public abstract class EntityConnection : EntityBase, IEntityConnection
    {
        #region IEntityConnection Implementation

        /// <summary>
        /// The action, or command, the entity intends to use.
        /// </summary>
        public Action Command { get; set; }
        /// <summary>
        /// The buffer that stores the information that is sent or received from interaction with the server.
        /// </summary>
        public byte[] Buffer { get; set; }

        #endregion

        #region Constructors

        public EntityConnection() : base()
        { }

        #endregion
    }

    public class PlayerConnection : EntityConnection
    {
        #region IDisposable Implementation

        // Override EntityBase's definition of Dispose to Dispose base class objects, but also the Socket object
        //   that is defined in this class.
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

        #region Constructors

        public PlayerConnection() : base()
        { }

        #endregion

        #region Overrides

        // Moves the entity, then tells the server the entity has moved.
        /* WITH FUTURE IMPLEMENTATION OF THE SERVER (IMPORTANT): Tell the server we wish to move this player entity, then use the server's response! */
        public override void MoveEntity(Direction EntityDirection, int amount)
        {
            base.MoveEntity(EntityDirection, amount);

            // Send a command to the server that states that we have moved.
        }

        #endregion

        #region Properties

        /// <summary>
        /// The socket that the entity uses to connect to the server.
        /// </summary>
        public Socket ConnectionSocket { get; set; }

        #endregion
    }
}