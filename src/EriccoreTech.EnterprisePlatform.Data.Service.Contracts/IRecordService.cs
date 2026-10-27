using EriccoreTech.EnterprisePlatform.Data.Model;

namespace EriccoreTech.EnterprisePlatform.Data.Service.Contracts {
    public interface IRecordService {

        SaveRecordResponse SaveRecord(SaveRecordRequest request);

    }
}
