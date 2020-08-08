using DryIoc;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using OmniSharp.Extensions.JsonRpc;
using OmniSharp.Extensions.JsonRpc.Serialization;
using Xunit.Abstractions;
using NSubstitute.Internals;
using OmniSharp.Extensions.LanguageServer.Protocol.Client.Capabilities;
using OmniSharp.Extensions.LanguageServer.Protocol.Serialization;

namespace JsonRpc.Tests
{
    internal static class LspTestContainer
    {
        public static IContainer Create(ITestOutputHelper testOutputHelper)
        {
            var container = JsonRpcServerContainer.Create(null)
                .AddJsonRpcMediatR()
                .With(rules => rules
                    .WithTestLoggerResolver((request, loggerType) => ActivatorUtilities.CreateInstance(request.Container, loggerType))
                    .WithUndefinedTestDependenciesResolver(request => Substitute.For(new[] { request.ServiceType }, null))
                    .WithConcreteTypeDynamicRegistrations((type, o) => true, Reuse.Transient)
            );
            container.RegisterInstanceMany(new Serializer(ClientVersion.Lsp3));
            return container;
        }
    }
}