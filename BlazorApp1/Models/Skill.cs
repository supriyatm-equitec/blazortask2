﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace BlazorApp1.Models;

public partial class Skill
{
    public int SkillId { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Emptbl> Emps { get; set; } = new List<Emptbl>();
}