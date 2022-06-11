using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public IState CurrentState { get; private set; }
    public IState PreviousState;

    private bool inTransition = false;

    public void ChangeState(IState newState)
    {
        if (CurrentState == newState || inTransition)
        {
            return;
        }

        ChangeStateRoutine(newState);
    }

    public void RevertState()
    {
        if (PreviousState != null)
        {
            ChangeState(PreviousState);
        }
    }

    public void Update()
    {
        if (CurrentState != null && inTransition)
        {
            CurrentState.Update();
        }
    }

    public void FixedUpdate()
    {
        if (CurrentState != null && inTransition)
        {
            CurrentState.FixedUpdate();
        }
    }

    private void ChangeStateRoutine(IState newState)
    {
        inTransition = true;

        if (CurrentState != null)
        {
            CurrentState.Exit();
        }

        if (CurrentState != null)//if (PreviousState != null)?
        {
            PreviousState = CurrentState;
        }

        CurrentState = newState;

        if (CurrentState != null)
        {
            CurrentState.Enter();
        }

        inTransition = false;
    }
}
