using UnityEngine;
using System.Linq;
using static Controller;

public class UnitUtil {
    public static UnitSO[] GetUnitsFor(UnitSO subject, UnitSO[] units, SkillSO skill)
    {
        Controller subjectController = subject.controller;
        Controller opposingController = subject.controller.Equals(PLAYER)? AI : PLAYER;
        Controller targetController = skill.offensive? opposingController : subjectController;
        return units.ToList().Where(it => it.controller.Equals(targetController)).ToArray();
    }

    public static UnitSO[] GetFriends(UnitSO[] units, Controller controller)
    {
        return units.ToList().Where(it => it.controller.Equals(controller)).ToArray();
    }

    public static UnitSO[] GetOpponents(UnitSO[] units, Controller controller)
    {
        return units.ToList().Where(it => !it.controller.Equals(controller)).ToArray();
    }

    public static void SubstractMana(UnitSO subject, SkillSO skill)
    {
        Debug.Log(subject.unitName +"/"+ subject.currentMP.ToString() +"/"+ skill.manaCost.ToString());
        subject.currentMP = Mathf.Clamp(subject.currentMP - skill.manaCost, 0, subject.maxMP);
    }
}