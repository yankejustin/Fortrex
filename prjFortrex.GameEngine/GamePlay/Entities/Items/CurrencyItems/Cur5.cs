
using System.Drawing;

namespace prjFortrex.GameEngine.GamePlay.Entities.Items.CurrencyItems
{
    class Cur5 : CurrencyBase
    {

        #region Constuctors

        public Cur5(int x, int y)
            : base(
                x, y, 5, "5 Gold",
                Image.FromFile(@"..\..\Bitmaps\Currency5.bmp)"), Image.FromFile(@"..\..\Bitmaps\Currency5.bmp"))
        {
        }

        #endregion
    }
}
