using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Robot.Web.UITests.Controllers
{
    [TestClass]
    public class HomeControllerTest : SeleniumTest
    {
        public HomeControllerTest() : base("NumericSequenceCalculator")
        {
        }

        [TestMethod]
        public void When_Input_Empty_Should_Return_Error_Message()
        {
            // Act
            this.FirefoxDriver.Navigate().GoToUrl(this.GetAbsoluteUrl("/"));
            this.FirefoxDriver.FindElement(By.Id("Input")).Clear();
            this.FirefoxDriver.FindElement(By.Id("btnExecute")).Click();

            // Assert
            Assert.IsTrue(
                this.FirefoxDriver.FindElement(By.ClassName("field-validation-error"))
                    .Text.Equals("Please enter a command for robot"));
        }

        [TestMethod]
        public void Test_Scenario_1()
        {
            // Act
            StringBuilder stringCommands = new StringBuilder();
            stringCommands.AppendLine("PLACE 0,0,NORTH");
            stringCommands.AppendLine("MOVE");
            stringCommands.AppendLine("MOVE");
            stringCommands.AppendLine("REPORT");

            this.FirefoxDriver.Navigate().GoToUrl(this.GetAbsoluteUrl("/"));
            this.FirefoxDriver.FindElement(By.Id("Input")).Clear();
            this.FirefoxDriver.FindElement(By.Id("Input")).SendKeys(stringCommands.ToString());
            this.FirefoxDriver.FindElement(By.Id("btnExecute")).Click();

            // Assert
            Assert.IsTrue(this.FirefoxDriver.FindElement(By.Id("divResult")).Text.Trim().Equals("0,2,NORTH"));
        }

        [TestMethod]
        public void Test_Scenario_2()
        {
            // Act
            StringBuilder stringCommands = new StringBuilder();
            stringCommands.AppendLine("PLACE 0,0,NORTH");
            stringCommands.AppendLine("LEFT");
            stringCommands.AppendLine("REPORT");

            this.FirefoxDriver.Navigate().GoToUrl(this.GetAbsoluteUrl("/"));
            this.FirefoxDriver.FindElement(By.Id("Input")).Clear();
            this.FirefoxDriver.FindElement(By.Id("Input")).SendKeys(stringCommands.ToString());
            this.FirefoxDriver.FindElement(By.Id("btnExecute")).Click();

            // Assert
            Assert.IsTrue(this.FirefoxDriver.FindElement(By.Id("divResult")).Text.Trim().Equals("0,0,WEST"));
        }


        [TestMethod]
        public void Test_Scenario_3()
        {
            // Act
            StringBuilder stringCommands = new StringBuilder();
            stringCommands.AppendLine("PLACE 1,2,EAST");
            stringCommands.AppendLine("MOVE");
            stringCommands.AppendLine("MOVE");
            stringCommands.AppendLine("LEFT");
            stringCommands.AppendLine("MOVE");
            stringCommands.AppendLine("REPORT");

            this.FirefoxDriver.Navigate().GoToUrl(this.GetAbsoluteUrl("/"));
            this.FirefoxDriver.FindElement(By.Id("Input")).Clear();
            this.FirefoxDriver.FindElement(By.Id("Input")).SendKeys(stringCommands.ToString());
            this.FirefoxDriver.FindElement(By.Id("btnExecute")).Click();

            // Assert
            Assert.IsTrue(this.FirefoxDriver.FindElement(By.Id("divResult")).Text.Trim().Equals("3,3,NORTH"));
        }

        [TestMethod]
        public void Test_Scenario_4()
        {
            // Act
            StringBuilder stringCommands = new StringBuilder();
            stringCommands.AppendLine("MOVE");
            stringCommands.AppendLine("LEFT");
            stringCommands.AppendLine("RIGHT");
            stringCommands.AppendLine("REPORT");

            this.FirefoxDriver.Navigate().GoToUrl(this.GetAbsoluteUrl("/"));
            this.FirefoxDriver.FindElement(By.Id("Input")).Clear();
            this.FirefoxDriver.FindElement(By.Id("Input")).SendKeys(stringCommands.ToString());
            this.FirefoxDriver.FindElement(By.Id("btnExecute")).Click();

            // Assert
            Assert.IsTrue(this.FirefoxDriver.FindElement(By.Id("divResult")).Text.Trim().Equals(string.Empty));
        }
        
        [TestMethod]
        public void Test_Scenario_5()
        {
            // Act
            StringBuilder stringCommands = new StringBuilder();
            stringCommands.AppendLine("MOVE");
            stringCommands.AppendLine("LEFT");
            stringCommands.AppendLine("PLACE 4,4,NORTH");
            stringCommands.AppendLine("LEFT");
            stringCommands.AppendLine("MOVE");
            stringCommands.AppendLine("MOVE");
            stringCommands.AppendLine("LEFT");
            stringCommands.AppendLine("REPORT");

            this.FirefoxDriver.Navigate().GoToUrl(this.GetAbsoluteUrl("/"));
            this.FirefoxDriver.FindElement(By.Id("Input")).Clear();
            this.FirefoxDriver.FindElement(By.Id("Input")).SendKeys(stringCommands.ToString());
            this.FirefoxDriver.FindElement(By.Id("btnExecute")).Click();

            // Assert
            Assert.IsTrue(this.FirefoxDriver.FindElement(By.Id("divResult")).Text.Trim().Equals("2,4,SOUTH"));
        }

        
        [TestMethod]
        public void Test_Scenario_6()
        {
            // Act
            StringBuilder stringCommands = new StringBuilder();

            stringCommands.AppendLine("MOVE");
            stringCommands.AppendLine("LEFT");
            stringCommands.AppendLine("PLACE 4,4,NORTH");
            stringCommands.AppendLine("LEFT");
            stringCommands.AppendLine("MOVE");
            stringCommands.AppendLine("MOVE");
            stringCommands.AppendLine("LEFT");
            stringCommands.AppendLine("REPORT");
            stringCommands.AppendLine("MOVE");
            stringCommands.AppendLine("MOVE");
            stringCommands.AppendLine("LEFT");
            stringCommands.AppendLine("REPORT");

            this.FirefoxDriver.Navigate().GoToUrl(this.GetAbsoluteUrl("/"));
            this.FirefoxDriver.FindElement(By.Id("Input")).Clear();
            this.FirefoxDriver.FindElement(By.Id("Input")).SendKeys(stringCommands.ToString());
            this.FirefoxDriver.FindElement(By.Id("btnExecute")).Click();

            // Assert
            Assert.IsTrue(this.FirefoxDriver.FindElement(By.Id("divResult")).Text.Trim().Equals("2,4,SOUTH 2,2,EAST"));
        }

        [TestMethod]
        public void Test_Scenario_7()
        {
            // Act
            StringBuilder stringCommands = new StringBuilder();
            stringCommands.AppendLine("PLACE 1.5,1.5,NORTH");
            stringCommands.AppendLine("REPORT");

            this.FirefoxDriver.Navigate().GoToUrl(this.GetAbsoluteUrl("/"));
            this.FirefoxDriver.FindElement(By.Id("Input")).Clear();
            this.FirefoxDriver.FindElement(By.Id("Input")).SendKeys(stringCommands.ToString());
            this.FirefoxDriver.FindElement(By.Id("btnExecute")).Click();

            // Assert
            Assert.IsTrue(this.FirefoxDriver.FindElement(By.Id("divResult")).Text.Trim().Equals(string.Empty));
        }

        [TestMethod]
        public void Test_Scenario_8()
        {
            // Act
            StringBuilder stringCommands = new StringBuilder();
            stringCommands.AppendLine("PLACE -1,-1,NORTH");
            stringCommands.AppendLine("LEFT");
            stringCommands.AppendLine("REPORT");

            this.FirefoxDriver.Navigate().GoToUrl(this.GetAbsoluteUrl("/"));
            this.FirefoxDriver.FindElement(By.Id("Input")).Clear();
            this.FirefoxDriver.FindElement(By.Id("Input")).SendKeys(stringCommands.ToString());
            this.FirefoxDriver.FindElement(By.Id("btnExecute")).Click();

            // Assert
            Assert.IsTrue(this.FirefoxDriver.FindElement(By.Id("divResult")).Text.Trim().Equals(string.Empty));
        }

        [TestMethod]
        public void Test_Scenario_9()
        {
            // Act
            StringBuilder stringCommands = new StringBuilder();
            stringCommands.AppendLine("PLACE 0, 0,SOUTH");
            stringCommands.AppendLine("MOVE");
            stringCommands.AppendLine("REPORT");


            this.FirefoxDriver.Navigate().GoToUrl(this.GetAbsoluteUrl("/"));
            this.FirefoxDriver.FindElement(By.Id("Input")).Clear();
            this.FirefoxDriver.FindElement(By.Id("Input")).SendKeys(stringCommands.ToString());
            this.FirefoxDriver.FindElement(By.Id("btnExecute")).Click();

            // Assert
            string test = this.FirefoxDriver.FindElement(By.Id("divResult")).Text.Trim();
            Assert.IsTrue(this.FirefoxDriver.FindElement(By.Id("divResult")).Text.Trim().Equals("0,0,SOUTH"));
        }


        [TestMethod]
        public void Test_Scenario_10()
        {
            // Act
            StringBuilder stringCommands = new StringBuilder();
            stringCommands.AppendLine("PLACE 4,4,NORTH");
            stringCommands.AppendLine("MOVE");
            stringCommands.AppendLine("REPORT");
            stringCommands.AppendLine("RIGHT");
            stringCommands.AppendLine("MOVE");
            stringCommands.AppendLine("REPORT");


            this.FirefoxDriver.Navigate().GoToUrl(this.GetAbsoluteUrl("/"));
            this.FirefoxDriver.FindElement(By.Id("Input")).Clear();
            this.FirefoxDriver.FindElement(By.Id("Input")).SendKeys(stringCommands.ToString());
            this.FirefoxDriver.FindElement(By.Id("btnExecute")).Click();

            // Assert
            Assert.IsTrue(this.FirefoxDriver.FindElement(By.Id("divResult")).Text.Trim().Equals("4,4,NORTH 4,4,EAST"));
        }
    }
}
