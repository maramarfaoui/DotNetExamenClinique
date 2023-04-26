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
    public class AdmissionConfiguration : IEntityTypeConfiguration<Admission>
    {
        public void Configure(EntityTypeBuilder<Admission> builder)
        {
            builder.HasKey(a => new
            {
                a.DateAdmission,
                a.ChambreFk,
                a.PatientFk
            });
        }
    }
}
