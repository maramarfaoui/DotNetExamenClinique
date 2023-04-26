using Application.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InfraStructure.Configuration
{
    internal class ChambreConfiguration : IEntityTypeConfiguration<Chambre>
    {
        public void Configure(EntityTypeBuilder<Chambre> builder)
        {
            builder.HasOne(c => c.Clinique)
                .WithMany(cl => cl.Chambres)
                .HasForeignKey(c => c.CliniqueFk);
        }
    }
}
