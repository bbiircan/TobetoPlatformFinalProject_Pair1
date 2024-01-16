﻿using Business.Abstracts;
using Business.Dtos.Requests.Announcement;
using Business.Dtos.Requests.Homework;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeworkController : ControllerBase
    {
        private readonly IHomeworkService _homeworkService;
        public HomeworkController(IHomeworkService homeworkService)
        {
            _homeworkService = homeworkService;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateHomeworkRequest homeworkRequest)
        {
            var result = await _homeworkService.AddAsync(homeworkRequest);
            return Ok(result);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] GetHomeworkRequest getHomeworkRequest)
        {
            var result = await _homeworkService.GetByIdAsync(getHomeworkRequest);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var result = await _homeworkService.GetListAsync(pageRequest);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteHomeworkRequest deleteHomeworkRequest)
        {
            var result = await _homeworkService.DeleteAsync(deleteHomeworkRequest);
            return Ok(result);
        }
    }
}