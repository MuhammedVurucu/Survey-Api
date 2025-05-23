using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Entities;

namespace Survey.Infrastructure.Persistence.Configuration
{
    // Alias tanımı 
    using SurveyEntity = Survey.Domain.Entities.Survey;

    public class SurveyConfiguration : IEntityTypeConfiguration<SurveyEntity>
    {
        public void Configure(EntityTypeBuilder<SurveyEntity> builder)
        {
            
            builder
                .HasMany(survey => survey.Questions)
                .WithOne(question => question.Survey)
                .HasForeignKey(question => question.SurveyId)
                .IsRequired(); // Yabancı anahtar zorunlu

           
            builder
                .HasOne(survey => survey.SurveySettings)
                .WithOne(settings => settings.Survey)
                .HasForeignKey<SurveySettings>(settings => settings.SurveyId)
                .IsRequired(false); // Ayarlar opsiyonel olabilir
        }
    }
}
