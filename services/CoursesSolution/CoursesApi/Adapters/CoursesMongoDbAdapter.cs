using CoursesApi.Domain;

using HypertheoryApiUtils;

using Microsoft.Extensions.Options;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;

namespace CoursesApi.Adapters;

public class CoursesMongoDbAdapter
{
    private readonly IMongoCollection<Course> _coursesCollection;
    private readonly ILogger<CoursesMongoDbAdapter> _logger;

    public CoursesMongoDbAdapter(ILogger<CoursesMongoDbAdapter> logger, IOptions<MongoConnectionOptions> options)
    {
        _logger = logger;

        _logger.LogInformation(options.Value.ConnectionString);

        var clientSettings = MongoClientSettings.FromConnectionString(options.Value.ConnectionString);
        if(options.Value.LogCommands)
        {
            clientSettings.ClusterConfigurator = db =>
            {
                db.Subscribe<CommandStartedEvent>(e =>
                {
                    using (_logger.BeginScope("Mongo Command Execution"))
                    {
                        _logger.LogInformation($"Running {e.CommandName}");
                        _logger.LogInformation(e.Command.ToJson());
                    }
                });
            };
        }

        var conn = new MongoClient(clientSettings);
        var db = conn.GetDatabase(options.Value.Database);
        _coursesCollection = db.GetCollection<Course>(options.Value.Collection);
    }

    public IMongoCollection<Course> GetCourseCollection() => _coursesCollection;
}
