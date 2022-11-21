using Application.CQRS.Commands.Admin.CreateEvent;
using Application.CQRS.Commands.Admin.DeleteEvent;
using Application.CQRS.Commands.Admin.UpdateEvent;
using Application.CQRS.DTOs.Admin;
using Application.CQRS.Queries.Admin.GetAllCategories;
using Application.CQRS.Queries.Admin.GetAllCities;
using Application.CQRS.Queries.Admin.GetAllEvents;
using Application.CQRS.Queries.Admin.GetEventById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class EventController : Controller
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: EventController
        public async Task<ActionResult> Index()
        {
            var events = await _mediator.Send(new GetAllEventsQuery());
            return View(events);
        }

        // GET: EventController/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: EventController/Create
        public async Task<ActionResult> Create()
        {
            var cities = await _mediator.Send(new GetAllCitiesQuery());
            var categories = await _mediator.Send(new GetAllCategoriesQuery());
            ViewBag.cities = cities.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            });
            ViewBag.categories = categories;
            return View();
        }

        // POST: EventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EventDetailDto model)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(new CreateEventCommand(model.Id, model.Title, model.Description, model.Image, model.CategoryId, model.CityId, model.Adress, model.Capacity, model.TicketNeeded, model.Price, model.EventDate, model.ApplicationDeadline));
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: EventController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var obj = await _mediator.Send(new GetEventByIdQuery(id));
            var cities = await _mediator.Send(new GetAllCitiesQuery());
            var categories = await _mediator.Send(new GetAllCategoriesQuery());
            ViewBag.cities = cities.Select(a => new SelectListItem
            {
                Value =a.Id.ToString(),
                Text = a.Name
            });
            ViewBag.categories = categories;

            return View(obj);
        }

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EventDetailDto model)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(new UpdateEventCommand(model.Id,model.Title,model.Description,model.Image,model.CategoryId,model.CityId,model.Adress,model.Capacity,model.TicketNeeded,model.Price,model.Status,model.EventDate,model.ApplicationDeadline));
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

       
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await _mediator.Send(new GetEventByIdQuery(id));
            if (entity == null)
            {
                return NotFound();
            }
            await _mediator.Send(new DeleteEventCommand(id));
            return RedirectToAction(nameof(Index));
        }
    }
}
