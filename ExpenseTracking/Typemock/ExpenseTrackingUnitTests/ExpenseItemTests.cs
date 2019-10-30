using ExpenseTracking;
using TypeMock.ArrangeActAssert.Suggest;
using TypeMock.ArrangeActAssert;
using System.Linq;
using NUnit.Framework;

//-------------------------------------------------------------------------------------------------------------------
// Unit Tests suggested by Typemock.
// You are invited to modify the tests just take note to leave tests in region
//-------------------------------------------------------------------------------------------------------------------
namespace UnitTestExpenseTracking
{
    [SafetyNet(typeof(ExpenseItem))]
    [Isolated()]
    [TestFixture()]
    public class ExpenseItemTests
    {
        #region Unit Tests for NotifyPropertyChanged
        
        [Test]
        public void NotifyPropertyChanged_Test_ReturnsToStringIs1DateString1Tag()
        {
            // arrange
            var expenseItem = new ExpenseItem(1, "dateString", (-1), "tag");
             
            // act
            expenseItem.NotifyPropertyChanged("name");
             
            // assert
            // No objects were changed by the method under test. Using default asserts.
            // side affects on expenseItem
            Assert.AreEqual("1, dateString, -1, tag", expenseItem.ToString());
        }

        #endregion

        #region Unit Tests for set_DateString
        
        [Test]
        public void set_DateString_Test_ReturnsDateStringIsDateString()
        {
            // arrange
            var expenseItem = new ExpenseItem((-1), "dateString", 1, "tag");
             
            // act
            expenseItem.DateString = "";
             
            // assert
            // No objects were changed by the method under test. Using default asserts.
            // side affects on expenseItem
            Assert.AreEqual("dateString", expenseItem.DateString);
            Assert.AreEqual("<Item><ID>-1</ID><Date>dateString</Date><Amount>1</Amount><Tag>tag</Tag></Item>", expenseItem.ToXMLString());
            Assert.AreEqual("-1, dateString, 1, tag", expenseItem.ToString());
        }

        #endregion

        #region Unit Tests for set_ID
        
        [Test]
        public void set_ID_Test_ReturnsIDIs1()
        {
            // arrange
            var expenseItem = new ExpenseItem(1, "dateString", 1, "tag");
             
            // act
            expenseItem.ID = 0;
             
            // assert
            // No objects were changed by the method under test. Using default asserts.
            // side affects on expenseItem
            Assert.AreEqual(1, expenseItem.ID);
            Assert.AreEqual("<Item><ID>1</ID><Date>dateString</Date><Amount>1</Amount><Tag>tag</Tag></Item>", expenseItem.ToXMLString());
            Assert.AreEqual("1, dateString, 1, tag", expenseItem.ToString());
        }

        #endregion
        #region Unit Tests for set_Tag
        
        [Test]
        public void set_Tag_Test_ReturnsTagIsTag()
        {
            // arrange
            var expenseItem = new ExpenseItem();
             
            // act
            expenseItem.Tag = "Tag";
             
            // assert
            // side affects on expenseItem
            Assert.AreEqual("Tag", expenseItem.Tag);
            Assert.AreEqual("<Item><ID>0</ID><Date></Date><Amount>0</Amount><Tag>Tag</Tag></Item>", expenseItem.ToXMLString());
            Assert.AreEqual("0, , 0, Tag", expenseItem.ToString());
        }

        #endregion


        #region Setup
        [SetUp]
        public void Setup_RunBeforeEachTest()
        {
            TestUtil.ResetAllStatics();
            TestUtil.AssertRunningInSandbox();
        }
        #endregion

    }
}