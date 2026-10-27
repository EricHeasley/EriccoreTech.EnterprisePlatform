using Microsoft.AspNetCore.Mvc;
using EriccoreTech.EnterprisePlatform.Data.Model;
using EriccoreTech.EnterprisePlatform.Data.Service.Contracts;

namespace EriccoreTech.EnterprisePlatform.Data.Api.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class RecordController : ControllerBase {

        private readonly IRecordService _recordService;

        public RecordController(IRecordService recordService) {
            _recordService = recordService;
        }

        [HttpPost]
        public SaveRecordResponse SaveRecord(SaveRecordRequest request) {
            return _recordService.SaveRecord(request);
        }

    }
}
