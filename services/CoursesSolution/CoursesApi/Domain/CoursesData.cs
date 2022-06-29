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
            Category = c.Category,
            NumberOfDays = c.NumberOfDays
            
        });
        var response = await _adapter.GetCourseCollection().Find(_ => true).Project(projection).ToListAsync();

        return new CollectionModel<GetCoursesItemModel>
        {
            Data = response
        };
    }

    public async Task<GetCoursesItemModel> AddCourseToServicesAsync(CourseCreateModel request)
    {
        var course = new Course {
            Title = request.Title,
            Description = request.Description,
            Category = "Services",
            NumberOfDays = request.NumberOfDays!.Value,
            PositionInCategory = 0

        };

        await _adapter.GetCourseCollection().InsertOneAsync(course);

        var response = new GetCoursesItemModel {
            Id = course.Id.ToString(),
            Title = course.Title,
            Category = course.Category,
            Description = course.Description
        };
        return response;
    }

    public async Task<GetCoursesItemModel> AddCourseToAngularAsync(CourseCreateModel request)
    {
        var course = new Course {
            Title = request.Title,
            Description = request.Description,
            Category = "Angular",
            NumberOfDays = request.NumberOfDays!.Value,
            PositionInCategory = 0

        };

        await _adapter.GetCourseCollection().InsertOneAsync(course);

        var response = new GetCoursesItemModel {
            Id = course.Id.ToString(),
            Title = course.Title,
            Category = course.Category,
            Description = course.Description
        };
        return response;
    }
}
