﻿/*
 * Shadowsocks-Net https://github.com/shadowsocks/Shadowsocks-Net
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Argument.Check;
using Microsoft.Extensions.Logging;

namespace Shadowsocks.Infrastructure.Pipe
{
    using Sockets;
    public abstract class PipeFilter : IPipeFilter, IComparer<PipeFilter>
    {
        /// <summary>
        /// The client applies to.
        /// </summary>
        public IClient Client { get; protected set; }

        /// <summary>
        /// Filter category.
        /// </summary>
        public PipeFilterCategory Category { get; protected set; }

        /// <summary>
        /// Smaller value higher priority.
        /// </summary>
        public byte Priority { get; protected set; }


        protected ILogger _logger = null;

        /// <summary>
        /// Create a filter with a client, catetory and priority.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="category"></param>
        /// <param name="priority"></param>
        public PipeFilter(IClient client, PipeFilterCategory category, byte priority)
        {
            Client = Throw.IfNull(() => client);
            Category = category;
            Priority = priority;
        }

        public abstract PipeFilterResult AfterReading(PipeFilterContext filterContext);
        public abstract PipeFilterResult BeforeWriting(PipeFilterContext filterContext);


        public int Compare(PipeFilter x, PipeFilter y)
        {
            int c = (int)x.Category.CompareTo((int)y.Category);
            return c != 0 ? c : x.Priority.CompareTo(y.Priority);
        }
    }
}
