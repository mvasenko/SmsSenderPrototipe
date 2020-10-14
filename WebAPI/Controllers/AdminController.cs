using System.Net;
using AutoMapper;
using BLL.Contracts.DTObjects;
using BLL.Contracts.Managers;
using Contracts.Requests;
using Contracts.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : DefaultController
    {
        private readonly IAuthenticationManager _authenticationManager;

        private readonly IMapper _mapper;

        public AdminController(
            IAuthenticationManager authenticationManager,
            IMapper mapper)
        {
            _authenticationManager = authenticationManager;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        public IActionResult Index()
        {
            return Ok(new ApiResponse<string>
            {
                StatusCode = HttpStatusCode.OK,
                Data = nameof(Index)
            });
        }

        [HttpPost("SendInvites")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        public IActionResult SendInvites([FromBody] SendInvitesRequest request)
        {
            return CallBusinessLogicAction(() =>
            {
                _authenticationManager.SendInvites(_mapper.Map<SendInvitesDto>(request));
                return new ApiResponse<string>
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = "Все приглашения отправлены."
                };
            });
        }
    }
}