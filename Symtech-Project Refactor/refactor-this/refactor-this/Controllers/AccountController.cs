using Core;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace refactor_this.Controllers
{
    public class AccountController : ApiController
    {
        AccountData dataAccess;
        public AccountController()
        {
            dataAccess = new AccountData();
        }

        [HttpGet, Route("api/Accounts/{id}")]
        public IHttpActionResult GetById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var account = dataAccess.GetById(id);

            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        [HttpGet, Route("api/Accounts")]
        public IEnumerable<Accounts> Get()
        {
            return dataAccess.GetAccounts();
        }

        [HttpPost, Route("api/Accounts")]
        public IHttpActionResult Add(Accounts account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dataAccess.Add(account);
            return Ok();

        }

        [HttpPut, Route("api/Accounts/{id}")]
        public IHttpActionResult Update(Guid id, Accounts account)
        {

            return Ok();
        }

        [HttpDelete, Route("api/Accounts/{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (dataAccess.Delete(id) == false)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}