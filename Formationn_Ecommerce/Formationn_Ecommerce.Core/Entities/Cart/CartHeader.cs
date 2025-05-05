using Formationn_Ecommerce.Core.Common;
using Formationn_Ecommerce.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formationn_Ecommerce.Core.Entities.Cart
{
    // Classe qui représente l'en-tête d'un panier d'achat, contenant les informations générales du panier
    public class CartHeader : BaseEntity
    {
        // Identifiant de l'utilisateur propriétaire du panier (clé étrangère)
        [Required]
        [ForeignKey("User")]
        public string UserID { get; set; }

        // Code de coupon de réduction appliqué au panier
        public string CouponCode { get; set; }

        // Référence à l'utilisateur propriétaire du panier (relation many-to-one)
        public ApplicationUser User { get; set; }

        // Collection des détails du panier associés à cet en-tête (relation one-to-many)
        public ICollection<CartDetails> CartDetails { get; set; }
    }
}
