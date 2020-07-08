using HousesPeru.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Threading.Tasks;

namespace HousesPeru.DB.Maps
{
    public class PlanMap : EntityTypeConfiguration<Plan>
    {
        public PlanMap()
        {
            ToTable("Plan");
            HasKey(x => x.Id);

            HasMany(x => x.Usuarios)
                .WithOptional()
                .HasForeignKey(x => x.PlanId);
        }
    }
}
