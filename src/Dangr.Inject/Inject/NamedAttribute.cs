﻿// -----------------------------------------------------------------------
//  <copyright file="NamedAttribute.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Inject
{
    using System;

    public class NamedAttribute : Attribute
    {
        public string Name { get; }

        public NamedAttribute(string name)
        {
            this.Name = name;
        }
    }
}