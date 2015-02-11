using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace prjFortrex.GameEngine.Network
{
    public interface IEntityConnection : IDisposable
    {
        byte[] Buffer { get; set; }
        Socket ConnectionSocket { get; set; }
    }

    public class EntityConnection : IEntityConnection
    {
        #region IDisposable Implementation

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                ConnectionSocket.Close();
                ConnectionSocket.Dispose();
            }
        }

        #endregion

        public EntityConnection()
        { }

        public byte[] Buffer { get; set; }
        public Socket ConnectionSocket { get; set; }
    }
}