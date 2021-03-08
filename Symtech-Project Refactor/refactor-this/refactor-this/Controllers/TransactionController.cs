using System;
using DataAccess;
using System.Web.Http;
using Core;

namespace refactor_this.Controllers
{
    public class TransactionController : ApiController
    {
        TransactionData dataAccess;
        public TransactionController()
        {
            dataAccess = new TransactionData();
        }

        [HttpGet, Route("api/Accounts/{id}/Transactions")]
        public IHttpActionResult Get(Guid id)
        {
            var transactions = dataAccess.GetTransactions(id);
            return Ok(transactions);
        }

        [HttpPost, Route("api/Accounts/{id}/Transactions")]
        public IHttpActionResult AddTransaction(Guid id, Transactions transaction)
        {

            var transactions = dataAccess.Add(id, transaction);
            if (transactions != true)
                return BadRequest("Could not update account amount or insert the transaction");
            return Ok();
        }

    }
}