using Microsoft.VisualStudio.TestTools.UnitTesting;
using PleaseBehave;
using PleaseBehave.Leafs;

namespace PleaseBehaveTests.LeafTests
{
    [TestClass]
    public class ActionTests
    {
        private bool _falseTrue;

        [TestMethod]
        public void OneTickActionTest()
        {
            // Arrange
            var action = new Act(() => true);

            // Act
            var result = action.Update();

            // Assert
            Assert.AreEqual(NodeStatus.Success, result);
        }

        [TestMethod]
        public void TwoTickActionTest()
        {
            // Arrange
            var action = new Act(ReturnFalseThenTrue);

            // Act
            var result1 = action.Update();
            var result2 = action.Update();
            _falseTrue = false;

            // Assert
            Assert.AreEqual(NodeStatus.Running, result1);
            Assert.AreEqual(NodeStatus.Success, result2);
        }

        private bool ReturnFalseThenTrue()
        {
            _falseTrue = !_falseTrue;
            return !_falseTrue;
        }
    }
}
