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
        Point CurrentPosition { get; private set; }
        Rectangle EntitySize { get; private set; }

        virtual void MoveEntity(Direction EntityDirection);
        virtual void MoveEntity(Direction EntityDirection, int speed);
    }

    public abstract class EntityBase : IMobileEntity
    {
        #region IMobileEntity Implementation

        public Point CurrentPosition { get; private set; }
        public Rectangle EntitySize { get; private set; }

        public virtual void MoveEntity(Direction EntityDirection)
        {
            MoveEntity(EntityDirection, 1);
        }

        public virtual void MoveEntity(Direction EntityDirection, int amount)
        {
            Point NextPosition;

            switch (EntityDirection)
            {
                case Direction.Up:
                    NextPosition = new Point(CurrentPosition.X, CurrentPosition.Y + amount);
                    break;
                case Direction.Down:
                    NextPosition = new Point(CurrentPosition.X, CurrentPosition.Y - amount);
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

            // The command to move is sent to the server by the class inheriting this base entity class.
        }

        #endregion

        #region Constructors

        public EntityBase()
        {
            EntitySize = new Rectangle(0, 0, 50, 50);
        }

        public EntityBase(Rectangle size)
        {
            EntitySize = size;
        }

        #endregion
    }
}
