using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrincaChurras.Core.Entities;
using TrincaChurras.Core.Interfaces.Repositories;
using TrincaChurras.Infra.Contexts;

namespace TrincaChurras.Infra.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly TrincaChurrasContext _context;

        public ScheduleRepository(TrincaChurrasContext context)
        {
            _context = context;
        }

        public async Task<List<Schedule>> GetSchedulesWithParticipantsAsync(Guid idUser)
        {
            return await _context.Schedules
                .AsNoTracking().Include(x => x.Participants).Where(x => x.IdUser == idUser).ToListAsync();
        }

        public async Task<Schedule> FindScheduleAsync(Guid idSchedule)
        {
            return await _context.Schedules.FirstOrDefaultAsync(x => x.Id == idSchedule);
        }

        public async Task<Schedule> FindScheduleWithParticipantsAsync(Guid idSchedule)
        {
            return await _context.Schedules.Include(x => x.Participants).FirstOrDefaultAsync(x => x.Id == idSchedule);
        }

        public void AddSchedule(Schedule schedule)
        {
            _context.Schedules.AddAsync(schedule);
        }

        public void UpdateSchedule(Schedule schedule)
        {
            _context.Schedules.Update(schedule);
        }

        public void RemoveSchedule(Schedule schedule)
        {
            _context.Schedules.Remove(schedule);
        }
    }
}
