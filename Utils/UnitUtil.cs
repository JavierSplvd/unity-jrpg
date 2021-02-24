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
}