using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoveIT.Data.Entities;

namespace MoveIT.Data.Persistence.Configurations;

internal sealed class ProposalConfiguration : IEntityTypeConfiguration<Proposal>
{
    public void Configure(EntityTypeBuilder<Proposal> builder)
    {
        builder.ToTable(nameof(Proposal));

        builder.HasKey(proposal => proposal.Id);

        builder.Property(proposal => proposal.FromAddress)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(proposal => proposal.ToAddress)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(proposal => proposal.HasPiano).HasDefaultValue(false);
        
        builder.Property(proposal => proposal.CreatedDate)
            .HasDefaultValue(DateTime.Now);

        builder.Property(proposal => proposal.UserId)
            .IsRequired()
            .HasMaxLength(450);
    }
}