using System;
using System.Collections.Generic;

namespace TrincaChurras.API.ViewModels.Schedule
{
    public class FindScheduleViewModel
    {
        public FindScheduleViewModel(Guid id, DateTime date, string description, string note, decimal suggestedValueWithDrink, 
            decimal suggestedValueWithoutDrink, int totalParticipants, decimal totalValue, IEnumerable<ParticipantViewModel> participants)
        {
            Id = id;
            Date = date;
            Description = description;
            Note = note;
            SuggestedValueWithDrink = suggestedValueWithDrink;
            SuggestedValueWithoutDrink = suggestedValueWithoutDrink;
            TotalParticipants = totalParticipants;
            TotalValue = totalValue;
            Participants = participants;
        }

        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }
        public string Description { get; private set; }
        public string Note { get; private set; }
        public decimal SuggestedValueWithDrink { get; private set; }
        public decimal SuggestedValueWithoutDrink { get; private set; }
        public int TotalParticipants { get; private set; }
        public decimal TotalValue { get; private set; }
        public IEnumerable<ParticipantViewModel> Participants { get; private set; }

        public class ParticipantViewModel
        {
            public ParticipantViewModel(Guid id, string name, decimal value)
            {
                Id = id;
                Name = name;
                Value = value;
            }

            public Guid Id { get; private set; }
            public string Name { get; private set; }
            public decimal Value { get; private set; }
        }
    }
}

