﻿using Microsoft.AspNetCore.Mvc;
using NIFTWebApp.Modules.UserModule.DTOs;
using NIFTWebApp.Modules.UserModule.Interfaces;

namespace NIFTWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto dto)
        {
            var createdUser = await _userService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserDto dto)
        {
            var existing = await _userService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _userService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _userService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}
