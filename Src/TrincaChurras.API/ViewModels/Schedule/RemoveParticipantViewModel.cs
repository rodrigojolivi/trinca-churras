using System;

namespace TrincaChurras.API.ViewModels.Schedule
{
    public class RemoveParticipantViewModel
    {
        public Guid IdSchedule { get; set; }
        public Guid IdParticipant { get; set; }
    }
}
