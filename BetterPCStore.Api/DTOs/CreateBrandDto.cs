﻿using System.ComponentModel.DataAnnotations;

namespace BetterPCStore.Api.DTOs;

public class CreateBrandDto
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Slug { get; set; }
}