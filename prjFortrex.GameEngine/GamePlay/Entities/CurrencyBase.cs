using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace prjFortrex.GameEngine.GamePlay.Entities
{
    abstract class CurrencyBase : IItemBase
    {
        int Value;

        private Bitmap Image =
            new Bitmap(@"C:\Users\Andrew\Dropbox\Gam\Fortrex\prjFortrex.GameEngine\GamePlay\Entities\bitmaps\Currency1.bmp");

    }
}
