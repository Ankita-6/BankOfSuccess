using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccess
{
    internal class BankDbContext : DbContext
    {
       public BankDbContext() : base("defaultConnection")
        {

        }

        public DbSet<Account> accounts {  get; set; }
           
    }
   
 }
