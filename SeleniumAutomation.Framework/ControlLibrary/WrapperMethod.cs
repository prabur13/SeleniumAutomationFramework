using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomation.Framework.BaseLibrary;
using SeleniumAutomation.Framework.UtilityLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.Framework.ControlLibrary
{
    public static class WrapperMethod
    {
        
        #region Extension Methods

        #region Set Methods

        /// <summary>
        /// Enter Text value into the element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void EnterTextByElement(this IWebElement element, string value)
        {
            try
            {
                element.Clear();
                element.SendKeys(value);
                LoggerInstance.log.Info("\"" + value + "\" has been entered in the " + element.Text);
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch(ElementNotVisibleException elementNotVisible)
            {
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
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
        /// Clear the existing text content from the element
        /// </summary>
        /// <param name="element"></param>
        public static void ClearTextByElement(this IWebElement element)
        {
            try
            {
                LoggerInstance.log.Info("Clearing text displayed in the " + element.Text);
                element.Clear();
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
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
        /// Click on the element
        /// </summary>
        /// <param name="element"></param>
        public static void ClickByElement(this IWebElement element)
        {
            try
            {
                LoggerInstance.log.Info("Clicking on element " + element.Text);
                element.Click();
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
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
        /// Double click on the element
        /// </summary>
        /// <param name="element"></param>
        public static void DoubleClickByElement(this IWebElement element)
        {
            try
            {
                Actions action = new Actions(DriverInstance.Instance);
                action.MoveToElement(element).DoubleClick().Build().Perform();
                LoggerInstance.log.Info(element.Text + " has been double clicked");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
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
        /// Right click / Context click on the element
        /// </summary>
        /// <param name="element"></param>
        public static void ContextClickByElement(this IWebElement element)
        {
            try
            {
                Actions action = new Actions(DriverInstance.Instance);
                action.ContextClick(element).Build().Perform();
                LoggerInstance.log.Info("Context click has been performed on the " + element.Text);
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
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
        /// Mouse hover over the element
        /// </summary>
        /// <param name="element"></param>
        public static void MouseHoverByElement(this IWebElement element)
        {
            try
            {
                Actions action = new Actions(DriverInstance.Instance);
                action.MoveToElement(element).Perform();
                LoggerInstance.log.Info("Mouse hover performed on the " + element.Text);
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
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
        /// Mouse hover over the element and click element
        /// </summary>
        /// <param name="element"></param>
        public static void MouseHoverClickByElement(this IWebElement element)
        {
            try
            {
                Actions action = new Actions(DriverInstance.Instance);
                action.MoveToElement(element).Click().Build().Perform();
                LoggerInstance.log.Info("Mouse hover & click performed on the element " + element.Text);
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
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
        /// Click on the element and hold
        /// </summary>
        /// <param name="element"></param>
        public static void ClickAndHoldByElement(this IWebElement element)
        {
            try
            {
                Actions action = new Actions(DriverInstance.Instance);
                action.ClickAndHold(element).Build().Perform();
                LoggerInstance.log.Info(element.Text + " element has been clicked and hold the control");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
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
        /// Release the element from the mouse / keybord control holds
        /// </summary>
        /// <param name="element"></param>
        public static void ReleaseHoldByElement(this IWebElement element)
        {
            try
            {
                Actions action = new Actions(DriverInstance.Instance);
                action.Release(element).Build().Perform();
                LoggerInstance.log.Info(element.Text + " element has been released from the click and hold control");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
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
        /// Click on the element and move the element location to the offset given (Drag and Drop)
        /// </summary>
        /// <param name="element"></param>
        /// <param name="offSetX"></param>
        /// <param name="offSetY"></param>
        public static void MoveElementOffsetByElement(this IWebElement element, int offSetX, int offSetY)
        {
            try
            {
                Actions action = new Actions(DriverInstance.Instance);
                action.ClickAndHold(element).Build().Perform();
                action.MoveByOffset(offSetX, offSetY).Build().Perform();
                action.Release().Build().Perform();
                LoggerInstance.log.Info(element.Text + " element offset has been moved from source offset to destination offset");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
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
        /// Select the value from the drop down using value
        /// </summary>
        /// <param name="element"></param>
        /// <param name="textValue"></param>
        public static void SelectDropDownTextByElement(this IWebElement element, string textValue)
        {
            try
            {
                Actions action = new Actions(DriverInstance.Instance);
                new SelectElement(element).SelectByText(textValue);
                LoggerInstance.log.Info(textValue + " has been selected from the drop down / list box by text");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
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
        /// Select the value from the drop down using index
        /// </summary>
        /// <param name="element"></param>
        /// <param name="indexValue"></param>
        public static void SelectDropDwonIndexByElement(this IWebElement element, int indexValue)
        {
            try
            {
                Actions action = new Actions(DriverInstance.Instance);
                new SelectElement(element).SelectByIndex(indexValue);
                LoggerInstance.log.Info("Drop down has been selected with the index value of "+ indexValue);
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
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
        /// Select the value from the drop down using the value attribute
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SelectDropDownValueByElement(this IWebElement element, string value)
        {
            try
            {
                Actions action = new Actions(DriverInstance.Instance);
                new SelectElement(element).SelectByValue(value);
                LoggerInstance.log.Info("Drop down has been selected with the value of " + value);
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
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
        /// De-select the value from the drop down / list box using the value
        /// </summary>
        /// <param name="element"></param>
        /// <param name="textValue"></param>
        public static void DeselectDropDownTextByElement(this IWebElement element, string textValue)
        {
            try
            {
                Actions action = new Actions(DriverInstance.Instance);
                new SelectElement(element).DeselectByText(textValue);
                LoggerInstance.log.Info("Unselected / De select the text "+ textValue + " from the drop down / list box");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
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
        /// De-select the value from the drop down / list box using the index
        /// </summary>
        /// <param name="element"></param>
        /// <param name="indexValue"></param>
        public static void DeselectDropDwonIndexByElement(this IWebElement element, int indexValue)
        {
            try
            {
                Actions action = new Actions(DriverInstance.Instance);
                new SelectElement(element).DeselectByIndex(indexValue);
                LoggerInstance.log.Info("Unselected / De select the value using index " + indexValue+ " from the drop down / list box");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
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
        /// De-select the value from the drop down / list box using the value attribute
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void DeselectDropDownValueByElement(this IWebElement element, string value)
        {
            try
            {
                Actions action = new Actions(DriverInstance.Instance);
                new SelectElement(element).DeselectByValue(value);
                LoggerInstance.log.Info("Unselected / De select the value " + value + " from the drop down / list box");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
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
        /// De-select all the values from the drop down (if multiple selection is possible) / list box 
        /// </summary>
        /// <param name="element"></param>
        public static void DeselectAllDropDownValuesByElement(this IWebElement element)
        {
            try
            {
                Actions action = new Actions(DriverInstance.Instance);
                new SelectElement(element).DeselectAll();
                LoggerInstance.log.Info("Unselected / De select all values from the drop down / list box control");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
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
        /// Click on element using tag name and linktext value
        /// </summary>
        /// <param name="element"></param>
        /// <param name="tagName"></param>
        /// <param name="linkTextValue"></param>
        public static void ClickElementUsingTagNameAndTextValueByElement(this IWebElement element, string tagName, string linkTextValue)
        {
            try
            {
                Actions action = new Actions(DriverInstance.Instance);
                List<IWebElement> listOfLinks = element.FindElements(By.TagName(tagName)).ToList();
                foreach (IWebElement item in listOfLinks)
                {
                    if (item.Text == linkTextValue)
                    {
                        item.Click();
                        LoggerInstance.log.Info(linkTextValue+ " has been clicked from the " + element.Text + " using tagName");
                        break;
                    }
                }
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
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

        #region Get Methods

        /// <summary>
        /// Get element text
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetTextByElement(this IWebElement element)
        {
            return element.Text;
        }

        /// <summary>
        /// Get the selected text value from the drop down control
        /// </summary>
        /// <param name="dropdownElement"></param>
        /// <returns></returns>
        public static string GetSelectedTextFromDropDownByElement(this IWebElement dropdownElement)
        {
            return new SelectElement(dropdownElement).SelectedOption.Text;
        }

        /// <summary>
        /// Get all items in the drop down control as IWebElement list
        /// </summary>
        /// <param name="dropdownElement"></param>
        /// <returns></returns>
        public static List<IWebElement> GetAllItemsFromDropDownByElement(this IWebElement dropdownElement)
        {
            return new SelectElement(dropdownElement).Options.ToList();
        }

        /// <summary>
        /// Get all items in the drop down control as string list
        /// </summary>
        /// <param name="dropdownElement"></param>
        /// <returns></returns>
        public static List<String> GetAllItemsFromFropDownAsStringByElement(this IWebElement dropdownElement)
        {
            List<IWebElement> elementList = new SelectElement(dropdownElement).Options.ToList();
            List<String> returnList = new List<String>();
            foreach (var item in elementList)
            {
                returnList.Add(item.Text);
            }
            return returnList;
        }

        /// <summary>
        /// Get only all selected items from drop down / list box (if multiple option is enabled) as IWebElement list
        /// </summary>
        /// <param name="dropdownElement"></param>
        /// <returns></returns>
        public static List<IWebElement> GetAllSelectedItemsFromDropDownByElement(this IWebElement dropdownElement)
        {
            return new SelectElement(dropdownElement).AllSelectedOptions.ToList();
        }

        /// <summary>
        /// Get only all selected items from drop down / list box (if multiple option is enabled) as string list
        /// </summary>
        /// <param name="dropdownElement"></param>
        /// <returns></returns>
        public static List<String> GetAllSelectedItemsFromDropDownAsStringByElement(this IWebElement dropdownElement)
        {
            List<IWebElement> elementList = new SelectElement(dropdownElement).AllSelectedOptions.ToList();
            List<String> returnList = new List<String>();
            foreach (var item in elementList)
            {
                returnList.Add(item.Text);
            }
            return returnList;
        }

        /// <summary>
        /// Get count of selected items from drop down / list box
        /// </summary>
        /// <param name="dropdownElement"></param>
        /// <returns></returns>
        public static int GetCountOfSelectedItemsFromDropDownByElement(this IWebElement dropdownElement)
        {
            return new SelectElement(dropdownElement).AllSelectedOptions.Count;
        }

        /// <summary>
        /// Get count of all items from drop down / list box
        /// </summary>
        /// <param name="dropdownElement"></param>
        /// <returns></returns>
        public static int GetCountOfAllItemsFromDropDownByElement(this IWebElement dropdownElement)
        {
            return new SelectElement(dropdownElement).Options.Count;
        }

        /// <summary>
        /// Get the status of the checkbox as checked (true) / unchecked (false)
        /// </summary>
        /// <param name="checkBoxElement"></param>
        /// <returns></returns>
        public static bool GetCheckBoxStatus(this IWebElement checkBoxElement)
        {
            return checkBoxElement.Selected;
        }

        /// <summary>
        /// Get the status of the radio button as selected (true) / unchecked (false)
        /// </summary>
        /// <param name="radioButtonElement"></param>
        /// <returns></returns>
        public static bool GetRadioBtnStatus(this IWebElement radioButtonElement)
        {
            return radioButtonElement.Selected;
        }

        /// <summary>
        /// Get row count of the table control 
        /// </summary>
        /// <param name="tableElement"></param>
        /// <returns></returns>
        public static int GetRowCountFromTableByElement(this IWebElement tableElement)
        {
            return tableElement.FindElements(By.TagName("tr")).Count;
        }

        /// <summary>
        /// Get all the row content of the table control 
        /// </summary>
        /// <param name="tableElement"></param>
        /// <returns></returns>
        public static List<String> GetRowDetailsFromTableByElement(this IWebElement tableElement)
        {
            var columns = tableElement.FindElements(By.TagName("th"));
            var rows = tableElement.FindElements(By.TagName("tr"));

            List<String> rowDetails = new List<String>();
            List<String> returnRowDetails = new List<String>();
            foreach (var tr in rows)
            {
                var td = tr.FindElements(By.TagName("td"));
                foreach (var item in td)
                {
                    rowDetails.Add(item.ToString());
                }
                returnRowDetails.AddRange(rowDetails);
            }
            return returnRowDetails;
        }

        /// <summary>
        /// Get all child element as IWebElement list using tagname of the parent element
        /// </summary>
        /// <param name="parentElement"></param>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public static List<IWebElement> GetAllChildElementsUsingTagNameByElement(this IWebElement parentElement, string tagName)
        {
            //return parentElement.FindElements(By.TagName(tagName)).ToList();
            IList<IWebElement> elementList = parentElement.FindElements(By.TagName(tagName));
            List<IWebElement> allListElement = new List<IWebElement>();
            foreach (var item in elementList)
            {
                if (item.Displayed)
                {
                    allListElement.Add(item);
                }
            }
            return allListElement;
        }

        /// <summary>
        /// Get all child element as IWebElement list using xpath of the parent element
        /// </summary>
        /// <param name="parentElement"></param>
        /// <param name="xpath"></param>
        /// <returns></returns>
        public static List<IWebElement> GetAllChildElementsUsingXpathByElement(this IWebElement parentElement, string xpath)
        {
            //return parentElement.FindElements(By.XPath(xpath)).ToList();
            IList<IWebElement> elementList = parentElement.FindElements(By.XPath(xpath));
            List<IWebElement> allListElement = new List<IWebElement>();
            foreach (var item in elementList)
            {
                if (item.Displayed)
                {
                    allListElement.Add(item);
                }
            }
            return allListElement;
        }

        /// <summary>
        /// Get the attribute value of the given element using attribute name
        /// </summary>
        /// <param name="element"></param>
        /// <param name="attributeText"></param>
        /// <returns></returns>
        public static string GetAttributeValueByElement(this IWebElement element, string attributeText)
        {
            return element.GetAttribute(attributeText).ToString();
        }

        /// <summary>
        /// Get text present from the alert message
        /// </summary>
        /// <returns></returns>
        public static string GetAlertMessageText()
        {
            return DriverInstance.Instance.SwitchTo().Alert().Text;
        }

        #endregion

        #endregion

        #region Locator Methods

        /// <summary>
        /// Get IWebElement using locator type and locator value
        /// </summary>
        /// <param name="elementText"></param>
        /// <param name="locator"></param>
        /// <returns></returns>
        public static IWebElement GetElementByLocator(string elementText, LocatorType locator)
        {
            try
            {
                IWebElement element;   
                switch (locator)
                {
                    case LocatorType.Id:
                        element = DriverInstance.Instance.FindElement(By.Id(elementText));
                        break;
                    case LocatorType.Name:
                        element = DriverInstance.Instance.FindElement(By.Name(elementText));
                        break;
                    case LocatorType.CssSelector:
                        element = DriverInstance.Instance.FindElement(By.CssSelector(elementText));
                        break;
                    case LocatorType.XPath:
                        element = DriverInstance.Instance.FindElement(By.XPath(elementText));
                        break;
                    case LocatorType.LinkText:
                        element = DriverInstance.Instance.FindElement(By.LinkText(elementText));
                        break;
                    case LocatorType.PartialLinkText:
                        element = DriverInstance.Instance.FindElement(By.PartialLinkText(elementText));
                        break;
                    case LocatorType.TagName:
                        element = DriverInstance.Instance.FindElement(By.TagName(elementText));
                        break;
                    case LocatorType.ClassName:
                        element = DriverInstance.Instance.FindElement(By.ClassName(elementText));
                        break;
                    default:
                        element = null;
                        break;
                }

                return element;
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
                return null;
            }
            catch(ElementNotVisibleException elementNotVisible)
            {
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
                return null;
            }
            catch(Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
                return null;
            }
        }

        /// <summary>
        /// Enter text using locator type and locator value
        /// </summary>
        /// <param name="elementText"></param>
        /// <param name="locator"></param>
        /// <param name="textValue"></param>
        public static void EnterTextByLocator(string elementText, LocatorType locator, string textValue)
        {
            try
            {
                switch (locator)
                {
                    case LocatorType.Id:
                        DriverInstance.Instance.FindElement(By.Id(elementText)).EnterTextByElement(textValue);
                        break;
                    case LocatorType.Name:
                        DriverInstance.Instance.FindElement(By.Name(elementText)).EnterTextByElement(textValue);
                        break;
                    case LocatorType.CssSelector:
                        DriverInstance.Instance.FindElement(By.CssSelector(elementText)).EnterTextByElement(textValue);
                        break;
                    case LocatorType.XPath:
                        DriverInstance.Instance.FindElement(By.XPath(elementText)).EnterTextByElement(textValue);
                        break;
                    case LocatorType.LinkText:
                        DriverInstance.Instance.FindElement(By.LinkText(elementText)).EnterTextByElement(textValue);
                        break;
                    case LocatorType.PartialLinkText:
                        DriverInstance.Instance.FindElement(By.PartialLinkText(elementText)).EnterTextByElement(textValue);
                        break;
                    case LocatorType.TagName:
                        DriverInstance.Instance.FindElement(By.TagName(elementText)).EnterTextByElement(textValue);
                        break;
                    case LocatorType.ClassName:
                        DriverInstance.Instance.FindElement(By.ClassName(elementText)).EnterTextByElement(textValue);
                        break;
                    default:
                        break;
                }
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Click on the element using locator type and locator value
        /// </summary>
        /// <param name="elementText"></param>
        /// <param name="locator"></param>
        public static void ClickByLocator(string elementText, LocatorType locator)
        {
            try
            {
                switch (locator)
                {
                    case LocatorType.Id:
                        DriverInstance.Instance.FindElement(By.Id(elementText)).Click();
                        break;
                    case LocatorType.Name:
                        DriverInstance.Instance.FindElement(By.Name(elementText)).Click();
                        break;
                    case LocatorType.CssSelector:
                        DriverInstance.Instance.FindElement(By.CssSelector(elementText)).Click();
                        break;
                    case LocatorType.XPath:
                        DriverInstance.Instance.FindElement(By.XPath(elementText)).Click();
                        break;
                    case LocatorType.LinkText:
                        DriverInstance.Instance.FindElement(By.LinkText(elementText)).Click();
                        break;
                    case LocatorType.PartialLinkText:
                        DriverInstance.Instance.FindElement(By.PartialLinkText(elementText)).Click();
                        break;
                    case LocatorType.TagName:
                        DriverInstance.Instance.FindElement(By.TagName(elementText)).Click();
                        break;
                    case LocatorType.ClassName:
                        DriverInstance.Instance.FindElement(By.ClassName(elementText)).Click();
                        break;
                    default:
                        break;
                }
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Click on the element using locator type and locator value
        /// </summary>
        /// <param name="elementText"></param>
        /// <param name="locator"></param>
        public static void DoubleClickByLocator(string elementText, LocatorType locator)
        {
            try
            {
                switch (locator)
                {
                    case LocatorType.Id:
                        DriverInstance.Instance.FindElement(By.Id(elementText)).DoubleClickByElement();
                        break;
                    case LocatorType.Name:
                        DriverInstance.Instance.FindElement(By.Name(elementText)).DoubleClickByElement();
                        break;
                    case LocatorType.CssSelector:
                        DriverInstance.Instance.FindElement(By.CssSelector(elementText)).DoubleClickByElement();
                        break;
                    case LocatorType.XPath:
                        DriverInstance.Instance.FindElement(By.XPath(elementText)).DoubleClickByElement();
                        break;
                    case LocatorType.LinkText:
                        DriverInstance.Instance.FindElement(By.LinkText(elementText)).DoubleClickByElement();
                        break;
                    case LocatorType.PartialLinkText:
                        DriverInstance.Instance.FindElement(By.PartialLinkText(elementText)).DoubleClickByElement();
                        break;
                    case LocatorType.TagName:
                        DriverInstance.Instance.FindElement(By.TagName(elementText)).DoubleClickByElement();
                        break;
                    case LocatorType.ClassName:
                        DriverInstance.Instance.FindElement(By.ClassName(elementText)).DoubleClickByElement();
                        break;
                    default:
                        break;
                }
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        #endregion

        #region Other Methods

        /// <summary>
        /// Accept the alert message 
        /// </summary>
        public static void AcceptAlert()
        {
            try
            {
                DriverInstance.Instance.SwitchTo().Alert().Accept();
                LoggerInstance.log.Info("Driver control switched to alert message and Alert message accepted");
                DriverInstance.Instance.SwitchTo().DefaultContent();
                LoggerInstance.log.Info("Driver control switched back to default content / page");
            }
            catch(NoAlertPresentException noAlertException)
            {
                LoggerInstance.log.Error(noAlertException.Message,noAlertException);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (WebDriverException webDriverException)
            {
                LoggerInstance.log.Error(webDriverException.Message, webDriverException);
            }
            catch(Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Dismiss the alert message
        /// </summary>
        public static void DismissAlert()
        {
            try
            {
                DriverInstance.Instance.SwitchTo().Alert().Dismiss();
                LoggerInstance.log.Info("Driver control switched to alert message and Alert message dismissed");
                DriverInstance.Instance.SwitchTo().DefaultContent();
                LoggerInstance.log.Info("Driver control switched back to default content / page");
            }
            catch (NoAlertPresentException noAlertException)
            {
                LoggerInstance.log.Error(noAlertException.Message, noAlertException);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (WebDriverException webDriverException)
            {
                LoggerInstance.log.Error(webDriverException.Message, webDriverException);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Enter the text to the alert message
        /// </summary>
        /// <param name="textValue"></param>
        public static void EnterTextToAlert(string textValue)
        {
            try
            {
                DriverInstance.Instance.SwitchTo().Alert().SendKeys(textValue);
                LoggerInstance.log.Info("Driver control switches to the alert and entered the text " + "\""+textValue+"\".");
            }
            catch (NoAlertPresentException noAlertException)
            {
                LoggerInstance.log.Error(noAlertException.Message, noAlertException);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (WebDriverException webDriverException)
            {
                LoggerInstance.log.Error(webDriverException.Message, webDriverException);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Pass username and password to the  user credential alert message
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public static void PassCredentialInAlert(string userName, string password)
        {
            try
            {
                DriverInstance.Instance.SwitchTo().Alert().SetAuthenticationCredentials(userName, password);
                LoggerInstance.log.Info("Driver control switched to the user credential alert and entered the username & password given as " + "\"" + userName + "\"" + " & " + "\"" + password + "\".");
            }
            catch (NoAlertPresentException noAlertException)
            {
                LoggerInstance.log.Error(noAlertException.Message, noAlertException);
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
            }
            catch (WebDriverException webDriverException)
            {
                LoggerInstance.log.Error(webDriverException.Message, webDriverException);
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Take screenshot of the page / window currently displaying
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string TakeScreenshot(string fileName)
        {
            try
            {
                Screenshot capturedFile = ((ITakesScreenshot)DriverInstance.Instance).GetScreenshot();
                capturedFile.SaveAsFile(fileName + ".png", System.Drawing.Imaging.ImageFormat.Png);
                return fileName + ".png";
            }
            catch(BadImageFormatException badImage)
            {
                LoggerInstance.log.Error(badImage.Message, badImage);
                return badImage.Message;
            }
            catch (WebDriverTimeoutException webdriverTimeOut)
            {
                LoggerInstance.log.Error(webdriverTimeOut.Message, webdriverTimeOut);
                return webdriverTimeOut.Message;
            }
            catch (TimeoutException timeOutEx)
            {
                LoggerInstance.log.Error(timeOutEx.Message, timeOutEx);
                return timeOutEx.Message;
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
                return e.Message;
            }
        }
        
        /// <summary>
        /// Run / Execute the javascript given as input string
        /// </summary>
        /// <param name="scriptText"></param>
        public static void RunJavascript(string scriptText)
        {
            try
            {
                IJavaScriptExecutor scriptExecutor = (IJavaScriptExecutor)DriverInstance.Instance;
                scriptExecutor.ExecuteScript(scriptText,"");
                LoggerInstance.log.Info("Executed Javascript "+ "\""+ scriptText+"\".");
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Drag and drop element from source element location to destination element location
        /// </summary>
        /// <param name="srcElement"></param>
        /// <param name="dstnElement"></param>
        public static void DragAndDropElementUsingSourceAndDestinationElement(IWebElement srcElement, IWebElement dstnElement)
        {
            try
            {
                Actions action = new Actions(DriverInstance.Instance);
                action.DragAndDrop(srcElement, dstnElement).Build().Perform();
                LoggerInstance.log.Info("source element " + srcElement.Text + " dragged and dropped to the destination element " + dstnElement);
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
        /// Drag and drop element from source to destination using offset
        /// </summary>
        /// <param name="element"></param>
        /// <param name="xOffset"></param>
        /// <param name="yOffset"></param>
        public static void DragAndDropElementUsingOffset(IWebElement element,int xOffset, int yOffset)
        {
            try
            {
                Actions action = new Actions(DriverInstance.Instance);
                action.DragAndDropToOffset(element, xOffset, yOffset);
                action.Build().Perform();
                LoggerInstance.log.Info("Element " + element.Text + " dragged and dropped from xOffset " + xOffset + " to "+yOffset + " location");
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


        #region Scroll Functions
        
        
        /// <summary>
        /// Scroll Down the page to 1 level using Coordinates
        /// </summary>
        public static void ScrollDown()
        {
            try
            {
                RunJavascript("window.scrollBy(0,250)");
                LoggerInstance.log.Info("Java script exucted for page scroll down to 1 level");
            }
            catch (Exception e)
            {
                   LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Scroll Up the page to 1 level using Coordinates
        /// </summary>
        public static void ScrollUp()
        {
            try
            {
                RunJavascript("window.scrollBy(250,0)");
                LoggerInstance.log.Info("Java script exucted for page scroll up to 1 level");
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }
        
        /// <summary>
        /// Scrolling to bottom of a page
        /// </summary>
        public static void ScrollingToBottomOfAPage()
        {
            try
            {
                RunJavascript("window.scrollTo(0, document.body.scrollHeight)");
                LoggerInstance.log.Info("Java script exucted for page scroll down to the bottom of the page");
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Scrolling to an element using coordinates
        /// </summary>
        /// <param name="xValue"> element.Location.X to get the x coordinate</param>
        /// <param name="yValue"> element.Location.Y to get the y coordinate</param>
        public static void ScrollingToAnElementUsingOffset(int xValue, int yValue)
        {
            try
            {
                RunJavascript("window.scrollTo("+xValue+","+yValue+")");
                LoggerInstance.log.Info("Java script exucted for page scroll to an element of the page");
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        /// <summary>
        /// Scrolling to an element
        /// </summary>
        /// <param name="element"></param>
        public static void ScrollingToAnElementUsingElementLocation(this IWebElement element)
        {
            try
            {
                IJavaScriptExecutor scriptExecutor = (IJavaScriptExecutor)DriverInstance.Instance;
                scriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);",element);
                LoggerInstance.log.Info("Java script exucted for page scroll to an element of the page");
            }
            catch (NoSuchElementException elementNotPresent)
            {
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
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
        /// Scroll to the bottom of a page in slow motion
        /// </summary>
        public static void ScrollingToBottomInSlowMotion()
        {
            try
            {
                for (int second = 0; ; second++)
                {
                    if(second >=60)
                    {
                        break;
                    }
                    RunJavascript("window.scrollBy(0,400)");
                    WaitMethods.WaitForImplicitTimeOut(TimeSpan.FromSeconds(3));
                }
            }
            catch (Exception e)
            {
                LoggerInstance.log.Error(e.Message, e);
            }
        }

        #endregion

        #endregion
    }
}
