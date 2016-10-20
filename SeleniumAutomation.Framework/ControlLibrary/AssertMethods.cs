using SeleniumAutomation.Framework.BaseLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;

namespace SeleniumAutomation.Framework.ControlLibrary
{
    public class AssertResult
    {
        public bool result { get; set; }
        public string resultMessage { get; set; }
    }

    public class AssertMethods
    {
        // Private Instance of AssertMethods class
        public AssertResult assertResult;
        
        /// <summary>
        /// Assert Method Constructor
        /// </summary>
        public AssertMethods()
        {
            //Initializing object for AssertResult class
            assertResult = new AssertResult();
        }

        #region Assert Statements
        /// <summary>
        /// Verify page title equals to given text
        /// </summary>
        /// <param name="titleName"></param>
        /// <returns></returns>
        public AssertResult AssertPageTitleIs(string titleName)
        {
            try
            {
                if(DriverInstance.Instance.Title.Equals(titleName))
                {
                    assertResult.result = true;
                    assertResult.resultMessage = titleName + " is displayed";
                    LoggerInstance.log.Info("Assertion verified as page title is : "+titleName);
                    return assertResult;
                }
                else
                {
                    assertResult.result = false;
                    assertResult.resultMessage = titleName + " is not equal";
                    LoggerInstance.log.Info("Assertion verified as page title " + DriverInstance.Instance.Title+ " is not same as"+titleName);
                    return assertResult;
                }
            }
            catch (NoSuchElementException elementNotPresent)
            {
                assertResult.result = false;
                assertResult.resultMessage = elementNotPresent.Message;
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
                return assertResult;
            }
            catch (NoSuchWindowException noWindowPresent)
            {
                assertResult.result = false;
                assertResult.resultMessage = noWindowPresent.Message;
                LoggerInstance.log.Error(noWindowPresent.Message, noWindowPresent);
                return assertResult;
            }
            catch(Exception e)
            {
                assertResult.result = false;
                assertResult.resultMessage = e.Message;
                LoggerInstance.log.Error(e.Message, e);
                return assertResult;
            }
        }

        /// <summary>
        /// Verify page title contains the given text
        /// </summary>
        /// <param name="titleName"></param>
        /// <returns></returns>
        public AssertResult AssertPageTitleContains(string titleName)
        {
            try
            {
                if (DriverInstance.Instance.Title.Contains(titleName))
                {
                    assertResult.result = true;
                    assertResult.resultMessage = titleName + " is displayed";
                    LoggerInstance.log.Info("Assertion verified as page tile contains : "+titleName);
                    return assertResult;
                }
                else
                {
                    assertResult.result = false;
                    assertResult.resultMessage = titleName + " is not equal";
                    LoggerInstance.log.Info("Assertion verified as page title " + DriverInstance.Instance.Title + " does not contain " + titleName);
                    return assertResult;
                }
            }
            catch (NoSuchElementException elementNotPresent)
            {
                assertResult.result = false;
                assertResult.resultMessage = elementNotPresent.Message;
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
                return assertResult;
            }
            catch (NoSuchWindowException noWindowPresent)
            {
                assertResult.result = false;
                assertResult.resultMessage = noWindowPresent.Message;
                LoggerInstance.log.Error(noWindowPresent.Message, noWindowPresent);
                return assertResult;
            }
            catch (Exception e)
            {
                assertResult.result = false;
                assertResult.resultMessage = e.Message;
                LoggerInstance.log.Error(e.Message, e);
                return assertResult;
            }
        }

        /// <summary>
        /// Verify that the element visible  
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public AssertResult AssertElementVisible(IWebElement element)
        {
            try
            {
                assertResult.result = element.Displayed;
                assertResult.resultMessage = "\" " + element.GetTextByElement() + "\" element is visible";
                LoggerInstance.log.Info("Assertion verified as: " + element.Text + " is visible on the screen");
                return assertResult;
            }
            catch (NoSuchElementException elementNotPresent)
            {
                assertResult.result = false;
                assertResult.resultMessage = elementNotPresent.Message;
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
                return assertResult;
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                assertResult.result = false;
                assertResult.resultMessage = elementNotVisible.Message;
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
                return assertResult;
            }
            catch (Exception e)
            {
                assertResult.result = false;
                assertResult.resultMessage = e.Message;
                LoggerInstance.log.Error(e.Message, e);
                return assertResult;
            }
        }

