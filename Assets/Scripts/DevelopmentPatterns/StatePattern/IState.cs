public interface IState
{
    // Get called on the start of the state
    void Enter();
    // Get called on the update function
    void Update();
    // Get called on the fixedUpdate function
    void FixedUpdate();
    // Get called on the end of the state
    void Exit();
}
