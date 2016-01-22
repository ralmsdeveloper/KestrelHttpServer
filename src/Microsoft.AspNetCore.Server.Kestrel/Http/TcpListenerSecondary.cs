// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Server.Kestrel.Networking;

namespace Microsoft.AspNetCore.Server.Kestrel.Http
{
    /// <summary>
    /// An implementation of <see cref="ListenerSecondary"/> using TCP sockets.
    /// </summary>
    public class TcpListenerSecondary : ListenerSecondary
    {
        public TcpListenerSecondary(ServiceContext serviceContext, ServerAddress address, KestrelThread thread, string pipeName)
            : base(serviceContext, address, thread, pipeName)
        {
        }

        /// <summary>
        /// Creates a socket which can be used to accept an incoming connection
        /// </summary>
        protected override UvStreamHandle CreateAcceptSocket()
        {
            var acceptSocket = new UvTcpHandle(Log);
            acceptSocket.Init(Thread.Loop, Thread.QueueCloseHandle);
            acceptSocket.NoDelay(ServerInformation.NoDelay);
            return acceptSocket;
        }
    }
}