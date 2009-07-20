using NUnit.Framework;

namespace WpfFoundation_Test.Commands.ActionCommandTests
{
    [TestFixture]
    public class When_executed : NewActionCommand
    {
        public override void OnWhen()
        {
            base.OnWhen();

            _command.Execute(null);
        }

        [Test]
        public void should_return_true()
        {
            When();
            Assert.IsTrue(_commandExecuted);
        }
    }
}