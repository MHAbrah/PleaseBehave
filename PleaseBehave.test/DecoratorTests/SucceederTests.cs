using NSubstitute;
using PleaseBehave;
using PleaseBehave.Decorators;
using Xunit;

namespace PleaseBehaveTests.DecoratorTests
{
    public class SucceederTests
    {
        [Fact]
        public void SucceederUpdateSTest()
        {
            // Arrange
            var node1 = Substitute.For<Node>();
            node1.Update().Returns(NodeStatus.Success);

            var succeeder = new Succeeder
            {
                Child = node1
            };

            // Act
            var result = succeeder.Update();

            // Assert
            Assert.Equal(NodeStatus.Success, result);
        }

        [Fact]
        public void SucceederUpdateFTest()
        {
            // Arrange
            var node1 = Substitute.For<Node>();
            node1.Update().Returns(NodeStatus.Success);
            var succeeder = new Succeeder
            {
                Child = node1
            };

            // Act
            var result = succeeder.Update();

            // Assert
            Assert.Equal(NodeStatus.Success, result);
        }

        [Fact]
        public void SucceederUpdateRunningSuccessTest()
        {
            // Arrange
            var node1 = Substitute.For<Node>();
            node1.Update().Returns(NodeStatus.Running);
            var node2 = Substitute.For<Node>();
            node2.Update().Returns(NodeStatus.Success);

            var succeeder = new Succeeder
            {
                Child = node1
            };

            // Act
            var result1 = succeeder.Update();
            succeeder.Child = node2;
            var result2 = succeeder.Update();

            // Assert
            Assert.Equal(NodeStatus.Running, result1);
            Assert.Equal(NodeStatus.Success, result2);
        }
    }
}
