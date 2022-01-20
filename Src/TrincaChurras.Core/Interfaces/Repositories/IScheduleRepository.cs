using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrincaChurras.Core.Entities;

namespace TrincaChurras.Core.Interfaces.Repositories
{
    public interface IScheduleRepository 
    {
        Task<List<Schedule>> GetSchedulesWithParticipantsAsync(Guid idUser);
        Task<Schedule> FindScheduleAsync(Guid idSchedule);
        Task<Schedule> FindScheduleWithParticipantsAsync(Guid idSchedule);
        void AddSchedule(Schedule schedule);
        void UpdateSchedule(Schedule schedule);
        void RemoveSchedule(Schedule schedule);
    }
}
