using NUnit.Framework;
using shipping.Controller;
using shipping.Model;
using System;
namespace Shipping.Test
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestCase()
        {
            BoxRepository rep = new BoxRepository();

            var boxes = rep.GetBoxes();

            var distribution = new Distribution(boxes);

            distribution.BoxDistribution();

        }
    }
}
