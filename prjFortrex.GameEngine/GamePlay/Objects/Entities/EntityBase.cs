using System;
using System.Collections.Generic;
using System.Drawing;
using prjFortrex.GameEngine.GamePlay.Logic.Movement;
using prjFortrex.GameEngine.GamePlay.Objects.Items;

namespace prjFortrex.GameEngine.GamePlay.Objects.Entities
{
    public interface IMobileEntity
    {
        Point CurrentPosition { get; set; }

        void MoveEntity(Direction EntityDirection);
        void MoveEntity(Direction EntityDirection, int speed);

        event EventHandler<EntityMovingEventArgs> EntityMoving;
        event EventHandler<EntityMovedEventArgs> EntityMoved;
    }

    public class EntityMovingEventArgs : EventArgs
    {
        public EntityMovingEventArgs(Point _CurrentLocation, Point _DesiredLocation)
        {
            CurrentLocation = _CurrentLocation;
            DesiredLocation = _DesiredLocation;
        }

        public Point CurrentLocation { get; private set; }
        public Point DesiredLocation { get; private set; }
    }

    public class EntityMovedEventArgs : EventArgs
    {
        public EntityMovedEventArgs(Point _NewLocation)
        {
            NewLocation = _NewLocation;
        }

        public Point NewLocation { get; private set; }
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

            OnEntityMoving(new EntityMovingEventArgs(CurrentPosition, NextPosition));

            CurrentPosition = NextPosition;
            EntitySize.X = CurrentPosition.X;
            EntitySize.Y = CurrentPosition.Y;

            OnEntityMoved(new EntityMovedEventArgs(CurrentPosition));

            // The command to move is sent to the server by the class inheriting this base entity class?
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
            EntityPicture = Properties.Resources.placeHolder;
        }

        protected EntityBase(Rectangle size)
        {
            EntitySize = size;
            EntityPicture = Properties.Resources.placeHolder;
        }

        #endregion

        #region Properties

        public Image EntityPicture { get; set; }


        public int CurrencyCount { get; set; }


        public List<ItemBase> inventoryList = new List<ItemBase>();

        #endregion

        #region Events

        public event EventHandler<EntityMovingEventArgs> EntityMoving;
        public event EventHandler<EntityMovedEventArgs> EntityMoved;

        protected virtual void OnEntityMoving(EntityMovingEventArgs e)
        {
            if (EntityMoving != null)
            {
                EntityMoving(this, e);
            }
        }

        protected virtual void OnEntityMoved(EntityMovedEventArgs e)
        {
            if (EntityMoved != null)
            {
                EntityMoved(this, e);
            }
        }

        #endregion
    }
}