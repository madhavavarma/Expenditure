using Maddy.Apps.Expenditure.Business.Managers;
using Maddy.Apps.Expenditure.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maddy.Apps.Expenditure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenditureController : ControllerBase
    {
        IExpenditureManager expenditureManager;

        public ExpenditureController(IExpenditureManager expenditureManager)
        {
            this.expenditureManager = expenditureManager;
        }

        [HttpGet]
        public async Task<ActionResult> Search()
        => Ok(await this.expenditureManager.Search());

        [HttpPost]
        public async Task<ActionResult> Save([FromBody]ExpenditureModel expenditureModel)
        => Ok(await this.expenditureManager.Save(expenditureModel));

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        => Ok(await this.expenditureManager.DeleteAsync(id));
    }
}
