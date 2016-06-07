namespace ReviewDatabaseFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Persons
    {
        public int ID { get; set; }

        public string FirstMidName { get; set; }

        public string LastName { get; set; }

        public virtual Students Students { get; set; }

        public virtual Teachers Teachers { get; set; }
    }
}
