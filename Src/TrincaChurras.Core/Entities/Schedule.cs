using System;
using System.Collections.Generic;
using System.Linq;

namespace TrincaChurras.Core.Entities
{
    public class Schedule : Entity
    {
        public Schedule(DateTime date, string description, string note, 
            decimal suggestedValueWithDrink, decimal suggestedValueWithoutDrink, Guid idUser)
        {
            Date = date;
            Description = description;
            Note = note;
            SuggestedValueWithDrink = suggestedValueWithDrink;
            SuggestedValueWithoutDrink = suggestedValueWithoutDrink;
            IdUser = idUser;

            Participants = new List<Participant>();
        }

        public DateTime Date { get; private set; }
        public string Description { get; private set; }
        public string Note { get; private set; }
        public decimal SuggestedValueWithDrink { get; private set; }
        public decimal SuggestedValueWithoutDrink { get; private set; }
        public Guid IdUser { get; private set; }
        public List<Participant> Participants { get; private set; }

        public void AddParticipant(Guid idSchedule, string name, decimal value)
        {
            Participants.Add(new Participant(idSchedule, name, value));
        }

        public Participant FindParticipant(Guid idParticipant, Schedule schedule)
        {
            return schedule.Participants.FirstOrDefault(x => x.Id == idParticipant);
        }

        public void RemoveParticipant(Participant participant)
        {
            Participants.Remove(participant);
        }
    }
}
