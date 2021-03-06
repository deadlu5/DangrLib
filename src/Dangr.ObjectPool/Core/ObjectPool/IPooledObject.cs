﻿// -----------------------------------------------------------------------
//  <copyright file="IPooledObject.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.ObjectPool
{
    /// <summary>
    /// Provides methods for acquiring and resetting items that can be used in
    /// an object pool.
    /// </summary>
    public interface IPooledObject
    {
        /// <summary>
        /// Acquires this <see cref="IPooledObject" /> instance as it is pulled from an <see cref="ObjectPool{T}" /> . Should only be called by the <see cref="ObjectPool{T}" /> .
        /// </summary>
        void Acquire();

        /// <summary>
        /// Resets this <see cref="IPooledObject" /> instance as it is returned to an <see cref="ObjectPool{T}" /> . Should only be called by the <see cref="ObjectPool{T}" /> .
        /// </summary>
        void Reset();
    }
}