        /// <summary>
        /// Verify that the element not visible  
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public AssertResult AssertElementNotPresent(IWebElement element)
        {
            try
            {
                if(!element.Displayed)
                {
                    assertResult.result = true;
                    assertResult.resultMessage = "\" " + element.GetTextByElement() + "\" element not visible";
                    LoggerInstance.log.Info("Assertion verified as: " + element.Text + " is not present on the screen");
                    return assertResult;
                }
                else
                {
                    assertResult.result = false;
                    assertResult.resultMessage = "\" " + element.GetTextByElement() + "\" element is visible";
                    LoggerInstance.log.Info("Assertion verified as: " + element.Text + " is present on the screen");
                    return assertResult;
                }
            }
            catch (NoSuchElementException elementNotPresent)
            {
                assertResult.result = false;
                assertResult.resultMessage = elementNotPresent.Message;
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
                return assertResult;
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                assertResult.result = false;
                assertResult.resultMessage = elementNotVisible.Message;
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
                return assertResult;
            }
            catch (Exception e)
            {
                assertResult.result = false;
                assertResult.resultMessage = e.Message;
                LoggerInstance.log.Error(e.Message, e);
                return assertResult;
            }
        }

        /// <summary>
        /// Verify the element present
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public AssertResult AssertElementPresent(IWebElement element)
        {
            try
            {
                if(!element.Size.IsEmpty)
                {
                    assertResult.result = true;
                    assertResult.resultMessage = "Element is present";
                    LoggerInstance.log.Info("Assertion verified as: " + element.Text + " is present");
                    return assertResult;
                }
                else
                {
                    assertResult.result = false;
                    assertResult.resultMessage = "Element not present";
                    LoggerInstance.log.Info("Assertion verified as: " + element.Text + " does not present");
                    return assertResult;
                }
            }
            catch (NoSuchElementException elementNotPresent)
            {
                assertResult.result = false;
                assertResult.resultMessage = elementNotPresent.Message;
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
                return assertResult;
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                assertResult.result = false;
                assertResult.resultMessage = elementNotVisible.Message;
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
                return assertResult;
            }
            catch (Exception e)
            {
                assertResult.result = false;
                assertResult.resultMessage = e.Message;
                LoggerInstance.log.Error(e.Message, e);
                return assertResult;
            }
        }

        /// <summary>
        /// Verify that the element present & visible
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public AssertResult AssertElementPresentAndVisible(IWebElement element)
        {
            try
            {
                if(element.Displayed && !element.Size.IsEmpty)
                {
                    assertResult.result = true;
                    assertResult.resultMessage = "Element is present & visible";
                    LoggerInstance.log.Info("Assertion verified as: " + element.Text + " is present and visible");
                    return assertResult;
                }
                else
                {
                    assertResult.result = false;
                    assertResult.resultMessage = "Element not present & visible";
                    LoggerInstance.log.Info("Assertion verified as: " + element.Text + " does not present / visible");
                    return assertResult;
                }
            }
            catch (NoSuchElementException elementNotPresent)
            {
                assertResult.result = false;
                assertResult.resultMessage = elementNotPresent.Message;
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
                return assertResult;
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                assertResult.result = false;
                assertResult.resultMessage = elementNotVisible.Message;
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
                return assertResult;
            }
            catch (Exception e)
            {
                assertResult.result = false;
                assertResult.resultMessage = e.Message;
                LoggerInstance.log.Error(e.Message, e);
                return assertResult;
            }
        }

        /// <summary>
        /// Verify that the element is enabled
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public AssertResult AssertElementEnabled(IWebElement element)
        {
            try
            {
                if(element.Enabled)
                {
                    assertResult.result = true;
                    assertResult.resultMessage = "Element enabled";
                    LoggerInstance.log.Info("Assertion verified as: " + element.Text + " is enabled");
                    return assertResult;
                }
                else
                {
                    assertResult.result = false;
                    assertResult.resultMessage = "Element not enabled";
                    LoggerInstance.log.Info("Assertion verified as: " + element.Text + " is not enabled");
                    return assertResult;
                }
            }
            catch (NoSuchElementException elementNotPresent)
            {
                assertResult.result = false;
                assertResult.resultMessage = elementNotPresent.Message;
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
                return assertResult;
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                assertResult.result = false;
                assertResult.resultMessage = elementNotVisible.Message;
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
                return assertResult;
            }
            catch (Exception e)
            {
                assertResult.result = false;
                assertResult.resultMessage = e.Message;
                LoggerInstance.log.Error(e.Message, e);
                return assertResult;
            }
        }

