using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest1
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
            NewTest();
        }

        [Test]
        public void NewTest()
        {
            app.Tap(x => x.Text("This is an item description."));
            app.Tap(x => x.ClassFull("android.support.design.widget.TabLayout$TabView"));
            app.Tap(x => x.Text("About"));
            app.Tap(x => x.Text("Learn more"));
            app.Tap(x => x.Text("Browse"));
            app.Tap(x => x.Class("AppCompatImageButton"));
            app.Tap(x => x.Text("This is an item description.").Index(3));
            app.Tap(x => x.Class("AppCompatImageButton"));
            app.Tap(x => x.Text("This is an item description.").Index(5));
            app.Tap(x => x.Class("AppCompatImageButton"));
        }
    }
}

