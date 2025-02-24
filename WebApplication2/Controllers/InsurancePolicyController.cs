using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using WebApplication2.Models;

    [ApiController]
    [Route("api/[controller]")]
    public class InsurancePolicyController : Controller
    {
        private static List<InsurancePolicy> policies = new List<InsurancePolicy>
    {
        new InsurancePolicy { Id = 1, PolicyNumber = "123", PolicyHolderName = "Yusif Azizli", PolicyType = "Property", StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(1), Amount = 2000 },
        new InsurancePolicy { Id = 2, PolicyNumber = "456", PolicyHolderName = "Khayal Huseynov", PolicyType = "Health", StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(1), Amount = 1500 }
    };

        [HttpGet]
        public ActionResult<IEnumerable<InsurancePolicy>> Get()
        {
            return Ok(policies);
        }

        [HttpGet("{id}")]
        public ActionResult<InsurancePolicy> Get(int id)
        {
            var policy = policies.FirstOrDefault(p => p.Id == id);
            if (policy == null)
            {
                return NotFound();
            }
            return Ok(policy);
        }

        [HttpPost]
        public ActionResult<InsurancePolicy> Post([FromBody] InsurancePolicy policy)
        {
            policy.Id = policies.Max(p => p.Id) + 1;
            policies.Add(policy);
            return CreatedAtAction(nameof(Get), new { id = policy.Id }, policy);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] InsurancePolicy updatedPolicy)
        {
            var policy = policies.FirstOrDefault(p => p.Id == id);
            if (policy == null)
            {
                return NotFound();
            }

            policy.PolicyNumber = updatedPolicy.PolicyNumber;
            policy.PolicyHolderName = updatedPolicy.PolicyHolderName;
            policy.PolicyType = updatedPolicy.PolicyType;
            policy.StartDate = updatedPolicy.StartDate;
            policy.EndDate = updatedPolicy.EndDate;
            policy.Amount = updatedPolicy.Amount;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var policy = policies.FirstOrDefault(p => p.Id == id);
            if (policy == null)
            {
                return NotFound();
            }

            policies.Remove(policy);
            return NoContent();
        }
    }

}
