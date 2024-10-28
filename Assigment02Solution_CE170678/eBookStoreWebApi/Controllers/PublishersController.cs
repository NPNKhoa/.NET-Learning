using BusinessObject;
using BusinessObject.DTOs;
using BusinessObject.Mappers;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace eBookStoreWebApi.Controllers
{
    [Route("odata/[controller]")]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublishersController(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        [HttpGet]
        [EnableQuery]

        public ActionResult<IEnumerable<Publisher>> GetAllPublishers()
        {
            return _publisherRepository.GetAllPublishers();
        }

        [HttpGet("{id}")]
        [EnableQuery]

        public IActionResult GetPublisherById([FromRoute] int id)
        {
            var publisher = _publisherRepository.GetPublisherById(id);

            if (publisher == null)
            {
                return NotFound();
            }

            return Ok(publisher);
        }

        [HttpPost]
        public ActionResult CreatePublisher([FromBody] CreatePublisherDto dto)
        {
            var publisher = dto.ToEntityPublisher();

            var existingPublisher = _publisherRepository.GetPublisherById(publisher.pub_id);

            if (existingPublisher == null)
            {
                _publisherRepository.AddPublisher(publisher);
            }
            else
            {
                return BadRequest("The publisher already exists!");
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePublisher([FromRoute] int id, [FromBody] CreatePublisherDto dto)
        {
            var publisher = dto.ToEntityPublisher();
            var existingPublisher = _publisherRepository.GetPublisherById(id);
            if (existingPublisher == null) return NotFound();

            _publisherRepository.UpdatePublisher(id, publisher);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePublisher([FromRoute] int id)
        {
            var existingPublisher = _publisherRepository.GetPublisherById(id);
            if (existingPublisher == null) return NotFound();

            _publisherRepository.DeletePublisher(id);
            return NoContent();
        }
    }
}

