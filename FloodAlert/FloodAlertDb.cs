﻿using System;
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
        public DbSet<ObservationData> ObservationData { get; set; }
        public DbSet<WaterStation> WaterStation { get; set; }
        public DbSet<Settings> Settings { get; set; }
        string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, "FloodAlert.db");
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {          
            optionsBuilder.UseSqlite("Data Source = "+ path);
        }
    }
}