        /// <summary>
        /// Verify that the given input text is same as element text
        /// </summary>
        /// <param name="element"></param>
        /// <param name="textValue"></param>
        /// <returns></returns>
        public AssertResult AssertElementText(IWebElement element, string textValue)
        {
            try
            {
                if(element.Text == textValue)
                {
                    assertResult.result = true;
                    assertResult.resultMessage = "\""+ textValue + "\" is matching with the element text : "+ element.Text;
                    LoggerInstance.log.Info("Assertion verified as: " + element.Text + " is same as " + textValue);
                    return assertResult;
                }
                else
                {
                    assertResult.result = false;
                    assertResult.resultMessage = "\"" + textValue + "\" is not matching with the element text : " + element.Text;
                    LoggerInstance.log.Info("Assertion verified as: " + element.Text + " is same as " + textValue);
                    return assertResult;
                }
            }
            catch (NoSuchElementException elementNotPresent)
            {
                assertResult.result = false;
                assertResult.resultMessage = elementNotPresent.Message;
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
                return assertResult;
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                assertResult.result = false;
                assertResult.resultMessage = elementNotVisible.Message;
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
                return assertResult;
            }
            catch (Exception e)
            {
                assertResult.result = false;
                assertResult.resultMessage = e.Message;
                LoggerInstance.log.Error(e.Message, e);
                return assertResult;
            }
        }

        /// <summary>
        /// Verify that the element text contains the given input text
        /// </summary>
        /// <param name="element"></param>
        /// <param name="textValue"></param>
        public AssertResult AssertElementTextContains(IWebElement element, string textValue)
        {
            try
            {
                if(element.Text.Contains(textValue))
                {
                    assertResult.result = true;
                    assertResult.resultMessage = "\"" + textValue + "\" contains the element text : " + element.Text;
                    LoggerInstance.log.Info("Assertion verified as: " + element.Text + " contains the " + textValue);
                    return assertResult;
                }
                else
                {
                    assertResult.result = false;
                    assertResult.resultMessage = "\"" + textValue + "\" does not contains the element text : " + element.Text;
                    LoggerInstance.log.Info("Assertion verified as: " + element.Text + " does not contains " + textValue);
                    return assertResult;
                }
            }
            catch (NoSuchElementException elementNotPresent)
            {
                assertResult.result = false;
                assertResult.resultMessage = elementNotPresent.Message;
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
                return assertResult;
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                assertResult.result = false;
                assertResult.resultMessage = elementNotVisible.Message;
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
                return assertResult;
            }
            catch (Exception e)
            {
                assertResult.result = false;
                assertResult.resultMessage = e.Message;
                LoggerInstance.log.Error(e.Message, e);
                return assertResult;
            }
        }

        /// <summary>
        /// Verify that the check box is selected (true = checked | false = unchecked)
        /// </summary>
        /// <param name="element"></param>
        /// <param name="expectedStatus"></param>
        /// <returns></returns>
        public AssertResult AssertCheckBoxStatus(IWebElement element, bool expectedStatus)
        {
            try
            {
                if(element.GetCheckBoxStatus() == expectedStatus)
                {
                    assertResult.result = true;
                    assertResult.resultMessage = "Check box is selected / checked";
                    LoggerInstance.log.Info("Assertion verified as: elements expected status is "+assertResult.resultMessage);
                    return assertResult;
                }
                else 
                {
                    assertResult.result = false;
                    assertResult.resultMessage = "Check box is not selected / unchecked";
                    LoggerInstance.log.Info("Assertion verified as: elements expected status is " + assertResult.resultMessage);
                    return assertResult;
                }
            }
            catch (NoSuchElementException elementNotPresent)
            {
                assertResult.result = false;
                assertResult.resultMessage = elementNotPresent.Message;
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
                return assertResult;
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                assertResult.result = false;
                assertResult.resultMessage = elementNotVisible.Message;
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
                return assertResult;
            }
            catch (Exception e)
            {
                assertResult.result = false;
                assertResult.resultMessage = e.Message;
                LoggerInstance.log.Error(e.Message, e);
                return assertResult;
            }
        }

