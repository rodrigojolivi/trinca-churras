using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrincaChurras.Core.Entities;
using TrincaChurras.Core.Validators;

namespace TrincaChurras.Core.Interfaces.Services
{
    public interface IScheduleService
    {
        Task<List<Notification>> AddScheduleAsync(Schedule schedule);
        Task<List<Notification>> AddParticipantAsync(Participant participant);
        Task<List<Notification>> RemoveParticipantAsync(Guid idSchedule, Guid idParticipant);
    }
}
