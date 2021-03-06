﻿// -----------------------------------------------------------------------
//  <copyright file="InitializableExtensions.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Util
{
    /// <summary>
    /// <para>Provides extension methods to the <see cref="IInitializable" />
    /// </para>
    /// <para>interface.</para>
    /// </summary>
    public static class InitializableExtensions
    {
        /// <summary>
        /// Initializes the specified <see cref="IInitializable" /> instance, and returns a typed reference to it.
        /// </summary>
        /// <typeparam name="T">
        /// The type of <see cref="IInitializable" /> to initialize.
        /// </typeparam>
        /// <param name="initializable">
        /// The <see cref="IInitializable" /> .
        /// </param>
        /// <returns>The reference that was initialized.</returns>
        public static T Initialize<T>(this T initializable) where T : IInitializable
        {
            initializable.Init();
            return initializable;
        }
    }
}