using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sween.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sween.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersGroupController : ControllerBase
    {
        private readonly IMessageService _messageRepository;
        private readonly IMapper _mapper;

        public UsersGroupController(IMessageService messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }



    }
}
