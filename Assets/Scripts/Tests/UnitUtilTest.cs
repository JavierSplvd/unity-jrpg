using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class UnitUtilTest {
    [Test]
    public void SetStatusEffectDontAddDuplicates() {
        UnitSO unit = TestUtil.CreateUnit();

        UnitUtil.SetStatusEffect(unit, StatusEffect.BURN);
        UnitUtil.SetStatusEffect(unit, StatusEffect.BURN);

        Assert.That(unit.currentStatusEffect.Length == 1);
        Assert.That(unit.currentStatusEffect.ToArray() [0].Equals(StatusEffect.BURN));
    }

    [Test]
    public void SetStatusEffectAddValues() {
        UnitSO unit = TestUtil.CreateUnit();

        UnitUtil.SetStatusEffect(unit, StatusEffect.BURN);
        UnitUtil.SetStatusEffect(unit, StatusEffect.STUN);

        Assert.That(unit.currentStatusEffect.Length == 2);
        Assert.That(unit.currentStatusEffect.Contains(StatusEffect.BURN));
        Assert.That(unit.currentStatusEffect.Contains(StatusEffect.STUN));
    }

    [Test]
    public void RemoveStatusEffectDeletesElement() {
        UnitSO unit = TestUtil.CreateUnit();
        UnitUtil.SetStatusEffect(unit, StatusEffect.BURN);
        UnitUtil.SetStatusEffect(unit, StatusEffect.STUN);

        UnitUtil.RemoveStatusEffect(unit, StatusEffect.BURN);

        Assert.That(unit.currentStatusEffect.Length == 1);
        Assert.That(!unit.currentStatusEffect.Contains(StatusEffect.BURN));
        Assert.That(unit.currentStatusEffect.Contains(StatusEffect.STUN));
    }

    [Test]
    public void RemoveStatusEffectDoesNothingWhenTypeNotContained() {
        UnitSO unit = TestUtil.CreateUnit();
        UnitUtil.SetStatusEffect(unit, StatusEffect.BURN);
        UnitUtil.SetStatusEffect(unit, StatusEffect.STUN);

        UnitUtil.RemoveStatusEffect(unit, StatusEffect.POISON);

        Assert.That(unit.currentStatusEffect.Length == 2);
        Assert.That(unit.currentStatusEffect.Contains(StatusEffect.BURN));
        Assert.That(unit.currentStatusEffect.Contains(StatusEffect.STUN));
    }

    [Test]
    public void RemoveStatusEffectAwareWhenArrayItsNull() {
        UnitSO unit = TestUtil.CreateUnit();

        UnitUtil.RemoveStatusEffect(unit, StatusEffect.POISON);

        Assert.That(unit.currentStatusEffect.Length == 0);
    }

    [Test]
    public void ChargeTurnPoints_FunctionOfSpeed() {
        UnitSO unit = TestUtil.CreateUnit();
        UnitSO[] allUnits = new UnitSO[] { unit };
        unit.maxTurnCount = 100f;
        unit.currentTurnCount = 0f;
        unit.finalSpeed = 50;

        UnitUtil.ChargeTurnPointsAllUnits(allUnits, 1);

        Assert.AreEqual(50, unit.currentTurnCount);
    }

    [Test]
    public void ChargeTurnPoints_ReducedWhenStun() {
        UnitSO unit = TestUtil.CreateUnit();
        UnitSO[] allUnits = new UnitSO[] { unit };
        unit.maxTurnCount = 100f;
        unit.currentTurnCount = 0f;
        unit.finalSpeed = 50;
        unit.currentStatusEffect = new StatusEffect[1] { StatusEffect.STUN };

        UnitUtil.ChargeTurnPointsAllUnits(allUnits, 1);

        Assert.AreEqual(25, unit.currentTurnCount);
    }

    [Test]
    public void ChargeTurnPoints_ZeroWhenDead() {
        UnitSO unit = TestUtil.CreateUnit();
        UnitSO[] allUnits = new UnitSO[] { unit };
        unit.maxTurnCount = 100f;
        unit.currentTurnCount = 0f;
        unit.finalSpeed = 50;
        unit.currentStatusEffect = new StatusEffect[1] { StatusEffect.DEATH };

        UnitUtil.ChargeTurnPointsAllUnits(allUnits, 1);

        Assert.AreEqual(0, unit.currentTurnCount);
    }

    [Test]
    public void GetSumOfHP_forEachController() {
        UnitSO playerUnitA = TestUtil.CreateUnit();
        playerUnitA.currentHP = 50;
        playerUnitA.controller = Controller.PLAYER;
        UnitSO playerUnitB = TestUtil.CreateUnit();
        playerUnitB.currentHP = 60;
        playerUnitB.controller = Controller.PLAYER;
        UnitSO aiUnitC = TestUtil.CreateUnit();
        aiUnitC.currentHP = 90;
        aiUnitC.controller = Controller.AI;

        UnitSO[] allUnits = new UnitSO[] { playerUnitA, playerUnitB, aiUnitC };
        float countPlayer = UnitUtil.GetSumOfHP(allUnits, Controller.PLAYER);
        float countAI = UnitUtil.GetSumOfHP(allUnits, Controller.AI);

        Assert.AreEqual(110, countPlayer);
        Assert.AreEqual(90, countAI);
    }

    [Test]
    public void GivenDeadAlliedUnit_GetFriendsDoesNotReturnIt() {
        UnitSO a = TestUtil.CreateUnit();
        a.controller = Controller.PLAYER;
        UnitSO b = TestUtil.CreateUnit();
        b.controller = Controller.AI;
        UnitSO dead = TestUtil.CreateUnit();
        dead.controller = Controller.PLAYER;
        dead.currentStatusEffect = new StatusEffect[] { StatusEffect.DEATH };

        var list = UnitUtil.GetAliveFriends(new UnitSO[] { a, b, dead }, Controller.PLAYER);

        Assert.AreEqual(1, list.Length);
        Assert.AreEqual(a, list[0]);
    }

    [Test]
    public void GivenDeadEnemyUnit_GetOpponentsDoesNotReturnIt() {
        UnitSO a = TestUtil.CreateUnit();
        a.controller = Controller.PLAYER;
        UnitSO b = TestUtil.CreateUnit();
        b.controller = Controller.AI;
        UnitSO dead = TestUtil.CreateUnit();
        dead.controller = Controller.AI;
        dead.currentStatusEffect = new StatusEffect[] { StatusEffect.DEATH };

        var list = UnitUtil.GetAliveOpponents(new UnitSO[] { a, b, dead }, Controller.PLAYER);

        Assert.AreEqual(1, list.Length);
        Assert.AreEqual(b, list[0]);
    }
}