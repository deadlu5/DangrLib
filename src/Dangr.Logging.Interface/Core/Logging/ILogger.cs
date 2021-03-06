﻿// -----------------------------------------------------------------------
//  <copyright file="ILogger.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Logging
{
    /// <summary>
    /// Provides methods for logging categorized messages at varying 
    /// <see cref="LogLevel" />s.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs a message at the specified <see cref="LogLevel" />.
        /// </summary>
        /// <param name="level">The <see cref="LogLevel" />.</param>
        /// <param name="category">The category.</param>
        /// <param name="message">The message.</param>
        void Log(LogLevel level, string category, object message);

        /// <summary>
        /// Logs a message at the specified <see cref="LogLevel" />.
        /// </summary>
        /// <param name="level">The <see cref="LogLevel" />.</param>
        /// <param name="feature">
        /// The feature gating this message logging.
        /// </param>
        /// <param name="category">The category.</param>
        /// <param name="message">The message.</param>
        void Log(LogLevel level, string feature, string category, object message);
    }
}