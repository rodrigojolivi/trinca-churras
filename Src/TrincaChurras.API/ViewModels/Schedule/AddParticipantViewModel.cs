using System;

namespace TrincaChurras.API.ViewModels.Schedule
{
    public class AddParticipantViewModel
    {
        public Guid IdSchedule { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
