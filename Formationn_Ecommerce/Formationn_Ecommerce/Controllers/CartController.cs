using System.Runtime.InteropServices;
using AutoMapper;
using Formationn_Ecommerce.Application.Cart.Dtos;
using Formationn_Ecommerce.Application.Cart.Interfaces;
using Formationn_Ecommerce.Core.Entities.Identity;
using Formationn_Ecommerce.Models.Cart;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Formationn_Ecommerce.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;
        public CartController(ICartService cartService,
                              SignInManager<ApplicationUser> signInManager,
                              IMapper mapper)
        {
            _cartService = cartService;
            _signInManager = signInManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> CartIndex()
        {
            var cartDto = await LoadCartDtoBasedOnLoggedInUser();
            if(cartDto == null)
            {
                return View(new CartIndexViewModel());
            }
            CartIndexViewModel cartIndexViewModel = _mapper.Map<CartIndexViewModel>(cartDto);
            return View(cartIndexViewModel);
        }

        private async Task<CartDto> LoadCartDtoBasedOnLoggedInUser()
        {
            // Retrive the user from SinInManager
            var user = await _signInManager.UserManager.GetUserAsync(User);

            if (string.IsNullOrEmpty(user.Id))
            {
                return new CartDto();
            }

            CartDto? cart = await _cartService.GetCartByUserIdAsync(user.Id);

            if (cart == null)
            {
                return new CartDto();
            }

            return cart;
        }
    }
}
