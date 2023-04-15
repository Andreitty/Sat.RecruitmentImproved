using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Entity.Dtos;
using Sat.Recruitment.Entity.Entities;

namespace Sat.Recruitment.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _service;
		private readonly ILogger<UserController> _logger;

		public UserController(IUserService service, ILogger<UserController> logger)
		{
			_service = service;
			_logger = logger;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetAllUsers()
		{
			try
			{
				var userList = await _service.GetAllUsersAsync();

				if (userList.Any())
				{
					_logger.LogInformation("Getting users list");
					return Ok(new ResultDto<List<User>> { IsSuccess = true, Results = new List<User>(userList) });
				}

				return NotFound(new ResultDto<List<User>> { IsSuccess = false });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new ResultDto<List<User>> { IsSuccess = false, Errors = new[] { ex.Message } });
			}
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> CreateUser([FromBody] User user)
		{
			try
			{
				var createdUser = await _service.AddUserAsync(user);

				if (createdUser.Id > 0)
				{
					_logger.LogInformation($"User with Id number: {createdUser.Id} created.");
					return Ok(new ResultDto<User> { IsSuccess = true, Results = createdUser });
				}

				return BadRequest(new ResultDto<User> { IsSuccess = false });
			}
			catch (DbUpdateException duEx)
			{
				if(duEx.InnerException is SqliteException innerSqLiteException)
					return StatusCode(500, new ResultDto<User> { IsSuccess = false, Errors = new[] { innerSqLiteException.Message } });
				
				return StatusCode(500, new ResultDto<User> { IsSuccess = false, Errors = new[] { duEx.Message } });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new ResultDto<User> { IsSuccess = false, Errors = new[] { ex.Message } });
			}
		}
	}
}