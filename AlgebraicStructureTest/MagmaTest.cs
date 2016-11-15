using NUnit.Framework;
using System.Linq;
using AlgebraicStructure.Magma.Implementation;

namespace AlgebraicStructureTest.Magma
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void StringMonoidLeftIdentity()
        {
            var e = StringMonoidFunctions.Instance.Identity;
            var a = new StringMonoid("hi");
            Assert.AreEqual(e.op(a), a);
        }

        [Test()]
        public void StringMonoidRightIdentity()
        {
            var e = StringMonoidFunctions.Instance.Identity;
            var a = new StringMonoid("hi");
            Assert.AreEqual(a.op(e), a);
        }

        [Test()]
        public void StringMonoidAssociativity()
        {
            var a = new StringMonoid("1");
            var b = new StringMonoid("2");
            var c = new StringMonoid("3");
            Assert.AreEqual((a * b) * c, a * (b * c));
        }
    }
}
