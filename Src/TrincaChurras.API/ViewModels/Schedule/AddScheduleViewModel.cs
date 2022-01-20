using System;

namespace TrincaChurras.API.ViewModels.Schedule
{
    public class AddScheduleViewModel
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public decimal SuggestedValueWithDrink { get; set; }
        public decimal SuggestedValueWithoutDrink { get; set; }
    }
}
