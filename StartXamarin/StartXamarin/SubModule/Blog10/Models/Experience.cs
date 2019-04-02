using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace StartXamarin.SubModule.Blog10.Models
{
    public class Experience
    {
        [PrimaryKey, AutoIncrement]
        private int Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }


        public string VenueName { get; set; } // NEW

        public string VenueCategory { get; set; } // NEW

        public float VenueLat { get; set; } // NEW

        public float VenueLng { get; set; } // NEW


        public override string ToString ()
        {
            return Title;
        }

        public static List<Experience> GetExperiences()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Experience>();

                return conn.Table<Experience>().ToList();
            }
        }
    }
}
