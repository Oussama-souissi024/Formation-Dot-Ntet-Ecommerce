﻿namespace Formationn_Ecommerce.Models.Coupon
{
    public class DeleteCouponViewModel
    {
        public Guid Id { get; set; }
        public string CouponCode { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal MinimumAmount { get; set; }
    }
}
