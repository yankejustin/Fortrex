using System;
using System.Drawing;
using System.Collections.Generic;

namespace prjFortrex.GameEngine.GamePlay.Objects.Items
{
    public interface IItemBase
    {
        int ID { get; set; }
        string Name { get; set; }
        int CombinationCost { get; set; }

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

            // TODO: Adjust these values to be more accurate based on real entities;
            image = new Bitmap(50, 50);
            Icon = new Bitmap(10, 10);
        }

        protected ItemBase(string name)
        {
            this.Name = name;

            // TODO: Adjust these values to be more accurate based on real entities;
            image = new Bitmap(50, 50);
            Icon = new Bitmap(10, 10);
        }


        protected ItemBase(string name, Image _Icon, Image _image)
        {
            // "this" for clarification.
            this.Name = name;
            
            // TODO: Check to see if the "Icon" and "image" parameters should or should not be disposed after giving the values
            // to the properties of this class...
            this.image = _image;
            this.Icon = _Icon;
        }

        #endregion

        #region Properties
        
        // Location of item.
        Point ItemLocation { get; set; }

        // The item's image.
        Image image { get; set; }
        Image Icon { get; set; }

        #endregion

        // Events to come...
    }
}
