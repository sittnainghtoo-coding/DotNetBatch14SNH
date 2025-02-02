using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBatch14SNH.Login.Fearures.Register
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly RegisterService _service;

        public RegisterController(RegisterService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Execute([FromBody] RegisterRequestModel requestModel)
        {
            var response = await _service.Execute(requestModel);

            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
