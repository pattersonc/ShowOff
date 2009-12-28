using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShowOff.Core.Model
{
    public class Item
    {
        public virtual int ID { get; set; }
        [Required]
        [StringLength(75)]
        public virtual string Name { get; set; }
        [Required]
        [StringLength(250)]
        public virtual string Description { get; set; }
        [Required]
        [StringLength(100)]
        public virtual string Url { get; set; }

        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual int DisplayPriority { get; set; }
        public virtual IList<ItemImage> Images { get; set; }
        public virtual ItemImage CoverImage { get; set; }
        public virtual ItemType Type { get; set; }
    }
}