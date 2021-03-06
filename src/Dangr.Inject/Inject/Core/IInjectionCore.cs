﻿// -----------------------------------------------------------------------
//  <copyright file="IInjectionCore.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Inject.Core
{
    /// <summary>
    /// Provides methods for building a dependency graph and creating instances from it.
    /// </summary>
    public interface IInjectionCore
    {
        /// <summary>
        /// Gets an instance of the dependency defined with the specified type.
        /// </summary>
        /// <typeparam name="T">The dependency type.</typeparam>
        /// <exception cref="System.InvalidOperationException">
        /// If no dependency with the specified <typeparamref name="T" /> is defined.
        /// </exception>
        T Get<T>();

        /// <summary>
        /// Gets an instance of the dependency defined with the specified name.
        /// </summary>
        /// <param name="name">The dependency name.</param>
        /// <exception cref="System.InvalidOperationException">
        /// If no dependency with the specified name is defined.
        /// </exception>
        T Get<T>(string name);
    }
}