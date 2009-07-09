using System.Collections.Generic;
using CombatLibrary.CombatMembers;
using CombatLibraryTest.CombatEncounters.Contexts;
using NUnit.Framework;

namespace CombatLibraryTest.CombatEncounters.CombatEncounterTests
{
    [TestFixture]
    public class When_adding_monsters : NewCombatEncounter
    {
        private MonsterCombatMember _monster;

        public override void When()
        {
            base.When();

            _monster = new MonsterCombatMember();

            var monsters = new List<IMonsterCombatMember>
                               {
                                   _monster
                               };

            _combatEncounter.AddMonsters(monsters);
        }

        [Test]
        public void should_add_monster_to_list()
        {
            Assert.AreEqual(_monster, _combatEncounter._monsters[0]);
        }

        [Test]
        public void should_have_one_monster_in_list()
        {
            Assert.AreEqual(1, _combatEncounter._monsters.Count);
        }
    }
}