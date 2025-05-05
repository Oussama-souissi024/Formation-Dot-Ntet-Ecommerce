using AutoMapper;
using Formationn_Ecommerce.Application.Coupons.Dtos;
using Formationn_Ecommerce.Application.Coupons.Interfaces;
using Formationn_Ecommerce.Core.Entities.Coupon;
using Formationn_Ecommerce.Core.Interfaces.Repositories;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V133.CSS;

namespace Formationn_Ecommerce.Application.Coupons.Services
{
    public class CouponServices : ICouponService
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IMapper _mapper;

        public CouponServices(ICouponRepository couponRepository, IMapper mapper)
        {
            _couponRepository = couponRepository;
            _mapper = mapper;
        }
        public async Task<CouponDto> AddAsync(CouponDto couponDto)
        {
            //Mapper le DTO vers l'entité Coupon
            var coupon = _mapper.Map<Coupon>(couponDto);

            // Appeler le repository avec l'entité
            var addedCoupon = await _couponRepository.AddAsync(coupon);

            //Retourner le résultat mapé en Dto
            return _mapper.Map<CouponDto>(addedCoupon);
        }

        public async Task<CouponDto> ReadByIdAsync(Guid couponId)
        {
            var coupon = await _couponRepository.ReadByIdAsync(couponId);
            if(coupon == null)
            {
                throw new NotFoundException("Coupon Not Found");
            }
            return _mapper.Map<CouponDto>(coupon);
        }

        public async Task<CouponDto> GetCouponByCodeAsync(string couponCode)
        {
            var coupon = await _couponRepository.ReadByCouponCodeAsync(couponCode);
            if(coupon == null)
            {
                throw new NotFoundException("Coupon Not Found");
            }
            return _mapper.Map<CouponDto>(coupon);
        }

        public async Task<IEnumerable<CouponDto>> ReadAllAsync()
        {
            var couponList = await _couponRepository.ReadAllAsync();
            return _mapper.Map<IEnumerable<CouponDto>>(couponList);
        }

        public async Task UpdateAsync(UpdateCouponDto updateCouponDto)
        {
            // Vérifier que le coupon existe
            var existingCoupon = _couponRepository.ReadByIdAsync(updateCouponDto.Id);
            if(existingCoupon == null)
            {
                throw new NotFoundException("Coupon Not Found");
            }
            // Mapper le DTO vers l'entité Coupon
            var couponToUpdate = _mapper.Map<Coupon>(updateCouponDto);

            // Mettre à jour l'entité dans le repository
            await _couponRepository.UpdateAsync(couponToUpdate);
        }

        public async Task DeleteAsync(Guid id)
        {
            // Vérifier que le coupon existe
            var Coupon = _couponRepository.ReadByIdAsync(id);
            if(Coupon == null)
            {
                throw new NotFoundException("Coupon Not Found");
            }
            // Supprimer le coupon
            await _couponRepository.DeleteAsync(id);
        }
    }
}
