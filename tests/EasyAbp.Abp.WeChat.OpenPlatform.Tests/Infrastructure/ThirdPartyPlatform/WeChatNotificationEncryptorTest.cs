using System.Threading.Tasks;
using EasyAbp.Abp.WeChat.Common.Infrastructure.Encryption;
using EasyAbp.Abp.WeChat.Common.Models;
using EasyAbp.Abp.WeChat.OpenPlatform.Infrastructure.Models.ThirdPartyPlatform;
using Shouldly;
using Xunit;

namespace EasyAbp.Abp.WeChat.OpenPlatform.Tests.Infrastructure.ThirdPartyPlatform;

public class WeChatNotificationEncryptorTest : AbpWeChatOpenPlatformTestBase
{
    [Fact]
    public async Task Should_Decrypt_PostData()
    {
        var encryptor = GetRequiredService<IWeChatNotificationEncryptor>();
        
        var options = new AbpWeChatThirdPartyPlatformOptions
        {
            Token = AbpWeChatOpenPlatformTestsConsts.Token,
            AppId = AbpWeChatOpenPlatformTestsConsts.AppId,
            EncodingAesKey = AbpWeChatOpenPlatformTestsConsts.EncodingAESKey
        };

        var model = await encryptor.DecryptPostDataAsync<WeChatAppNotificationModel>(
            options.Token,
            options.EncodingAesKey,
            options.AppId,
            AbpWeChatOpenPlatformTestsConsts.ReqMsgSig,
            AbpWeChatOpenPlatformTestsConsts.ReqTimeStamp,
            AbpWeChatOpenPlatformTestsConsts.ReqNonce,
            AbpWeChatOpenPlatformTestsConsts.ReqData);

        model.MsgType.ShouldBe("text");
        model.ToUserName.ShouldBe("wx5823bf96d3bd56c7");
    }
}