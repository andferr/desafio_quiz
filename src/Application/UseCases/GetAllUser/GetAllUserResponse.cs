﻿namespace Application.UseCases.GetAllUser;

public sealed record GetAllUserResponse
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Name { get; set; }
}
