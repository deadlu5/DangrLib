﻿// -----------------------------------------------------------------------
//  <copyright file="ErrorCommand.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Command.Commands
{
    using Dangr.Core.Command;
    using Dangr.Core.Command.Annotation;

    [DangrCommand("Error", "A dangr command that writes a value to error.")]
    public class ErrorCommand : IDangrCommand
    {
        [Parameter("The value to output.", Mandatory = true, Position = 0)]
        public string Value { get; set; }

        public void Execute(ICommandContext executionContext)
        {
            executionContext.Error(this.Value);
        }
    }
}