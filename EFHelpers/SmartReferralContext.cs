using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartReferralApiCore2.Models;

namespace SmartReferralApiCore2.EFHelpers
{
    public class SmartReferralContext: DbContext
    {
        public SmartReferralContext(DbContextOptions<SmartReferralContext> options) : base(options)
        {
        }

        //Create EF Core entity sets using models for database tables 
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateSkill> CandidateSkills { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Candidate>().ToTable("Candidate");
            modelBuilder.Entity<CandidateSkill>().ToTable("CandidateSkill");
            modelBuilder.Entity<Skill>().ToTable("Skill");
        }
    }
}
