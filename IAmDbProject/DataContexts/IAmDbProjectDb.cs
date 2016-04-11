using IAmDbProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAmDbProject.DataContexts
{
    public class IAmDbProjectDb : DbContext
    {
        public IAmDbProjectDb() : base("name=DefaultConnection")
        {

        }

        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<Item_In_Transaction> ItemsInTransactions { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Donor> Donors { get; set; }


    }
}
