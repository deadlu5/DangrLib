﻿// -----------------------------------------------------------------------
//  <copyright file="DangrCommandHelpTest.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Command.Commands
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Assert = Dangr.Diagnostics.Assert;

    [TestClass]
    public class DangrCommandHelpTest
    {
        [TestMethod]
        public void ShowHelp()
        {
            TextWriter outputStream = new StringWriter();
            TextWriter errorStream = new StringWriter();

            CommandContext context = new CommandContext("TestContext", outputStream, errorStream);
            context.AddCommand<OutputCommand>();
            context.Execute("help help");

            Assert.Validate.IsNotNullOrWhiteSpace(outputStream.ToString(),
                "Did not find the expected output.");
            Assert.Validate.IsNullOrWhiteSpace(errorStream.ToString(),
                "Should not have written value to error.");
            Console.WriteLine(outputStream.ToString());
        }

        [TestMethod]
        public void ShowHelp_All()
        {
            TextWriter outputStream = new StringWriter();
            TextWriter errorStream = new StringWriter();

            CommandContext context = new CommandContext("TestContext", outputStream, errorStream);
            context.AddCommand<OutputCommand>();
            context.Execute("help");

            Assert.Validate.IsNotNullOrWhiteSpace(outputStream.ToString(),
                "Did not find the expected output.");
            Assert.Validate.IsNullOrWhiteSpace(errorStream.ToString(),
                "Should not have written value to error.");
            Console.WriteLine(outputStream.ToString());
        }

        [TestMethod]
        public void ShowHelp_InvalidCommand()
        {
            TextWriter outputStream = new StringWriter();
            TextWriter errorStream = new StringWriter();

            CommandContext context = new CommandContext("TestContext", outputStream, errorStream);
            context.AddCommand<OutputCommand>();
            context.Execute("help invalid");

            Assert.Validate.IsNullOrWhiteSpace(outputStream.ToString(),
                "Should not have written value to output.");
            Assert.Validate.IsNotNullOrWhiteSpace(errorStream.ToString(),
                "Did not find the expected error output.");
            Console.WriteLine(errorStream.ToString());
        }
    }
}