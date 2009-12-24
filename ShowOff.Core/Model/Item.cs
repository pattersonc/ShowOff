using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShowOff.Core.Model
{
    public class Item
    {
        public virtual int ID { get; set; }
        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual string Description { get; set; }
        [Required]
        public virtual string Url { get; set; }

        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual int DisplayPriority { get; set; }
        public virtual IList<ItemImage> Images { get; set; }
        public virtual ItemImage CoverImage { get; set; }
        public virtual ItemType Type { get; set; }
    }
}