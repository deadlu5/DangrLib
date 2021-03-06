﻿// -----------------------------------------------------------------------
//  <copyright file="AssertionFailedException.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Core.Diagnostics
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Exception that is thrown when an Assertion is failed.
    /// </summary>
    [Serializable]
    public class AssertionFailedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssertionFailedException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public AssertionFailedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssertionFailedException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected AssertionFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}