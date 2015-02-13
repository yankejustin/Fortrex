
using System.Drawing;

namespace prjFortrex.GameEngine.GamePlay.Entities.Items.CurrencyItems
{
    class Cur1 : CurrencyBase
    {

        #region Constuctors

        public Cur1(int x, int y)
            : base(
                x, y, 1, "1 Gold",
                Image.FromFile(@"..\..\Bitmaps\Currency1.bmp)"), Image.FromFile(@"..\..\Bitmaps\Currency1.bmp"))
        {
        }

        #endregion
    }
}
