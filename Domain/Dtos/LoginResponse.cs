﻿namespace Domain.Dtos;

public class LoginResponse
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? FullName => $"{FirstName} {LastName}";
}