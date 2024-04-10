namespace Student_Portal_MVC_Dotnet_core.Models.Entities;

public class Student
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public bool Subscribed { get; set; }
}