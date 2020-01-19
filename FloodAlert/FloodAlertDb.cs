using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.Data.SqlClient;
using Windows.Storage;
using System.IO;

namespace FloodAlert
{
    class FloodAlertDb : DbContext
    {
        public DbSet<ObservationData> ObservationData{ get; set; }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {          
            optionsBuilder.UseSqlite(@"DataSource=C:\\Users\fatih\AppData\Local\Packages\2e3bd0da-5be9-4478-b548-4bc6f715a7d2_gny0dyt6zbn0e\LocalState\FloodAlert.db");
            base.OnConfiguring(optionsBuilder);
        }
        //public virtual DbSet<ObservationData> ObservationData { get; set; }
    }
}
