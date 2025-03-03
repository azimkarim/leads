using LeadsApi.Models;
using LeadsApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LeadsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeadsController : ControllerBase
    {
        private readonly ILeadRepository _leadRepository;

        public LeadsController(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        // GET: LeadsController
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var leads = _leadRepository.GetLeads();
                return Ok(leads);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Lead> Details(Guid id)
        {
            if (_leadRepository.TryGetLeadById(id, out var lead))
            {
                //Optional to immediately send sms to lead
                if (lead.AllowText)
                {
                    SendTextMessage(lead.PhoneNumber);
                }

                //Optional to immediately send email to lead
                if (lead.AllowEmail && !string.IsNullOrEmpty(lead.Email))
                {
                    SendEmail(lead.Email);
                }
                return Ok(lead);
            }

            return NotFound(); //Lead not found
        }

        private void SendTextMessage(string phoneNumber)
        {
            //Integration with sms service, etc
            Console.WriteLine($"Sending text message to {phoneNumber}: An agent will call you soon.");
        }

        private void SendEmail(string email)
        {
            //Integration with email service, etc
            Console.WriteLine($"Sending email to {email}: An agent will call you soon.");
        }

    }
}
