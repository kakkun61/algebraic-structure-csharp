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
            var e = RelativePathGroupFunctions.Instance.Identity;
            var a = new RelativePathGroup("hi");
            Assert.AreEqual(e.op(a), a);
        }

        [Test()]
        public void RightIdentity()
        {
            var e = RelativePathGroupFunctions.Instance.Identity;
            var a = new RelativePathGroup("hi");
            Assert.AreEqual(a.op(e), a);
        }

        [Test()]
        public void Associativity()
        {
            var a = new RelativePathGroup("1");
            var b = new RelativePathGroup("2");
            var c = new RelativePathGroup("3");
            Assert.AreEqual((a * b) * c, a * (b * c));
        }

        [Test()]
        public void LeftInvertibility()
        {
            var e = RelativePathGroupFunctions.Instance.Identity;
            var a = new RelativePathGroup("hi");
            var ai = RelativePathGroupFunctions.Instance.Invertibility(a);
            Assert.AreEqual(ai.op(a), e);
        }

        [Test()]
        public void RightInvertibility()
        {
            var e = RelativePathGroupFunctions.Instance.Identity;
            var a = new RelativePathGroup("hi");
            var ai = RelativePathGroupFunctions.Instance.Invertibility(a);
            Assert.AreEqual(a.op(ai), e);
        }
    }
}
