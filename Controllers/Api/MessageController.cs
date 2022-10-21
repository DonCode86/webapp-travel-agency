using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Data;

namespace webapp_travel_agency.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private ApplicationDbContext _ctx;
        public MessageController()
        {
            _ctx = new ApplicationDbContext();
        }

        [HttpPost("{id}")]
        public IActionResult Send(int id, Message message)
        {
            TravelPackage package = _ctx.TravelPackages.Where(pack => pack.Id == id).FirstOrDefault();
            if (package == null)
            {
                return NotFound();
            }
            message.TravelPackageId = id;
            _ctx.Messages.Add(message);
            _ctx.SaveChanges();
            return Ok();
        }
    }
}
