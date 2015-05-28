using PleaseBehave;
using PleaseBehave.Leafs;
using Xunit;

namespace PleaseBehaveTests.LeafTests
{
    public class ActionTests
    {
        private bool _falseTrue;

        [Fact]
        public void OneTickActionTest()
        {
            // Arrange
            var action = new Act(() => true);

            // Act
            var result = action.Update();

            // Assert
            Assert.Equal(NodeStatus.Success, result);
        }

        [Fact]
        public void TwoTickActionTest()
        {
            // Arrange
            var action = new Act(ReturnFalseThenTrue);

            // Act
            var result1 = action.Update();
            var result2 = action.Update();
            _falseTrue = false;

            // Assert
            Assert.Equal(NodeStatus.Running, result1);
            Assert.Equal(NodeStatus.Success, result2);
        }

        private bool ReturnFalseThenTrue()
        {
            _falseTrue = !_falseTrue;
            return !_falseTrue;
        }
    }
}
