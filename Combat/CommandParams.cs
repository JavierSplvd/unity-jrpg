public class CommandParams
{
    private UnitSO subject, target;
    private ItemSO item;
    private SkillSO skill;
    public CommandParams(UnitSO subject, UnitSO target, ItemSO item, SkillSO skill)
    {
        this.subject = subject;
        this.target = target;
        this.item = item;
        this.skill = skill;
    }

    public UnitSO GetSubject() => subject;
    public UnitSO GetTarget() => target;
    public ItemSO GetItem() => item;
    public SkillSO GetSkill() => skill;
}