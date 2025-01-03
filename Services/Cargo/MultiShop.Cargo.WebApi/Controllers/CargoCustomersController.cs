using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BuisnessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoDetailService _CargoDetailService;

        public CargoCustomersController(ICargoDetailService CargoDetailService)
        {
            _CargoDetailService = CargoDetailService;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _CargoDetailService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail CargoDetail = new CargoDetail()
            {
                Barcode = createCargoDetailDto.Barcode,
                CargoCompanyId=createCargoDetailDto.CargoCompanyId,
                RecieverCustomer=createCargoDetailDto.RecieverCustomer,
                SenderCustomer=createCargoDetailDto.SenderCustomer,
            };

            _CargoDetailService.TInsert(CargoDetail);
            return Ok("Kargo detayları başarıyla oluşturuldu");
        }

        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _CargoDetailService.TDelete(id);
            return Ok("Kargo detayları başarıyla silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var values = _CargoDetailService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail CargoDetail = new CargoDetail()
            {
                Barcode=updateCargoDetailDto.Barcode,
                CargoCompanyId=updateCargoDetailDto.CargoCompanyId,
                CargoDetailId=updateCargoDetailDto.CargoDetailId,
                RecieverCustomer=updateCargoDetailDto.RecieverCustomer,
                SenderCustomer = updateCargoDetailDto.SenderCustomer,
            };
            _CargoDetailService.TUpdate(CargoDetail);
            return Ok("Kargo detayları başarıyla güncellendi");
        }
    }
}
