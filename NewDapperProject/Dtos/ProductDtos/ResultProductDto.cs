﻿namespace NewDapperProject.Dtos.ProductDtos;

public class ResultProductDto
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
}