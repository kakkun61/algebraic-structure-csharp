using NUnit.Framework;
using AlgebraicStructure.Magma.Implementation;

namespace AlgebraicStructureTest.Magma
{
    [TestFixture()]
    public class StringMonoidTest
    {
        [Test()]
        public void LeftIdentity()
        {
            var e = StringMonoidFunctions.Instance.Identity;
            var a = new StringMonoid("hi");
            Assert.AreEqual(e.op(a), a);
        }

        [Test()]
        public void RightIdentity()
        {
            var e = StringMonoidFunctions.Instance.Identity;
            var a = new StringMonoid("hi");
            Assert.AreEqual(a.op(e), a);
        }

        [Test()]
        public void Associativity()
        {
            var a = new StringMonoid("1");
            var b = new StringMonoid("2");
            var c = new StringMonoid("3");
            Assert.AreEqual((a * b) * c, a * (b * c));
        }
    }

    [TestFixture()]
    public class RelativePathGroupTest
    {
        [Test()]
        public void LeftIdentity()
        {
            var e = RelativePathMagmaFunctions.Instance.Identity;
            var a = new RelativePathMagma("hi");
            Assert.AreEqual(e.op(a), a);
        }

        [Test()]
        public void RightIdentity()
        {
            var e = RelativePathMagmaFunctions.Instance.Identity;
            var a = new RelativePathMagma("hi");
            Assert.AreEqual(a.op(e), a);
        }

        [Test()]
        public void Associativity()
        {
            var a = new RelativePathMagma("1");
            var b = new RelativePathMagma("2");
            var c = new RelativePathMagma("3");
            Assert.AreEqual((a * b) * c, a * (b * c));
        }

        [Test()]
        public void RightInvertibility()
        {
            var e = RelativePathMagmaFunctions.Instance.Identity;
            var a = new RelativePathMagma("hi");
            var ai = RelativePathMagmaFunctions.Instance.RightInvertibility(a);
            Assert.AreEqual(a.op(ai), e);
        }

        [Test()]
        public void RightDivisibility()
        {
            var a = new RelativePathMagma("hi/ho");
            var b = new RelativePathMagma("ho");
            var c = new RelativePathMagma("hi");
            Assert.AreEqual(a / b, c);
        }
    }
}
