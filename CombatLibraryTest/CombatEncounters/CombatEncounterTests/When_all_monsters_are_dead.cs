using System.Collections.Generic;
using CombatLibrary.CombatMembers;
using CombatLibraryTest.CombatEncounters.Contexts;
using NUnit.Framework;

namespace CombatLibraryTest.CombatEncounters.CombatEncounterTests
{
    [TestFixture]
    public class When_all_monsters_are_dead : NewCombatEncounter
    {
        private bool _result;

        public override void Given()
        {
            base.Given();

            var monsters = new List<IMonsterCombatMember>
                               {
                                   new MonsterCombatMember(0, "monster")
                               };

            _combatEncounter.AddMonsters(monsters);
        }

        public override void OnWhen()
        {
            base.OnWhen();

            _result = _combatEncounter.AllMonstersAreDead();
        }

        [Test]
        public void should_return_true()
        {
            When();
            Assert.IsTrue(_result);
        }
    }
}