using System.Collections.Generic;
using Foundation.Extensions;
using FoundationTest.ContextSpecifications;
using NUnit.Framework;

namespace FoundationTest.Extensions.EnumerableExtensionsTests
{
    [TestFixture]
    public class When_for_eaching_an_enumeration : ContextSpecification
    {
        private int _count;
        private IEnumerable<Mock> _items;

        public override void Given()
        {
            base.Given();

            _count = 0;
            _items = new List<Mock>
                         {
                             new Mock(),
                             new Mock(),
                             new Mock()
                         };
        }

        public override void OnWhen()
        {
            base.OnWhen();

            _items.ForEach(i =>
                               {
                                   i.Num++;
                                   _count++;
                               });
        }

        [Test]
        public void should_execute_action_for_every_item()
        {
            When();
            Assert.AreEqual(3, _count);
        }

        [Test]
        public void should_execute_action_on_every_item()
        {
            When();

            foreach (var item in _items)
            {
                Assert.AreEqual(1, item.Num);
            }
        }

        private class Mock
        {
            public Mock()
            {
                Num = 0;
            }

            public int Num { get; set; }
        }
    }
}