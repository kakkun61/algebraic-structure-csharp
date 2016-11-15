using System.Collections.Generic;

namespace AlgebraicStructure.Magma.Implementation
{
#region String

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

        public override int GetHashCode()
        {
            return raw.GetHashCode();
        }
    }

    public class StringMonoidFunctions : IMonoidFunctions<StringMonoid>
    {
        public static readonly StringMonoidFunctions Instance = new StringMonoidFunctions();

        public StringMonoid Identity { get { return new StringMonoid(""); } }
    }

#endregion
}
