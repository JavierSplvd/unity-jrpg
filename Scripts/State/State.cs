public abstract class State<T>
{
    protected T owner;

    public abstract void Tick();

    public virtual void OnStateEnter() { }
    
    public virtual void OnStateExit() { }

    public State(T subject)
    {
        this.owner = subject;
    }
}