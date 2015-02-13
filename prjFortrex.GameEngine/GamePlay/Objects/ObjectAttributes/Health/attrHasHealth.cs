using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjFortrex.GameEngine.GamePlay.Objects.ObjectAttributes.Health
{
    // Template for our attributes.

    public interface IHasHealth
    {
        float EntityHealth { get; set; }
        HealthBar EntityHealthBar { get; set; }
    }

    /// <summary>
    /// Defines an object that has health.
    /// </summary>
    public abstract class attrHasHealth : IDisposable
    {
        #region IHasHealth Implementation

        public float EntityHealth { get; set; }
        public HealthBar EntityHealthBar { get; set; }

        #endregion

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
                // Remove the event wire-ups.
            }
        }

        #endregion

        public attrHasHealth()
        {

        }

        public attrHasHealth(bool HealthRegenerates)
        {

        }
    }
}