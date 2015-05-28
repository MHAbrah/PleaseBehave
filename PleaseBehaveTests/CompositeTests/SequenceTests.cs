using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PleaseBehave;
using PleaseBehave.Composites;
using PleaseBehave.Fakes;

namespace PleaseBehaveTests.CompositeTests
{
    [TestClass]
    public class SequenceTests
    {
        
        [TestMethod]
        public void SequenceUpdateSuccessSuccessSuccessTest()
        {
            // Arrange
            var sequence = new Sequence
            {
                Children = new Collection<Node>
                {
                    new StubNode
                    {
                        Update01 = () => NodeStatus.Success
                    },
                    new StubNode
                    {
                        Update01 = () => NodeStatus.Success
                    },
                    new StubNode
                    {
                        Update01 = () => NodeStatus.Success
                    },
                }
            };

            // Act
            var result = sequence.Update();

            // Assert
            Assert.AreEqual(NodeStatus.Success, result);
            Assert.AreEqual(0, sequence.Currentchild);
        }

        [TestMethod]
        public void SequenceUpdateFailureSuccessSuccessTest()
        {
            // Arrange
            var sequence = new Sequence
            {
                Children = new Collection<Node>
                {
                    new StubNode
                    {
                        Update01 = () => NodeStatus.Failure
                    },
                    new StubNode
                    {
                        Update01 = () => NodeStatus.Success
                    },
                    new StubNode
                    {
                        Update01 = () => NodeStatus.Success
                    },
                }
            };

            // Act
            var result = sequence.Update();

            // Assert
            Assert.AreEqual(NodeStatus.Failure, result);
            Assert.AreEqual(0, sequence.Currentchild);
        }

        [TestMethod]
        public void SequenceUpdateSuccessFailureSuccessTest()
        {
            // Arrange
            var sequence = new Sequence
            {
                Children = new Collection<Node>
                {
                    new StubNode
                    {
                        Update01 = () => NodeStatus.Success
                    },
                    new StubNode
                    {
                        Update01 = () => NodeStatus.Failure
                    },
                    new StubNode
                    {
                        Update01 = () => NodeStatus.Success
                    },
                }
            };

            // Act
            var result = sequence.Update();

            // Assert
            Assert.AreEqual(NodeStatus.Failure, result);
            Assert.AreEqual(0, sequence.Currentchild);
        }

        [TestMethod]
        public void SequenceUpdateSuccessSuccessFailureTest()
        {
            // Arrange
            var sequence = new Sequence
            {
                Children = new Collection<Node>
                {
                    new StubNode
                    {
                        Update01 = () => NodeStatus.Success
                    },
                    new StubNode
                    {
                        Update01 = () => NodeStatus.Success
                    },
                    new StubNode
                    {
                        Update01 = () => NodeStatus.Failure
                    },
                }
            };

            // Act
            var result = sequence.Update();

            // Assert
            Assert.AreEqual(NodeStatus.Failure, result);
            Assert.AreEqual(0, sequence.Currentchild);
        }
    }
}
