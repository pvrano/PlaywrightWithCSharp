using Microsoft.Playwright;

namespace MakeMyTrip
{
    [TestFixture]
    public class NewTestClass : Microsoft.Playwright.NUnit.PageTest
    {
        [Test]
        public async Task TestAriaSnapshot()
        {
            await Page.GotoAsync("https://playwright.dev/");
            await Expect(Page.Locator("banner")).ToMatchAriaSnapshotAsync(@"
        - banner:
            - heading ""Playwright enables reliable end-to-end testing for modern web apps."" [level=1]
            - link ""Get started""
            - link ""Star microsoft/playwright on GitHub""
            - link /[\\d]+k\\+ stargazers on GitHub/
        ");


        }
    }

}


