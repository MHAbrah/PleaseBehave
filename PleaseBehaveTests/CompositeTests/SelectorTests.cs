using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PleaseBehave;
using PleaseBehave.Composites;
using PleaseBehave.Fakes;

namespace PleaseBehaveTests.CompositeTests
{
    [TestClass]
    public class SelectorTests
    {
        [TestMethod]
        public void SelectorUpdateSuccessSuccessSuccessTest()
        {
            // Arrange
            var selector = new Selector
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
            var result = selector.Update();

            // Assert
            Assert.AreEqual(NodeStatus.Success, result);
            Assert.AreEqual(0, selector.Currentchild);
        }

        [TestMethod]
        public void SelectorUpdateSuccessFailureSuccessTest()
        {
            // Arrange
            var selector = new Selector
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
            var result = selector.Update();

            // Assert
            Assert.AreEqual(NodeStatus.Success, result);
            Assert.AreEqual(0, selector.Currentchild);
        }

        [TestMethod]
        public void SelectorUpdateSuccessSuccessFailureTest()
        {
            // Arrange
            var selector = new Selector
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
            var result = selector.Update();

            // Assert
            Assert.AreEqual(NodeStatus.Success, result);
            Assert.AreEqual(0, selector.Currentchild);
        }

        [TestMethod]
        public void SelectorUpdateFailureFailureFailureTest()
        {
            // Arrange
            var selector = new Selector
            {
                Children = new Collection<Node>
                {
                    new StubNode
                    {
                        Update01 = () => NodeStatus.Failure
                    },
                    new StubNode
                    {
                        Update01 = () => NodeStatus.Failure
                    },
                    new StubNode
                    {
                        Update01 = () => NodeStatus.Failure
                    },
                }
            };

            // Act
            var result = selector.Update();

            // Assert
            Assert.AreEqual(NodeStatus.Failure, result);
            Assert.AreEqual(0, selector.Currentchild);
        }
    }
}
