using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sween.API.Response;
using Sween.Core.DTOs;
using Sween.Core.Entities;
using Sween.Core.Interfaces;
using Sween.Infrastructure.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sween.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }


        [HttpGet("{id}")]
        public  async Task<IActionResult> GetMessage(int id)
        {
            var ms = await _messageService.GetMessages(id);
            if(ms == null)
            {
                return NotFound();
            }
            return Ok(ms);
        }

        [HttpGet("{iduser}/{idmessage}")]
        public async Task<IActionResult> GetMessageByUser(int iduser,int idmessage)
        {
            var ms = await _messageService.GetMessagesByUser(iduser,idmessage);
            if (ms == null)
            {
                return NotFound();
            }
            return Ok(ms);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> PostMessage(int id, MessageDTO ms)
        {
             await _messageService.InsertMessages(id,ms);
            return Ok(ms);
        }

        [HttpDelete("{iduser}/{idmessage}")]
        public async Task<IActionResult> DeleteMessage(int iduser,int idmessage)
        {

            var result = await _messageService.DeleteMessage(iduser, idmessage);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
