using Microsoft.VisualStudio.TestTools.UnitTesting;
using PleaseBehave;
using PleaseBehave.Decorators;
using PleaseBehave.Fakes;

namespace PleaseBehaveTests.DecoratorTests
{
    [TestClass]
    public class SucceederTests
    {
        [TestMethod]
        public void SucceederUpdateSTest()
        {
            // Arrange
            var succeeder = new Succeeder
            {
                Child = new StubNode
                {
                    Update01 = () => NodeStatus.Success
                }
            };

            // Act
            var result = succeeder.Update();

            // Assert
            Assert.AreEqual(NodeStatus.Success, result);
        }

        [TestMethod]
        public void SucceederUpdateFTest()
        {
            // Arrange
            var succeeder = new Succeeder
            {
                Child = new StubNode
                {
                    Update01 = () => NodeStatus.Failure
                }
            };

            // Act
            var result = succeeder.Update();

            // Assert
            Assert.AreEqual(NodeStatus.Success, result);
        }

        [TestMethod]
        public void SucceederUpdateRunningSuccessTest()
        {
            // Arrange
            var child1 = new StubNode
            {
                Update01 = () => NodeStatus.Running
            };

            var child2 = new StubNode
            {
                Update01 = () => NodeStatus.Success
            };

            var succeeder = new Succeeder
            {
                Child = child1
            };

            // Act
            var result1 = succeeder.Update();
            succeeder.Child = child2;
            var result2 = succeeder.Update();
           

            // Assert
            Assert.AreEqual(NodeStatus.Running, result1);
            Assert.AreEqual(NodeStatus.Success, result2);
        }
    }
}
