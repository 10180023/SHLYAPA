using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООО_Стройматериалы
{
    public partial class Product
    {
        public string validImage => ProductPhoto == null ? "../../Resources/picture.png" : "../../Img/" + ProductPhoto;

        public string validColor
        {
            get
            {
                if (ProductQuantityInStock == 0)
                {
                    return "#808080";
                }

                return "";
            }
        }
    }
}
