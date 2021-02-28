using NUnit.Framework;

public class UnitUpkeepStateTest {
    [Test]
    public void WhenEnterState_RemoveStun()
    {
        UnitSO unit = TestUtil.CreateUnit();
        unit.currentDebuffs = new Debuff[] {Debuff.STUN};
        BattleSystem battleSystem = TestUtil.CreateBattleSystem();

        UnitUpkeepState state = new UnitUpkeepState(battleSystem, unit);

        state.OnStateEnter();

        Assert.AreEqual(0, unit.currentDebuffs.Length);
    }

    [Test]
    public void WhenEnterState_TriesToRemoveStun_DoesNotFail()
    {
        UnitSO unit = TestUtil.CreateUnit();
        unit.currentDebuffs = new Debuff[0];
        BattleSystem battleSystem = TestUtil.CreateBattleSystem();

        UnitUpkeepState state = new UnitUpkeepState(battleSystem, unit);

        state.OnStateEnter();

        Assert.AreEqual(0, unit.currentDebuffs.Length);
    }
}