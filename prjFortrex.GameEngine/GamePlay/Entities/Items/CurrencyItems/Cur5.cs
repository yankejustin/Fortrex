using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace prjFortrex.GameEngine.GamePlay.Entities.Items.CurrencyItems
{
    class Cur5 : CurrencyBase
    {

        //this'll be an object that'll act as a currency object, valued at five. 
        int value = 5;

        private Bitmap picture =
            new Bitmap(@"..\bitmaps\Currency5.bmp");

    }
}
