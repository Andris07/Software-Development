using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumDemo;

public class LocalWebTest
{
    private WebDriver _webDriver;
    [SetUp]
    public void Setup()
    {
        _webDriver = new ChromeDriver();
    }

    [TearDown]
    public void TearDown()
    {
        _webDriver.Close();
        _webDriver.Quit();
    }

    [Test]
    public void PageIsTitledHelloWorld()
    {
        _webDriver.Navigate().GoToUrl("http://localhost:5500");
        Assert.That(_webDriver.Title, Is.EqualTo("Hello World"));
    }

    [Test]
    public void TheLightsAreRedByDefault()
    {
        _webDriver.Navigate().GoToUrl("http://localhost:5500");
        // arrange, act assert
        // ciklus, elágazás

        Assert.That(_webDriver.FindElement(By.Id("red")).GetDomProperty("checked"), Is.EqualTo("True"));
        Assert.That(_webDriver.FindElement(By.Id("yellow")).GetDomProperty("checked"), Is.EqualTo("False"));
        Assert.That(_webDriver.FindElement(By.Id("green")).GetDomProperty("checked"), Is.EqualTo("False"));
        
    }
    [TestCase("red", true, false, false)]
    [TestCase("red-yellow", true, true, false)]
    [TestCase("yellow", false, true, false)]
    [TestCase("green", false, false, true)]
    public void TestLightsForState(string fromState, bool isRed, bool isYellow, bool isGreen)
    {
        _webDriver.Navigate().GoToUrl("http://localhost:5500");
        // arrange, act assert
        // ciklus, elágazás
        ((IJavaScriptExecutor)_webDriver).ExecuteScript("setState('"+fromState+"')");
        
        Assert.That(_webDriver.FindElement(By.Id("red")).GetDomProperty("checked"), Is.EqualTo(isRed.ToString()).IgnoreCase);
        Assert.That(_webDriver.FindElement(By.Id("yellow")).GetDomProperty("checked"), Is.EqualTo(isYellow.ToString()).IgnoreCase);
        Assert.That(_webDriver.FindElement(By.Id("green")).GetDomProperty("checked"), Is.EqualTo(isGreen.ToString()).IgnoreCase);
    }

    [TestCase("red", "red-yellow")]
    [TestCase("red-yellow", "green")]
    [TestCase("green", "yellow")]
    [TestCase("yellow", "red")]
    public void TestStateTransition(string fromState, string toState)
    {
        _webDriver.Navigate().GoToUrl("http://localhost:5500");
        ((IJavaScriptExecutor)_webDriver).ExecuteScript("setState('"+fromState+"')");
        _webDriver.FindElement(By.Id("next")).Click();
        Assert.That(((IJavaScriptExecutor)_webDriver).ExecuteScript("return state;"), Is.EqualTo(toState));
    }

    [Test]
    public void TestBlinkTransition()
    {
        _webDriver.Navigate().GoToUrl("http://localhost:5500");
        _webDriver.FindElement(By.Id("stop")).Click();
        Assert.That(((IJavaScriptExecutor)_webDriver).ExecuteScript("return state;"), Is.EqualTo("stopped"));
        Assert.That(_webDriver.FindElement(By.Id("next")).Enabled, Is.False);
        _webDriver.FindElement(By.Id("stop")).Click();
        Assert.That(((IJavaScriptExecutor)_webDriver).ExecuteScript("return state;"), Is.EqualTo("red"));
        Assert.That(_webDriver.FindElement(By.Id("next")).Enabled, Is.True);
    }

    [Test]
    public void TestBlinking()
    {
        _webDriver.Navigate().GoToUrl("http://localhost:5500");
        _webDriver.FindElement(By.Id("stop")).Click();

        WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
        wait.PollingInterval =  TimeSpan.FromMilliseconds(100);

        wait.Until(w => { return w.FindElement(By.Id("yellow")).GetDomProperty("checked") == "True"; });
        Assert.That(_webDriver.FindElement(By.Id("red")).GetDomProperty("checked"), Is.EqualTo("False"));
        Assert.That(_webDriver.FindElement(By.Id("green")).GetDomProperty("checked"), Is.EqualTo("False"));
        
        wait.Until(w => { return w.FindElement(By.Id("yellow")).GetDomProperty("checked") == "False"; });
        Assert.That(_webDriver.FindElement(By.Id("red")).GetDomProperty("checked"), Is.EqualTo("False"));
        Assert.That(_webDriver.FindElement(By.Id("green")).GetDomProperty("checked"), Is.EqualTo("False"));

        wait.Until(w => { return w.FindElement(By.Id("yellow")).GetDomProperty("checked") == "True"; });
        Assert.That(_webDriver.FindElement(By.Id("red")).GetDomProperty("checked"), Is.EqualTo("False"));
        Assert.That(_webDriver.FindElement(By.Id("green")).GetDomProperty("checked"), Is.EqualTo("False"));

    }
        
    // Az oldalon legyen legalább 2 gomb
    // Valamit csináljon a 2 gombra az oldal
    // Közlekedési lámpa szimultátor
    // Következő állapot
    // Ki/be kapcsolás
    // Kikapcsolt állapotban a következő gomb legyen disabled és sárgán villogjon a lámpa

}