﻿// -----------------------------------------------------------------------
//  <copyright file="DangrCommandAttribute.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Command.Annotation
{
    using System;

    /// <summary>
    /// Defines an object as an <see cref="IDangrCommand"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class DangrCommandAttribute : Attribute
    {
        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        public string CommandName { get; }

        /// <summary>
        /// Gets the summary of the command used when displaying the command help.
        /// </summary>
        public string Summary { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DangrCommandAttribute"/> class.
        /// </summary>
        /// <param name="commandName">The name of the command.</param>
        /// <param name="summary">The summary of the command used when displaying the command help.</param>
        public DangrCommandAttribute(string commandName, string summary)
        {
            this.CommandName = commandName;
            this.Summary = summary;
        }
    }
}