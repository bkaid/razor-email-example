using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Notification.Infrastructure.Razor;
using Xunit;
using Xunit.Abstractions;

namespace Notification.Emails
{
    public class ConfirmEmailTests
    {
        private readonly ITestOutputHelper testOutputHelper;
        private readonly IViewRenderer viewRenderer;

        public ConfirmEmailTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
            var server = new WebApplicationFactory<Startup>();
            viewRenderer = server.Services.CreateScope().ServiceProvider.GetService<IViewRenderer>();
        }

        [Fact]
        public async Task CanRenderConfirmationMail()
        {
            // arrange
            var confirmationUrl = $"http://example.com/user/{Guid.NewGuid()}/confirm/{Guid.NewGuid()}";

            // act
            var renderedView = await viewRenderer.RenderViewToStringAsync("~/emails/ConfirmEmail.cshtml", confirmationUrl);

            // assert
            testOutputHelper.WriteLine(renderedView);
            Assert.NotNull(renderedView);
            Assert.Contains(confirmationUrl, renderedView, StringComparison.OrdinalIgnoreCase);
        }
    }
}
