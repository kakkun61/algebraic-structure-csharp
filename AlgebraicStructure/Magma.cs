using System.Collections.Generic;

namespace AlgebraicStructure
{
    public interface IMagma<T> where T : IMagma<T>
    {
        T op(T e);
    }

    /// <summary>Associative magma.</summary>
    interface ISemigroup<T> : IMagma<T> where T : ISemigroup<T>
    {
    }

    interface IIdenticalMagma<T> : IMagma<T> where T : IIdenticalMagma<T>
    {
    }

    interface IIdenticalMagmaFunctions<T> where T : IIdenticalMagma<T>
    {
        ISet<T> Identities { get; }
    }

    interface ICancellativeMagma<T> : IMagma<T> where T : ICancellativeMagma<T>
    {
    }

    /// <summary>Invertible magma. Identical and cancellative.</summary>
    interface ILoop<T> : ICancellativeMagma<T>, IIdenticalMagma<T> where T : ILoop<T>
    {
    }

    interface ILoopFunctions<T> : IIdenticalMagmaFunctions<T> where T : ILoop<T>
    {
        ISet<T> Invertibilities { get; }
    }

    /// <summary>Associative and identical magma.</summary>
    interface IMonoid<T> : IIdenticalMagma<T>, ISemigroup<T> where T : IMonoid<T>
    {
    }

    interface IMonoidFunctions<T> : IIdenticalMagmaFunctions<T> where T : IMonoid<T>
    {
    }
    
    /// <summary>Associative and identical and cancellative magma.</summary>
    interface IGroup<T> : ILoop<T>, ISemigroup<T> where T : IGroup<T>
    {
    }

    interface IGroupFunctions<T> : ILoopFunctions<T> where T : IGroup<T>
    {
    }
}
