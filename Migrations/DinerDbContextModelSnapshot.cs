using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace netcore.Migrations
{
    [DbContext(typeof(DinerDbContext))]
    partial class DinerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-preview1-22509");

            modelBuilder.Entity("Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("ExtraInfo");

                    b.Property<int?>("MealId");

                    b.HasKey("Id");

                    b.HasIndex("MealId");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Chef");

                    b.Property<string>("ExtraInfo");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("Ingredient", b =>
                {
                    b.HasOne("Meal")
                        .WithMany("Ingredients")
                        .HasForeignKey("MealId");
                });
        }
    }
}
