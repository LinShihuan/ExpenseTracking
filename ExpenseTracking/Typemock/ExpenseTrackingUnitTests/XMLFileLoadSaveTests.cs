using System.Configuration;
using System;
using System.Xml;
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
    [SafetyNet(typeof(XMLFileLoadSave))]
    [Isolated()]
    [TestFixture()]
    public class XMLFileLoadSaveTests
    {
        #region Unit Tests for LoadFromFile
        
        [Test]
        [ExpectedException(typeof(Exception))]
        public void LoadFromFile_Test_ThrowsException()
        {
            // arrange
            var xmlfileLoadSave = new XMLFileLoadSave();
             
            // act
            var result = xmlfileLoadSave.LoadFromFile("fileName");
        }

        
        [Test]
        [ExpectedException(typeof(ConfigurationErrorsException))]
        public void LoadFromFile_Test_ThrowsConfigurationErrorsException()
        {
            // arrange
            var xmlfileLoadSave = new XMLFileLoadSave();
            Isolate.WhenCalled(() => File.Exists(null)).WillReturn(true);
            var handleXmlTextReader = Isolate.Fake.AllInstances<XmlTextReader>(Members.CallOriginal);
            Isolate.WhenCalled(() => handleXmlTextReader.NodeType).WillReturn(XmlNodeType.EndElement);
            Isolate.WhenCalled(() => handleXmlTextReader.Name).WillReturn("Name");
            var handleXmlUrlResolver = Isolate.Fake.AllInstances<XmlUrlResolver>(Members.CallOriginal);
            var uri = new Uri("http://www.example.com/page.html?query=1324&nbsp;o=qwer");
            Isolate.WhenCalled(() => handleXmlUrlResolver.ResolveUri(null, null)).WillReturn(uri);
             
            // act
            var result = xmlfileLoadSave.LoadFromFile("fileName");
        }

        #endregion
        #region Unit Tests for SaveToFile
        
        [Test]
        public void SaveToFile_Test_ReturnsTrue()
        {
            // arrange
            var xmlfileLoadSave = new XMLFileLoadSave();
            var expenseItem = new ExpenseItem();
            var items = new List<ExpenseItem> {expenseItem};
            Isolate.WhenCalled(() => File.WriteAllLines(null, (IEnumerable<string>)null)).IgnoreCall();
             
            // act
            var result = xmlfileLoadSave.SaveToFile("fileName", items);
             
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