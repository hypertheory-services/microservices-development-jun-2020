using CoursesApi.Adapters;
using CoursesApi.Models;

using MongoDB.Driver;

namespace CoursesApi.Domain;

public class CoursesData
{

    private readonly CoursesMongoDbAdapter _adapter;

    public CoursesData(CoursesMongoDbAdapter adapter)
    {
        _adapter = adapter;
    }

    public async Task<CollectionModel<GetCoursesItemModel>> GetAllCoursesAsync()
    {
        var projection = Builders<Course>.Projection.Expression(c => new GetCoursesItemModel {
            Id = c.Id.ToString(),
            Title = c.Title,
            Description = c.Description,
            Category = c.Category
            
        });
        var response = await _adapter.GetCourseCollection().Find(_ => true).Project(projection).ToListAsync();

        return new CollectionModel<GetCoursesItemModel>
        {
            Data = response
        };
    }
}
