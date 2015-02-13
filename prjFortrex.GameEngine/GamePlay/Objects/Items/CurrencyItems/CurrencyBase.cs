using System.ComponentModel;
using System.Drawing;

namespace prjFortrex.GameEngine.GamePlay.Entities
{
    abstract class CurrencyBase : ItemBase
    {
        #region Constructors

        protected CurrencyBase(int x, int y, int value, string name, Image Icon, Image image)
            : base(x, y, name, Icon, image)
        {
            this.Value = value;
        }

        #endregion

        #region Properties

        int Value { get; set; }

        #endregion
    }
}