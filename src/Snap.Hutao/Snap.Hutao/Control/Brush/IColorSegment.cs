﻿// Copyright (c) DGP Studio. All rights reserved.
// Licensed under the MIT license.

using Windows.UI;

namespace Snap.Hutao.Control.Brush;

internal interface IColorSegment
{
    Color Color { get; }

    double Value { get; set; }
}