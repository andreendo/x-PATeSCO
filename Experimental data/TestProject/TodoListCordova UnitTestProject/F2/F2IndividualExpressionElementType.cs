using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using Evaluation;

namespace UnitTestProject.F2
{

    [TestClass]
    public class F2IndividualExpressionElementType
    {
		AppiumDriver<IWebElement> _driver = null;
		DesiredCapabilities _capabilities = new DesiredCapabilities();
        LocatorStrategy _locator = null; 

		
        [TestMethod]
        public void TestMethodMain()
        {

			/*APPIUM config*/
			_capabilities.SetCapability("platformName", ProjectConfig.PlataformName);
			_capabilities.SetCapability("platformVersion", ProjectConfig.PlatformVersion);
			_capabilities.SetCapability("deviceName", ProjectConfig.DeviceName);
			_capabilities.SetCapability("appPackage", ProjectConfig.AppPackage);
			_capabilities.SetCapability("newCommandTimeout", "3000");
			_capabilities.SetCapability("sessionOverride", "true");

			Uri defaultUri = new Uri(ProjectConfig.AppiumServer);

			if (ProjectConfig.PlataformName == "Android")
			{
			    _capabilities.SetCapability("app", ProjectConfig.AppPath);
				_capabilities.SetCapability("appActivity", ProjectConfig.AppActivity);

				_driver = new AndroidDriver<IWebElement>(defaultUri, _capabilities, TimeSpan.FromSeconds(3000));
			}
			else if (ProjectConfig.PlataformName == "iOS")
			{
                //_capabilities.SetCapability("automationName", "XCUITest");
                _capabilities.SetCapability("app", ProjectConfig.AppPath);
			    _capabilities.SetCapability("bundleId", ProjectConfig.AppPackage);
 				_capabilities.SetCapability("udid", ProjectConfig.Uuid);
				_driver = new IOSDriver<IWebElement>(defaultUri, _capabilities, TimeSpan.FromSeconds(3000));
			}

            System.Threading.Thread.Sleep(5000);


            Exec.Create("TodoListCordova", ProjectConfig.OutputDeviceID, "F2", 2,"IndividualExpressionElementType", ProjectConfig.OutputPath);
            Exec.Instance.Start();

            _locator = new LocatorStrategy(_driver, Exec.Instance);



            /*initialing test*/
            inserirTextoSendKeys_Test(); //inserirTexto
            btnAdicionarSendClick_Test(); //btnAdicionar			
            alterarTextoSendKeys_Test(); //alterarTexto
            tocarForaSendClick_Test(); //tocarFora

            Exec.Instance.EndSuccefull();


        }


        public void inserirTextoSendKeys_Test()
        {
            ForceUpdateScreen();
            Exec.Instance.AddEvent("inserirTexto");

            string[] selectors = new string[0];
            string contingencyXPathSelector = "";

            if (ProjectConfig.PlataformName == "Android")
            {
                selectors = new string[] { @"//*/android.widget.EditText[@text='What needs to be done?']" };
                contingencyXPathSelector = "hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.webkit.WebView/android.webkit.WebView/android.view.View/android.view.View/android.widget.EditText";
            }
            else if (ProjectConfig.PlataformName == "iOS")
            {
                selectors = new string[] { @"//*/XCUIElementTypeTextField[@value='What needs to be done?']" };
                contingencyXPathSelector = "XCUIElementTypeWindow/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeTextField";
            }

            string[] selectorsType = new string[] { @"ElementType" };

            IWebElement e = _locator.FindElementByXPath(selectors[0], selectorsType[0]);

            if (e == null)
            {
                e = _locator.FindElementByContingencyXPath(contingencyXPathSelector);
                if (e != null)
                    Exec.Instance.CurrentEvent.UsedContingencyXPathSelector = true;
            }

            e.Click();
            e.Clear();
            e.SendKeys("Tarefa1");
            try
            {
                if (ProjectConfig.PlataformName == "Android")
                    _driver.HideKeyboard();
                else if (ProjectConfig.PlataformName == "iOS")
                    _driver.FindElementByXPath("//*[@name='Hide keyboard']").Click();
            }
            catch { }

            /*Insert your assert here*/

            Exec.Instance.CurrentEvent.EndSucessfull();

        }


