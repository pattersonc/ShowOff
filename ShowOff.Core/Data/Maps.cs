using FluentNHibernate.Mapping;
using ShowOff.Core.Model;

namespace ShowOff.Core.Data
{
    public class ItemMap : ClassMap<Item>
    {
        //public virtual int ID { get; set; }
        //public virtual string Name { get; set; }
        //public virtual string Description { get; set; }
        //public virtual string Url { get; set; }
        //public virtual string CreatedDate { get; set; }
        //public virtual string ModifiedDate { get; set; }
        //public virtual int DisplayPriority { get; set; }
        //public virtual IList<ItemImage> Images { get; set; }
        //public virtual ItemImage CoverImage { get; set; }
        //public virtual ItemType Type { get; set; }
        public ItemMap()
        {
            Id(x => x.ID);
            Map(x => x.Name).Unique().Not.Nullable();
            Map(x => x.Description);
            Map(x => x.Url);
            Map(x => x.CreatedDate).Not.Nullable();
            Map(x => x.ModifiedDate).Not.Nullable();
            Map(x => x.DisplayPriority);
            HasMany(x => x.Images).KeyColumn("ItemID").Cascade.All();
            References(x => x.CoverImage).Column("CoverImageID").Cascade.All().Nullable();
            References(x => x.Type).Column("ItemTypeID").Not.Nullable();
        }
    }

    public class ItemImageMap : ClassMap<ItemImage>
    {
        //public virtual int ID { get; set; }
        //public virtual string Filename { get; set; }
        //public virtual string ThumbFilename { get; set; }
        public ItemImageMap()
        {
            Id(x => x.ID);
            Map(x => x.Filename).Not.Nullable();
            Map(x => x.ThumbFilename).Not.Nullable();
            References(x => x.ItemID).Column("ItemID");
        }
    }

    public class ItemTypeMap : ClassMap<ItemType>
    {
        //public virtual int ID { get; set; }
        //public virtual string Name { get; set; }
        //public virtual string DisplayName { get; set; }
        public ItemTypeMap()
        {
            Id(x => x.ID).GeneratedBy.Assigned();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.DisplayName).Not.Nullable();
        }
    }
}