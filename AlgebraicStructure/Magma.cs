namespace AlgebraicStructure.Magma
{
#region Magma

    public interface IMagma<T> where T : IMagma<T>
    {
        T op(T e);
    }

#endregion

#region Semigroup

    /// <summary>Associative magma.</summary>
    interface ISemigroup<T> : IMagma<T> where T : ISemigroup<T>
    {
    }

#endregion

#region Identical Magma

    interface IIdenticalMagma<T> : IMagma<T> where T : IIdenticalMagma<T>
    {
    }

    interface IIdenticalMagmaFunctions<T> where T : IIdenticalMagma<T>
    {
        T Identity { get; }
    }

#endregion

#region Cancellative Magma

    interface ICancellativeMagma<T> : IMagma<T> where T : ICancellativeMagma<T>
    {
    }

#endregion

#region Loop

    /// <summary>Invertible magma. Identical and cancellative.</summary>
    interface ILoop<T> : ICancellativeMagma<T>, IIdenticalMagma<T> where T : ILoop<T>
    {
    }

    interface ILoopFunctions<T> : IIdenticalMagmaFunctions<T> where T : ILoop<T>
    {
        T Invertibility(T e);
    }

#endregion

#region Monoid

    /// <summary>Associative and identical magma.</summary>
    interface IMonoid<T> : IIdenticalMagma<T>, ISemigroup<T> where T : IMonoid<T>
    {
    }

    interface IMonoidFunctions<T> : IIdenticalMagmaFunctions<T> where T : IMonoid<T>
    {
    }

#endregion

#region Group

    /// <summary>Associative and identical and cancellative magma.</summary>
    interface IGroup<T> : ILoop<T>, ISemigroup<T> where T : IGroup<T>
    {
    }

    interface IGroupFunctions<T> : ILoopFunctions<T> where T : IGroup<T>
    {
    }

#endregion
}
