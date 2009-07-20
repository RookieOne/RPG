using FoundationTest.ContextSpecifications;
using WpfFoundation.Commands;

namespace WpfFoundation_Test.Commands.ActionCommandTests
{
    public class NewActionCommand : ContextSpecification
    {
        protected ActionCommand _command;
        protected bool _commandExecuted;

        public override void Given()
        {
            base.Given();

            _commandExecuted = false;
            _command = new ActionCommand(() => _commandExecuted = true);
        }
    }
}