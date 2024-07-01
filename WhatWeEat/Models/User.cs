using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WhatWeEat.Models
{
    public class User
    {
        public long Id { get; init; }
        
        [MaxLength(64)]
        public string Name { get; init; }
        
        [MaxLength(64)]
        public string Email { get; init; }

        public ICollection<EatRecord> EatRecords { get; init; } = new List<EatRecord>();
    }
}