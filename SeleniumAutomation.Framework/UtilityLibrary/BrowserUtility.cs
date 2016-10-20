using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using SeleniumAutomation.Framework.BaseLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.Framework.UtilityLibrary
{
    public static class BrowserUtility
    {
        private static string binPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        #region Browser Functions

        /// <summary>
        /// Launch the browser by given browser type
        /// </summary>
        /// <param name="browser"></param>
        public static void LaunchBrowser(BrowserType browser)
        {
            try
            {
                String downloadFilepath = @"C:\Users\" + Environment.UserName + @"\Downloads";
                String driverLocation = binPath + ConfigurationManager.AppSettings["DriverLocation"];
                switch (browser)
                {
                    case BrowserType.Firefox:
                        LaunchFireFox(downloadFilepath);
                        LoggerInstance.log.Info("Launched Browser - Firefox");
                        break;
                    case BrowserType.Chrome:
                        LaunchChrome(driverLocation, downloadFilepath);
                        LoggerInstance.log.Info("Launched Browser - Chrome");
                        break;
                    case BrowserType.InternetExplorer:
                        LaunchInternetExplorer(driverLocation, downloadFilepath);
                        LoggerInstance.log.Info("Launched Browser - IntenetExplorer");
                        break;
                    case BrowserType.Headless:
                        LaunchHtmlUnitDriver(driverLocation);
                        LoggerInstance.log.Info("Launched Browser - HTMLUnitDriver");
                        break;
                    case BrowserType.Safari:
                        LaunchSafari(driverLocation);
                        LoggerInstance.log.Info("Launched Browser - Safari");
                        break;
                    case BrowserType.Edge:
                        //TODO: Need to implement the EDGE browser driver
                        break;
                    default:
                        LaunchFireFox(downloadFilepath);
                        LoggerInstance.log.Info("Launched default browser as - Firefox");
                        break;
                }
            }
            catch(Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Launch the browser by given browesr name
        /// </summary>
        /// <param name="browser"></param>
        public static void LaunchBrowser(string browser)
        {
            try
            {
                String downloadFilepath = @"C:\Users\" + Environment.UserName + @"\Downloads";
                String driverLocation = binPath + ConfigurationManager.AppSettings["DriverLocation"];
                switch (browser)
                {
                    case "Firefox":
                        LaunchFireFox(downloadFilepath);
                        LoggerInstance.log.Info("Launched Browser - Firefox");
                        break;
                    case "Chrome":
                        LaunchChrome(driverLocation, downloadFilepath);
                        LoggerInstance.log.Info("Launched Browser - Chrome");
                        break;
                    case "InternetExplorer":
                        LaunchInternetExplorer(driverLocation, downloadFilepath);
                        LoggerInstance.log.Info("Launched Browser - InternetExplorer");
                        break;
                    case "Safari":
                        LaunchSafari(driverLocation);
                        LoggerInstance.log.Info("Launched Browser - Safari");
                        break;
                    case "HtmlUnitDriver":
                        LaunchHtmlUnitDriver(driverLocation);
                        LoggerInstance.log.Info("Launched Browser - Html Unit Driver");
                        break;
                    case "Edge":
                        //TODO: Need to implement the EDGE browser driver
                        break;
                    default:
                        LaunchFireFox(downloadFilepath);
                        LoggerInstance.log.Info("Launched default browser as - Firefox");
                        break;
                }
            }
            catch(Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Navigate to the url
        /// </summary>
        /// <param name="url"></param>
        public static void NavigateTo(string url)
        {
            try
            {
                DriverInstance.Instance.Navigate().GoToUrl(url);
                LoggerInstance.log.Info("Page navigate to url : \""+ url+"\"");
            }
            catch(UriFormatException uriFormat)
            {
                LoggerInstance.log.Error("Given URL format is wrong. " + uriFormat.Message, uriFormat);
            }
            catch(Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Navigate back
        /// </summary>
        public static void NavigateBack()
        {
            try
            {
                DriverInstance.Instance.Navigate().Back();
                LoggerInstance.log.Info("Page navigate back");
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Navigate Forward
        /// </summary>
        public static void NavigateForward()
        {
            try
            {
                DriverInstance.Instance.Navigate().Forward();
                LoggerInstance.log.Info("Page navigate forward");
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
            
        }

        /// <summary>
        /// Refresh the page
        /// </summary>
        public static void PageRefresh()
        {
            try
            {
                DriverInstance.Instance.Navigate().Refresh();
                LoggerInstance.log.Info("Page refreshed");
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
         
        }

        /// <summary>
        /// Maximize the browser launched
        /// </summary>
        public static void MaximizeBrowser()
        {
            try
            {
                DriverInstance.Instance.Manage().Window.Maximize();
                LoggerInstance.log.Info("Browser window maximized");
            }
            catch(NoSuchWindowException noWindow)
            {
                LoggerInstance.log.Error("Browser window does not exist", noWindow);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Minimize the browser launched
        /// </summary>
        public static void MinimizeBrowser()
        {
            try
            {
                DriverInstance.Instance.Manage().Window.Position.Offset(-2000, 0);
                LoggerInstance.log.Info("Browser window minimized");
            }
            catch (NoSuchWindowException noWindow)
            {
                LoggerInstance.log.Error("Browser window does not exist", noWindow);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Close the browser session
        /// </summary>
        public static void CloseBrowser()
        {
            try
            {
                DriverInstance.Instance.Close();
                LoggerInstance.log.Info("Clsoed the browser instance");
            }
            catch(NoSuchWindowException noWindow)
            {
                LoggerInstance.log.Error("Browser window does not exist", noWindow);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Close the web driver session
        /// </summary>
        public static void CloseDriverSession()
        {
            try
            {
                DriverInstance.Instance.Quit();
                LoggerInstance.log.Info("Driver session closed");
            }
            catch(DriverServiceNotFoundException driverNotFound)
            {
                LoggerInstance.log.Error("Driver Instance not available", driverNotFound);
            }
            catch(WebDriverException driverException)
            {
                LoggerInstance.log.Error(driverException.Message, driverException);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Clear / Delete all browser cookies
        /// </summary>
        public static void ClearBrowserCookies()
        {
            try
            {
                DriverInstance.Instance.Manage().Cookies.DeleteAllCookies();
                LoggerInstance.log.Info("All cookies are deleted");
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Clear / Delete browser cookie by name
        /// </summary>
        /// <param name="cookieName"></param>
        public static void ClearBrowserCookieByName(string cookieName)
        {
            try
            {
                DriverInstance.Instance.Manage().Cookies.DeleteCookieNamed(cookieName);
                LoggerInstance.log.Info(cookieName + " cleared from browser cookies");
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Clear / Delete browser cookie by cookie name
        /// </summary>
        /// <param name="cookieName"></param>
        public static void ClearBrowserCookieByCookieName(Cookie cookieName)
        {
            try
            {
                DriverInstance.Instance.Manage().Cookies.DeleteCookie(cookieName);
                LoggerInstance.log.Info(cookieName + " cleared from browser cookies");
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Launch Firefox browser with browser profile capabilities
        /// </summary>
        /// <param name="downloadFilepath"></param>
        public static void LaunchFireFox(string downloadFilepath)
        {
            try
            {
                FirefoxProfile profile = new FirefoxProfile();
                profile.SetPreference("browser.download.folderList", 2);
                profile.SetPreference("browser.download.dir", downloadFilepath);
                profile.SetPreference("browser.download.manager.focusWhenStarting", false);
                profile.SetPreference("browser.download.manager.alertOnEXEOpen", false);
                profile.SetPreference("browser.download.manager.closeWhenDone", false);
                profile.SetPreference("browser.download.manager.showAlertOnComplete", false);
                profile.SetPreference("browser.download.manager.useWindow", false);
                profile.SetPreference("browser.helperApps.neverAsk.saveToDisk",
                        "image/jpg, text/plain, text/html, text/csv, text/xml, application/xml, application/xhtml+xml, "
                        + "application/csv, application/msword, application/excel, text/comma-separated-values, "
                        + "application/x-rar-compressed, application/x-download, application/vnd.ms-excel, "
                        + "application/x-jar, application/pdf, application/msexcel, application/octet-stream, "
                        + "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

                profile.SetPreference("browser.helperApps.neverAsk.openFile", false);
                profile.SetPreference("browser.helperApps.alwaysAsk.force", false);
                profile.SetPreference("services.sync.prefs.sync.browser.download.manager.showWhenStarting", false);
                profile.SetPreference("pdfjs.disabled", false);
                profile.SetPreference("network.proxy.type", 1);
                profile.EnableNativeEvents = true;
                DriverInstance.Instance = new FirefoxDriver(profile);
                LoggerInstance.log.Info("Driver Instance created for browser - Firefox");
            }
            catch(Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Launch Chrome browser with options
        /// </summary>
        /// <param name="driverLocation"></param>
        /// <param name="downloadFilepath"></param>
        public static void LaunchChrome(string driverLocation, string downloadFilepath)
        {
            try
            {
                var options = new ChromeOptions();
                options.AddArguments("--test-type");
                options.AddArguments("start-maximized");
                DriverInstance.Instance = new ChromeDriver(driverLocation, options);
                LoggerInstance.log.Info("Driver Instance created for browser - Chrome");
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Launch Internet Explorer browser with desired capabilities
        /// </summary>
        /// <param name="driverLocation"></param>
        /// <param name="downloadFilepath"></param>
        public static void LaunchInternetExplorer(string driverLocation, string downloadFilepath)
        {
            try
            {
                var option = new InternetExplorerOptions { RequireWindowFocus = true, EnablePersistentHover = false };
                DriverInstance.Instance = new InternetExplorerDriver(driverLocation, option);
                DesiredCapabilities capabilities = DesiredCapabilities.InternetExplorer();
                capabilities.SetCapability("INTRODUCE_FLAKINESS_BY_IGNORING_SECURITY_DOMAINS", true);
                capabilities.SetCapability(CapabilityType.AcceptSslCertificates, true);
                capabilities.IsJavaScriptEnabled = true;
                LoggerInstance.log.Info("Driver Instance created for browser - Internet Explorer");
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Launch Safri browser
        /// </summary>
        /// <param name="driverLocation"></param>
        public static void LaunchSafari(string driverLocation)
        {
            try
            {
                DriverInstance.Instance = new SafariDriver();
                LoggerInstance.log.Info("Driver Instance created for browser - Safari");
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Launch HTNL Unit Driver / Headless browser
        /// </summary>
        /// <param name="driverLocation"></param>
        public static void LaunchHtmlUnitDriver(string driverLocation)
        {
            try
            {
                DriverInstance.Instance = new RemoteWebDriver(DesiredCapabilities.HtmlUnit());
                DesiredCapabilities capabilities = DesiredCapabilities.HtmlUnitWithJavaScript();
                capabilities.IsJavaScriptEnabled = true;
                LoggerInstance.log.Info("Driver Instance created for browser - HtmlUnit Driver");
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        #endregion
    }
}
