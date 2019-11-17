using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace IndividuellAngular.Models
{
    public class Question
    {
        [Key]
        public int id { get; set; }
        public string sporsmal { get; set; }
        public string svar { get; set; }
        public int ratingOpp { get; set; }
        public int ratingNed { get; set; }
    }

    public class Bruker
    {
        [Key]
        public int id { get; set; }
        public string email { get; set; }
        public string fornavn { get; set; }
        public string etternavn { get; set; }
        public string adresse { get; set; }

        public string brukersporsmal { get; set; }
    }

    public class QuestionContext : DbContext
    {
        public QuestionContext(DbContextOptions<QuestionContext> options)
            : base(options)
        {
           
        }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Bruker> Brukere { get; set; }


    }
}
