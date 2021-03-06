﻿// -----------------------------------------------------------------------
//  <copyright file="RegistryValueChangedEventArgs.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Registry
{
    using System;

    /// <summary>
    /// <para>EventArgs for an 
    /// <see cref="IRegistry.ValueChanged" /></para>
    /// <para>event.</para>
    /// </summary>
    /// <seealso cref="T:System.EventArgs" />
    public class RegistryValueChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the key of the registry value that changed.
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistryValueChangedEventArgs" /> class.
        /// </summary>
        /// <param name="key">
        /// The key of the registry value that changed.
        /// </param>
        public RegistryValueChangedEventArgs(string key)
        {
            this.Key = key;
        }
    }
}