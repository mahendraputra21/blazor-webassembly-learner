﻿using Blazor.Learner.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Learner.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public PositionController(ApplicationDBContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosition()
        {
            var positions = await _context.Positions.Select(x => new
                {
                    x.PositionId,
                    x.PositionName
                })
                .ToListAsync();
            return Ok(positions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPositionById(int id)
        {
            var positionById = await _context.Positions
                .Where(x => x.PositionId == id)
                .Select(x => x.PositionName)
                .ToListAsync();

            return Ok(positionById);
        }

    }
}