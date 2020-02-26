﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NxtLvl_E_Diary
{
    public class user
    {
        public int id { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }

        // User kann mehrere Tagebuecher haben
        public ICollection<diary> Diaries { get; set; }
    }

    public class diary
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [ForeignKey("user")]
        [Required]
        public int user_id { get; set; }

        // Tagebuch kann zu genau einem User gehoeren
        public virtual user user { get; set; }

        // Tagebuch kann mehrere Eintraege haben
        public ICollection<entry> entries { get; set; }
    }

    public class entry
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string text { get; set; }
        /*
        public EntryType entrytype1 { get; set;  }
        public EntryType entrytype2 { get; set;  }
        public EntryType entrytype3 { get; set;  }
        */
        public int entryType1_id { get; set; }
        public int entryType2_id { get; set; }
        public int entryType3_id { get; set; }
        [Required]
        public DateTime date { get; set; }
        [ForeignKey("diary")]
        [Required]
        public int diary_id { get; set; }

        // Ein Eintrag kann zu einem Tagebuch gehoeren
        public virtual diary diary { get; set; }

    }
    /*
    public enum EntryType
    {
        Family = 0,
        Sport = 1, 
        Work = 2,
        School = 4,
        Friends = 8
    }
    */
    public class type
    {
        public int id { get; set; }
        [Required]
        public string typename { get; set; }
    }

    public class databaseContext : DbContext
    {
        public databaseContext() : base()
        {
            Database.SetInitializer<databaseContext>(new CreateDatabaseIfNotExists<databaseContext>());
        }

        public DbSet<user> tableObjUser { get; set; }
        public DbSet<diary> tableObjDiary { get; set; }
        public DbSet<entry> tableObjentry { get; set; }
        public DbSet<type> tableObjType { get; set; }
    }

    /*
    class createModel
    {
    }
    */
}
