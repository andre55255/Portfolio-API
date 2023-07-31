using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Core.Entities.Sql;
using Portfolio.Helpers;

namespace Portfolio.Infrastructure.Data.Sql.Seed
{
    public class GenericTypeSeed : IEntityTypeConfiguration<GenericType>
    {
        public void Configure(EntityTypeBuilder<GenericType> builder)
        {
            builder.HasData(
                new GenericType
                {
                    Id = 1,
                    Token = TokensGenericType.ExperienceWorkStatus,
                    Description = "Status de jornada experiência de trabalho",
                    Value = "Integral"
                },
                new GenericType
                {
                    Id = 2,
                    Token = TokensGenericType.ExperienceWorkStatus,
                    Description = "Status de jornada experiência de trabalho",
                    Value = "Meio período"
                },
                new GenericType
                {
                    Id = 3,
                    Token = TokensGenericType.ExperienceWorkStatus,
                    Description = "Status de jornada experiência de trabalho",
                    Value = "Noturna"
                },
                new GenericType
                {
                    Id = 4,
                    Token = TokensGenericType.ExperienceWorkStatus,
                    Description = "Status de jornada experiência de trabalho",
                    Value = "Turno"
                },
                new GenericType
                {
                    Id = 5,
                    Token = TokensGenericType.EducationStatus,
                    Description = "Status de faculdade/curso experiência de trabalho",
                    Value = "Em curso"
                },
                new GenericType
                {
                    Id = 6,
                    Token = TokensGenericType.EducationStatus,
                    Description = "Status de faculdade/curso experiência de trabalho",
                    Value = "Concluído"
                },
                new GenericType
                {
                    Id = 7,
                    Token = TokensGenericType.EducationStatus,
                    Description = "Status de faculdade/curso experiência de trabalho",
                    Value = "Incompleto"
                },
                new GenericType
                {
                    Id = 8,
                    Token = TokensGenericType.EducationStatus,
                    Description = "Status de faculdade/curso experiência de trabalho",
                    Value = "Trancado"
                });
        }
    }
}
