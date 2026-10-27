using EriccoreTech.EnterprisePlatform.Data.Model;

namespace EriccoreTech.EnterprisePlatform.Data.Service {
    public class RecordService : Contracts.IRecordService {

        public SaveRecordResponse SaveRecord(SaveRecordRequest request) {
            if (request is null) {
                throw new ArgumentNullException(nameof(request));
            }

            // implement behavior here
            throw new NotImplementedException();
        }

    }
}
