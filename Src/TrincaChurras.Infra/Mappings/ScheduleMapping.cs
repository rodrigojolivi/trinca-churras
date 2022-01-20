using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrincaChurras.Core.Entities;

namespace TrincaChurras.Infra.Mappings
{
    public class ScheduleMapping : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(x => x.Id);

            builder
               .Property(x => x.SuggestedValueWithDrink)
               .HasColumnType("decimal(10,2)")
               .IsRequired();

            builder
               .Property(x => x.SuggestedValueWithoutDrink)
               .HasColumnType("decimal(10,2)")
               .IsRequired();
        }
    }
}