        public void btnAdicionarSendClick_Test()
        {
            ForceUpdateScreen();
            Exec.Instance.AddEvent("btnAdicionar");

            string[] selectors = new string[0];
            string contingencyXPathSelector = "";

            if (ProjectConfig.PlataformName == "Android")
            {
                selectors = new string[] { @"//*/android.widget.Button[@content-desc='+']" };
                contingencyXPathSelector = "hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.webkit.WebView/android.webkit.WebView/android.view.View/android.view.View/android.widget.Button";
            }
            else if (ProjectConfig.PlataformName == "iOS")
            {
                selectors = new string[] { @"//*/XCUIElementTypeButton[@label='+']" };
                contingencyXPathSelector = "XCUIElementTypeWindow/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeButton";
            }

            string[] selectorsType = new string[] { @"ElementType" };

            IWebElement e = _locator.FindElementByXPath(selectors[0], selectorsType[0]);

            if (e == null)
            {
                e = _locator.FindElementByContingencyXPath(contingencyXPathSelector);
                if (e != null)
                    Exec.Instance.CurrentEvent.UsedContingencyXPathSelector = true;
            }

            e.Click();

            /*Insert your assert here*/
            System.Threading.Thread.Sleep(2000);
            if (ProjectConfig.IndexDeviceUnderTest == 0)
            {
                _driver.FindElementById("com.android.packageinstaller:id/permission_allow_button").Click();
            }

            Exec.Instance.CurrentEvent.EndSucessfull();

        }

        public void alterarTextoSendKeys_Test()
        {
            ForceUpdateScreen();
            Exec.Instance.AddEvent("alterarTexto");

            string[] selectors = new string[0];
            string contingencyXPathSelector = "";

            if (ProjectConfig.PlataformName == "Android")
            {
                selectors = new string[] {@"//*/android.widget.EditText[@text='Tarefa1']"};
                contingencyXPathSelector = "hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.webkit.WebView/android.webkit.WebView/android.view.View/android.view.View[2]/android.view.View/android.view.View/android.widget.EditText";
            }
            else if (ProjectConfig.PlataformName == "iOS")
            {
                selectors = new string[] {@"//*/XCUIElementTypeTextField[@value='Tarefa1']"};
                contingencyXPathSelector = "XCUIElementTypeWindow/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther[2]/XCUIElementTypeTextField";
            }

            string[] selectorsType = new string[] {@"ElementType"};

            IWebElement e = _locator.FindElementByXPath(selectors[0], selectorsType[0]);

            if (e == null)
            {
                e = _locator.FindElementByContingencyXPath(contingencyXPathSelector);
                if (e != null)
                    Exec.Instance.CurrentEvent.UsedContingencyXPathSelector = true;
            }

            e.Click();
            e.Clear();
            e.SendKeys("Tarefa1a");
            try {
                if (ProjectConfig.PlataformName == "Android")
                    _driver.HideKeyboard();
                else if (ProjectConfig.PlataformName == "iOS")
                    _driver.FindElementByXPath("//*[@name='Hide keyboard']").Click();
            } catch {}

            /*Insert your assert here*/

            Exec.Instance.CurrentEvent.EndSucessfull();

        }


        public void tocarForaSendClick_Test()
        {
            ForceUpdateScreen();
            Exec.Instance.AddEvent("tocarFora");

            string[] selectors = new string[0];
            string contingencyXPathSelector = "";

            if (ProjectConfig.PlataformName == "Android")
            {
                selectors = new string[] {@"//*/android.view.View[@resource-id='todoapp']"};
                contingencyXPathSelector = "hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.webkit.WebView/android.webkit.WebView/android.view.View";
            }
            else if (ProjectConfig.PlataformName == "iOS")
            {
                selectors = new string[] {@"//*/XCUIElementTypeOther[@label='CordovaToDoApp_AngularJS']"};
                contingencyXPathSelector = "XCUIElementTypeWindow/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther";
            }

            string[] selectorsType = new string[] {@"ElementType"};

            IWebElement e = _locator.FindElementByXPath(selectors[0], selectorsType[0]);

            if (e == null)
            {
                e = _locator.FindElementByContingencyXPath(contingencyXPathSelector);
                if (e != null)
                    Exec.Instance.CurrentEvent.UsedContingencyXPathSelector = true;
            }

            e.Click();

            /*Insert your assert here*/

            Exec.Instance.CurrentEvent.EndSucessfull();

        }





		private void ForceUpdateScreen()
		{
            //workaround for forces screen update 
            System.Threading.Thread.Sleep(500);
            string x = _driver.PageSource;
            System.Threading.Thread.Sleep(500);

        }


        private void ScrollToBottom()
        {
            var size = _driver.Manage().Window.Size;
            int startx = size.Width / 2;
            int starty = (int)(size.Height * 0.9);
            int endx = size.Width / 2;
            int endy = (int)(size.Height * 0.2);
            _driver.Swipe(startx, starty, startx, endy, 100);

            System.Threading.Thread.Sleep(1000);


        }

        private void Tap(int x, int y)
        {
            _driver.Tap(1, x, y, 500);

        }
    }
}