        /// <summary>
        /// Verify that the radio button is selected (true = selected | false = unselected
        /// </summary>
        /// <param name="element"></param>
        /// <param name="expectedStatus"></param>
        public AssertResult AssertRadioButtonStatus(IWebElement element, bool expectedStatus)
        {
            try
            {
                if (element.GetRadioBtnStatus() == expectedStatus)
                {
                    assertResult.result = true;
                    assertResult.resultMessage = "Radio button is selected";
                    LoggerInstance.log.Info("Assertion verified as: " + assertResult.resultMessage);
                    return assertResult;
                }
                else
                {
                    assertResult.result = false;
                    assertResult.resultMessage = "Radio button is not selected";
                    LoggerInstance.log.Info("Assertion verified as: "+ assertResult.resultMessage);
                    return assertResult;
                }
            }
            catch (NoSuchElementException elementNotPresent)
            {
                assertResult.result = false;
                assertResult.resultMessage = elementNotPresent.Message;
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
                return assertResult;
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                assertResult.result = false;
                assertResult.resultMessage = elementNotVisible.Message;
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
                return assertResult;
            }
            catch (Exception e)
            {
                assertResult.result = false;
                assertResult.resultMessage = e.Message;
                LoggerInstance.log.Error(e.Message, e);
                return assertResult;
            }
        }

        /// <summary>
        /// Verify that the given input text is selected text of the drop down control
        /// </summary>
        /// <param name="element"></param>
        /// <param name="selectedText"></param>
        /// <returns></returns>
        public AssertResult AssertSelectedTextInDropDown(IWebElement element, string selectedText)
        {
            try
            {
                if(element.GetSelectedTextFromDropDownByElement() == selectedText)
                {
                    assertResult.result = true;
                    assertResult.resultMessage = "\"" + selectedText + "\" is selected in the drop down";
                    LoggerInstance.log.Info("Assertion verified as: " + assertResult.resultMessage);
                    return assertResult;
                }
                else
                {
                    assertResult.result = false;
                    assertResult.resultMessage = "\"" + selectedText + "\" is not selected in the drop down";
                    LoggerInstance.log.Info("Assertion verified as: " + assertResult.resultMessage);
                    return assertResult;
                }

            }
            catch (NoSuchElementException elementNotPresent)
            {
                assertResult.result = false;
                assertResult.resultMessage = elementNotPresent.Message;
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
                return assertResult;
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                assertResult.result = false;
                assertResult.resultMessage = elementNotVisible.Message;
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
                return assertResult;
            }
            catch (Exception e)
            {
                assertResult.result = false;
                assertResult.resultMessage = e.Message;
                LoggerInstance.log.Error(e.Message, e);
                return assertResult;
            }
        }

        /// <summary>
        /// Verify that the given input text is present / exists in the drop down list item.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="textItem"></param>
        /// <returns></returns>
        public AssertResult AssertTextItemExistsInDropDownList(IWebElement element, string textItem)
        {
            try
            {
                bool itemExist = false;
                List<string> itemList = new List<string>();
                itemList.AddRange(element.GetAllItemsFromFropDownAsStringByElement());
                if (itemList.Count > 0)
                {
                    foreach (var item in itemList)
                    {
                        if(item == textItem)
                        {
                            itemExist = true;
                            break;
                        }
                    }
                }
                else
                {
                    assertResult.result = false;
                    assertResult.resultMessage = "Given \" " + textItem + "\" does not exist in drop down list";
                    LoggerInstance.log.Info("Assertion verified as: " + assertResult.resultMessage);
                    return assertResult;
                }

                if(itemExist)
                {
                    assertResult.result = true;
                    assertResult.resultMessage = "Given \" " + textItem + "\" exist in drop down list";
                    LoggerInstance.log.Info("Assertion verified as: " + assertResult.resultMessage);
                    return assertResult;
                }
                else
                {
                    assertResult.result = false;
                    assertResult.resultMessage = "Given \" " + textItem + "\" does not exist in drop down list";
                    LoggerInstance.log.Info("Assertion verified as: " + assertResult.resultMessage);
                    return assertResult;
                }

            }
            catch (NoSuchElementException elementNotPresent)
            {
                assertResult.result = false;
                assertResult.resultMessage = elementNotPresent.Message;
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
                return assertResult;
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                assertResult.result = false;
                assertResult.resultMessage = elementNotVisible.Message;
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
                return assertResult;
            }
            catch (Exception e)
            {
                assertResult.result = false;
                assertResult.resultMessage = e.Message;
                LoggerInstance.log.Error(e.Message, e);
                return assertResult;
            }
        }

