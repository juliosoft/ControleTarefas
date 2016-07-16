using Itriad.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Itriad.Infra.Data.EntityMap
{
    /// <summary>
    /// Classe de mapeamento da entidade junto ao banco
    /// </summary>
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            ToTable("Cliente");
            HasKey(c => c.ClienteId);

            Property(c => c.Cnpj)
                .IsRequired()
                .HasMaxLength(20).HasColumnAnnotation(
            IndexAnnotation.AnnotationName,
            new IndexAnnotation(new IndexAttribute("INDEX_CNPJ") { IsUnique = true}));
            
            Property(c => c.NomeFantasia)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.RazaoSocial)
               .IsRequired()
               .HasMaxLength(150).HasColumnAnnotation(
           IndexAnnotation.AnnotationName,
           new IndexAnnotation(new IndexAttribute("INDEX_RZSOC") { IsUnique = true }));

        }
    }
}
