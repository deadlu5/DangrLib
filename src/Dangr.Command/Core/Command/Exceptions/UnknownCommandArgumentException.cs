﻿// -----------------------------------------------------------------------
//  <copyright file="UnknownCommandArgumentException.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Core.Command.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    /// <summary>
    /// The Exception that is thrown when an unknown argument is passed to a command.
    /// </summary>
    /// <seealso cref="CommandExecutionException" />
    [Serializable]
    public class UnknownCommandArgumentException : CommandExecutionException
    {
        /// <summary>
        /// Gets the name of the unknown argument.
        /// </summary>
        public string ArgumentName { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnknownCommandArgumentException"/> class.
        /// </summary>
        /// <param name="argumentName">The name of the unknown argument. </param>
        /// <param name="message">The message that describes the error.</param>
        public UnknownCommandArgumentException(string argumentName, string message) : base(message)
        {
            this.ArgumentName = argumentName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnknownCommandArgumentException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected UnknownCommandArgumentException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
            this.ArgumentName = (string) info.GetValue(nameof(this.ArgumentName), typeof(string));
        }

        /// <summary>
        /// When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Read="*AllFiles*" PathDiscovery="*AllFiles*" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="SerializationFormatter" />
        /// </PermissionSet>
        [SecurityPermission(
             SecurityAction.LinkDemand,
             Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(this.ArgumentName), this.ArgumentName);

            base.GetObjectData(info, context);
        }
    }
}