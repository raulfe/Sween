using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sween.API.Response;
using Sween.Core.DTOs;
using Sween.Core.Entities;
using Sween.Core.Enumerations;
using Sween.Core.Interfaces;
using System.Threading.Tasks;

namespace Sween.API.Controllers
{
    [Authorize(Roles = nameof(RoleType.Administrator))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IMapper _mapper;

        public SecurityController(ISecurityService securityService, IMapper mapper)
        {
            _securityService = securityService;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> InsertUser(SecurityDTO security)
        {
            var data = _mapper.Map<Security>(security);
            await _securityService.RegisterUser(data);
            security = _mapper.Map<SecurityDTO>(data);
            var response = new ApiResponse<SecurityDTO>(security);
            return Ok(response);
        }
    }
}
