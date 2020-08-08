using System;
using OmniSharp.Extensions.JsonRpc;
using OmniSharp.Extensions.LanguageServer.Protocol.Progress;
using OmniSharp.Extensions.LanguageServer.Protocol.Server.WorkDone;

namespace OmniSharp.Extensions.LanguageServer.Protocol.Server
{
    internal class WindowLanguageServer : LanguageProtocolProxy, IWindowLanguageServer
    {
        public WindowLanguageServer(IResponseRouter requestRouter, IServiceProvider serviceProvider, IProgressManager progressManager,
            ILanguageProtocolSettings languageProtocolSettings) : base(requestRouter, serviceProvider, progressManager, languageProtocolSettings)
        {
        }
    }
}