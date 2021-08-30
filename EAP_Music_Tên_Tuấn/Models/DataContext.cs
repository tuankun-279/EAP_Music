using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EAP_Music_Tên_Tuấn.Models
{
    public class DataContext :DbContext
    {
        public DataContext() : base("EAP_Music")
        {
            Database.SetInitializer<DataContext>(new DataInitializer());
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Album> Albums { get; set; }

        

    }

}