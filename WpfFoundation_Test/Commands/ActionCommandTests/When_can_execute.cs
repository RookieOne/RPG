using NUnit.Framework;

namespace WpfFoundation_Test.Commands.ActionCommandTests
{
    [TestFixture]
    public class When_can_execute : NewActionCommand
    {
        private bool _result;

        public override void OnWhen()
        {
            base.OnWhen();

            _result = _command.CanExecute(null);
        }

        [Test]
        public void should_return_true()
        {
            When();
            Assert.IsTrue(_result);
        }
    }
}