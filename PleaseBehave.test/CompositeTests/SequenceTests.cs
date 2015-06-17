using System.Collections.ObjectModel;
using NSubstitute;
using PleaseBehave;
using PleaseBehave.Composites;
using Xunit;

namespace PleaseBehaveTests.CompositeTests
{
    public class SequenceTests
    {
        
        [Fact]
        public void SequenceUpdateSuccessSuccessSuccessTest()
        {
            // Arrange
            var node1 = Substitute.For<Node>();
            var node2 = Substitute.For<Node>();
            var node3 = Substitute.For<Node>();

            node1.Update().Returns(NodeStatus.Success);
            node2.Update().Returns(NodeStatus.Success);
            node3.Update().Returns(NodeStatus.Success);

            var sequence = new Sequence
            {
                Children = new Collection<Node>
                {
                    node1,
                    node2,
                    node3,
                }
            };

            // Act
            var result = sequence.Update();

            // Assert
            Assert.Equal(NodeStatus.Success, result);
            Assert.Equal(0, sequence.Currentchild);
        }

        [Fact]
        public void SequenceUpdateFailureSuccessSuccessTest()
        {
            // Arrange
            var node1 = Substitute.For<Node>();
            var node2 = Substitute.For<Node>();
            var node3 = Substitute.For<Node>();

            node1.Update().Returns(NodeStatus.Failure);
            node2.Update().Returns(NodeStatus.Success);
            node3.Update().Returns(NodeStatus.Success);

            var sequence = new Sequence
            {
                Children = new Collection<Node>
                {
                    node1,
                    node2,
                    node3
                }
            };

            // Act
            var result = sequence.Update();

            // Assert
            Assert.Equal(NodeStatus.Failure, result);
            Assert.Equal(0, sequence.Currentchild);
        }

        [Fact]
        public void SequenceUpdateSuccessFailureSuccessTest()
        {
            // Arrange
            var node1 = Substitute.For<Node>();
            var node2 = Substitute.For<Node>();
            var node3 = Substitute.For<Node>();

            node1.Update().Returns(NodeStatus.Success);
            node2.Update().Returns(NodeStatus.Failure);
            node3.Update().Returns(NodeStatus.Success);

            var sequence = new Sequence
            {
                Children = new Collection<Node>
                {
                    node1,
                    node2,
                    node3
                }
            };

            // Act
            var result = sequence.Update();

            // Assert
            Assert.Equal(NodeStatus.Failure, result);
            Assert.Equal(0, sequence.Currentchild);
        }

        [Fact]
        public void SequenceUpdateSuccessSuccessFailureTest()
        {
            // Arrange
            var node1 = Substitute.For<Node>();
            var node2 = Substitute.For<Node>();
            var node3 = Substitute.For<Node>();

            node1.Update().Returns(NodeStatus.Success);
            node2.Update().Returns(NodeStatus.Success);
            node3.Update().Returns(NodeStatus.Failure);

            var sequence = new Sequence
            {
                Children = new Collection<Node>
                {
                    node1,
                    node2,
                    node3
                }
            };

            // Act
            var result = sequence.Update();

            // Assert
            Assert.Equal(NodeStatus.Failure, result);
            Assert.Equal(0, sequence.Currentchild);
        }
    }
}
