namespace EriccoreTech.EnterprisePlatform.Data.Model {
    public class StoredRecord {

        public Guid RecordId { get; set; }

        public string RecordType { get; set; } = string.Empty;

        public string Payload { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

    }
}
