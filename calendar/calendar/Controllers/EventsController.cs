using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace calendar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        static private List<Event> events = new List<Event>
        { new Event { Id = 1, Title = "event 1", Start = new DateTime(2023,12,09),End = new DateTime(2023,12,09) },
          new Event { Id = 2, Title = "event 2", Start = new DateTime(2023,01,09),End = new DateTime(2023,02,09) },
          new Event { Id = 3, Title = "event 3", Start = new DateTime(2023,01,09),End = new DateTime(2023,01,09) }
        };
         static private int id = 3;
        // GET: api/<EventsController>
        [HttpGet]
        public List<Event> Get()
        {
            return events;
        }

        // POST api/<EventsController>
        [HttpPost]
        public Event Post([FromBody] Event eve)
        {
            //TODO add event
            id = getId();
            Event newEvent = new Event { Id = id, Title = eve.Title ,Start= eve.Start,End = eve.End };
            events.Add(newEvent);
            return newEvent;
        }
        private int getId() {
            id++;
            return id;
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event eve)
        {
            var eve2 = events.Find(e => e.Id == id);
            events.Remove(eve2);
            Event newEvent = new Event { Id = id, Title = eve.Title, Start = eve.Start,End = eve.End };
            events.Add(newEvent);
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var eve = events.Find(e => e.Id == id);
            events.Remove(eve);
        }
    }
}
