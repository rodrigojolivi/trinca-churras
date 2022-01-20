using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TrincaChurras.API.Mappers;
using TrincaChurras.API.ViewModels.Schedule;
using TrincaChurras.Core.Entities;
using TrincaChurras.Core.Interfaces.Repositories;
using TrincaChurras.Core.Interfaces.Services;

namespace TrincaChurras.API.Controllers.v1
{
    [Authorize]
    [Route("api/v1/schedules")]

    public class ScheduleController : CustomController
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleRepository scheduleRepository,
            IScheduleService scheduleService, IHttpContextAccessor httpContextAccessor)
            : base(httpContextAccessor)
        {
            _scheduleRepository = scheduleRepository;
            _scheduleService = scheduleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSchedulesWithParticipantsAsync()
        {
            var schedules = await _scheduleRepository.GetSchedulesWithParticipantsAsync(GetIdUser());

            var schedulesViewModel = schedules.ToGetSchedulesViewModel();

            var result = new { data = schedulesViewModel };

            return Ok(result);
        }

        [HttpGet("{idSchedule:guid}")]
        public async Task<IActionResult> FindScheduleWithParticipantsAsync(Guid idSchedule)
        {
            var schedule = await _scheduleRepository.FindScheduleWithParticipantsAsync(idSchedule);

            if (schedule == null)
                return NotFound();

            var scheduleViewModel = schedule.ToFindScheduleViewModel();

            var result = new { data = scheduleViewModel };

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddScheduleAsync(AddScheduleViewModel addScheduleViewModel)
        {
            var schedule = new Schedule(addScheduleViewModel.Date, addScheduleViewModel.Description,
                addScheduleViewModel.Note, addScheduleViewModel.SuggestedValueWithDrink,
                addScheduleViewModel.SuggestedValueWithoutDrink, GetIdUser());

            var notifications = await _scheduleService.AddScheduleAsync(schedule);

            if (HasNotifications(notifications))
                return BadRequest(new { notifications = FormatNotifications(notifications) });

            return Created("", null);
        }

        [HttpPost("{idSchedule:guid}/participants")]
        public async Task<IActionResult> AddParticipantAsync(AddParticipantViewModel addParticipantViewModel)
        {
            var participant = new Participant(addParticipantViewModel.IdSchedule, addParticipantViewModel.Name, addParticipantViewModel.Value);

            var notifications = await _scheduleService.AddParticipantAsync(participant);

            if (HasNotifications(notifications))
                return BadRequest(new { notifications = FormatNotifications(notifications) });

            return Created("", null);
        }

        [HttpDelete("{idSchedule:guid}/participants/{idParticipant:guid}")]
        public async Task<IActionResult> RemoveParticipantAsync(Guid idSchedule, Guid idParticipant)
        {
            var notifications = await _scheduleService.RemoveParticipantAsync(idSchedule, idParticipant);

            if (HasNotifications(notifications))
                return BadRequest(new { notifications = FormatNotifications(notifications) });

            return NoContent();
        }
    }
}
