using System;
using System.Collections.Generic;
using System.Text;
using WebApi.DTO.ShoppingCart;

namespace WebApi.Services
{
    interface IShoppingCartService
    {
        IEnumerable<ShoppingItemDTO> GetAllItems();

        ShoppingItemDTO Add(ShoppingItemDTO newItem);
    }
}
