using System.Collections.Generic;
using System.IO;
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
    [SafetyNet(typeof(ExpenseViewer))]
    [Isolated()]
    [TestFixture()]
    public class ExpenseViewerTests
    {
        #region Unit Tests for LoadExpenseItems
        
        [Test]
        public void LoadExpenseItems_Test_ReturnsFalse()
        {
            // arrange
            var expenseViewer = new ExpenseViewer();
            var propertyChangedWasRaised = false;
            expenseViewer.PropertyChanged += (a, b) => propertyChangedWasRaised = true;
            var expenseData = new ExpenseData();
            var propertyChangedWasRaised1 = false;
            expenseData.PropertyChanged += (a, b) => propertyChangedWasRaised1 = true;
            var items = expenseData.Items;
            expenseData.Items = items;
            expenseViewer.ExpenseTable = expenseData;
            var propertyChangedWasRaised2 = false;
            expenseViewer.PropertyChanged += (a, b) => propertyChangedWasRaised2 = true;
            var propertyChangedWasRaised3 = false;
            expenseViewer.PropertyChanged += (a, b) => propertyChangedWasRaised3 = true;
            var fileLoader = new TxtFileLoadSave();
            Isolate.WhenCalled(() => File.Exists(null)).WillReturn(true);
            var expenseItem = new ExpenseItem();
            var expenseItemList = new List<ExpenseItem> {expenseItem};
            Isolate.WhenCalled(() => fileLoader.LoadFromFile(null)).WillReturn(expenseItemList);
             
            // act
            var result = expenseViewer.LoadExpenseItems(fileLoader, "Unable to load any data");
             
            // assert
            Assert.AreEqual(false, result);
        }

        #endregion

        #region Unit Tests for NotifyPropertyChanged
        
        [Test]
        public void NotifyPropertyChanged_Test_NoAsserts()
        {
            // arrange
            var expenseViewer = new ExpenseViewer();
             
            // act
            expenseViewer.NotifyPropertyChanged("name");
        }

        #endregion

        #region Unit Tests for set_AmountAdd
        
        [Test]
        public void set_AmountAdd_Test_ReturnsAmountAddIsAmountAdd()
        {
            // arrange
            var expenseViewer = new ExpenseViewer();
            var propertyChangedWasRaised = false;
            expenseViewer.PropertyChanged += (a, b) => propertyChangedWasRaised = true;
             
            // act
            expenseViewer.AmountAdd = "AmountAdd";
             
            // assert
            // side affects on expenseViewer
            Assert.AreEqual("AmountAdd", expenseViewer.AmountAdd);
            // side affects on propertyChangedWasRaised
            Assert.AreEqual(true, propertyChangedWasRaised);
        }

        #endregion
        #region Unit Tests for set_SelectedExpenseItem
        
        [Test]
        public void set_SelectedExpenseItem_Test_ReturnsSelectedExpenseItemIsValue()
        {
            // arrange
            var expenseViewer = new ExpenseViewer();
            var propertyChangedWasRaised = false;
            expenseViewer.PropertyChanged += (a, b) => propertyChangedWasRaised = true;
            var value = new ExpenseItem();
            var propertyChangedWasRaised1 = false;
            value.PropertyChanged += (a, b) => propertyChangedWasRaised1 = true;
            var propertyChangedWasRaised2 = false;
            value.PropertyChanged += (a, b) => propertyChangedWasRaised2 = true;
             
            // act
            expenseViewer.SelectedExpenseItem = value;
             
            // assert
            // side affects on expenseViewer
            Assert.AreSame(value, expenseViewer.SelectedExpenseItem);
            Assert.AreEqual(true, expenseViewer.IsSelected);
            // side affects on propertyChangedWasRaised
            Assert.AreEqual(true, propertyChangedWasRaised);
        }

        #endregion

        #region Unit Tests for set_TagAdd
        
        [Test]
        public void set_TagAdd_Test_ReturnsTagAddIsTagAdd()
        {
            // arrange
            var expenseViewer = new ExpenseViewer();
            var propertyChangedWasRaised = false;
            expenseViewer.PropertyChanged += (a, b) => propertyChangedWasRaised = true;
             
            // act
            expenseViewer.TagAdd = "TagAdd";
             
            // assert
            // side affects on expenseViewer
            Assert.AreEqual("TagAdd", expenseViewer.TagAdd);
            // side affects on propertyChangedWasRaised
            Assert.AreEqual(true, propertyChangedWasRaised);
        }

        #endregion
        #region Unit Tests for UpdateSelectedItem
        
        [Test]
        public void UpdateSelectedItem_Test_ReturnsAmountIs01()
        {
            // arrange
            var expenseViewer = new ExpenseViewer();
            var expenseItem = new ExpenseItem();
            expenseViewer.SelectedExpenseItem = expenseItem;
            var propertyChangedWasRaised = false;
            expenseViewer.PropertyChanged += (a, b) => propertyChangedWasRaised = true;
             
            // act
            expenseViewer.UpdateSelectedItem(0.1, "tag");
             
            // assert
            // side affects on expenseViewer
            Assert.AreEqual(0.1, expenseViewer.SelectedExpenseItem.Amount, 0.01);
            Assert.AreEqual("tag", expenseViewer.SelectedExpenseItem.Tag);
            Assert.AreEqual("<Item><ID>0</ID><Date></Date><Amount>0.1</Amount><Tag>tag</Tag></Item>", expenseViewer.SelectedExpenseItem.ToXMLString());
            // side affects on propertyChangedWasRaised
            Assert.AreEqual(true, propertyChangedWasRaised);
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