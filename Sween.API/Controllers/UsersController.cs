using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sween.API.Response;
using Sween.Core.CustomEntities;
using Sween.Core.DTOs;
using Sween.Core.Entities;
using Sween.Core.Interfaces;
using Sween.Core.QueryFilters;
using Sween.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Sween.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriServicer;

        public UsersController(IUserService userService, IMapper mapper, IUriService uriServicer)
        {
            _userService = userService;
            _mapper = mapper;
            _uriServicer = uriServicer;
        }

        [HttpGet("GetUsersByCredential/{nick}/{password}")]
        public async Task<IActionResult> GetUserByCredentials(string nick, string password)
        {
            User data = await _userService.GetUserByCredentials(nick, password);
            var ndata = _mapper.Map<UserDTO>(data);

            if (data == null)
            {
                return NotFound();
            }
            return Ok(ndata);
        }

        /// <summary>
        /// Retrieve all Users
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetUsers))]
        [ProducesResponseType((int)HttpStatusCode.OK,Type = typeof(ApiResponse<IEnumerable<UserDTO>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public  IActionResult GetUsers([FromQuery]UserQueryFilter filters)
        {
            var data =  _userService.GetUsers(filters);
            var ndata = _mapper.Map<IEnumerable<UserDTO>>(data);
            var metadata = new Metadata
            {
                TotalCount = data.TotalCount,
                PageSize = data.PageSize,
                CurrentPage = data.CurrentPage,
                TotalPages = data.TotalPages,
                HasNextPage = data.HasNextPage,
                HasPreviousPage = data.HasPreviousPage,
                NextPageURL = _uriServicer.GetUserPaginationUri(filters, Url.RouteUrl(nameof(GetUsers))).ToString()
            };

            var response = new ApiResponse<IEnumerable<UserDTO>>(ndata) { Meta = metadata};
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            User data = await _userService.GetUser(id);
            var ndata = _mapper.Map<UserDTO>(data);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(ndata);
        }


        [HttpPost]
        public async Task<IActionResult> InsertUser(UserDTO ndata)
        {
            var data = _mapper.Map<User>(ndata);
            await _userService.InsertUser(data);
            return Ok(ndata);
        }

        [HttpPut]
        public async Task<IActionResult> PutUser(int id, UserDTO ndata) 
        {
            
            ndata.IdUser = id;
            var result = await _userService.PutUser(ndata);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            
            var result = await _userService.DeleteUser(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
