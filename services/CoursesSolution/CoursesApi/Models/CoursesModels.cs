namespace CoursesApi.Models;

public class GetCoursesItemModel
{
    public string Id { get; set; } = string.Empty;
    public string Title {get; set;} = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
}


public class CollectionModel<T>
{
    public List<T> Data { get; set; } = new();
}