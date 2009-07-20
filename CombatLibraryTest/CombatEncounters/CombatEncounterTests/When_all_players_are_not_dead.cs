using System.Collections.Generic;
using CombatLibrary.CombatMembers;
using CombatLibraryTest.CombatEncounters.Contexts;
using NUnit.Framework;

namespace CombatLibraryTest.CombatEncounters.CombatEncounterTests
{
    [TestFixture]
    public class When_all_players_are_not_dead : NewCombatEncounter
    {
        private bool _result;

        public override void Given()
        {
            base.Given();

            var players = new List<IPlayerCombatMember>
                              {
                                  new PlayerCombatMember(10, "player")
                              };

            _combatEncounter.SetPlayers(players);
        }

        public override void OnWhen()
        {
            base.OnWhen();

            _result = _combatEncounter.AllPlayersAreDead();
        }

        [Test]
        public void should_return_false()
        {
            When();
            Assert.IsFalse(_result);
        }
    }
}