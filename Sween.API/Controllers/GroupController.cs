using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sween.API.Response;
using Sween.Core.DTOs;
using Sween.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sween.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;

        public GroupController(IGroupService groupService,IMapper mapper)
        {
            _groupService = groupService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroup(int id)
        {
            var gr = await _groupService.GetGroup(id);
            if (gr == null)
            {
                return NotFound();
            }
            return Ok(gr);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> InsertGroup(int id, GroupDTO gr)
        {
            gr.IdGroup = id;
            await _groupService.InsertGroup(gr);
            return Ok(gr);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {

            var result = await _groupService.DeleteGroup(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
