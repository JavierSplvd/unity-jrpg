public class CommandParams
{
    private UnitSO subject;
    private UnitSO[] targets;
    private ItemSO item;
    private SkillSO skill;
    public CommandParams(UnitSO subject, ItemSO item, SkillSO skill)
    {
        this.subject = subject;
        this.item = item;
        this.skill = skill;
    }
    public CommandParams(UnitSO subject, UnitSO[] targets, ItemSO item, SkillSO skill)
    {
        this.subject = subject;
        this.targets = targets;
        this.item = item;
        this.skill = skill;
    }

    public CommandParams(UnitSO subject, UnitSO target, ItemSO item, SkillSO skill)
    {
        this.subject = subject;
        this.targets = new UnitSO[1] {target};
        this.item = item;
        this.skill = skill;
    }

    public UnitSO GetSubject() => subject;
    public UnitSO[] GetTargets() => targets;
    public ItemSO GetItem() => item;
    public SkillSO GetSkill() => skill;
}