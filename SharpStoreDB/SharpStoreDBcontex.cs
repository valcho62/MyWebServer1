namespace SharpStoreDB
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SharpStoreDBcontex : DbContext
    {
       
        public SharpStoreDBcontex()
            : base("name=SharpStoreDB")
        {
        }

        public virtual DbSet<Knife> Knives { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        
    }

    
}