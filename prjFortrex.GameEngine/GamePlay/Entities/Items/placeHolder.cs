using System;
using System.Drawing;

namespace prjFortrex.GameEngine.GamePlay.Entities.Items
{
    class PlaceHolder : IItemBase
    {

        //this is a base object, pickup-able, should get added to inventory 


        int id = 00000;
        string name = "Place Holders!!";

        int X;
        int Y;

        Bitmap _PlaceHolder = new Bitmap(@"..\placeHolder.bmp");


        public override void onPickUp(ref dynamic Entity, ref IItemBase item)
        {
            throw new NotImplementedException();
        }
    }
}
