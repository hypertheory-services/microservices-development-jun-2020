using System.ComponentModel.DataAnnotations;

namespace CoursesApi.Models;

public class GetCoursesItemModel
{
    public string Id { get; set; } = string.Empty;
    public string Title {get; set;} = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;

    public int NumberOfDays { get; set; }
}


public class CollectionModel<T>
{
    public List<T> Data { get; set; } = new();
}

public class CourseCreateModel {
    [Required]
    public string Title {get; set;} = string.Empty;
    [Required]
    public string Description {get; set;} = string.Empty;

    [Required]
    public int? NumberOfDays {get; set;} 
 }