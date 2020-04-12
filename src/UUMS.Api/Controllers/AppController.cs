using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UUMS.Enitites;
using UUMS.Services.IServices;

namespace UUMS.Api.Controllers
{
    /// <summary>
    /// 应用
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AppController : ControllerBase
    {
        private readonly ILogger<AppController> _logger;
        private IAppService _appService;

        public AppController(ILogger<AppController> logger, IAppService appService)
        {
            _logger = logger;
            _appService = appService;
        }

        /// <summary>
        /// 获取应用
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(AppDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public ActionResult<AppDto> Get(Guid id)
        {
            return _appService.Get(id);
        }

        /// <summary>
        /// 获取所有应用
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(IEnumerable<AppDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("All")]
        public ActionResult<IEnumerable<AppDto>> GetAll()
        {
            return _appService.GetAll();
        }

        /// <summary>
        /// 新增应用
        /// </summary>
        /// <param name="appDto"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(AppDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult<AppDto> Post(AppDto appDto)
        {
            if (appDto == null || string.IsNullOrEmpty(appDto.AppName))
            {
                return BadRequest("参数错误");
            }
            appDto.Id = Guid.NewGuid();
            _appService.Add(appDto);
            return appDto;
        }

        /// <summary>
        /// 修改应用
        /// </summary>
        /// <param name="appDto"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public ActionResult Put(AppDto appDto)
        {
            if (appDto == null || appDto.Id == null || string.IsNullOrEmpty(appDto.AppName))
            {
                return BadRequest("参数错误");
            }
            _appService.Modify(appDto);
            return Ok();
        }

        /// <summary>
        /// 删除应用
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return BadRequest("参数错误");
            }
            _appService.Remove(id);
            return Ok();
        }
    }
}
