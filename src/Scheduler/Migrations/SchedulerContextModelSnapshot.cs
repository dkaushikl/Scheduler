﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Scheduler.Data;

namespace Scheduler.Migrations
{
    [DbContext(typeof(SchedulerContext))]
    internal class SchedulerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Scheduler.Model.Entities.Attendee", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<int>("ScheduleId");

                b.Property<int>("UserId");

                b.HasKey("Id");

                b.HasIndex("ScheduleId");

                b.HasIndex("UserId");

                b.ToTable("Attendee");
            });

            modelBuilder.Entity("Scheduler.Model.Entities.Schedule", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<int>("CreatorId");

                b.Property<DateTime>("DateCreated")
                    .ValueGeneratedOnAdd()
                    .HasDefaultValue(new DateTime(2017, 3, 5, 9, 56, 55, 386, DateTimeKind.Local));

                b.Property<DateTime>("DateUpdated")
                    .ValueGeneratedOnAdd()
                    .HasDefaultValue(new DateTime(2017, 3, 5, 9, 56, 55, 418, DateTimeKind.Local));

                b.Property<string>("Description");

                b.Property<string>("Location");

                b.Property<int>("Status")
                    .ValueGeneratedOnAdd()
                    .HasDefaultValue(1);

                b.Property<DateTime>("TimeEnd");

                b.Property<DateTime>("TimeStart");

                b.Property<string>("Title");

                b.Property<int>("Type")
                    .ValueGeneratedOnAdd()
                    .HasDefaultValue(1);

                b.HasKey("Id");

                b.HasIndex("CreatorId");

                b.ToTable("Schedule");
            });

            modelBuilder.Entity("Scheduler.Model.Entities.User", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("Avatar");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasAnnotation("MaxLength", 100);

                b.Property<string>("Profession");

                b.HasKey("Id");

                b.ToTable("User");
            });

            modelBuilder.Entity("Scheduler.Model.Entities.Attendee", b =>
            {
                b.HasOne("Scheduler.Model.Entities.Schedule", "Schedule")
                    .WithMany("Attendees")
                    .HasForeignKey("ScheduleId");

                b.HasOne("Scheduler.Model.Entities.User", "User")
                    .WithMany("SchedulesAttended")
                    .HasForeignKey("UserId");
            });

            modelBuilder.Entity("Scheduler.Model.Entities.Schedule", b =>
            {
                b.HasOne("Scheduler.Model.Entities.User", "Creator")
                    .WithMany("SchedulesCreated")
                    .HasForeignKey("CreatorId");
            });
        }
    }
}