﻿// -----------------------------------------------------------------------
//  <copyright file="ObjectPool.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.ObjectPool
{
    using System;

    /// <summary>
    /// Abstract class used to store a pool of objects that can be reused.
    /// </summary>
    /// <typeparam name="T">The type of objects to store.</typeparam>
    public abstract class ObjectPool<T>
        where T : IPooledObject, new()
    {
        /// <summary>
        /// Gets the first available object from the <see cref="ObjectPool{T}" /> .
        /// </summary>
        /// <returns>
        /// The first available object from the <see cref="ObjectPool{T}" /> .
        /// </returns>
        public T Get()
        {
            T pooledObject;
            if (!this.TryFetch(out pooledObject))
            {
                pooledObject = this.Create();
            }

            pooledObject.Acquire();
            return pooledObject;
        }

        /// <summary>
        /// Gets the first available object from the <see cref="ObjectPool{T}" /> that matches the given <see cref="Predicate{T}" /> .
        /// </summary>
        /// <param name="condition">
        /// The <see cref="Predicate{T}" /> to match.
        /// </param>
        /// <returns>
        /// The first available object from the <see cref="ObjectPool{T}" /> .
        /// </returns>
        public T Get(Predicate<T> condition)
        {
            T pooledObject;
            if (!this.TryFetch(condition, out pooledObject))
            {
                pooledObject = this.Create();
            }

            pooledObject.Acquire();
            return pooledObject;
        }

        /// <summary>
        /// Returns the specified object to the <see cref="ObjectPool{T}" /> .
        /// </summary>
        /// <param name="obj">The object to return.</param>
        public void Return(T obj)
        {
            obj.Reset();
            this.Store(obj);
        }

        /// <summary>
        /// Creates a new instance of the pooled object.
        /// </summary>
        /// <returns>A new instance of the pooled object.</returns>
        protected virtual T Create()
        {
            return new T();
        }

        /// <summary>
        /// Clears all items from the <see cref="ObjectPool{T}" /> .
        /// </summary>
        public abstract void Clear();

        /// <summary>
        /// Tries to get a reference to an object of type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="obj">
        /// The reference to the object fetched from the <see cref="ObjectPool{T}" /> .
        /// </param>
        /// <returns><c> true </c> if a reference was fetched.</returns>
        protected abstract bool TryFetch(out T obj);

        /// <summary>
        /// <para>Tries to get a reference to an object of type <typeparamref name="T"/> that matches the given <see cref="Predicate{T}" /></para>
        /// <para>.</para>
        /// </summary>
        /// <param name="condition">
        /// The condition that the fetched object should match.
        /// </param>
        /// <param name="obj">
        /// The reference to the object fetched from the <see cref="ObjectPool{T}" /> .
        /// </param>
        /// <returns><c> true </c> if a reference was fetched.</returns>
        protected abstract bool TryFetch(Predicate<T> condition, out T obj);

        /// <summary>
        /// Stores the given object in the <see cref="ObjectPool{T}" /> .
        /// </summary>
        /// <param name="obj">The object to store.</param>
        protected abstract void Store(T obj);
    }
}