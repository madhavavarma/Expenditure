using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maddy.Apps.Expenditure.Business.Managers;
using Maddy.Apps.Expenditure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Maddy.Apps.Expenditure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        IFilterManager filterManager;

        public FilterController(IFilterManager filterManager)
        {
            this.filterManager = filterManager;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult> SearchAsync(string partialFilterName)
        {
            return Ok(await this.filterManager.SearchAsync(partialFilterName));
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody]FilterModel filterModel)
        {
            await this.filterManager.AddFilter(filterModel);

            return Ok();
        }
    }
}
