using CarBookProje.Application.Features.CQRS.Commands.CarCommands;
using CarBookProje.Application.Features.CQRS.Commands.ContactCommands;
using CarBookProje.Application.Features.CQRS.Handlers.ContactHandler;
using CarBookProje.Application.Features.CQRS.Handlers.CarHandler;
using CarBookProje.Application.Features.CQRS.Queries.CarQueries;
using CarBookProje.Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProje.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        private readonly CreateContactCommandHandler _createContactCommandHandler;

        private readonly UpdateContactCommandHandler _updateContactCommandHandler;

        private readonly RemoveContactCommandHandler _removeContactCommandHandler;

        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
        
        private readonly GetContactQueryHandler _getContactQueryHandler;

        public ContactController(CreateContactCommandHandler createContactCommandHandler, UpdateContactCommandHandler updateContactCommandHandler, RemoveContactCommandHandler removeContactCommandHandler, GetContactByIdQueryHandler getContactByIdQueryHandler, GetContactQueryHandler getContactQueryHandler)
        {
            _createContactCommandHandler = createContactCommandHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
            _removeContactCommandHandler = removeContactCommandHandler;
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
            _getContactQueryHandler = getContactQueryHandler;
        }



        [HttpGet]

        public async Task<IActionResult> ContactList()
        {
            var value = await _getContactQueryHandler.Handle();
            return Ok(value);
        }

        [HttpGet("{id}")]


        public async Task<IActionResult> GetContact(int id)
        {
            var values = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
            return Ok(values);
        }


        [HttpPost]

        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            await _createContactCommandHandler.Handle(command);
            return Ok("Contact Bilgisi Eklendi");

        }


        [HttpDelete]
        public async Task<IActionResult> RemoveContact(int id)
        {
            await _removeContactCommandHandler.Handle(new RemoveContactCommand(id));
            return Ok("Contact Bilgisi Siilindi");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
            await _updateContactCommandHandler.Handle(command);
            return Ok("Contact Bilgisi Güncellendi");
        }


     

    }
}
