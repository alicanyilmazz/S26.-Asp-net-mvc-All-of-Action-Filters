using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Action_Filter_sample_1.Models.Managers
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Log> db_context_Log { get; set; }
        public DbSet<User> db_context_User { get; set; }
    }
}