        /// <summary>
        /// Verify that the element is having multiple selection option
        /// </summary>
        /// <param name="element"></param>
        public AssertResult AssertDropDownIsMultiple(IWebElement element)
        {
            try
            {
                SelectElement dropdownbox = new SelectElement(element);
                if(dropdownbox.IsMultiple)
                {
                    assertResult.result = true;
                    assertResult.resultMessage = "Element is having the multiple selection option enabled";
                    LoggerInstance.log.Info("Assertion verified as: " + assertResult.resultMessage);
                    return assertResult;
                }
                else
                {
                    assertResult.result = false;
                    assertResult.resultMessage = "Element does not have the multiple selection option enabled";
                    LoggerInstance.log.Info("Assertion verified as: " + assertResult.resultMessage);
                    return assertResult;
                }
            }
            catch (NoSuchElementException elementNotPresent)
            {
                assertResult.result = false;
                assertResult.resultMessage = elementNotPresent.Message;
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
                return assertResult;
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                assertResult.result = false;
                assertResult.resultMessage = elementNotVisible.Message;
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
                return assertResult;
            }
            catch (Exception e)
            {
                assertResult.result = false;
                assertResult.resultMessage = e.Message;
                LoggerInstance.log.Error(e.Message, e);
                return assertResult;
            }
        }

        /// <summary>
        /// Verify that the given 2 input texts are equal
        /// </summary>
        /// <param name="text1"></param>
        /// <param name="text2"></param>
        /// <returns></returns>
        public AssertResult AssertTextEqual(string text1, string text2)
        {
            try
            {
                if(text1 == text2)
                {
                    assertResult.result = true;
                    assertResult.resultMessage = text1 + " & " + text2 + " are equal";
                    LoggerInstance.log.Info("Assertion verified as: " + assertResult.resultMessage);
                    return assertResult;
                }
                else
                {
                    assertResult.result = false;
                    assertResult.resultMessage = text1 + " & " + text2 + " are not equal";
                    LoggerInstance.log.Info("Assertion verified as: " + assertResult.resultMessage);
                    return assertResult;
                }
            }
            catch (NullReferenceException nullException)
            {
                assertResult.result = false;
                assertResult.resultMessage = nullException.Message;
                LoggerInstance.log.Error(nullException.Message, nullException);
                return assertResult;
            }
            catch (Exception e)
            {
                assertResult.result = false;
                assertResult.resultMessage = e.Message;
                LoggerInstance.log.Error(e.Message, e);
                return assertResult;
            }
        }

        /// <summary>
        /// Verify that the given 2 input elements are equal
        /// </summary>
        /// <param name="element1"></param>
        /// <param name="element2"></param>
        /// <returns></returns>
        public AssertResult AssertElementsAreEqual(IWebElement element1, IWebElement element2)
        {
            try
            {
                if(element1 == element2)
                {
                    assertResult.result = true;
                    assertResult.resultMessage = element1.Text + " & " + element2.Text + " are equal";
                    LoggerInstance.log.Info("Assertion verified as: " + assertResult.resultMessage);
                    return assertResult;
                }
                else
                {
                    assertResult.result = false;
                    assertResult.resultMessage = element1.Text + " & " + element2.Text + " are not equal";
                    LoggerInstance.log.Info("Assertion verified as: " + assertResult.resultMessage);
                    return assertResult;
                }

            }
            catch (NoSuchElementException elementNotPresent)
            {
                assertResult.result = false;
                assertResult.resultMessage = elementNotPresent.Message;
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
                return assertResult;
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                assertResult.result = false;
                assertResult.resultMessage = elementNotVisible.Message;
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
                return assertResult;
            }
            catch (Exception e)
            {
                assertResult.result = false;
                assertResult.resultMessage = e.Message;
                LoggerInstance.log.Error(e.Message, e);
                return assertResult;
            }
        }

        /// <summary>
        /// Verify that the given 2 input elements are not equal
        /// </summary>
        /// <param name="element1"></param>
        /// <param name="element2"></param>
        /// <returns></returns>
        public AssertResult AssertElementsAreNotEqual(IWebElement element1, IWebElement element2)
        {
            try
            {
                if (element1 != element2)
                {
                    assertResult.result = true;
                    assertResult.resultMessage = element1.Text + " & " + element2.Text + " are not equal";
                    LoggerInstance.log.Info("Assertion verified as: " + assertResult.resultMessage);
                    return assertResult;
                }
                else
                {
                    assertResult.result = false;
                    assertResult.resultMessage = element1.Text + " & " + element2.Text + " are same & equal";
                    LoggerInstance.log.Info("Assertion verified as: " + assertResult.resultMessage);
                    return assertResult;
                }

            }
            catch (NoSuchElementException elementNotPresent)
            {
                assertResult.result = false;
                assertResult.resultMessage = elementNotPresent.Message;
                LoggerInstance.log.Error(elementNotPresent.Message, elementNotPresent);
                return assertResult;
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                assertResult.result = false;
                assertResult.resultMessage = elementNotVisible.Message;
                LoggerInstance.log.Error(elementNotVisible.Message, elementNotVisible);
                return assertResult;
            }
            catch (Exception e)
            {
                assertResult.result = false;
                assertResult.resultMessage = e.Message;
                LoggerInstance.log.Error(e.Message, e);
                return assertResult;
            }
        }

