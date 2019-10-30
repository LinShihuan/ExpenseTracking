using System.Collections.ObjectModel;
using System.Collections.Generic;
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
    [SafetyNet(typeof(ExpenseData))]
    [Isolated()]
    [TestFixture()]
    public class ExpenseDataTests
    {
        #region Unit Tests for AddOneItem
        
        [Test]
        public void AddOneItem_Test_ReturnsFalse()
        {
            // arrange
            var expenseData = new ExpenseData();
             
            // act
            var result = expenseData.AddOneItem((-1), "dateString", 1.2, "tag");
             
            // assert
            Assert.AreEqual(false, result);
        }

        
        [Test]
        public void AddOneItem_Test_ReturnsFalse_001()
        {
            // arrange
            var expenseData = new ExpenseData();
             
            // act
            var result = expenseData.AddOneItem(1, "dateString", 1.2, "tag");
             
            // assert
            Assert.AreEqual(false, result);
        }

        
        [Test]
        public void AddOneItem_Test_ReturnsFalse_002()
        {
            // arrange
            var expenseData = new ExpenseData();
             
            // act
            var result = expenseData.AddOneItem((-1), "dateString", 0, "tag");
             
            // assert
            Assert.AreEqual(false, result);
        }

        
        [Test]
        public void AddOneItem_Test_ReturnsFalse_003()
        {
            // arrange
            var expenseData = new ExpenseData();
             
            // act
            var result = expenseData.AddOneItem((-1), "dateString", 0, "tag");
             
            // assert
            Assert.AreEqual(false, result);
        }

        
        [Test]
        public void AddOneItem_Test_ReturnsTrue()
        {
            // arrange
            var expenseData = new ExpenseData();
            var expenseItem = new ExpenseItem();
            var expenseItem1 = new ExpenseItem(0, "dateString", 0.0, "tag");
            var expenseItemList = new List<ExpenseItem> {expenseItem1};
            expenseItemList = new List<ExpenseItem> {expenseItem1, expenseItem};
            var handleExpenseItem = Isolate.Fake.AllInstances<ExpenseItem>(Members.CallOriginal);
            Isolate.WhenCalled(() => handleExpenseItem.ID).WillReturn((-1));
            Isolate.WhenCalled(() => handleExpenseItem.Validate()).WillReturn(true);
            var boolean = expenseData.LoadFromList(expenseItemList);
             
            // act
            var result = expenseData.AddOneItem(0, "dateString", 0.1, "tag");
             
            // assert
            Assert.AreEqual(true, result);
            // side affects on expenseData
            Assert.AreEqual(2, expenseData.Items.Count);
            Assert.AreEqual("dateString", expenseData.Items[1].DateString);
            Assert.AreEqual(0.1, expenseData.Items[1].Amount, 0.01);
            Assert.AreEqual("tag", expenseData.Items[1].Tag);
            Assert.AreEqual("<Item><ID>0</ID><Date>dateString</Date><Amount>0.1</Amount><Tag>tag</Tag></Item>", expenseData.Items[1].ToXMLString());
            Assert.AreEqual("0,dateString,0.1,tag", expenseData.Items[1].ToTextString());
        }

        
        [Test]
        public void AddOneItem_Test_ReturnsFalse_004()
        {
            // arrange
            var expenseData = new ExpenseData();
            var expenseItem = new ExpenseItem(0, "dateString", 0.0, "tag");
            var expenseItem1 = new ExpenseItem(0, "dateString", 0.0, "tag");
            var expenseItem2 = new ExpenseItem();
            var expenseItemList = new ObservableCollection<ExpenseItem> {expenseItem, expenseItem1, expenseItem2};
            expenseData.Items = expenseItemList;
            var handleExpenseItem = Isolate.Fake.AllInstances<ExpenseItem>();
            Isolate.WhenCalled(() => handleExpenseItem.Validate()).WillReturn(true);
             
            // act
            var result = expenseData.AddOneItem(0, "dateString", 0.0, "tag");
             
            // assert
            Assert.AreEqual(false, result);
        }

        #endregion

        #region Unit Tests for ContainsID
        
        [Test]
        public void ContainsIDByCallingAddOneItem_Test_ReturnsTrue()
        {
            // arrange
            var expenseData = new ExpenseData();
             
            // act
            var result = expenseData.AddOneItem((-1), "06-06-2019", 2.2, "tag");
             
            // assert
            Assert.AreEqual(true, result);
            // side affects on expenseData
            Assert.AreEqual(2, expenseData.GetNextID());
            Assert.AreEqual(1, expenseData.Items.Count);
        }

        
        [Test]
        public void ContainsIDByCallingAddOneItem_Test_ReturnsFalse()
        {
            // arrange
            var expenseData = new ExpenseData();
             
            // act
            var result = expenseData.AddOneItem(1, "06-06-2019", 2.2, "tag");
             
            // assert
            Assert.AreEqual(true, result);
        }

        #endregion

        #region Unit Tests for GetNextID
        
        [Test]
        public void GetNextID_Test_Returns4()
        {
            // arrange
            var expenseData = new ExpenseData();
             
            // act
            var result = expenseData.GetNextID();
             
            // assert
            Assert.AreEqual(1, result);
        }

        #endregion

        #region Unit Tests for LoadFromList
        
        [Test]
        public void LoadFromList_Test_ReturnsTrue()
        {
            // arrange
            var expenseData = new ExpenseData();
            var expenseItem = new ExpenseItem((-1), "dateString", 0.1, "tag");
            var itemList = new List<ExpenseItem> {expenseItem};
            var handleExpenseItem = Isolate.Fake.AllInstances<ExpenseItem>(Members.CallOriginal);
            Isolate.WhenCalled(() => handleExpenseItem.Validate()).WillReturn(true);
             
            // act
            var result = expenseData.LoadFromList(itemList);
             
            // assert
            Assert.AreEqual(true, result);
            // side affects on expenseData
            Assert.AreEqual(1, expenseData.Items.Count);
        }

        
        [Test]
        public void LoadFromList_Test_ReturnsFalse()
        {
            // arrange
            var expenseData = new ExpenseData();
            var expenseItem = new ExpenseItem((-1), "dateString", 0.1, "tag");
            var itemList = new List<ExpenseItem> {expenseItem};
             
            // act
            var result = expenseData.LoadFromList(itemList);
             
            // assert
            Assert.AreEqual(false, result);
        }

        #endregion
        #region Unit Tests for NotifyPropertyChanged
        
        [Test]
        public void NotifyPropertyChanged_Test_NoAsserts()
        {
            // arrange
            var expenseData = new ExpenseData();
             
            // act
            expenseData.NotifyPropertyChanged("name");
        }

        #endregion

        #region Unit Tests for RemoveItemAt
        
        [Test]
        public void RemoveItemAt_Test_ReturnsTrue()
        {
            // arrange
            var expenseData = new ExpenseData();
             
            // act
            var result = expenseData.RemoveItemAt(0);
             
            // assert
            Assert.AreEqual(false, result);
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