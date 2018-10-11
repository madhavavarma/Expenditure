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
    public class TransactionTypeController : ControllerBase
    {
        ITransactionTypeManager transactionTypeManager;

        public TransactionTypeController(ITransactionTypeManager transactionTypeManager)
        {
            this.transactionTypeManager = transactionTypeManager;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        => Ok(await this.transactionTypeManager.GetAllAsync());
    }
}
