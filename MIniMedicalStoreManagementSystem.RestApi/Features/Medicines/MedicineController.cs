using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MIniMedicalStoreManagementSystem.RestApi.Features.Medicines
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {

        private readonly IMedicineService _medicineService;

        public MedicineController()
        {
            _medicineService = new MedicineService();
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] MedicineModel requestModel)
        {
            var model = _medicineService.CreateProduct(requestModel);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }
            return Ok(model);
        }

        [HttpGet]
        public IActionResult GetMedicines()
        {
            var model = _medicineService.GetMedicines();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetMedicine(string id)
        {
            var model = _medicineService.GetMedicine(id);
            if (model is null)
            {
                return NotFound("No data Found");
            }
            return Ok(model);
        }

        

        [HttpPut("{id}")]
        public IActionResult UpdateMedicine(string id, MedicineModel requestModel)
        {
            requestModel.MedicineId = id;

            var model = _medicineService.UpdateMedicine(requestModel);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMedicine(string id, MedicineModel requestModel)
        {

            requestModel.MedicineId = id;
            var model = _medicineService.DeleteMedicine(id);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }
            return Ok(model);
        }

    }
}
