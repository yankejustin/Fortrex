using System;
using System.Drawing;
using System.Collections.Generic;

namespace prjFortrex.GameEngine.GamePlay.Entities
{
    public interface IItemBase
    {
        int ID { get; set; }
        string Name { get; set; }
        int Cost { get; set; }

        string Path { get; set; }

        List<IItemBase> Recipe { get; set; }
    }

    public abstract class ItemBase : IItemBase, IDisposable
    {
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
                image.Dispose();
                Icon.Dispose();
            }
        }

        #endregion

        #region IItemBase Implementation

        public int ID { get; set; }
        public string Name { get; set; }
        public int CombinationCost { get; set; }
        
        public string Path { get; set; }

        // This list can hold any item that can implement the IItemBase interface.
        public virtual List<IItemBase> Recipe { get; set; }

        #endregion

        #region Constructors

        protected ItemBase(int x, int y)
        {
            ID = 00000;
            Name = "Item";

            //TODO: Adjust these values to be more accurate based on real entities;
            image = new Bitmap(50, 50);
            Icon = new Bitmap(10, 10);


            //"this" for clarification
            this.X = x;
            this.Y = y;
        }


        protected ItemBase(int x, int y, string name)
        {
            id = 00000;
            this.name = name;

            //TODO: Adjust these values to be more accurate based on real entities;
            image = new Bitmap(50, 50);
            Icon = new Bitmap(10, 10);

            //"this" for clarification
            this.X = x;
            this.Y = y;
        }


        protected ItemBase(int x, int y, string name, Image Icon, Image image)
        {
            //"this" for clarification

            this.id = 00000;
            this.name = name;
            this.image = image;
            this.Icon = Icon;
            this.X = x;
            this.Y = y;
        }

        #endregion

        #region Properties
        
        // Location of item.
        Point ItemLocation { get; set; }

        // The item's image.
        Image image { get; set; }
        Image Icon { get; set; }

        #endregion

        // Events to add:
        // OnItemPickup
        // 
    }
}
