using Microsoft.Playwright;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTesting.TestCases
{
    [TestFixture]
    public class MakeMyTrip 
    {
        [Test]
        public async Task makeMyTrip() 
        {
            
            using var playwright = await Playwright.CreateAsync();
            
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
            });
            var context = await browser.NewContextAsync();

            var page = await context.NewPageAsync();

            
            await page.GotoAsync("https://www.makemytrip.com/");
            
            await page.Locator("//*[@id='SW']/div[3]/div/div/a[1]").ClickAsync(new LocatorClickOptions
            {
                Button = MouseButton.Right,
            });
            var page1 = await page.RunAndWaitForPopupAsync(async () =>
            {
                await page.Locator("//*[@id='SW']/div[3]/div/div/a[1]").ClickAsync();
            });
            await page1.GetByRole(AriaRole.Textbox, new() { Name = "From LON, All airports United" }).ClickAsync();
            await page1.GetByText("Mumbai, India").ClickAsync();
            await page1.GetByRole(AriaRole.Textbox, new() { Name = "To MAN, Manchester United" }).ClickAsync();
            await page1.GetByRole(AriaRole.Textbox, new() { Name = "To", Exact = true }).FillAsync("London");
            await page1.GetByText("Heathrow Airport").ClickAsync();
           
            await page1.GetByText("Departure").ClickAsync();
            await page1.GetByText("June").ClickAsync();
            await page1.GetByLabel("Thu Jun 19").GetByText("19").ClickAsync();
            await page1.GetByText("Travellers & Class").ClickAsync();
            await page1.GetByText("‎4").First.ClickAsync();
            await page1.GetByText("‎2").Nth(1).ClickAsync();
            await page1.GetByText("‎1").Nth(2).ClickAsync();
            await page1.GetByText("Premium Economy", new() { Exact = true }).ClickAsync();
            await page1.GetByRole(AriaRole.Button, new() { Name = "APPLY" }).ClickAsync();
            /*var applyBtn = page1.Locator("//*[@class=\"fltTravellers \"]/div[2]/button");
            Assert.That(applyBtn, Is.Not.Null);
            string applyBtnText = await applyBtn.InnerTextAsync();
            Assert.That(applyBtnText, Is.EqualTo("APPLY"));
            await applyBtn.ClickAsync();*/
            await page1.Locator("//a[contains(text(),'Search')]").ClickAsync();
            
            

        }
    }
}

