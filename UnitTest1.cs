using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace MakeMyTrip
{
    public class Tests : PageTest
    {
        [SetUp]     
        public async Task SetUp()
            {
               
            }


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

