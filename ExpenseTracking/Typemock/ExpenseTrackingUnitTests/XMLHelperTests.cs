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
    [SafetyNet(typeof(XMLHelper))]
    [Isolated()]
    [TestFixture()]
    public class XMLHelperTests
    {
        #region Unit Tests for AddNode
        
        [Test]
        public void AddNode_Test_ReturnsEmptyString()
        {
            // act
            var result = XMLHelper.AddNode(null, "value");
             
            // assert
            Assert.AreEqual("", result);
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