﻿// -----------------------------------------------------------------------
//  <copyright file="TestEndpoint.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Framework.Logging
{
    using Dangr.Core.Logging;

    public class TestEndpoint : ILogEndpoint
    {
        public int NumMessagesLogged { get; private set; }

        /// <summary>
        /// Logs the specified entry.
        /// </summary>
        /// <param name="entry">The entry.</param>
        public void Log(LogEntry entry)
        {
            this.NumMessagesLogged++;
        }
    }
}