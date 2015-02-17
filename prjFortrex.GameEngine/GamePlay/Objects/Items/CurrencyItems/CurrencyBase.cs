using System.ComponentModel;
using System.Drawing;

namespace prjFortrex.GameEngine.GamePlay.Objects.Items.CurrencyItems
{
    abstract class CurrencyBase : ItemBase
    {
        #region Constructors

        protected CurrencyBase(Point location, int value, string name, Image Icon, Image image)
            : base(name, Icon, image)
        {
            this.Value = value;
        }

        #endregion

        #region Properties

        int Value { get; set; }

        #endregion
    }
}