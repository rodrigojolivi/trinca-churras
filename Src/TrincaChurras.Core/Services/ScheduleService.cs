using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrincaChurras.Core.Entities;
using TrincaChurras.Core.Interfaces.Repositories;
using TrincaChurras.Core.Interfaces.Services;
using TrincaChurras.Core.Validators;

namespace TrincaChurras.Core.Services
{
    public class ScheduleService : Validator, IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ScheduleService(IScheduleRepository scheduleRepository, IUnitOfWork unitOfWork)
        {
            _scheduleRepository = scheduleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Notification>> AddScheduleAsync(Schedule schedule)
        {
            Validate(new ScheduleValidator(), schedule);

            if (!IsValid()) 
                return _notifications;

            _scheduleRepository.AddSchedule(schedule);

            await SaveAsync();

            return _notifications;
        }      

        public async Task<List<Notification>> AddParticipantAsync(Participant participant)
        {
            Validate(new ParticipantValidator(), participant);

            if (!IsValid()) 
                return _notifications;

            var schedule = await _scheduleRepository.FindScheduleAsync(participant.IdSchedule);

            if (schedule == null)
            {
                AddNotification("Schedule not found");

                return _notifications;
            }

            schedule.AddParticipant(participant.IdSchedule, participant.Name, participant.Value);

            _scheduleRepository.UpdateSchedule(schedule);

            await SaveAsync();

            return _notifications;
        }

        public async Task<List<Notification>> RemoveParticipantAsync(Guid idSchedule, Guid idParticipant)
        {
            var schedule = await _scheduleRepository.FindScheduleWithParticipantsAsync(idSchedule);

            if (schedule == null)
            {
                AddNotification("Schedule not found");

                return _notifications;
            }

            var participant = schedule.FindParticipant(idParticipant, schedule);

            if (participant == null)
            {
                AddNotification("Participant not found");

                return _notifications;
            }

            schedule.RemoveParticipant(participant);

            _scheduleRepository.UpdateSchedule(schedule);

            await SaveAsync();

            return _notifications;
        }        

        private async Task SaveAsync()
        {
            var isSuccess = await _unitOfWork.CommitAsync();

            if (!isSuccess) 
                AddNotification("Error saving schedule");
        }
    }
}
