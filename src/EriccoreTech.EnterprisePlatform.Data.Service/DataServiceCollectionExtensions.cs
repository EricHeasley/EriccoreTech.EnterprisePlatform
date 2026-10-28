using Microsoft.Extensions.DependencyInjection;

namespace EriccoreTech.EnterprisePlatform.Data.Service {
    public static class DataServiceCollectionExtensions {

        private const int QueueCapacity = 10000;

        public static IServiceCollection AddRecordServices(this IServiceCollection services, string connectionString) {
            services.AddSingleton(new PendingRecordStore(QueueCapacity));
            services.AddSingleton<Contracts.IRecordRepository>(new SqlRecordRepository(connectionString));
            services.AddSingleton<Contracts.IRecordService, RecordService>();
            services.AddHostedService<RecordWriter>();

            return services;
        }

    }
}
