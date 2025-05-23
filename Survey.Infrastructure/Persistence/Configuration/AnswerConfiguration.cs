using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Entities;

namespace Survey.Infrastructure.Persistence.Configuration
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasOne(a => a.Survey)
                   .WithMany()
                   .HasForeignKey(a => a.SurveyId);

            builder.HasOne(a => a.Question)
                   .WithMany()
                   .HasForeignKey(a => a.QuestionID);

            builder.HasOne(a => a.Option)
                   .WithMany()
                   .HasForeignKey(a => a.OptionID);
        }
    }
}
