using System;
using System.Collections.Generic;
using System.Drawing;
using prjFortrex.GameEngine.GamePlay.Logic.Movement;

namespace prjFortrex.GameEngine.GamePlay.Objects
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

        #region Constructors

        protected EntityBase()
        {
            EntitySize = new Rectangle(0, 0, 50, 50);
            EntityPicture = Image.FromFile("C:\\Users\\jyanke\\Desktop\\KsmaBg1xIs3JuKuee6QzbJpxr2TLzFfkG7oWYLoZsD7bh2cOTEMYWR7t1H7QMXNzuFN0tw=w1246-h833.jpg");
        }

        protected EntityBase(Rectangle size)
        {
            EntitySize = size;
            EntityPicture = Image.FromFile("C:\\Users\\jyanke\\Desktop\\KsmaBg1xIs3JuKuee6QzbJpxr2TLzFfkG7oWYLoZsD7bh2cOTEMYWR7t1H7QMXNzuFN0tw=w1246-h833.jpg");


        }

        #endregion

        #region Properties

        public Image EntityPicture { get; set; }


        public int CurrencyCount { get; set; }
        

        public List<ItemBase> inventoryList = new List<ItemBase>();

        


        #endregion
    }
}