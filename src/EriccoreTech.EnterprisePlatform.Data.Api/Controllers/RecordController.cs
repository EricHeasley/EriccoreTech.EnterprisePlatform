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
        public async Task<SaveRecordResponse> SaveRecord(SaveRecordRequest request, CancellationToken cancellationToken) {
            return await _recordService.SaveRecordAsync(request, cancellationToken);
        }

        [HttpGet]
        public async Task<GetRecordResponse> GetRecord([FromQuery] GetRecordRequest request, CancellationToken cancellationToken) {
            return await _recordService.GetRecordAsync(request, cancellationToken);
        }

    }
}
