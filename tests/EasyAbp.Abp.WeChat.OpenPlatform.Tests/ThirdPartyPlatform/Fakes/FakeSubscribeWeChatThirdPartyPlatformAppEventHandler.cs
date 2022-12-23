﻿using System.Threading.Tasks;
using EasyAbp.Abp.WeChat.Common.Models;
using EasyAbp.Abp.WeChat.OpenPlatform.RequestHandling.Dtos;
using EasyAbp.Abp.WeChat.OpenPlatform.ThirdPartyPlatform.RequestHandling;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.Abp.WeChat.OpenPlatform.Tests.ThirdPartyPlatform.Fakes;

public class FakeSubscribeWeChatThirdPartyPlatformAppEventHandler : IWeChatThirdPartyPlatformAppEventHandler,
    ITransientDependency
{
    public string Event => "subscribe";
    public int Priority => 0;

    public Task<AppEventHandlingResult> HandleAsync(
        string componentAppId, string authorizerAppId, WeChatAppEventModel model)
    {
        return Task.FromResult(new AppEventHandlingResult(true));
    }
}