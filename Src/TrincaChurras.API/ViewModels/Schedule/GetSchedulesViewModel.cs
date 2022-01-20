using System;

namespace TrincaChurras.API.ViewModels.Schedule
{
    public class GetSchedulesViewModel
    {
        public GetSchedulesViewModel(Guid id, DateTime date, string description, string note, 
            decimal suggestedValueWithDrink, decimal suggestedValueWithoutDrink, int totalParticipants, decimal totalValue)
        {
            Id = id;
            Date = date;
            Description = description;
            Note = note;
            SuggestedValueWithDrink = suggestedValueWithDrink;
            SuggestedValueWithoutDrink = suggestedValueWithoutDrink;
            TotalParticipants = totalParticipants;
            TotalValue = totalValue;
        }

        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }
        public string Description { get; private set; }
        public string Note { get; private set; }
        public decimal SuggestedValueWithDrink { get; private set; }
        public decimal SuggestedValueWithoutDrink { get; private set; }
        public int TotalParticipants { get; private set; }
        public decimal TotalValue { get; private set; }
    }
}
