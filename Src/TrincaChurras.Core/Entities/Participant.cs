using System;

namespace TrincaChurras.Core.Entities
{
    public class Participant : Entity   
    {
        public Participant(Guid idSchedule, string name, decimal value)
        {
            IdSchedule = idSchedule;
            Name = name;
            Value = value;
        }

        public string Name { get; private set; }
        public decimal Value { get; private set; }
        public Guid IdSchedule { get; private set; }
        public Schedule Schedule { get; private set; }
    }
}
