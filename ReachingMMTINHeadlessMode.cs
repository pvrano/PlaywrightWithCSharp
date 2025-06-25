using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace MakeMyTrip
{
    public class ReachingMMTInHeadlessMode : PageTest
    {
        [SetUp]     
        public async Task SetUp()
            {
               
            }

         //this test method will fail since makemytrip does not allow headless mode rowser automation
        [Test]
        public async Task Test1()
        {
            await Page.GotoAsync("https://www.makemytrip.com");
            Console.WriteLine("Logged in to makemytrip");
            await Expect(Page).ToHaveTitleAsync("Online Courses - Learn Anything, On Your Schedule | Udemy");
            Console.WriteLine("Test Passed");
        }
    }
}

