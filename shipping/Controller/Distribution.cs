using System;
using System.Collections.Generic;
using System.Linq;
using shipping.Model;

namespace shipping.Controller
{
    public class Distribution
    {
        private List<BoxEntity> _boxes;
        private BoxDetailRepository _repository = new BoxDetailRepository();
        private const int baseCost = 50;
        private const int itemCost = 7;

        public Distribution(List<BoxEntity> boxes)
        {
            _boxes = boxes;
        }

        public List<BoxDetailEntity> BoxDistribution()
        {
            List<BoxDetailEntity> result = new List<BoxDetailEntity>();
            int partCount = 2;
            int partNumber = 1;

            var sortedBoxes = _boxes.OrderBy(x => x.Weight).ToList();

            foreach(var item in sortedBoxes)
            {
                item.PartCount = partCount;

                var boxPart = BoxDiv(item.Weight, item.PartCount);

                partNumber = 1;
                foreach(var part in boxPart)
                {
                    result.Add(new BoxDetailEntity {
                                                    BoxId = item.BoxId,
                                                    PartNumber = partNumber,
                                                    PartWeight = part,
                                                    PartCost = baseCost + (part * itemCost) });
                    partNumber++;
                }

                partCount++;
            }

            _repository.Save(result);

            return result;
        }

        private List<int> BoxDiv(int weight, int partCount)
        {
            List<int> boxPart = new List<int>();

            int minWeight = (int)(weight / partCount);
            int dif = weight - (minWeight * partCount);

            boxPart.Add(minWeight);

            for (int i = 1; i <= dif; i++)
            {
                boxPart.Add(minWeight + 1);
            }

            for (int j= boxPart.Count; j< partCount; j++)
            {
                boxPart.Add(minWeight);
            }

            return boxPart;
        }
    }
}
