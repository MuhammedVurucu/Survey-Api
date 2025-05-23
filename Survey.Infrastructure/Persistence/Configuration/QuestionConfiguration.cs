using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Entities;

namespace Survey.Infrastructure.Persistence.Configuration
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasMany(q => q.Options)
                   .WithOne(o => o.Question)
                   .HasForeignKey(o => o.QuestionId);
        }
    }
}

