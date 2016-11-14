using System.Collections.Generic;

namespace AlgebraicStructure.Magma.Implementation
{
    public class StringMonoid : IMonoid<StringMonoid>
    {
        readonly string raw;

        public StringMonoid(string raw)
        {
            if (raw == null)
                throw new System.ArgumentNullException();
            this.raw = raw;
        }

        public StringMonoid op(StringMonoid e)
        {
            return new StringMonoid(raw + e.raw);
        }

        public static StringMonoid operator*(StringMonoid a, StringMonoid b)
        {
            return a.op(b);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is StringMonoid))
                return false;
            var s = (StringMonoid) obj;
            return raw.Equals(s.raw);
        }
    }

    public class StringMonoidFunctions : IMonoidFunctions<StringMonoid>
    {
        public ISet<StringMonoid> Identities { get { return new HashSet<StringMonoid> { new StringMonoid("") }; } }
    }
}
