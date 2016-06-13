namespace DatabaseFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pets
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Owner_Id { get; set; }

        public virtual Cats Cats { get; set; }

        public virtual Dogs Dogs { get; set; }

        public virtual People People { get; set; }
    }
}
