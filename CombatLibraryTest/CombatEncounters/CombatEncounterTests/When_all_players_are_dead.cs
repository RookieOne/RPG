using System.Collections.Generic;
using CombatLibrary.CombatMembers;
using CombatLibraryTest.CombatEncounters.Contexts;
using NUnit.Framework;

namespace CombatLibraryTest.CombatEncounters.CombatEncounterTests
{
    [TestFixture]
    public class When_all_players_are_dead : NewCombatEncounter
    {
        private bool _result;

        public override void Given()
        {
            base.Given();

            var players = new List<IPlayerCombatMember>
                              {
                                  new PlayerCombatMember(0)
                              };

            _combatEncounter.SetPlayers(players);
        }

        public override void When()
        {
            base.When();

            _result = _combatEncounter.AllPlayersAreDead();
        }

        [Test]
        public void should_return_true()
        {
            Assert.IsTrue(_result);
        }
    }
}