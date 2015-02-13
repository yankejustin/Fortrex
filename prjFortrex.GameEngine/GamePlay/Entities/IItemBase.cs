using System;
using System.Drawing;


namespace prjFortrex.GameEngine.GamePlay.Entities
{
    public abstract class ItemBase : IDisposable
    {
        #region Constructors

        protected ItemBase(int x, int y)
        {
            id = 00000;
            name = "Item";

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

        int id { get; set; }
        string name { get; set; }

        //location of item
        int X { get; set; }
        int Y { get; set; }

        //items image
        Image image { get; set; }
        Image Icon { get; set; }
        

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
                image.Dispose();
                Icon.Dispose();
            }
        }
        #endregion


        void OnPickUp(ref EntityBase entity, ref ItemBase item)
        {
            entity.inventoryList.Add(item);
            item.Dispose();
        }
    }
}
