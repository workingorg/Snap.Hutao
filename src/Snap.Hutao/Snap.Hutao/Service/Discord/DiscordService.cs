﻿// Copyright (c) DGP Studio. All rights reserved.
// Licensed under the MIT license.

using Snap.Hutao.Core;
using Snap.Hutao.Service.Notification;
using System.Diagnostics;

namespace Snap.Hutao.Service.Discord;

[ConstructorGenerated]
[Injection(InjectAs.Singleton, typeof(IDiscordService))]
internal sealed partial class DiscordService : IDiscordService, IDisposable
{
    private readonly IInfoBarService infoBarService;
    private readonly RuntimeOptions runtimeOptions;

    private bool isInitialized;

    public async ValueTask SetPlayingActivityAsync(bool isOversea)
    {
        if (IsSupported())
        {
            _ = isOversea
                ? await DiscordController.SetPlayingGenshinImpactAsync().ConfigureAwait(false)
                : await DiscordController.SetPlayingYuanShenAsync().ConfigureAwait(false);
        }
    }

    public async ValueTask SetNormalActivityAsync()
    {
        if (IsSupported())
        {
            _ = await DiscordController.SetDefaultActivityAsync(runtimeOptions.AppLaunchTime).ConfigureAwait(false);
        }
    }

    public void Dispose()
    {
        DiscordController.Stop();
    }

    private bool IsSupported()
    {
        try
        {
            // Actually requires a discord client to be running on Windows platform.
            // If not, discord core creation code will throw.
            Process[] discordProcesses = Process.GetProcessesByName("Discord");

            if (discordProcesses.Length <= 0)
            {
                return false;
            }

            foreach (Process process in discordProcesses)
            {
                try
                {
                    _ = process.Handle;
                }
                catch (Exception)
                {
                    if (!isInitialized)
                    {
                        infoBarService.Warning(SH.ServiceDiscordActivityElevationRequiredHint);
                    }

                    return false;
                }
            }

            return true;
        }
        finally
        {
            isInitialized = true;
        }
    }
}