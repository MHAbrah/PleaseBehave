using System.Collections.ObjectModel;
using NSubstitute;
using PleaseBehave;
using PleaseBehave.Composites;
using Xunit;

namespace PleaseBehaveTests.CompositeTests
{
    public class SelectorTests
    {
        [Fact]
        public void SelectorUpdateSuccessSuccessSuccessTest()
        {
            // Arrange
            var successNode1 = Substitute.For<Node>();
            var successNode2 = Substitute.For<Node>();
            var successNode3 = Substitute.For<Node>();

            successNode1.Update().Returns(NodeStatus.Success);
            successNode2.Update().Returns(NodeStatus.Success);
            successNode3.Update().Returns(NodeStatus.Success);

            var selector = new Selector
            {
                Children = new Collection<Node>
                {
                    successNode1,
                    successNode2,
                    successNode3
                }
            };

            // Act
            var result = selector.Update();

            // Assert
            Assert.Equal(NodeStatus.Success, result);
            Assert.Equal(0, selector.Currentchild);
        }

        [Fact]
        public void SelectorUpdateSuccessFailureSuccessTest()
        {
            // Arrange
            var node1 = Substitute.For<Node>();
            var node2 = Substitute.For<Node>();
            var node3 = Substitute.For<Node>();

            node1.Update().Returns(NodeStatus.Success);
            node2.Update().Returns(NodeStatus.Failure);
            node3.Update().Returns(NodeStatus.Success);
            
            var selector = new Selector
            {
                Children = new Collection<Node>
                {
                    node1,
                    node2,
                    node3
                }
            };

            // Act
            var result = selector.Update();

            // Assert
            Assert.Equal(NodeStatus.Success, result);
            Assert.Equal(0, selector.Currentchild);
        }

        [Fact]
        public void SelectorUpdateSuccessSuccessFailureTest()
        {
            // Arrange
            var node1 = Substitute.For<Node>();
            var node2 = Substitute.For<Node>();
            var node3 = Substitute.For<Node>();

            node1.Update().Returns(NodeStatus.Success);
            node2.Update().Returns(NodeStatus.Success);
            node3.Update().Returns(NodeStatus.Failure);

            var selector = new Selector
            {
                Children = new Collection<Node>
                {
                    node1,
                    node2,
                    node3
                }
            };

            // Act
            var result = selector.Update();

            // Assert
            Assert.Equal(NodeStatus.Success, result);
            Assert.Equal(0, selector.Currentchild);
        }

        [Fact]
        public void SelectorUpdateFailureFailureFailureTest()
        {
            // Arrange
            var node1 = Substitute.For<Node>();
            var node2 = Substitute.For<Node>();
            var node3 = Substitute.For<Node>();

            node1.Update().Returns(NodeStatus.Failure);
            node2.Update().Returns(NodeStatus.Failure);
            node3.Update().Returns(NodeStatus.Failure);

            var selector = new Selector
            {
                Children = new Collection<Node>
                {
                    node1,
                    node2,
                    node3
                }
            };

            // Act
            var result = selector.Update();

            // Assert
            Assert.Equal(NodeStatus.Failure, result);
            Assert.Equal(0, selector.Currentchild);
        }
    }
}
