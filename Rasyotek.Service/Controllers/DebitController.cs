using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rasyotek.DTO;
using Rasyotek.Entities.Concrete;
using Rasyotek.Service.HttpResponse;
using Rasyotek.Uow;
using System.Diagnostics;

namespace Rasyotek.Service.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class DebitController : ControllerBase
    {
        IUow _uow;
        Response _response;
        public DebitController(Response response, IUow uow)
        {
            _response = response;
            _uow = uow;
        }

        [HttpPost]
        public Response AddDebit()
        {
            try
            {
                _uow._DebitRep.AddDebit();
                _response.Error = false;
                _response.Msg = "Başarı ile eklendi";
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

        [HttpGet]
        public List<Debit> GetDebits() 
        {
            return _uow._DebitRep.List();
        }

        [HttpGet("{id:int}")]
        public List<DebitDetailDTO> GetDebitDetails(int id)
        {
            return _uow._DebitDetailRep.ListDebitDetail(id);
        }
    }
}
