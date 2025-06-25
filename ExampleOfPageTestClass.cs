using Microsoft.Playwright;

namespace MakeMyTrip
{
    //Example of using PageTest class for launching browser in the headless mode and directly running the automation using Page class object.
    [TestFixture]
    public class ExampleOfPageTestClass : Microsoft.Playwright.NUnit.PageTest
    {
        //this test will capture the snapshot of a section in the webpage in the headless mode, if the website disregards headless browser automation then this test will fail
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


