using CombatLibrary.Events;
using CombatLibrary.Messages;
using CombatLibraryTest.CombatEncounters.Contexts;
using Foundation.Messaging;
using NUnit.Framework;

namespace CombatLibraryTest.CombatEncounters.CombatEncounterServiceTests
{
    [TestFixture]
    public class When_recieving_start_combat_message : CreatedCombatEncounterService
    {
        public override void When()
        {
            base.When();

            var message = new StartCombatMessage(null, null);
            MessageBroker.Send(message);
        }

        [Test]
        public void should_recieve_combat_started_event()
        {
            Assert.AreEqual(1, _eventAggregator.GetPublicationCount<CombatStartedEvent>());
        }
    }
}