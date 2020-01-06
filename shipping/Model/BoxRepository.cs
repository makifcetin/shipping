using System;
using System.Collections.Generic;

namespace shipping.Model
{
    public class BoxRepository
    {
        public List<BoxEntity> GetBoxes()
        {
            return new List<BoxEntity>()
                { new BoxEntity{ BoxId = 123450, Weight = 3, PartCount = 0},
                  new BoxEntity{ BoxId = 123461, Weight = 8, PartCount = 0},
                  new BoxEntity{ BoxId = 123472, Weight = 11, PartCount = 0},
                  new BoxEntity{ BoxId = 123483, Weight = 3, PartCount = 0},
                  new BoxEntity{ BoxId = 123494, Weight = 13, PartCount = 0},
            };
        }
    }
}
