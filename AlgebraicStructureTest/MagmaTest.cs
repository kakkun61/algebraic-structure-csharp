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
            var es = StringMonoidFunctions.Instance.Identities;
            var a = new StringMonoid("hi");
            foreach (var e in es)
                Assert.AreEqual(e.op(a), a);
        }

        [Test()]
        public void StringMonoidRightIdentity()
        {
            var es = StringMonoidFunctions.Instance.Identities;
            var a = new StringMonoid("hi");
            foreach (var e in es)
                Assert.AreEqual(a.op(e), a);
        }

        [Test()]
        public void StringMonoidAssociativity()
        {
            var a = new StringMonoid("1");
            var b = new StringMonoid("2");
            var c = new StringMonoid("3");
            Assert.AreEqual((a*b)*c, a*(b*c));
        }
    }
}

