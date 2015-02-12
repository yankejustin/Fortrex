using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using prjFortrex.GameEngine.GamePlay.Movement;

namespace prjFortrex.GameEngine.GamePlay.Entities
{
    public interface IMobileEntity
    {
        Point CurrentPosition { get; set; }

        void MoveEntity(Direction EntityDirection);
        void MoveEntity(Direction EntityDirection, int speed);
    }

    public abstract class EntityBase : IMobileEntity, IDisposable
    {
        #region IMobileEntity Implementation

        public Point CurrentPosition { get; set; }

        public Rectangle EntitySize;

        

        public virtual void MoveEntity(Direction EntityDirection)
        {
            MoveEntity(EntityDirection, 20);
        }

        public virtual void MoveEntity(Direction EntityDirection, int amount)
        {
            Point NextPosition;

            switch (EntityDirection)
            {
                case Direction.Up:
                    NextPosition = new Point(CurrentPosition.X, CurrentPosition.Y - amount);
                    break;
                case Direction.Down:
                    NextPosition = new Point(CurrentPosition.X, CurrentPosition.Y + amount);
                    break;
                case Direction.Left:
                    NextPosition = new Point(CurrentPosition.X - amount, CurrentPosition.Y);
                    break;
                case Direction.Right:
                    NextPosition = new Point(CurrentPosition.X + amount, CurrentPosition.Y);
                    break;
                default:
                    return;
            }

            CurrentPosition = NextPosition;
            EntitySize.X = CurrentPosition.X;
            EntitySize.Y = CurrentPosition.Y;

            // The command to move is sent to the server by the class inheriting this base entity class.
        }

        #endregion

        #region IDisposable Implementation

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                EntityPicture.Dispose();
            }
        }

        #endregion

        public Image EntityPicture { get; set; }

        #region Constructors

        public EntityBase()
        {
            EntitySize = new Rectangle(0, 0, 50, 50);
            EntityPicture = Image.FromFile("C:\\Users\\jyanke\\Desktop\\KsmaBg1xIs3JuKuee6QzbJpxr2TLzFfkG7oWYLoZsD7bh2cOTEMYWR7t1H7QMXNzuFN0tw=w1246-h833.jpg");
        }

        public EntityBase(Rectangle size)
        {
            EntitySize = size;
            EntityPicture = Image.FromFile("C:\\Users\\jyanke\\Desktop\\KsmaBg1xIs3JuKuee6QzbJpxr2TLzFfkG7oWYLoZsD7bh2cOTEMYWR7t1H7QMXNzuFN0tw=w1246-h833.jpg");
        }

        #endregion
    }
}
