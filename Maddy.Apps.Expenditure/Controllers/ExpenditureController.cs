using Maddy.Apps.Expenditure.Business.Managers;
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
    }
}
