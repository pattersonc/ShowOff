namespace ShowOff.Core.Model
{
    public class ItemImage
    {
        public virtual int ID { get; set;}
        public virtual string Filename { get; set;}
        public virtual string ThumbFilename { get; set; }
        public virtual Item ItemID { get; set; }
    }
}