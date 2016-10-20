using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.Framework.BaseLibrary
{
    public static class DriverInstance
    {
        /// <summary>
        /// Global Selenium WebDriver Instance 
        /// </summary>
        public static IWebDriver Instance { get; set; }

        #region Driver Instance Functions
        /// <summary>
        /// Switch the driver control to Alert
        /// </summary>
        public static void SwitchToAlert()
        {
            try
            {
                DriverInstance.Instance.SwitchTo().Alert();
                LoggerInstance.log.Info("Control switched from current window to alert.");
            }
            catch(NoAlertPresentException noAlert)
            {
                LoggerInstance.log.Error("No Alert exist to switch",noAlert);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error("Failed to switch to the alert.", e);
            }
        }

        /// <summary>
        /// Switch the webdriver control back to the defaultcontent
        /// </summary>
        public static void SwitchToDefaultContent()
        {
            try
            {
                DriverInstance.Instance.SwitchTo().DefaultContent();
                LoggerInstance.log.Info("Control switched back to the default content.");
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error("Failed to switch to the default content.", e);
            }
        }

        /// <summary>
        /// Switch the webdriver control to the Frame using FrameName
        /// </summary>
        /// <param name="frameName"></param>
        public static void SwitchToFrame(String frameName)
        {
            try
            {
                DriverInstance.Instance.SwitchTo().Frame(frameName);
                LoggerInstance.log.Info("Control switch from current window to iframe : "+ "\""+frameName + "\".");
            }
            catch(NoSuchFrameException noframe)
            {
                LoggerInstance.log.Error("Frame does not exist to switch.", noframe);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error("Failed to switch to iframe : "+ "\""+frameName + "\".", e);
            }
        }

        /// <summary>
        /// Switch the webdriver control to the Frame using IWebElement
        /// </summary>
        /// <param name="frameElement"></param>
        public static void SwitchToFrame(IWebElement frameElement)
        {
            try
            {
                DriverInstance.Instance.SwitchTo().Frame(frameElement);
                LoggerInstance.log.Info("Control switch from current window to iframe : " + "\"" + frameElement.Text + "\".");
            }
            catch (NoSuchFrameException noframe)
            {
                LoggerInstance.log.Error("Frame does not exist to switch.", noframe);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error("Failed to switch to iframe : " + "\"" + frameElement.Text + "\".", e);
            }
        }

        /// <summary>
        /// Switch the webdriver control back to the parent frame
        /// </summary>
        public static void SwitchToParentFrame()
        {
            try
            {
                DriverInstance.Instance.SwitchTo().ParentFrame();
                LoggerInstance.log.Info("Control switch to the parent iframe of current iframe.");
            }
            catch (NoSuchFrameException noframe)
            {
                LoggerInstance.log.Error("Frame does not exist to switch.", noframe);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error("Failed to switch parent iframe.", e);
            }
        }

        /// <summary>
        /// Switch the webdriver control to the frame by using frame index
        /// </summary>
        /// <param name="frameIndex"></param>
        public static void SwitchToFrameIndex(int frameIndex)
        {
            try
            {
                DriverInstance.Instance.SwitchTo().Frame(frameIndex);
                LoggerInstance.log.Info("Switched to frame with the frameindex of : " + frameIndex +".");
            }
            catch (NoSuchFrameException noframe)
            {
                LoggerInstance.log.Error("Frame does not exist to switch.", noframe);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error("Failed to switch iframe with index : "+ frameIndex+".", e);
            }
        }

        /// <summary>
        /// Switch the webdriver control to the active element
        /// </summary>
        public static void SwitchToActiveElement()
        {
            try
            {
                DriverInstance.Instance.SwitchTo().ActiveElement();
                LoggerInstance.log.Info("Switched to the active element.");
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error("Failed to switch to active element.", e);
            }
        }

        /// <summary>
        /// Switch the webdriver control from one window to another using window name
        /// </summary>
        /// <param name="windowName"></param>
        public static void SwitchToWindow(string windowName)
        {
            try
            {
                DriverInstance.Instance.SwitchTo().Window(windowName);
                LoggerInstance.log.Info("Switched to window : "+ "\""+windowName+"\".");
            }
            catch(NoSuchWindowException noWindow)
            {
                LoggerInstance.log.Error(windowName + " does not exist.", noWindow);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error("Window doea not exist", e);
            }
        }

        #endregion

    }
}
