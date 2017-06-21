﻿// -----------------------------------------------------------------------
//  <copyright file="IWcfLogService.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
//  <dateCreated>2017-04-24</dateCreated>
//  <dateModified>2017-06-20</dateModified>
//  <lastModifiedBy>Dan Garvey</lastModifiedBy>
// -----------------------------------------------------------------------

namespace Dangr.Logging.Wcf
{
    using System.ServiceModel;

    /// <summary>
    /// Interface for a service that listens for connections from 
    /// <see cref="WcfLogClient" /> s and logs the messages to a designated 
    /// <see cref="LogService" /> .
    /// </summary>
    [ServiceContract(Namespace = "http://Dangr/Logging/2015/10")]
    public interface IWcfLogService
    {
        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        [OperationContract]
        void Log(LogEntry message);

        /// <summary>
        /// Logs a batch of messages.
        /// </summary>
        /// <param name="messages">The messages.</param>
        [OperationContract]
        void LogBatch(LogEntry[] messages);
    }
}