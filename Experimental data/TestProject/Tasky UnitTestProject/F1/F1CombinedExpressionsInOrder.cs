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

namespace UnitTestProject.F1
{

    [TestClass]
    public class F1CombinedExpressionsInOrder
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
			    _capabilities.SetCapability("app", ProjectConfig.AppPath);
			    _capabilities.SetCapability("bundleId", ProjectConfig.AppPackage);
 				_capabilities.SetCapability("udid", ProjectConfig.Uuid);
				_driver = new IOSDriver<IWebElement>(defaultUri, _capabilities, TimeSpan.FromSeconds(3000));
			}



            Exec.Create("Tasky", ProjectConfig.OutputDeviceID, "F1", 4,"CombinedExpressionsInOrder", ProjectConfig.OutputPath);
            Exec.Instance.Start();

            _locator = new LocatorStrategy(_driver, Exec.Instance);


			 
			 /*initialing test*/
			
            btnaddSendClick_Test(); //btnadd
            inserirnomeSendKeys_Test(); //inserirnome
            btndoneSendClick_Test(); //btndone
            btnsaveSendClick_Test(); //btnsave

            Exec.Instance.EndSuccefull();


        }

        public void btnaddSendClick_Test()
        {
            ForceUpdateScreen();
            Exec.Instance.AddEvent("btnadd");

            string[] selectors = new string[0];
            string contingencyXPathSelector = "";

            if (ProjectConfig.PlataformName == "Android")
            {
                selectors = new string[] {@"//*[@text='Add Task' or @label='Add']", @"//*/android.widget.Button[@text='Add Task']", @"//*[@resource-id='com.xamarin.samples.taskyandroid:id/AddButton']", @"//*[@resource-id='android:id/content']//*[@text='Add Task']", @"//*[@resource-id='android:id/content']/*[1]/*[1]", @"hierarchy/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[2]/android.widget.LinearLayout/android.widget.Button"};
                contingencyXPathSelector = "hierarchy/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[2]/android.widget.LinearLayout/android.widget.Button";
            }
            else if (ProjectConfig.PlataformName == "iOS")
            {
                selectors = new string[] {@"//*[@text='Add Task' or @label='Add']", @"//*/UIAButton[@label='Add']", @"//*[@name='Add']", @"//*[@name='Tasky']//*[@label='Add']", @"//*[@name='Tasky']/*[4]", @"AppiumAUT/UIAApplication/UIAWindow/UIANavigationBar/UIAButton[2]"};
                contingencyXPathSelector = "AppiumAUT/UIAApplication/UIAWindow/UIANavigationBar/UIAButton[2]";
            }

            string[] selectorsType = new string[] {@"CrossPlatform", @"ElementType", @"IdentifyAttributes", @"AncestorAttributes", @"AncestorIndex", @"AbsolutePath"};

            IWebElement e = _locator.FindElementByXPathInOrder(selectors, selectorsType);

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


        public void inserirnomeSendKeys_Test()
        {
            ForceUpdateScreen();
            Exec.Instance.AddEvent("inserirnome");

            string[] selectors = new string[0];
            string contingencyXPathSelector = "";

            if (ProjectConfig.PlataformName == "Android")
            {
                selectors = new string[] {@"//*[@value='task name']", @"//*/android.widget.EditText[@resource-id='com.xamarin.samples.taskyandroid:id/NameText']", @"//*[@resource-id='com.xamarin.samples.taskyandroid:id/NameText']", @"//*[@resource-id='android:id/content']//*[@resource-id='com.xamarin.samples.taskyandroid:id/NameText']", @"//*[@resource-id='android:id/content']/*[1]/*[2]", @"hierarchy/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[2]/android.widget.RelativeLayout/android.widget.EditText"};
                contingencyXPathSelector = "hierarchy/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[2]/android.widget.RelativeLayout/android.widget.EditText";
            }
            else if (ProjectConfig.PlataformName == "iOS")
            {
                selectors = new string[] {@"//*[@value='task name']", @"//*/UIATextField[@value='task name']", @"", @"//*[@name='Name']//*[@value='task name']", @"//*[@name='Name']/*[2]", @"AppiumAUT/UIAApplication/UIAWindow/UIATableView/UIATableCell/UIATextField"};
                contingencyXPathSelector = "AppiumAUT/UIAApplication/UIAWindow/UIATableView/UIATableCell/UIATextField";
            }

            string[] selectorsType = new string[] {@"CrossPlatform", @"ElementType", @"IdentifyAttributes", @"AncestorAttributes", @"AncestorIndex", @"AbsolutePath"};

            IWebElement e = _locator.FindElementByXPathInOrder(selectors, selectorsType);

            if (e == null)
            {
                e = _locator.FindElementByContingencyXPath(contingencyXPathSelector);
                if (e != null)
                    Exec.Instance.CurrentEvent.UsedContingencyXPathSelector = true;
            }

            e.Click();
            e.Clear();
            e.SendKeys("Tarefa 1");
            try {
                if (ProjectConfig.PlataformName == "Android")
                    _driver.HideKeyboard();
                else if (ProjectConfig.PlataformName == "iOS")
                    _driver.FindElementByXPath("//*[@name='Hide keyboard']").Click();
            } catch {}

            /*Insert your assert here*/

            Exec.Instance.CurrentEvent.EndSucessfull();

        }


        public void btndoneSendClick_Test()
        {
            ForceUpdateScreen();
            Exec.Instance.AddEvent("btndone");

            string[] selectors = new string[0];
            string contingencyXPathSelector = "";

            if (ProjectConfig.PlataformName == "Android")
            {
                selectors = new string[] {@"//*[@text='Done' or @label='Done']", @"//*/android.widget.CheckBox[@text='Done']", @"//*[@resource-id='com.xamarin.samples.taskyandroid:id/chkDone']", @"//*[@resource-id='android:id/content']//*[@text='Done']", @"//*[@resource-id='android:id/content']/*[1]/*[5]", @"hierarchy/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[2]/android.widget.RelativeLayout/android.widget.CheckBox"};
                contingencyXPathSelector = "hierarchy/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[2]/android.widget.RelativeLayout/android.widget.CheckBox";
            }
            else if (ProjectConfig.PlataformName == "iOS")
            {
                selectors = new string[] {@"//*[@text='Done' or @label='Done']", @"//*/UIASwitch[@label='Done']", @"//*[@name='Done']", @"//*[@value='0']//*[@label='Done']", @"//*[@value='0']/*[2]", @"AppiumAUT/UIAApplication/UIAWindow/UIATableView/UIATableCell[3]/UIASwitch"};
                contingencyXPathSelector = "AppiumAUT/UIAApplication/UIAWindow/UIATableView/UIATableCell[3]/UIASwitch";
            }

            string[] selectorsType = new string[] {@"CrossPlatform", @"ElementType", @"IdentifyAttributes", @"AncestorAttributes", @"AncestorIndex", @"AbsolutePath"};

            IWebElement e = _locator.FindElementByXPathInOrder(selectors, selectorsType);

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


        public void btnsaveSendClick_Test()
        {
            ForceUpdateScreen();
            Exec.Instance.AddEvent("btnsave");

            string[] selectors = new string[0];
            string contingencyXPathSelector = "";

            if (ProjectConfig.PlataformName == "Android")
            {
                selectors = new string[] {@"//*[@text='Save' or @label='Save']", @"//*/android.widget.Button[@text='Save']", @"//*[@resource-id='com.xamarin.samples.taskyandroid:id/SaveButton']", @"//*[@resource-id='android:id/content']//*[@text='Save']", @"//*[@resource-id='android:id/content']/*[1]/*[6]", @"hierarchy/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[2]/android.widget.RelativeLayout/android.widget.Button"};
                contingencyXPathSelector = "hierarchy/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[2]/android.widget.RelativeLayout/android.widget.Button";
            }
            else if (ProjectConfig.PlataformName == "iOS")
            {
                selectors = new string[] {@"//*[@text='Save' or @label='Save']", @"//*/UIAStaticText[@label='Save']", @"//*[@name='Save']", @"//*[@name='Save']//*[@label='Save']", @"//*[@name='Save']/*[1]", @"AppiumAUT/UIAApplication/UIAWindow/UIATableView/UIATableCell[4]/UIAStaticText"};
                contingencyXPathSelector = "AppiumAUT/UIAApplication/UIAWindow/UIATableView/UIATableCell[4]/UIAStaticText";
            }

            string[] selectorsType = new string[] {@"CrossPlatform", @"ElementType", @"IdentifyAttributes", @"AncestorAttributes", @"AncestorIndex", @"AbsolutePath"};

            IWebElement e = _locator.FindElementByXPathInOrder(selectors, selectorsType);

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
