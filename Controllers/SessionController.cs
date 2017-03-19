using AuthenApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthenApi.Controllers
{
    [Route("api/[controller]")]
    public class SessionController : Controller
    {
        public ISessionRepository _sessionRepository { get ; set;}

        public SessionController(ISessionRepository sessions)
        {
            _sessionRepository = sessions;
        }

        [HttpGet("{id}", Name="GetSession")]
        public IActionResult GetByKey(int id)
        {
            Session session = _sessionRepository.Find(id);
            if(session == null) 
            {
                return NotFound();
            }
            return new ObjectResult(session);
        }

        [HttpPost]
        public IActionResult Create([FromBody] int UserID)
        {
            Session session = _sessionRepository.Add(UserID);
            if(session == null) {
                return BadRequest();
            }
            return  CreatedAtRoute("GetSession", new {id = session.SessionID}, session);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Session session = _sessionRepository.Find(id);
            if(session == null)
            {
                return NotFound();
            }
            _sessionRepository.Remove(id);
            return new NoContentResult();
        }
    }
}