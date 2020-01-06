using System;
namespace shipping.Model
{
    public class BoxDetailEntity
    {
        public int BoxId { get; set; }

        public int PartNumber { get; set; }

        public int PartWeight { get; set; }

        public int PartCost { get; set; }
    }
}
