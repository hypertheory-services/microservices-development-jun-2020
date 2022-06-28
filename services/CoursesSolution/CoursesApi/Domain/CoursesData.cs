using CoursesApi.Adapters;

using MongoDB.Driver;

namespace CoursesApi.Domain;

public class CoursesData
{

    private readonly CoursesMongoDbAdapter _adapter;

    public CoursesData(CoursesMongoDbAdapter adapter)
    {
        _adapter = adapter;
    }

    public async Task<List<Course>> GetAllCoursesAsync()
    {
        var response = await _adapter.GetCourseCollection().Find(_ => true).ToListAsync();

        return response;
    }
}
