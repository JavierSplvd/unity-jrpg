using NUnit.Framework;

public class UnitUpkeepStateTest {
    [Test]
    public void WhenEnterState_RemoveStun()
    {
        UnitSO unit = TestUtil.CreateUnit();
        unit.currentStatusEffect = new StatusEffect[] {StatusEffect.STUN};
        BattleSystem battleSystem = TestUtil.CreateBattleSystem();

        UnitUpkeepState state = new UnitUpkeepState(battleSystem, unit);

        state.OnStateEnter();

        Assert.AreEqual(0, unit.currentStatusEffect.Length);
    }

    [Test]
    public void WhenEnterState_TriesToRemoveStun_DoesNotFail()
    {
        UnitSO unit = TestUtil.CreateUnit();
        unit.currentStatusEffect = new StatusEffect[0];
        BattleSystem battleSystem = TestUtil.CreateBattleSystem();

        UnitUpkeepState state = new UnitUpkeepState(battleSystem, unit);

        state.OnStateEnter();

        Assert.AreEqual(0, unit.currentStatusEffect.Length);
    }
}