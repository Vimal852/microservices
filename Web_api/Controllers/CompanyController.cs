using Application.DTOs;
using Application.Interfaces;
using Domain.Modal;
using Microsoft.AspNetCore.Mvc;

namespace Web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController(ICompanyService companyService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> AddCompany(CompanyDTOs dto)
        {
            await companyService.AddAsync(dto);
            return Ok();
        }
    }
}