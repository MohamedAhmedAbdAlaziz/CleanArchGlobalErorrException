using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Config;

//public class UserFCMConfiguration : IEntityTypeConfiguration<UserFCM>
//{
//    public void Configure(EntityTypeBuilder<UserFCM> builder)
//    {
//        builder.Property(p => p.Id).IsRequired();
//        builder.Property(p => p.UserName).IsRequired();
//        builder.Property(p => p.App).IsRequired();
//        builder.Property(p => p.DeviceId).IsRequired();
//        builder.Property(p => p.FcmToken).IsRequired().HasColumnType("nvarchar(max)");
//        builder.Property(p => p.CreatedOn).IsRequired();
//        builder.HasMany(e => e.Notifications)
//             .WithOne(e => e.UserFCM)
//            .HasForeignKey(e => e.UserFCMId);
             



//    }
//}
