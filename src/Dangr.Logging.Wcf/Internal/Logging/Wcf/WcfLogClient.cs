﻿// -----------------------------------------------------------------------
//  <copyright file="WcfLogClient.cs" company="Phoenix Game Studios, LLC">
//      Copyright (c) 2017 Phoenix Game Studios, LLC. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/PhoenixGameStudios/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------
namespace Dangr.Internal.Logging.Wcf
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using Dangr.Core.Diagnostics;
    using Dangr.Core.Logging;
    using Dangr.Core.Logging.Wcf;
    using Dangr.Core.Util;

    /// <summary>
    /// A WCF client for sending logs to a connected 
    /// <see cref="WcfLogService" /> .
    /// </summary>
    internal class WcfLogClient : ICheckedDisposable
    {
        private ChannelFactory<IWcfLogService> proxyFactory;
        private IWcfLogService proxy;
        private IChannel channel;

        /// <summary>
        /// Gets a value indicating whether this object is disposed.
        /// </summary>
        public bool IsDisposed { get; private set; }

        private WcfLogClient()
        {
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="WcfLogClient" /> class.
        /// </summary>
        ~WcfLogClient()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="isDisposing">
        /// <c> true </c> to release both managed and unmanaged resources; <c> false </c> to release only unmanaged resources.
        /// </param>
        [SuppressMessage(
            "Microsoft.Usage",
            "CA2213:DisposableFieldsShouldBeDisposed",
            MessageId = "proxyFactory",
            Justification = "CA2213 does not work with null conditional operator. Known issue https://github.com/dotnet/roslyn-analyzers/issues/291")]
        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing && !this.IsDisposed)
            {
                if ((this.channel.State == CommunicationState.Opening) ||
                    (this.channel.State == CommunicationState.Opened))
                {
                    try
                    {
                        this.channel.Close();
                    }
                    catch (CommunicationException)
                    {
                    }
                }

                this.proxyFactory?.Close();

                this.IsDisposed = true;
            }
        }

        /// <summary>
        /// Creates and connects a new <see cref="WcfLogClient" /> .
        /// </summary>
        /// <param name="binding">The WCF binding.</param>
        /// <param name="endpointAddress">The endpoint address.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Binding or endpointAddress is null.
        /// </exception>
        /// <returns>A newly created <see cref="WcfLogClient" /></returns>
        [SuppressMessage(
            "Microsoft.Reliability", 
            "CA2000:Dispose objects before losing scope",
            Justification = "The method constructs a new client. Disposing of it does not make sense here.")]
        public static WcfLogClient CreateClient(Binding binding, EndpointAddress endpointAddress)
        {
            Validate.Value.IsNotNull(binding, nameof(binding));
            Validate.Value.IsNotNull(endpointAddress, nameof(endpointAddress));

            WcfLogClient client = new WcfLogClient
            {
                proxyFactory = new ChannelFactory<IWcfLogService>(binding, endpointAddress)
            };
            client.CreateProxy();

            return client;
        }

        /// <summary>
        /// Sends the specified message to the connected <see cref="WcfLogService" /> .
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="System.InvalidOperationException">
        /// The WCF Channel is in an invalid state.
        /// </exception>
        public void Log(LogEntry message)
        {
            Validate.Value.IsNotDisposed(this, nameof(WcfLogClient));
            Validate.Value.IsNotNull(message, nameof(message));

            if ((this.channel.State == CommunicationState.Closed) || (this.channel.State == CommunicationState.Faulted))
            {
                this.channel.Abort();
                this.CreateProxy();
            }

            if ((this.channel.State == CommunicationState.Opened) || (this.channel.State == CommunicationState.Created))
            {
                this.proxy.Log(message);
            }
            else
            {
                throw new InvalidOperationException(
                    $"WCF Channel on endpoint {this.proxyFactory.Endpoint.Address} is in {this.channel.State} state.");
            }
        }

        /// <summary>
        /// Sends a batch of messages to the connected <see cref="WcfLogService" /> .
        /// </summary>
        /// <param name="messages">The messages.</param>
        public void LogBatch(LogEntry[] messages)
        {
            Validate.Value.IsNotDisposed(this, nameof(WcfLogClient));
            Validate.Value.IsNotNull(messages, nameof(messages));
            Validate.Value.Comparison(messages.Length, CompareOperation.Greater, 0, "Attempting to log empty batch.");

            if ((this.channel.State == CommunicationState.Closed) || (this.channel.State == CommunicationState.Faulted))
            {
                this.channel.Abort();
                this.CreateProxy();
            }

            if ((this.channel.State == CommunicationState.Opened) || (this.channel.State == CommunicationState.Created))
            {
                this.proxy.LogBatch(messages);
            }
            else
            {
                throw new InvalidOperationException(
                    $"WCF Channel on endpoint {this.proxyFactory.Endpoint.Address} is in {this.channel.State} state.");
            }
        }

        private void CreateProxy()
        {
            Validate.Value.IsNotDisposed(this, nameof(WcfLogClient));

            this.proxy = this.proxyFactory.CreateChannel(this.proxyFactory.Endpoint.Address);

            this.channel = this.proxy as IChannel;
            if (this.channel == null)
            {
                throw new InvalidOperationException();
            }

            this.channel.Open();
        }
    }
}