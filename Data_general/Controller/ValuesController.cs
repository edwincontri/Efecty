using Data_general.Interface;
using Data_general.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Data_general.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly IDataInterface _dataInterface;

        public ValuesController(IDataInterface dataInterface)
        {
            _dataInterface = dataInterface;       
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _dataInterface.GetData();
            return Ok(data);
        }
                
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DataPersonal value)
        {
            try
            {
                if (value.valorGanar < 0)
                    return BadRequest("valorno valido");

                await _dataInterface.PostData(value);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }
        
        [HttpDelete("{nombre}")]
        public async Task<IActionResult> Delete(string nombre)
        {
            await _dataInterface.DelData(nombre);
            return Ok(); 
        }
    }
}
