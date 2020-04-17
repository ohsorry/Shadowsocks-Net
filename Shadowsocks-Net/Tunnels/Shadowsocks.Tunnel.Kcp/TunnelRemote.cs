﻿/*
 * Shadowsocks-Net https://github.com/shadowsocks/Shadowsocks-Net
 */

using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Buffers;
using System.Linq;
using System.IO;
using Microsoft.Extensions.Logging;
using Argument.Check;
using System.Text;

namespace Shadowsocks.Tunnel.Kcp
{
    using Infrastructure;
    using Infrastructure.Sockets;
    using Infrastructure.Pipe;

    [Tunnel("Tunnel.Kcp")]
    public class TunnelRemote : ITunnelLocal
    {
        public Task<IClient> ConnectTcp()
        {
            throw new NotImplementedException();
        }

        public Task<IClient> ConnectUdp()
        {
            throw new NotImplementedException();
        }
    }
}
