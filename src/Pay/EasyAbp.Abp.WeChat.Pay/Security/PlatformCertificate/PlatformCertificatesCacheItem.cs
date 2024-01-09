﻿using System;
using System.Collections.Generic;

namespace EasyAbp.Abp.WeChat.Pay.Security.PlatformCertificate;

[Serializable]
public class PlatformCertificatesCacheItem
{
    public Dictionary<string, PlatformCertificateEntity> Certificates { get; set; } = new();
}