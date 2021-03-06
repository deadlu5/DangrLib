﻿// -----------------------------------------------------------------------
//  <copyright file="StringExtensionsTests.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Util
{
    using Dangr.Core.Diagnostics;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void TestCapsToPascalCase_EmptyString()
        {
            string testStringAllCaps = "";
            string testStringPascal = "";
            Validate.Value.AreEqual(
                testStringAllCaps.CapsToPascalCase(),
                testStringPascal,
                "Did not correctly convert string to PascalCase.");
        }

        [TestMethod]
        public void TestCapsToPascalCase_SingleWord()
        {
            string testStringAllCaps = "HELLO";
            string testStringPascal = "Hello";
            Validate.Value.AreEqual(
                testStringAllCaps.CapsToPascalCase(),
                testStringPascal,
                "Did not correctly convert string to PascalCase.");
        }

        [TestMethod]
        public void TestCapsToPascalCase_TwoWord()
        {
            string testStringAllCaps = "HELLO_THERE";
            string testStringPascal = "HelloThere";
            Validate.Value.AreEqual(
                testStringAllCaps.CapsToPascalCase(),
                testStringPascal,
                "Did not correctly convert string to PascalCase.");
        }

        [TestMethod]
        public void TestCapsToPascalCase_ThreeWord()
        {
            string testStringAllCaps = "HELLO_THERE_YOU";
            string testStringPascal = "HelloThereYou";
            Validate.Value.AreEqual(
                testStringAllCaps.CapsToPascalCase(),
                testStringPascal,
                "Did not correctly convert string to PascalCase.");
        }

        [TestMethod]
        public void TestCapsToPascalCase_TwoUnderscore()
        {
            string testStringAllCaps = "HELLO__THERE";
            string testStringPascal = "HelloThere";
            Validate.Value.AreEqual(
                testStringAllCaps.CapsToPascalCase(),
                testStringPascal,
                "Did not correctly convert string to PascalCase.");
        }

        [TestMethod]
        public void TestCapsToPascalCase_StartWithUnderscore()
        {
            string testStringAllCaps = "_HELLO";
            string testStringPascal = "Hello";
            Validate.Value.AreEqual(
                testStringAllCaps.CapsToPascalCase(),
                testStringPascal,
                "Did not correctly convert string to PascalCase.");
        }

        [TestMethod]
        public void TestCapsToPascalCase_StartWithTwoUnderscores()
        {
            string testStringAllCaps = "__HELLO";
            string testStringPascal = "Hello";
            Validate.Value.AreEqual(
                testStringAllCaps.CapsToPascalCase(),
                testStringPascal,
                "Did not correctly convert string to PascalCase.");
        }

        [TestMethod]
        public void TestCapsToPascalCase_EndWithUnderscore()
        {
            string testStringAllCaps = "HELLO_";
            string testStringPascal = "Hello";
            Validate.Value.AreEqual(
                testStringAllCaps.CapsToPascalCase(),
                testStringPascal,
                "Did not correctly convert string to PascalCase.");
        }

        [TestMethod]
        public void TestCapsToPascalCase_EndWithTwoUnderscores()
        {
            string testStringAllCaps = "HELLO__";
            string testStringPascal = "Hello";
            Validate.Value.AreEqual(
                testStringAllCaps.CapsToPascalCase(),
                testStringPascal,
                "Did not correctly convert string to PascalCase.");
        }

        [TestMethod]
        public void TestEscapeVerbatimString()
        {
            string testStringUnescaped = "\"";
            string testStringEscaped = "\"\"";

            Validate.Value.AreEqual(
                testStringUnescaped.EscapeVerbatimString(),
                testStringEscaped,
                "Did not correctly escape verbatim string.");
        }

        [TestMethod]
        public void TestEscapeQuoteString()
        {
            string testStringUnescaped = "\"";
            string testStringEscaped = "\\\"";

            Validate.Value.AreEqual(
                testStringUnescaped.EscapeStringQuotes(),
                testStringEscaped,
                "Did not correctly escape quoted string.");
        }
    }
}