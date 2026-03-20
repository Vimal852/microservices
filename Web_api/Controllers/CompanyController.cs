using Application.DTOs;
using Application.Interfaces;
using Domain.Modal;
using Microsoft.AspNetCore.Mvc;

namespace Web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiVersion("1")]
    //[Route("v{version:apiVersion}/[controller]")]

    public class CompanyController(ICompanyService companyService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> AddCompany(CompanyDTOs dto)
        {
            await companyService.AddAsync(dto);
            return Ok();
        }

        [HttpGet("Get/all")]
        public async Task<IActionResult> GetCompany()
        {
            var company = await companyService.GetCompanyAsync();
            return Ok(company);
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            var company = await companyService.GetCompanyByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCompanyById(int id)
        {
            var company = await companyService.DeleteCompanybyidAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateCompany(Company company)
        {
            await companyService.UpdateAsync(company);
            return Ok();
        }


    }
}