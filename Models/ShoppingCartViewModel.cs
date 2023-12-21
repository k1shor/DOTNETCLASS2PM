using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webapp2pm.Models;

namespace Webapp2pm.Models
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<ShoppingCart> shoppingCarts { get; set; }
        public double total { get; set; }
    }
}
