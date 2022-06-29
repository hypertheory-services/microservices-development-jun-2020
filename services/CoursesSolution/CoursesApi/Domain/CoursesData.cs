using CoursesApi.Adapters;
using CoursesApi.Models;

using MongoDB.Driver;

namespace CoursesApi.Domain;

public class CoursesData
{

    private readonly CoursesMongoDbAdapter _adapter;
    private readonly CoursesPublish _publisher;

    public CoursesData(CoursesMongoDbAdapter adapter, CoursesPublish publisher)
    {
        _adapter = adapter;
        _publisher = publisher;
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
        var category = "Services";
        return await SaveCourse(request, category);
    }

    private async Task<GetCoursesItemModel> SaveCourse(CourseCreateModel request, string category)
    {
        var course = new Course
        {
            Title = request.Title,
            Description = request.Description,
            Category = category,
            NumberOfDays = request.NumberOfDays!.Value,
            PositionInCategory = 0

        };

        await _adapter.GetCourseCollection().InsertOneAsync(course);
        // await _adapter.GetCourseCollection().ReplaceOneAsync(c => c.Id == course.Id, course, new ReplaceOptions { IsUpsert = true});
        var response = new GetCoursesItemModel
        {
            Id = course.Id.ToString(),
            Title = course.Title,
            Category = course.Category,
            Description = course.Description
        };

        await _publisher.PublishCourseAsync(course);
        return response;
    }

    public async Task<GetCoursesItemModel> AddCourseToAngularAsync(CourseCreateModel request)
    {
        return await SaveCourse(request, "Angular");
    }
}
