using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record RegisterRequest(
       [Required] string FullName,
       [Required][EmailAddress] string Email,
       [Required][MinLength(6)] string Password,
       [Required] int CompanyId,
       string? Role = "User"
   );
}
