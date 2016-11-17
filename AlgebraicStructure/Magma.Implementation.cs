using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlgebraicStructure.Magma.Implementation
{
#region String

    public class StringMonoid : IMonoid<StringMonoid>
    {
        public readonly string Raw;

        public StringMonoid(string raw)
        {
            if (raw == null)
                throw new System.ArgumentNullException();
            this.Raw = raw;
        }

        public StringMonoid op(StringMonoid e)
        {
            return new StringMonoid(Raw + e.Raw);
        }

        public static StringMonoid operator *(StringMonoid a, StringMonoid b)
        {
            return a.op(b);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is StringMonoid))
                return false;
            var s = (StringMonoid)obj;
            return Raw.Equals(s.Raw);
        }

        public override int GetHashCode()
        {
            return Raw.GetHashCode();
        }
    }

    public class StringMonoidFunctions : IMonoidFunctions<StringMonoid>
    {
        public static readonly StringMonoidFunctions Instance = new StringMonoidFunctions();

        public StringMonoid Identity { get { return new StringMonoid(""); } }
    }

#endregion

#region Relative Path

    public class RelativePathGroup : IGroup<RelativePathGroup>
    {
        public readonly string Raw;

        public RelativePathGroup(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
                throw new System.ArgumentNullException();
            this.Raw = Normalize(raw);
        }

        public RelativePathGroup op(RelativePathGroup e)
        {
            var r = new RelativePathGroup(Path.Combine(Raw, e.Raw));
            System.Diagnostics.Debug.WriteLine("op: \"{0}\" \"{1}\" \"{2}\"", Raw, e.Raw, r.Raw);
            return r;
        }

        public static RelativePathGroup operator *(RelativePathGroup a, RelativePathGroup b)
        {
            return a.op(b);
        }

        public static string Normalize(string path)
        {
            var norm = path.Split(new char[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar })
                .Where(p => !"".Equals(p))
                .Aggregate(new Stack<string>(), (acc, e) =>
                {
                    switch (e)
                    {
                        case RelativePathGroupFunctions.InvertibilityUnit:
                            if (acc.Count == 0)
                            {
                                acc.Push(e);
                                break;
                            }
                            acc.Pop();
                            break;
                        case RelativePathGroupFunctions.IdentityString:
                            break;
                        default:
                            acc.Push(e);
                            break;
                    }
                    return acc;
                })
                .Reverse()
                .Aggregate("", Path.Combine);
            System.Diagnostics.Debug.WriteLine("Normalize: \"{0}\" \"{1}\"", path, norm);
            return norm;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is RelativePathGroup))
                return false;
            var s = (RelativePathGroup)obj;
            return Raw.Equals(s.Raw);
        }

        public override int GetHashCode()
        {
            return Raw.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("RelativePathGroup {{ raw: \"{0}\" }}", Raw);
        }
    }

    public class RelativePathGroupFunctions : IGroupFunctions<RelativePathGroup>
    {
        public static readonly RelativePathGroupFunctions Instance = new RelativePathGroupFunctions();

        internal const string IdentityString = ".";

        static readonly RelativePathGroup identity = new RelativePathGroup(IdentityString);

        public RelativePathGroup Identity
        {
            get
            {
                return identity;
            }
        }

        internal const string InvertibilityUnit = "..";

        public RelativePathGroup Invertibility(RelativePathGroup e)
        {
            var raw = "";
            for (var i = 0; i < Depth(e); i++)
            {
                raw = Path.Combine(raw, InvertibilityUnit);
            }
            return new RelativePathGroup(raw);
        }

        static int Depth(RelativePathGroup p)
        {
            return 1 + p.Raw.Count(c => c == Path.DirectorySeparatorChar || c == Path.AltDirectorySeparatorChar);
        }
    }

#endregion
}
