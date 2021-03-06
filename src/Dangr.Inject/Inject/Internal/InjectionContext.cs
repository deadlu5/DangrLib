﻿// -----------------------------------------------------------------------
//  <copyright file="InjectionContext.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Inject.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    internal class InjectionContext : IDisposable
    {
        public static ThreadLocal<InjectionContext> CurrentContext { get; } = new ThreadLocal<InjectionContext>();

        public readonly ISet<string> NamedDependencies = new HashSet<string>();
        public readonly ISet<Type> TypedDependencies = new HashSet<Type>();

        private InjectionContext()
        {
        }

        public void Dispose()
        {
            InjectionContext.CurrentContext.Value = null;
        }

        public static InjectionContext NewContext()
        {
            if(InjectionContext.CurrentContext.Value != null)
            {
                return null;
            }

            InjectionContext.CurrentContext.Value = new InjectionContext();
            return InjectionContext.CurrentContext.Value;
        }
    }
}