using NSubstitute;
using PleaseBehave;
using PleaseBehave.Decorators;
using Xunit;

namespace PleaseBehaveTests.DecoratorTests
{
    public class RepeaterTests
    {
        [Fact]
        public void RepeaterUpdateSuccessSuccessSuccessTest()
        {
            // Arrange
            const uint repetitions = 5;
            var childUpdateCalls = 0;
            
            var node1 = Substitute.For<Node>();

            node1.Update().ReturnsForAnyArgs(x =>
            {
                childUpdateCalls++;
                return NodeStatus.Success;
            });

            var repeater = new Repeater(repetitions)
            {
                Child = node1
            };

            // Act
            var result = repeater.Update();

            // Assert
            Assert.Equal(NodeStatus.Success, result);
            Assert.Equal(repetitions, (uint) childUpdateCalls);
        }

        [Fact]
        public void RepeaterUpdateFailureFailureFailureTest()
        {
            // Arrange
            const uint repetitions = 5;
            var childUpdateCalls = 0;

            var node1 = Substitute.For<Node>();

            node1.Update().ReturnsForAnyArgs(x =>
            {
                childUpdateCalls++;
                return NodeStatus.Failure;
            });

            var repeater = new Repeater(repetitions)
            {
                Child = node1
            };

            // Act
            var result = repeater.Update();

            // Assert
            Assert.Equal(NodeStatus.Failure, result);
            Assert.Equal(repetitions, (uint) childUpdateCalls);
        }
    }
}