        /// <summary>
        /// Verify that the alert is present
        /// </summary>
        /// <returns></returns>
        public AssertResult AssertAlertPresent()
        {
            try
            {
                if (DriverInstance.Instance.SwitchTo().Alert() != null)
                {
                    assertResult.result = true;
                    assertResult.resultMessage = "Alert message is present";
                    LoggerInstance.log.Info("Assertion verified as: " + assertResult.resultMessage);
                    return assertResult;
                }
                else if (ExpectedConditions.AlertIsPresent() != null)
                {
                    assertResult.result = true;
                    assertResult.resultMessage = "Alert message is present";
                    LoggerInstance.log.Info("Assertion verified as: " + assertResult.resultMessage);
                    return assertResult;
                }
                else
                {
                    assertResult.result = false; ;
                    assertResult.resultMessage = "Alert message does not present";
                    LoggerInstance.log.Info("Assertion verified as: " + assertResult.resultMessage);
                    return assertResult;
                }
            }
            catch (NoAlertPresentException alertNotPresent)
            {
                assertResult.result = false; ;
                assertResult.resultMessage = "Alert message does not present" + alertNotPresent.Message;
                LoggerInstance.log.Error(alertNotPresent.Message, alertNotPresent);
                return assertResult;
            }
            catch(Exception e)
            {
                assertResult.result = false; ;
                assertResult.resultMessage = e.Message;
                LoggerInstance.log.Error(e.Message, e);
                return assertResult;
            }
        }

        /// <summary>
        /// Verify that the given text is equal to the text present in the alert message
        /// </summary>
        /// <param name="alertText"></param>
        /// <returns></returns>
        public AssertResult AssertTextPresentInAlertMessage(string alertText)
        {
            try
            {
                if (DriverInstance.Instance.SwitchTo().Alert().Text == alertText)
                {
                    assertResult.result = true;
                    assertResult.resultMessage = "Alert is present & alert message text is same as the input text \" " + alertText + "\"";
                    LoggerInstance.log.Info("Assertion is verified as: " + assertResult.resultMessage);
                    return assertResult;
                }
                else
                {
                    assertResult.result = false; ;
                    assertResult.resultMessage = "Alert message does not present";
                    LoggerInstance.log.Info("Assertion is verified as: " + assertResult.resultMessage);
                    return assertResult;
                }
            }
            catch (NoAlertPresentException alertNotPresent)
            {
                assertResult.result = false; ;
                assertResult.resultMessage = "Alert message does not present" + alertNotPresent.Message;
                LoggerInstance.log.Error(alertNotPresent.Message, alertNotPresent);
                return assertResult;
            }
            catch (Exception e)
            {
                assertResult.result = false; ;
                assertResult.resultMessage = e.Message;
                LoggerInstance.log.Error(e.Message, e);
                return assertResult;
            }
        }

        /// <summary>
        /// Verify that the current page  url is matching with the given input url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public AssertResult AssertPageUrl(string url)
        {
            try
            {
                if (DriverInstance.Instance.Url == url)
                {
                    assertResult.result = true;
                    assertResult.resultMessage = "Current URL matches the given input url";
                    LoggerInstance.log.Info("Assertion is verified as: " + assertResult.resultMessage);
                    return assertResult;
                }
                else
                {
                    assertResult.result = false;
                    assertResult.resultMessage = "Current URL does not match with the given input url";
                    LoggerInstance.log.Info("Assertion is verified as: " + assertResult.resultMessage);
                    return assertResult;
                }
            }
            catch (Exception e)
            {
                assertResult.result = false;
                assertResult.resultMessage = e.Message;
                LoggerInstance.log.Error(e.Message, e);
                return assertResult;
            }
        }

        #endregion
    }
}
