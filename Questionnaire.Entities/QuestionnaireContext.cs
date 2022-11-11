using Microsoft.EntityFrameworkCore;
using Questionnaire.Entities.Models;
using System.Numerics;
using System;
using Microsoft.Data.SqlClient.Server;

namespace Questionnaire.Entities;
public class QuestionnaireContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Form> Forms { get; set; }
    public DbSet<Element> Elements { get; set; }
    public DbSet<ElementOnForm> ElementOnForms { get; set; }
    public DbSet<Variant> Variants { get; set; }
    public DbSet<ResultOnQuestion> ResultOnQuestions { get; set; }
    public DbSet<Result> Results { get; set; }


    public QuestionnaireContext(DbContextOptions<QuestionnaireContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region Users

        builder.Entity<User>().ToTable("users");
        builder.Entity<User>().HasKey(x => x.Id);

        #endregion

        #region Forms

        builder.Entity<Form>().ToTable("forms");
        builder.Entity<Form>().HasKey(x => x.Id);

        builder.Entity<Form>().HasOne(x => x.User)
                              .WithMany(x => x.Forms)
                              .HasForeignKey(x => x.UserId)
                              .OnDelete(DeleteBehavior.Restrict);

        #endregion

        #region Element

        builder.Entity<Element>().ToTable("elements");
        builder.Entity<Element>().HasKey(x => x.Id);

        #endregion

        #region ElementOnForm

        builder.Entity<ElementOnForm>().ToTable("elements_on_form");
        builder.Entity<ElementOnForm>().HasKey(x => x.Id);

        builder.Entity<ElementOnForm>().HasOne(x => x.Form)
                                       .WithMany(x => x.ElementOnForms)
                                       .HasForeignKey(x => x.FormId)
                                       .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ElementOnForm>().HasOne(x => x.Element)
                                       .WithMany(x => x.ElementOnForms)
                                       .HasForeignKey(x => x.ElementId)
                                       .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region Variant

        builder.Entity<Variant>().ToTable("variants");
        builder.Entity<Variant>().HasKey(x => x.Id);

        builder.Entity<Variant>().HasOne(x => x.ElementOnForm)
                                 .WithMany(x => x.Variants)
                                 .HasForeignKey(x => x.ElementOnFormId)
                                 .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region ResultOnQuestion

        builder.Entity<ResultOnQuestion>().ToTable("results_on_question");
        builder.Entity<ResultOnQuestion>().HasKey(x => x.Id);

        builder.Entity<ResultOnQuestion>().HasOne(x => x.Variant)
                                          .WithMany(x => x.ResultOnQuestions)
                                          .HasForeignKey(x => x.VariantId)
                                          .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<ResultOnQuestion>().HasOne(x => x.ElementOnForm)
                                          .WithMany(x => x.ResultOnQuestions)
                                          .HasForeignKey(x => x.ElementOnFormId)
                                          .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<ResultOnQuestion>().HasOne(x => x.Result)
                                          .WithMany(x => x.ResultOnQuestions)
                                          .HasForeignKey(x => x.ResultId)
                                          .OnDelete(DeleteBehavior.Restrict);

        #endregion

        #region Result

        builder.Entity<Result>().ToTable("results");
        builder.Entity<Result>().HasKey(x => x.Id);

        builder.Entity<Result>().HasOne(x => x.User)
                                .WithMany(x => x.Results)
                                .HasForeignKey(x => x.UserId)
                                .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Result>().HasOne(x => x.Form)
                                .WithMany(x => x.Results)
                                .HasForeignKey(x => x.FormId)
                                .OnDelete(DeleteBehavior.Restrict);

        #endregion
    }
}