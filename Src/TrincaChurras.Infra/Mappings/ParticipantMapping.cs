using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrincaChurras.Core.Entities;

namespace TrincaChurras.Infra.Mappings
{
    public class ParticipantMapping : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder
                .Property(x => x.Id)
                .ValueGeneratedNever();

            builder
                .Property(x => x.Value)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder
                .HasOne(x => x.Schedule)
                .WithMany(x => x.Participants)
                .HasForeignKey(x => x.IdSchedule)
                .IsRequired();
        }
    }
}
