﻿// -----------------------------------------------------------------------
//  <copyright file="AssertType.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.Diagnostics
{
    /// <summary>
    /// Defines the different assert conditions usable in 
    /// <see cref="AssertResolver" /> implementations.
    /// </summary>
    public enum AssertType
    {
        /// <summary>
        /// The <see cref="AssertType.IsTrue" /> assert type.
        /// </summary>
        IsTrue,

        /// <summary>
        /// The <see cref="AssertType.IsFalse" /> assert type.
        /// </summary>
        IsFalse,

        /// <summary>
        /// The <see cref="AssertType.AreEqual" /> assert type.
        /// </summary>
        AreEqual,

        /// <summary>
        /// The <see cref="AssertType.AreNotEqual" /> assert type.
        /// </summary>
        AreNotEqual,

        /// <summary>
        /// The <see cref="AssertType.IsNotNull" /> assert type.
        /// </summary>
        IsNotNull,

        /// <summary>
        /// The <see cref="AssertType.IsNull" /> assert type.
        /// </summary>
        IsNull,

        /// <summary>
        /// The is <c>null</c> or empty assert type.
        /// </summary>
        IsNullOrEmpty,

        /// <summary>
        /// The is not <c>null</c> or empty assert type.
        /// </summary>
        IsNotNullOrEmpty,

        /// <summary>
        /// The is <c>null</c> or whitespace assert type.
        /// </summary>
        IsNullOrWhiteSpace,

        /// <summary>
        /// The is not <c>null</c> or whitespace assert type.
        /// </summary>
        IsNotNullOrWhiteSpace,

        /// <summary>
        /// The <see cref="AssertType.IsNotEmpty" /> assert type.
        /// </summary>
        IsNotEmpty,

        /// <summary>
        /// The <see cref="AssertType.IsEmpty" /> assert type.
        /// </summary>
        IsEmpty,

        /// <summary>
        /// The <see cref="AssertType.IsNotZero" /> assert type.
        /// </summary>
        IsNotZero,

        /// <summary>
        /// The <see cref="AssertType.IsInRange" /> assert type.
        /// </summary>
        IsInRange,

        /// <summary>
        /// The <see cref="AssertType.Compare" /> assert type.
        /// </summary>
        Compare,

        /// <summary>
        /// The <see cref="AssertType.NotDisposed" /> assert type.
        /// </summary>
        NotDisposed,

        /// <summary>
        /// The is <see cref="AssertType.IsDisposed"/> assert type.
        /// </summary>
        IsDisposed,

        /// <summary>
        /// The <see cref="AssertType.IsType" /> assert type.
        /// </summary>
        IsType,

        /// <summary>
        /// The <see cref="AssertType.IsTypeOrNull" /> assert type.
        /// </summary>
        IsTypeOrNull,

        /// <summary>
        /// The <see cref="AssertType.Fail" /> assert type.
        /// </summary>
        Fail
    }
}