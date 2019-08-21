﻿using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace Zony.Abp.WeiXin.Official.HttpApi
{
    [DependsOn(typeof(AbpWeiXinOfficialModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class AbpWeiXinOfficialHttpApiModule : AbpModule
    {
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            VerifyOptions(context);
        }

        private void VerifyOptions(ApplicationInitializationContext context)
        {
            var options = context.ServiceProvider.GetRequiredService<IOptions<AbpWeiXinOfficialOptions>>().Value;

            if (string.IsNullOrEmpty(options.Token)) throw new ArgumentNullException(nameof(options.Token), "该参数是微信公众平台的必填参数，不能够为空。");
            if (string.IsNullOrEmpty(options.AppId)) throw new ArgumentNullException(nameof(options.AppId), "该参数是微信公众平台的必填参数，不能够为空。");
            if (string.IsNullOrEmpty(options.AppSecret)) throw new ArgumentNullException(nameof(options.AppSecret), "该参数是微信公众平台的必填参数，不能够为空。");
        }
    }
}