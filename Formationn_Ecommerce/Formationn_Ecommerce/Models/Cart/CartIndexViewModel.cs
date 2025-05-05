using Formationn_Ecommerce.Application.Cart.Dtos;

namespace Formationn_Ecommerce.Models.Cart
{
    public class CartIndexViewModel
    {
        public CartHeaderDto CartHeader { get; set; }
        public IEnumerable<CartDetailsDto> CartDetails { get; set; }

    }
}
