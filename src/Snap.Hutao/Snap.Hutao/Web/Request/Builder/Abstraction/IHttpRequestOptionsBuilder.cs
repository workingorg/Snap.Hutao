﻿// Copyright (c) DGP Studio. All rights reserved.
// Licensed under the MIT license.

using System.Net.Http;
using Snap.Hutao.Core.Abstraction;

namespace Snap.Hutao.Web.Request.Builder.Abstraction;

internal interface IHttpRequestOptionsBuilder : IBuilder
{
    HttpRequestOptions Options { get; }
}