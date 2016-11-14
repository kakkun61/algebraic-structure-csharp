using NUnit.Framework;
using System.Linq;
using AlgebraicStructure.Magma.Implementation;

namespace AlgebraicStructureTest.Magma
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void StringMonoidIdentity()
        {
            var es = StringMonoidFunctions.Instance.Identities;
            var a = new StringMonoid("hi");
            foreach (var e in es)
                Assert.AreEqual(e.op(a), a);
        }
    }
}

