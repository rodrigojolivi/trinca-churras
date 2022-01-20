using System.Collections.Generic;
using System.Linq;
using TrincaChurras.API.ViewModels.Schedule;
using TrincaChurras.Core.Entities;

namespace TrincaChurras.API.Mappers
{
    public static class ScheduleMapper
    {
        public static IEnumerable<GetSchedulesViewModel> ToGetSchedulesViewModel(this List<Schedule> schedules)
        {
            return schedules.Select(x => new GetSchedulesViewModel(x.Id, x.Date, x.Description, x.Note,
                x.SuggestedValueWithDrink, x.SuggestedValueWithoutDrink, x.Participants.Count, x.Participants.Sum(x => x.Value)));
        }

        public static FindScheduleViewModel ToFindScheduleViewModel(this Schedule schedule)
        {
            return new FindScheduleViewModel(schedule.Id, schedule.Date, schedule.Description, schedule.Note, schedule.SuggestedValueWithDrink,
                schedule.SuggestedValueWithoutDrink, schedule.Participants.Count, schedule.Participants.Sum(x => x.Value),
                schedule.Participants.Select(x => new FindScheduleViewModel.ParticipantViewModel(x.Id, x.Name, x.Value)));
        }
    }
}
