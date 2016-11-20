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

    /// <summary>Cancellative magma.</summary>
    interface ICancellativeMagma<T> : IRightCancellativeMagma<T>, ILeftCancellativeMagma<T> where T : ICancellativeMagma<T>
    {
    }

    interface IRightCancellativeMagma<T> : IMagma<T> where T : IRightCancellativeMagma<T>
    {
    }

    interface ILeftCancellativeMagma<T> : IMagma<T> where T : ILeftCancellativeMagma<T>
    {
    }

    #endregion

    #region Quasigroup

    /// <summary>Devisibile magma.</summary>
    interface IQuasigroup<T> : ILeftQuasigroup<T>, IRightQuasigroup<T> where T : IQuasigroup<T>
    {
    }

    interface IRightQuasigroup<T> : IRightCancellativeMagma<T> where T : IRightQuasigroup<T>
    {
    }

    interface ILeftQuasigroup<T> : ILeftCancellativeMagma<T> where T : ILeftQuasigroup<T>
    {
    }

    interface IQuasigroupFunctions<T> : IRightQuasigroupFunctions<T>, ILeftQuasigroupFunctions<T> where T : IQuasigroup<T>
    {
        /// <summary>c = a / b ⇔ a = c * b</summary>
        /// <returns>c</returns>
        /// <param name="a">a</param>
        /// <param name="b">b</param>
        T Devide(T a, T b);
    }

    interface IRightQuasigroupFunctions<T> where T : IRightQuasigroup<T>
    {
        /// <summary>c = a / b ⇔ a = c * b</summary>
        /// <returns>c</returns>
        /// <param name="a">a</param>
        /// <param name="b">b</param>
        T RightDevide(T a, T b);
    }

    interface ILeftQuasigroupFunctions<T> where T : ILeftQuasigroup<T>
    {
        /// <summary>c = b \ a ⇔ a = b * c</summary>
        /// <returns>c</returns>
        /// <param name="a">a</param>
        /// <param name="b">b</param>
        T LeftDevide(T a, T b);
    }

    #endregion

    #region Loop

    /// <summary>Invertible magma. Identical and cancellative.</summary>
    interface ILoop<T> : IRightLoop<T>, ILeftLoop<T> where T : ILoop<T>
    {
    }

    interface IRightLoop<T> : IRightCancellativeMagma<T>, IIdenticalMagma<T> where T : IRightLoop<T>
    {
    }

    interface ILeftLoop<T> : ILeftCancellativeMagma<T>, IIdenticalMagma<T> where T : ILeftLoop<T>
    {
    }

    interface ILoopFunctions<T> : IRightLoopFunctions<T>, ILeftLoopFunctions<T> where T : ILoop<T>
    {
        T Invertibility(T e);
    }

    interface IRightLoopFunctions<T> : IIdenticalMagmaFunctions<T> where T : IRightLoop<T>
    {
        T RightInvertibility(T e);
    }

    interface ILeftLoopFunctions<T> : IIdenticalMagmaFunctions<T> where T : ILeftLoop<T>
    {
        T LeftInvertibility(T e);
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
