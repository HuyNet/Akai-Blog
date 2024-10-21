﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Domian.Identity
{
    [Table("AppRoles")]
    public class AppRole : IdentityRole<Guid>
    {
        [Required]
        [MaxLength(200)]
        public required string DisplayName { get; set; }
    }
}
