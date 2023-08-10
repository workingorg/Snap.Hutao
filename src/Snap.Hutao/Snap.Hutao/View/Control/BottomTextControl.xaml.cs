﻿// Copyright (c) DGP Studio. All rights reserved.
// Licensed under the MIT license.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.Media;
using Snap.Hutao.Control;

namespace Snap.Hutao.View.Control;

/// <summary>
/// 底部带有文本的控件
/// </summary>
[HighQuality]
[ContentProperty(Name = nameof(TopContent))]
[DependencyProperty("Text", typeof(string), "")]
[DependencyProperty("TopContent", typeof(UIElement), default!)]
[DependencyProperty("Fill", typeof(Brush), default!)]
internal sealed partial class BottomTextControl : ContentControl
{
    /// <summary>
    /// 构造一个新的底部带有文本的控件
    /// </summary>
    public BottomTextControl()
    {
        InitializeComponent();
    }
}