﻿namespace Entities.DTOs.Review;

public class ReviewPostDto : IDto
{
    public string Comment { get; set; }
    public Rating Rating { get; set; }

    //Relations
    public string UserId { get; set; }
    public int BlogId { get; set; }
}