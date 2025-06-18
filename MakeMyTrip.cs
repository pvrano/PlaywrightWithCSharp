using Microsoft.Playwright;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using NUnit.Framework.Internal;
using NLog;

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

            //Code to authenticate in http
            /*var context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                HttpCredentials = new HttpCredentials
                {
                    Username = "",
                    Password = ""
                }

            });*/
            

            var page = await context.NewPageAsync();


            await page.GotoAsync("https://www.makemytrip.com/");


            //right click code through mouse actions
            await page.Locator("//*[@id='SW']/div[3]/div/div/a[1]").ClickAsync(new LocatorClickOptions
            {
                Button = MouseButton.Right,
            });

            //code to wait for popup to select the first element and then proceed with rest of the page in new context
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

            //extra lines of assertions
            /*var applyBtn = page1.Locator("//*[@class=\"fltTravellers \"]/div[2]/button");
            Assert.That(applyBtn, Is.Not.Null);
            string applyBtnText = await applyBtn.InnerTextAsync();
            Assert.That(applyBtnText, Is.EqualTo("APPLY"));
            await applyBtn.ClickAsync(); 

            //code to handle alerts which are events on a page and Dialog is event handler uder IDialog interface
            page1.Dialog += async (_, dialog) =>
            {
                await dialog.AcceptAsync();
                await dialog.DismissAsync();
                Console.WriteLine(dialog.Message);
            };*/

            //code to work with frames
            /*var frame = page.FrameLocator("#cssselector");
             frame then acts as a seperate html dom*/

            
             
            await page1.Locator("//a[contains(text(),'Search')]").ClickAsync();
            string newUrl = page1.Url;

            Console.WriteLine(newUrl);


            await page1.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

            await page1.ScreenshotAsync(new()
            {
                Path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent + "\\screenshots\\screenshot.png",
                FullPage = true
            });

            //code to capture screenshot of a locator
            /*page1.Locator("").ScreenshotAsync(new LocatorScreenshotOptions
            {
                Path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent + "\\screenshots\\screenshot.png"
            });

            **code to download file on clicking a link
            IDownload downloadedfile = await page1.RunAndWaitForDownloadAsync(async () =>
            {
                await page1.Locator("").ClickAsync();
            });
            string Path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent+"";
            downloadedfile.SaveAsAsync(Path);

            //code to upload a file
            await page1.Locator("file upload input button").SetInputFilesAsync("Pathofuploadfile");

            //to upload multiple files just give an array
            await page1.Locator().SetInputFilesAsync(new[] { "path1", "path2", "path3" });*/
            

            string rootPath = Directory.GetCurrentDirectory();
            Console.WriteLine(rootPath);
            string Path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent+"\\screenshots\\";
            Console.WriteLine(Path);


        }
    }
}

