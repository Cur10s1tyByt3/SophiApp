﻿// <copyright file="DefaultActivationHandler.cs" company="Team Sophia">
// Copyright (c) Team Sophia. All rights reserved.
// </copyright>

namespace SophiApp.Activation;
using Microsoft.UI.Xaml;
using SophiApp.Contracts.Services;
using SophiApp.ViewModels;

public class DefaultActivationHandler : ActivationHandler<LaunchActivatedEventArgs>
{
    private readonly INavigationService navigationService;

    public DefaultActivationHandler(INavigationService navigationService)
    {
        this.navigationService = navigationService;
    }

    protected override bool CanHandleInternal(LaunchActivatedEventArgs args)
    {
        // None of the ActivationHandlers has handled the activation.
        return navigationService.Frame?.Content == null;
    }

    protected async override Task HandleInternalAsync(LaunchActivatedEventArgs args)
    {
        _ = navigationService.NavigateTo(typeof(PrivacyViewModel).FullName!, args.Arguments);
        await Task.CompletedTask;
    }
}
