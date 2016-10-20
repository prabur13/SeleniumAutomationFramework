using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomation.Framework.BaseLibrary;
using System.Configuration;

namespace SeleniumAutomation.Framework.ControlLibrary
{
    public class WaitMethods
    {
        private static TimeSpan pageLoadTimeOut = TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["PageLoadTimeOut"]));
        private static TimeSpan implicitTimeInSeconds = TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["ImplicitTimeOutPeriod"]));
        private static TimeSpan explicitTimeOutPeriod = TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["ExplicitTimeOutPeriod"]));
        private static TimeSpan retryTimeOutPeriod = TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["RetryTimeOutPeriod"]));
        private static TimeSpan sleepTime = TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["SleepTime"]));

        #region Wait methods

        /// <summary>
        /// Implicit wait for configured time
        /// </summary>
        public static void WaitForImplicitTimeOut()
        {
            try
            {
                DriverInstance.Instance.Manage().Timeouts().ImplicitlyWait(implicitTimeInSeconds);
                LoggerInstance.log.Info("Driver implicitly waits for "+ implicitTimeInSeconds + " seconds");
            }
            catch(Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Implicit wait for given timeout
        /// </summary>
        /// <param name="timeOutSeconds"></param>
        public static void WaitForImplicitTimeOut(TimeSpan timeOutSecs)
        {
            try
            {
                DriverInstance.Instance.Manage().Timeouts().ImplicitlyWait(timeOutSecs);
                LoggerInstance.log.Info("Driver implicitly waits for " + timeOutSecs + " seconds");
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for page load using timeoutseconds configured
        /// </summary>
        public static void WaitForPageLoad()
        {
            try
            {
                DriverInstance.Instance.Manage().Timeouts().SetPageLoadTimeout(pageLoadTimeOut);
                LoggerInstance.log.Info("Driver waits for " + pageLoadTimeOut + " to complete pageload.");

            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeout)
            {
                LoggerInstance.log.Error(timeout.Message, timeout);
            }
            catch (WebDriverException webDriverEx)
            {
                WrapperMethod.RunJavascript("window.stop()");
                LoggerInstance.log.Error(webDriverEx.Message, webDriverEx);
                LoggerInstance.log.Info("Stops page load", webDriverEx);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for page load using given timeout in seconds
        /// </summary>
        /// <param name="timeOutSeconds"></param>
        public static void WaitForPageLoad(TimeSpan timeOutSecs)
        {
            try
            {
                DriverInstance.Instance.Manage().Timeouts().SetPageLoadTimeout(timeOutSecs);
                LoggerInstance.log.Info("Driver waits for " + timeOutSecs + " to complete pageload.");
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeout)
            {
                LoggerInstance.log.Error(timeout.Message, timeout);
            }
            catch (WebDriverException webDriverEx)
            {
                WrapperMethod.RunJavascript("window.stop()");
                LoggerInstance.log.Error(webDriverEx.Message, webDriverEx);
                LoggerInstance.log.Info("Stops page load", webDriverEx);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait untill the element is visible for timeout configured
        /// </summary>
        public static void WaitForElementVisibilityByLocator(By by)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, explicitTimeOutPeriod);
                wait.Until(ExpectedConditions.ElementIsVisible(by));
                LoggerInstance.log.Info("Driver explicitly waits "+ explicitTimeOutPeriod + " seconds for element visibility");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch(TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch(Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for the element is visible for the given timeout
        /// </summary>
        public static void WaitForElementVisibilityByLocator(By by, TimeSpan timeOutSecs)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, timeOutSecs);
                wait.Until(ExpectedConditions.ElementIsVisible(by));
                LoggerInstance.log.Info("Driver explicitly waits " + timeOutSecs + " seconds for element visibility");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait untill the element is exist in DOM
        /// </summary>
        public static void WaitForElementExists(By by)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, explicitTimeOutPeriod);
                wait.Until(ExpectedConditions.ElementExists(by));
                LoggerInstance.log.Info("Driver explicitly waits " + explicitTimeOutPeriod + " seconds for element presence");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait untill the element is exist in DOM for the given timeout
        /// </summary>
        /// <param name="by"></param>
        /// <param name="timeOutSeconds"></param>
        public static void WaitForElementExists(By by, TimeSpan timeOutSecs)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, timeOutSecs);
                wait.Until(ExpectedConditions.ElementExists(by));
                LoggerInstance.log.Info("Driver explicitly waits " + timeOutSecs + " seconds for element presence");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for element enabled and clickable
        /// </summary>
        public static void WaitForElementEnable(IWebElement element)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, explicitTimeOutPeriod);
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
                LoggerInstance.log.Info("Driver explicitly waits " + explicitTimeOutPeriod + " seconds for element get enable");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for element enabled and clickable for given input time
        /// </summary>
        /// <param name="element"></param>
        /// <param name="timeOutSeconds"></param>
        public static void WaitForElementEnable(IWebElement element, TimeSpan timeOutSecs)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, timeOutSecs);
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
                LoggerInstance.log.Info("Driver explicitly waits " + timeOutSecs + " seconds for element get enable");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for element visible 
        /// </summary>
        /// <param name="by"></param>
        public static void WaitForElementVisible(By by)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, explicitTimeOutPeriod);
                wait.Until(ExpectedConditions.ElementIsVisible(by));
                LoggerInstance.log.Info("Driver explicitly waits " + explicitTimeOutPeriod + " seconds for element visibility");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for element visible for the given timeout
        /// </summary>
        /// <param name="by"></param>
        /// <param name="timeOutSeconds"></param>
        public static void WaitForElementVisible(By by, TimeSpan timeOutSecs)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, timeOutSecs);
                wait.Until(ExpectedConditions.ElementIsVisible(by));
                LoggerInstance.log.Info("Driver explicitly waits " + timeOutSecs + " seconds for element visibility");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for text to be present on the element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="textPresent"></param>
        public static void WaitForElementTextToBePresent(IWebElement element, string textPresent)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, explicitTimeOutPeriod);
                wait.Until(ExpectedConditions.TextToBePresentInElement(element, textPresent));
                LoggerInstance.log.Info("Driver explicitly waits " + explicitTimeOutPeriod + " seconds for " + textPresent + " to be present");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for text to be present on the element for given timeout
        /// </summary>
        /// <param name="element"></param>
        /// <param name="textPresent"></param>
        /// <param name="timeOutSeconds"></param>
        public static void WaitForElementTextToBePresent(IWebElement element, string textPresent, TimeSpan timeOutSecs)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, timeOutSecs);
                wait.Until(ExpectedConditions.TextToBePresentInElement(element, textPresent));
                LoggerInstance.log.Info("Driver explicitly waits " + timeOutSecs + " seconds for "+ textPresent +" to be present");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for element nor element text not present
        /// </summary>
        /// <param name="by"></param>
        /// <param name="textPresent"></param>
        public static void WaitForElementTextNotPresent(By by, string textPresent)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, explicitTimeOutPeriod);
                wait.Until(ExpectedConditions.InvisibilityOfElementWithText(by, textPresent));
                LoggerInstance.log.Info("Driver explicitly waits " + explicitTimeOutPeriod + " seconds for " + textPresent + " to be disappear");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for element nor element text not present for given timeout
        /// </summary>
        /// <param name="by"></param>
        /// <param name="textPresent"></param>
        /// <param name="timeOutSeconds"></param>
        public static void WaitForElementTextNotPresent(By by, string textPresent, TimeSpan timeOutSecs)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, timeOutSecs);
                wait.Until(ExpectedConditions.InvisibilityOfElementWithText(by, textPresent));
                LoggerInstance.log.Info("Driver explicitly waits " + timeOutSecs + " seconds for " + textPresent + " to be disappear");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for element not visible / disapperar's
        /// </summary>
        /// <param name="by"></param>
        public static void WaitForElementNotVisible(By by)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, explicitTimeOutPeriod);
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
                LoggerInstance.log.Info("Driver explicitly waits " + explicitTimeOutPeriod + " seconds for element to be disappear");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for element not visible / disappear's
        /// </summary>
        /// <param name="by"></param>
        /// <param name="timeOutSeconds"></param>
        public static void WaitForElementNotVisible(By by, TimeSpan timeOutSecs)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, timeOutSecs);
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
                LoggerInstance.log.Info("Driver explicitly waits " + timeOutSecs + " seconds for element to be disappear");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for Page Title as given text
        /// </summary>
        /// <param name="titleText"></param>
        public static void WaitForPageTitle(string titleText)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, explicitTimeOutPeriod);
                wait.Until(ExpectedConditions.TitleIs(titleText));
                LoggerInstance.log.Info("Driver explicitly waits " + explicitTimeOutPeriod + " seconds for page title text " + "\""+ titleText+ "\".");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for page title as given text for given timeout seconds
        /// </summary>
        /// <param name="titleText"></param>
        /// <param name="timeOutSeconds"></param>
        public static void WaitForPageTitle(string titleText, TimeSpan timeOutSecs)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, timeOutSecs);
                wait.Until(ExpectedConditions.TitleIs(titleText));
                LoggerInstance.log.Info("Driver explicitly waits " + timeOutSecs + " seconds for page title text " + "\"" + titleText + "\".");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for Page Title contains given text
        /// </summary>
        /// <param name="titleText"></param>
        public static void WaitForPageTitleContains(string titleText)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, explicitTimeOutPeriod);
                wait.Until(ExpectedConditions.TitleContains(titleText));
                LoggerInstance.log.Info("Driver explicitly waits " + explicitTimeOutPeriod + " seconds for page title text contains " + "\"" + titleText + "\".");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for page title conatins given text for given timeout seconds
        /// </summary>
        /// <param name="titleText"></param>
        /// <param name="timeOutSeconds"></param>
        public static void WaitForPageTitleContains(string titleText, TimeSpan timeOutSecs)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, timeOutSecs);
                wait.Until(ExpectedConditions.TitleContains(titleText));
                LoggerInstance.log.Info("Driver explicitly waits " + explicitTimeOutPeriod + " seconds for page title text contains " + "\"" + titleText + "\".");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for the URL to be matching with given text
        /// </summary>
        /// <param name="urlText"></param>
        public static void WaitForUrlMatches(string urlText)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, explicitTimeOutPeriod);
                wait.Until(ExpectedConditions.UrlMatches(urlText));
                LoggerInstance.log.Info("Driver explicitly waits " + explicitTimeOutPeriod + " seconds for url text matches with " + "\"" + urlText + "\".");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for the URL to be matching with the given text for given timeout
        /// </summary>
        /// <param name="urlText"></param>
        /// <param name="timeOutSeconds"></param>
        public static void WaitForUrlMatches(string urlText, TimeSpan timeOutSecs)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, timeOutSecs);
                wait.Until(ExpectedConditions.UrlMatches(urlText));
                LoggerInstance.log.Info("Driver explicitly waits " + timeOutSecs + " seconds for url text matches with " + "\"" + urlText + "\".");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for the URL contains the given text 
        /// </summary>
        /// <param name="urlText"></param>
        public static void WaitForUrlTextContains(string urlText)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, explicitTimeOutPeriod);
                wait.Until(ExpectedConditions.UrlContains(urlText));
                LoggerInstance.log.Info("Driver explicitly waits " + explicitTimeOutPeriod + " seconds for url text contains " + "\"" + urlText + "\".");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for the URL contains the given text for given timeout
        /// </summary>
        /// <param name="urlText"></param>
        /// <param name="timeOutSeconds"></param>
        public static void WaitForUrlTextContains(string urlText, TimeSpan timeOutSecs)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, timeOutSecs);
                wait.Until(ExpectedConditions.UrlContains(urlText));
                LoggerInstance.log.Info("Driver explicitly waits " + timeOutSecs + " seconds for url text contains " + "\"" + urlText + "\".");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for the URL to be
        /// </summary>
        /// <param name="urlText"></param>
        public static void WaitForUrlToBe(string urlText)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, explicitTimeOutPeriod);
                wait.Until(ExpectedConditions.UrlToBe(urlText));
                LoggerInstance.log.Info("Driver explicitly waits " + explicitTimeOutPeriod + " seconds for url text to be " + "\"" + urlText + "\".");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for the given time till the URL to be
        /// </summary>
        /// <param name="urlText"></param>
        /// <param name="timeOutSeconds"></param>
        public static void WaitForUrlToBe(string urlText, TimeSpan timeOutSecs)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, timeOutSecs);
                wait.Until(ExpectedConditions.UrlToBe(urlText));
                LoggerInstance.log.Info("Driver explicitly waits " + timeOutSecs + " seconds for url text to be " + "\"" + urlText + "\".");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for the value of the element to be given text
        /// </summary>
        /// <param name="element"></param>
        /// <param name="textValue"></param>
        public static void WaitForElementTextValue(IWebElement element, string textValue)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, explicitTimeOutPeriod);
                wait.Until(ExpectedConditions.TextToBePresentInElementValue(element, textValue));
                LoggerInstance.log.Info("Driver explicitly waits "+explicitTimeOutPeriod+" seconds for web element text value to be" +"\"" +textValue+"\".");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for the value of the element to be given text for given timeout
        /// </summary>
        /// <param name="element"></param>
        /// <param name="urlText"></param>
        /// <param name="timeOutSeconds"></param>
        public static void WaitForElementTextValue(IWebElement element, string textValue, TimeSpan timeOutSecs)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, timeOutSecs);
                wait.Until(ExpectedConditions.TextToBePresentInElementValue(element, textValue));
                LoggerInstance.log.Info("Driver explicitly waits " + timeOutSecs + " seconds for web element text value to be" + "\"" + textValue + "\".");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for element to be selected
        /// </summary>
        /// <param name="element"></param>
        public static void WaitForElementToBeSelected(IWebElement element)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, explicitTimeOutPeriod);
                wait.Until(ExpectedConditions.ElementToBeSelected(element));
                LoggerInstance.log.Info("Driver explicitly waits " + explicitTimeOutPeriod + " seconds for " + element.Text + " to be selcted");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for element to be selected for given timeout
        /// </summary>
        /// <param name="element"></param>
        /// <param name="timeOutSeconds"></param>
        public static void WaitForElementToBeSelected(IWebElement element, TimeSpan timeOutSecs)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, timeOutSecs);
                wait.Until(ExpectedConditions.ElementToBeSelected(element));
                LoggerInstance.log.Info("Driver explicitly waits " + timeOutSecs + " seconds for " + element.Text + " to be selcted");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for Frame available and switch to it
        /// </summary>
        /// <param name="by"></param>
        public static void WaitForFrameAndSwitchToIt(By by)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, explicitTimeOutPeriod);
                wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(by));
                LoggerInstance.log.Info("Driver explicitly waits " + explicitTimeOutPeriod + " seconds for iframe to be available and switch to it");
            }
            catch (NoSuchFrameException frameNotPresent)
            {
                LoggerInstance.log.Error(frameNotPresent.Message, frameNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOut)
            {
                LoggerInstance.log.Error(timeOut.Message, timeOut);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for frame available for given timeout and switch to it
        /// </summary>
        /// <param name="by"></param>
        /// <param name="timeOutSeconds"></param>
        public static void WaitForFrameAndSwitchToIt(By by, TimeSpan timeOutSecs)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, timeOutSecs);
                wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(by));
                LoggerInstance.log.Info("Driver explicitly waits " + timeOutSecs + " seconds for iframe to be available and switch to it");
            }
            catch (NoSuchFrameException frameNotPresent)
            {
                LoggerInstance.log.Error(frameNotPresent.Message, frameNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOut)
            {
                LoggerInstance.log.Error(timeOut.Message, timeOut);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for alert to be present
        /// </summary>
        public static void WaitForAlertPresent()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, explicitTimeOutPeriod);
                wait.Until(ExpectedConditions.AlertIsPresent());
                LoggerInstance.log.Info("Driver explicitly waits" + explicitTimeOutPeriod + " seconds for alert to be present");
            }
            catch (NoAlertPresentException alertNotPresent)
            {
                LoggerInstance.log.Info(alertNotPresent.Message, alertNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOut)
            {
                LoggerInstance.log.Error(timeOut.Message, timeOut);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for alert to be present for given timeout
        /// </summary>
        /// <param name="timeOutSeconds"></param>
        public static void WaitForAlertPresent(TimeSpan timeOutSecs)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, timeOutSecs);
                wait.Until(ExpectedConditions.AlertIsPresent());
                LoggerInstance.log.Info("Driver explicitly waits" + timeOutSecs + " seconds for alert to be present");
            }
            catch (NoAlertPresentException alertNotPresent)
            {
                LoggerInstance.log.Info(alertNotPresent.Message, alertNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOut)
            {
                LoggerInstance.log.Error(timeOut.Message, timeOut);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for alert state to be true (exist) / false (not exist)
        /// </summary>
        /// <param name="alertState"></param>
        public static void WaitForAlertStateToBe(bool alertState)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, explicitTimeOutPeriod);
                wait.Until(ExpectedConditions.AlertState(alertState));
                LoggerInstance.log.Info("Driver explicitly waits " + explicitTimeOutPeriod + "seconds for alert state to be " + "\"" + alertState + "\".");
            }
            catch (NoAlertPresentException alertNotPresent)
            {
                LoggerInstance.log.Info(alertNotPresent.Message, alertNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOut)
            {
                LoggerInstance.log.Error(timeOut.Message, timeOut);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Wait for alert state to be true (exist) / false (not exist) for given timeout
        /// </summary>
        /// <param name="alertState"></param>
        /// <param name="timeOutSeconds"></param>
        public static void WaitForAlertStateToBe(bool alertState, TimeSpan timeOutSecs)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(DriverInstance.Instance, timeOutSecs);
                wait.Until(ExpectedConditions.AlertState(alertState));
                LoggerInstance.log.Info("Driver explicitly waits " + timeOutSecs + "seconds for alert state to be " + "\"" + alertState + "\".");
            }
            catch (NoAlertPresentException alertNotPresent)
            {
                LoggerInstance.log.Info(alertNotPresent.Message, alertNotPresent);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOut)
            {
                LoggerInstance.log.Error(timeOut.Message, timeOut);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        #endregion
    }
}