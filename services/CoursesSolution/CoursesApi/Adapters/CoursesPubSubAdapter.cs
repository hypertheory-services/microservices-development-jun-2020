using CoursesApi.Domain;


namespace CoursesApi.Adapters;

using Dapr.Client;
using Courses.Messages;

public class CoursesPubSubAdapter
{
    private readonly DaprClient _daprClient;

    public CoursesPubSubAdapter(DaprClient daprClient)
    {
        this._daprClient = daprClient;
    }

    public async Task PublishCourseAsync(Course course)
    {
        await _daprClient.PublishEventAsync("courses", "course", course);
    }
}