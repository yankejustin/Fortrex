using System.Drawing;


namespace prjFortrex.GameEngine.GamePlay.Entities
{
    abstract class IItemBase
    {

        int id;
        string name;

        //location of item
        int X; 
        int Y;

        //items image
        Bitmap bitmap;

        void onPickUp(/*TODO: Declare Entity that picks it up*/ ref dynamic Entity, ref IItemBase item);
      
        

    }
}
