using Microsoft.VisualStudio.TestTools.UnitTesting;
using PleaseBehave;
using PleaseBehave.Decorators;
using PleaseBehave.Fakes;

namespace PleaseBehaveTests.DecoratorTests
{
    [TestClass]
    public class RepeaterTests
    {
        [TestMethod]
        public void RepeaterUpdateSuccessSuccessSuccessTest()
        {
            // Arrange
            const uint repetitions = 5;
            var childUpdateCalls = 0;
            var repeater = new Repeater(repetitions)
            {
                Child = new StubNode
                {
                    Update01 = () =>
                    {
                        childUpdateCalls++;
                        return NodeStatus.Success;
                    }
                }
            };

            // Act
            var result = repeater.Update();

            // Assert
            Assert.AreEqual(NodeStatus.Success, result);
            Assert.AreEqual(repetitions, (uint) childUpdateCalls);
        }

        [TestMethod]
        public void RepeaterUpdateFailureFailureFailureTest()
        {
            // Arrange
            const uint repetitions = 5;
            var childUpdateCalls = 0;
            var repeater = new Repeater(repetitions)
            {
                Child = new StubNode
                {
                    Update01 = () =>
                    {
                        childUpdateCalls++;
                        return NodeStatus.Failure;
                    }
                }
            };

            // Act
            var result = repeater.Update();

            // Assert
            Assert.AreEqual(NodeStatus.Failure, result);
            Assert.AreEqual(repetitions, (uint) childUpdateCalls);
        }
    }
}
