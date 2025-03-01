﻿namespace AcademyApp.Core.Entities;

public class Student : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public string FileName { get; set; }
    public int GroupId { get; set; }
    public Group Group { get; set; }
}
