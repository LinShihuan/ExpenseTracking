using System;
using System.IO;
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
    [SafetyNet(typeof(TxtFileLoadSave))]
    [Isolated()]
    [TestFixture()]
    public class TxtFileLoadSaveTests
    {
        #region Unit Tests for LoadFromFile
        
        [Test]
        public void LoadFromFile_Test_ReturnsCountIs0()
        {
            // arrange
            var txtFileLoadSave = new TxtFileLoadSave();
            Isolate.WhenCalled(() => File.Exists(null)).WillReturn(true);
            var stringList = new string[] {};
            Isolate.WhenCalled(() => File.ReadAllLines(null)).WillReturn(stringList);
             
            // act
            var result = txtFileLoadSave.LoadFromFile("fileName");
             
            // assert
            Assert.AreEqual(0, result.Count);
        }

        
        [Test]
        [ExpectedException(typeof(Exception))]
        public void LoadFromFile_Test_ThrowsException()
        {
            // arrange
            var txtFileLoadSave = new TxtFileLoadSave();
             
            // act
            var result = txtFileLoadSave.LoadFromFile("fileName");
        }

        #endregion

        #region Unit Tests for SaveToFile
        
        [Test]
        public void SaveToFile_Test_ReturnsTrue()
        {
            // arrange
            var txtFileLoadSave = new TxtFileLoadSave();
            var expenseItem = new ExpenseItem(1, "dateString", 0.1, "tag");
            var items = new List<ExpenseItem> {expenseItem};
            Isolate.WhenCalled(() => File.WriteAllLines(null, (IEnumerable<string>)null)).IgnoreCall();
             
            // act
            var result = txtFileLoadSave.SaveToFile("fileName", items);
             
            // assert
            Assert.AreEqual(true, result);
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