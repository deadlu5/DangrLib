﻿// -----------------------------------------------------------------------
//  <copyright file="DangrCommandFactoryTest.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Command
{
    using System;
    using Dangr.Command.Commands;
    using Dangr.Core;
    using Dangr.Core.Command;
    using Dangr.Core.Command.Exceptions;
    using Dangr.Core.Diagnostics;
    using Dangr.Core.Test;
    using Dangr.Internal.Command;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DangrCommandFactoryTest
    {
        [TestMethod]
        public void InitializeType_NoDangrCommandAttribute()
        {
            TestUtils.TestForError<InvalidOperationException>(
                () => new DangrCommandFactory<NoDangrCommandAttribute>(),
                "Expected exception not thrown.");
        }

        [TestMethod]
        public void InitializeType_PrivateSetterOnParameter()
        {
            TestUtils.TestForError<InvalidOperationException>(
                () => new DangrCommandFactory<PrivateSetterOnParameter>(),
                "Expected exception not thrown.");
        }

        [TestMethod]
        public void InitializeType_DuplicateParameterName()
        {
            TestUtils.TestForError<InvalidOperationException>(
                () => new DangrCommandFactory<DuplicateParameterName>(),
                "Expected exception not thrown.");
        }

        [TestMethod]
        public void InitializeType_DuplicateParameterPosition()
        {
            TestUtils.TestForError<InvalidOperationException>(
                () => new DangrCommandFactory<DuplicateParameterPosition>(),
                "Expected exception not thrown.");
        }

        [TestMethod]
        public void Create_JustMandatoryArgs()
        {
            CommandLine commandLine = new CommandLine("ValidCommand -MandatoryArg 1");
            IDangrCommandFactory factory = new DangrCommandFactory<ValidCommand>();
            IDangrCommand command = factory.Create(commandLine);

            Validate.Value.IsType<ValidCommand>(command, "Wrong type of command created.");
            ValidCommand validCommand = (ValidCommand) command;

            Validate.Value.AreEqual("1", validCommand.MandatoryArg,
                "Wrong value assigned for madatory arg.");
            Validate.Value.IsNull(validCommand.Named0,
                "Value should not have been assigned for named arg.");
            Validate.Value.IsNull(validCommand.Parameter0,
                "Value should not have been assigned for positional arg 0.");
            Validate.Value.IsNull(validCommand.Parameter1,
                "Value should not have been assigned for positional arg 1.");
            Validate.Value.IsFalse(validCommand.Flag0, "Flag0 should not have been set.");
            Validate.Value.IsNull(validCommand.SkipThisProperty,
                "Value should not have been assigned for non parameter property.");
        }

        [TestMethod]
        public void Create_WithNamedArg()
        {
            CommandLine commandLine = new CommandLine("ValidCommand -MandatoryArg 1 -Named0 named");
            IDangrCommandFactory factory = new DangrCommandFactory<ValidCommand>();
            IDangrCommand command = factory.Create(commandLine);

            Validate.Value.IsType<ValidCommand>(command, "Wrong type of command created.");
            ValidCommand validCommand = (ValidCommand) command;

            Validate.Value.AreEqual("1", validCommand.MandatoryArg,
                "Wrong value assigned for madatory arg.");
            Validate.Value.AreEqual("named", validCommand.Named0,
                "Wrong value assigned for named arg.");
            Validate.Value.IsNull(validCommand.Parameter0,
                "Value should not have been assigned for positional arg 0.");
            Validate.Value.IsNull(validCommand.Parameter1,
                "Value should not have been assigned for positional arg 1.");
            Validate.Value.IsFalse(validCommand.Flag0, "Flag0 should not have been set.");
            Validate.Value.IsNull(validCommand.SkipThisProperty,
                "Value should not have been assigned for non parameter property.");
        }

        [TestMethod]
        public void Create_WithNamedArgAlias()
        {
            CommandLine commandLine = new CommandLine("ValidCommand -MandatoryArg 1 -name named");
            IDangrCommandFactory factory = new DangrCommandFactory<ValidCommand>();
            IDangrCommand command = factory.Create(commandLine);

            Validate.Value.IsType<ValidCommand>(command, "Wrong type of command created.");
            ValidCommand validCommand = (ValidCommand) command;

            Validate.Value.AreEqual("1", validCommand.MandatoryArg,
                "Wrong value assigned for madatory arg.");
            Validate.Value.AreEqual("named", validCommand.Named0,
                "Wrong value assigned for named arg.");
            Validate.Value.IsNull(validCommand.Parameter0,
                "Value should not have been assigned for positional arg 0.");
            Validate.Value.IsNull(validCommand.Parameter1,
                "Value should not have been assigned for positional arg 1.");
            Validate.Value.IsFalse(validCommand.Flag0, "Flag0 should not have been set.");
            Validate.Value.IsNull(validCommand.SkipThisProperty,
                "Value should not have been assigned for non parameter property.");
        }

        [TestMethod]
        public void Create_WithPositionalArgs()
        {
            CommandLine commandLine = new CommandLine("ValidCommand -MandatoryArg 1 10 25");
            IDangrCommandFactory factory = new DangrCommandFactory<ValidCommand>();
            IDangrCommand command = factory.Create(commandLine);

            Validate.Value.IsType<ValidCommand>(command, "Wrong type of command created.");
            ValidCommand validCommand = (ValidCommand) command;

            Validate.Value.AreEqual("1", validCommand.MandatoryArg,
                "Wrong value assigned for madatory arg.");
            Validate.Value.IsNull(validCommand.Named0,
                "Value should not have been assigned for named arg.");
            Validate.Value.AreEqual("10", validCommand.Parameter0,
                "Wrong value assigned for positional arg 0.");
            Validate.Value.AreEqual("25", validCommand.Parameter1,
                "Wrong value assigned for positional arg 1.");
            Validate.Value.IsFalse(validCommand.Flag0, "Flag0 should not have been set.");
            Validate.Value.IsNull(validCommand.SkipThisProperty,
                "Value should not have been assigned for non parameter property.");
        }

        [TestMethod]
        public void Create_WithFlag()
        {
            CommandLine commandLine = new CommandLine("ValidCommand -MandatoryArg 1 -Flag0");
            IDangrCommandFactory factory = new DangrCommandFactory<ValidCommand>();
            IDangrCommand command = factory.Create(commandLine);

            Validate.Value.IsType<ValidCommand>(command, "Wrong type of command created.");
            ValidCommand validCommand = (ValidCommand) command;

            Validate.Value.AreEqual("1", validCommand.MandatoryArg,
                "Wrong value assigned for madatory arg.");
            Validate.Value.IsNull(validCommand.Named0,
                "Value should not have been assigned for named arg.");
            Validate.Value.IsNull(validCommand.Parameter0,
                "Value should not have been assigned for positional arg 0.");
            Validate.Value.IsNull(validCommand.Parameter1,
                "Value should not have been assigned for positional arg 1.");
            Validate.Value.IsTrue(validCommand.Flag0, "Flag0 was not set.");
            Validate.Value.IsNull(validCommand.SkipThisProperty,
                "Value should not have been assigned for non parameter property.");
        }

        [TestMethod]
        public void Create_WithAllArgs()
        {
            CommandLine commandLine = new CommandLine("ValidCommand -MandatoryArg 1 -name named 10 25 -Flag0");
            IDangrCommandFactory factory = new DangrCommandFactory<ValidCommand>();
            IDangrCommand command = factory.Create(commandLine);

            Validate.Value.IsType<ValidCommand>(command, "Wrong type of command created.");
            ValidCommand validCommand = (ValidCommand) command;

            Validate.Value.AreEqual("1", validCommand.MandatoryArg,
                "Wrong value assigned for madatory arg.");
            Validate.Value.AreEqual("named", validCommand.Named0,
                "Wrong value assigned for named arg.");
            Validate.Value.AreEqual("10", validCommand.Parameter0,
                "Wrong value assigned for positional arg 0.");
            Validate.Value.AreEqual("25", validCommand.Parameter1,
                "Wrong value assigned for positional arg 1.");
            Validate.Value.IsTrue(validCommand.Flag0, "Flag0 was not set.");
            Validate.Value.IsNull(validCommand.SkipThisProperty,
                "Value should not have been assigned for non parameter property.");
        }

        [TestMethod]
        public void Create_UnknownArgumentName()
        {
            CommandLine commandLine = new CommandLine("ValidCommand -MandatoryArg 1 -unknown value");
            IDangrCommandFactory factory = new DangrCommandFactory<ValidCommand>();
            UnknownCommandArgumentException exception = TestUtils.TestForError<UnknownCommandArgumentException>(
                () => factory.Create(commandLine),
                "Expected exception not thrown.");
            Validate.Value.AreEqual("unknown", exception.ArgumentName,
                "Exception thrown for wrong argument.");
        }

        [TestMethod]
        public void Create_UnknownPositionalParameter()
        {
            CommandLine commandLine = new CommandLine("ValidCommand -MandatoryArg 1 positional0 positional1 positional2");
            IDangrCommandFactory factory = new DangrCommandFactory<ValidCommand>();
            UnknownCommandArgumentException exception = TestUtils.TestForError<UnknownCommandArgumentException>(
                () => factory.Create(commandLine),
                "Expected exception not thrown.");
            Validate.Value.AreEqual("Positional parameter 2", exception.ArgumentName,
                "Exception thrown for wrong argument.");
        }

        [TestMethod]
        public void Create_UnknownFlag()
        {
            CommandLine commandLine = new CommandLine("ValidCommand -MandatoryArg 1 -unknownFlag");
            IDangrCommandFactory factory = new DangrCommandFactory<ValidCommand>();
            UnknownCommandArgumentException exception = TestUtils.TestForError<UnknownCommandArgumentException>(
                () => factory.Create(commandLine),
                "Expected exception not thrown.");
            Validate.Value.AreEqual("unknownFlag", exception.ArgumentName,
                "Exception thrown for wrong argument.");
        }

        [TestMethod]
        public void Create_WrongTypeForFlag()
        {
            CommandLine commandLine = new CommandLine("ValidCommand -MandatoryArg 1  -name");
            IDangrCommandFactory factory = new DangrCommandFactory<ValidCommand>();
            InvalidCommandArgumentException exception = TestUtils.TestForError<InvalidCommandArgumentException>(
                () => factory.Create(commandLine),
                "Expected exception not thrown.");
            Validate.Value.AreEqual("name", exception.ArgumentName,
                "Exception thrown for wrong argument.");
        }

        [TestMethod]
        public void Create_MissingMandatory()
        {
            CommandLine commandLine = new CommandLine("ValidCommand -name 1");
            IDangrCommandFactory factory = new DangrCommandFactory<ValidCommand>();
            MissingCommandArgumentException exception = TestUtils.TestForError<MissingCommandArgumentException>(
                () => factory.Create(commandLine),
                "Expected exception not thrown.");
            Validate.Value.AreEqual("MandatoryArg", exception.ArgumentName,
                "Exception thrown for wrong argument.");
        }

        [TestMethod]
        public void Parse_Decimal()
        {
            const decimal expected = 12.345M;
            CommandLine commandLine = new CommandLine($"Types -Decimal {expected}");
            IDangrCommandFactory factory = new DangrCommandFactory<TypeCommand>();

            IDangrCommand command = factory.Create(commandLine);

            Validate.Value.IsType<TypeCommand>(command, "Wrong type of command created.");
            TypeCommand typeCommand = (TypeCommand)command;
            Validate.Value.AreEqual(expected, typeCommand.Decimal, "Wrong value assigned arg.");
        }

        [TestMethod]
        public void Parse_Double()
        {
            const double expected = 12.345;
            CommandLine commandLine = new CommandLine($"Types -Double {expected}");
            IDangrCommandFactory factory = new DangrCommandFactory<TypeCommand>();

            IDangrCommand command = factory.Create(commandLine);

            Validate.Value.IsType<TypeCommand>(command, "Wrong type of command created.");
            TypeCommand typeCommand = (TypeCommand)command;
            Validate.Value.AreEqual(expected, typeCommand.Double, "Wrong value assigned arg.");
        }

        [TestMethod]
        public void Parse_Float()
        {
            const float expected = 12.345f;
            CommandLine commandLine = new CommandLine($"Types -Float {expected}");
            IDangrCommandFactory factory = new DangrCommandFactory<TypeCommand>();

            IDangrCommand command = factory.Create(commandLine);

            Validate.Value.IsType<TypeCommand>(command, "Wrong type of command created.");
            TypeCommand typeCommand = (TypeCommand)command;
            Validate.Value.AreEqual(expected, typeCommand.Float, "Wrong value assigned arg.");
        }

        [TestMethod]
        public void Parse_Long()
        {
            const long expected = 12345L;
            CommandLine commandLine = new CommandLine($"Types -Long {expected}");
            IDangrCommandFactory factory = new DangrCommandFactory<TypeCommand>();

            IDangrCommand command = factory.Create(commandLine);

            Validate.Value.IsType<TypeCommand>(command, "Wrong type of command created.");
            TypeCommand typeCommand = (TypeCommand)command;
            Validate.Value.AreEqual(expected, typeCommand.Long, "Wrong value assigned arg.");
        }

        [TestMethod]
        public void Parse_Int()
        {
            const int expected = 12345;
            CommandLine commandLine = new CommandLine($"Types -Int {expected}");
            IDangrCommandFactory factory = new DangrCommandFactory<TypeCommand>();

            IDangrCommand command = factory.Create(commandLine);

            Validate.Value.IsType<TypeCommand>(command, "Wrong type of command created.");
            TypeCommand typeCommand = (TypeCommand)command;
            Validate.Value.AreEqual(expected, typeCommand.Int, "Wrong value assigned arg.");
        }

        [TestMethod]
        public void Parse_String()
        {
            const string expected = "1234.5";
            CommandLine commandLine = new CommandLine($"Types -String {expected}");
            IDangrCommandFactory factory = new DangrCommandFactory<TypeCommand>();

            IDangrCommand command = factory.Create(commandLine);

            Validate.Value.IsType<TypeCommand>(command, "Wrong type of command created.");
            TypeCommand typeCommand = (TypeCommand)command;
            Validate.Value.AreEqual(expected, typeCommand.String, "Wrong value assigned arg.");
        }

        [TestMethod]
        public void Parse_Bool()
        {
            CommandLine commandLine = new CommandLine($"Types -Bool");
            IDangrCommandFactory factory = new DangrCommandFactory<TypeCommand>();

            IDangrCommand command = factory.Create(commandLine);

            Validate.Value.IsType<TypeCommand>(command, "Wrong type of command created.");
            TypeCommand typeCommand = (TypeCommand)command;
            Validate.Value.IsTrue(typeCommand.Bool, "Wrong value assigned arg.");
        }
    }
}