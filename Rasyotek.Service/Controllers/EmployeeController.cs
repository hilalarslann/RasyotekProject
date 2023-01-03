using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rasyotek.DTO;
using Rasyotek.Entities.Concrete;
using Rasyotek.Service.HttpResponse;
using Rasyotek.Uow;

namespace Rasyotek.Service.Controllers
{
    [Route("/[controller]/[action]")]

    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IUow _uow;
        Response _response;
        public EmployeeController(Response response, IUow uow)
        {
            _response = response;
            _uow = uow;
        }

        [HttpPost]
        public ActionResult<Response> Add([FromBody] EmployeeDTO employee)
        {
            try
            {
                var result = _uow._EmployeeRep.AddEmployee(employee);
                _uow.Commit();
                if (result != null)
                {
                    foreach (var item in employee.DebitIdList)
                    {
                        _uow._DebitDetailRep.Add(new EmployeeDebits
                        {
                            DebitId =item,
                            EmployeeId = result.Id
                        });
                    }
                    
                    _uow.Commit();
                }
                _response.Error = false;
                _response.Msg = "Başarılı eklendi";
               
            }
            catch (Exception ex)
            {
                _response.Error = true;
                _response.Msg = ex.Message;
                throw;
            }
            return Ok(_response);
        }

        [HttpGet]
        public List<EmployeeModel> List()
        {
            var emp =_uow._EmployeeRep.Set()
                .Include(x=>x.EmployeeDebits)
                .ThenInclude(x=>x.Debit)
                .Select(x=>new EmployeeModel
                {
                    Id = x.Id,
                    Gender = x.Gender,
                    GraduatedSchool = x.GraduatedSchool,
                    Name = x.Name,
                    Surname = x.Surname,
                    EmployeeDebits = x.EmployeeDebits
                })
                .ToList();
            return emp;
        }

        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            try
            {
                _uow._EmployeeRep.Delete(id);
                _response.Error = false;
                _response.Msg = "Başarı ile silindi";
                _uow.Commit();
            }
            catch (Exception ex)
            {
                _response.Error = false;
                _response.Msg = ex.Message;
                throw;
            }
            return _response;
        }

        [HttpPut("{id}")]
        public Response Update(int id, EmployeeDTO empDTO)
        {
            try
            {
                _uow._EmployeeRep.UpdateEmployee(id, empDTO);
                _uow.Commit();
                _response.Error = false;
                _response.Msg = "Güncellendi";
            }
            catch (Exception ex)
            {
                _response.Error = true;
                _response.Msg = ex.Message;
                throw;
            }

            return _response;
        }

        [HttpGet("{id}")]
        public async Task<EmployeeModel> GetById(int id)
        {

            var emp = await _uow._EmployeeRep.Set()
                .Include(x => x.EmployeeDebits)
                .ThenInclude(x => x.Debit)
                .Select(x => new EmployeeModel
                {
                    Id = x.Id,
                    Gender = x.Gender,
                    GraduatedSchool = x.GraduatedSchool,
                    Name = x.Name,
                    Surname = x.Surname,
                    EmployeeDebits = x.EmployeeDebits
                })
                .Where(x=>x.Id == id)
                .FirstOrDefaultAsync();
            return emp!;
        }
    }
}
