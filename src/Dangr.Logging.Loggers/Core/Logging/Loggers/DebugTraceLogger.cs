﻿// -----------------------------------------------------------------------
//  <copyright file="DebugTraceLogger.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Logging.Loggers
{
    using System.Diagnostics;
    using Dangr.Core.Logging;

    /// <summary>
    /// Logger pipeline logger that will log a message to the debug trace
    /// </summary>
    public class DebugTraceLogger : ILogEndpoint
    {
        /// <summary>
        /// Logs the specified entry.
        /// </summary>
        /// <param name="entry">The entry.</param>
        public void Log(LogEntry entry)
        {
            Debug.WriteLine(entry.ToString());
        }
    }
}