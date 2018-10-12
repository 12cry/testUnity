namespace testUnity.constant
{
    
    public enum GameState
    {
        HumanRuning,
        AIRuning,
        Paused,
        GameOver,
    }

    public enum AIState
    {
        Idel,
        Building,
        Playing,
        // PlayerRunning,
    }
    // public enum AIState
    // {
    //     Ready,
    //     Builded,
    //     Playing,
    //     Played,
    //     Finish,
    // }

    public enum PlayerState
    {
        Idle,
        Running,
        Moving,
        AfterMove,
        Attacking,
        Finish,
    }

    // public enum PlayerState
    // {
    //     Ready,
    //     Playing,
    //     Moving,
    //     AfterMove,
    //     Attacking,
    //     Finish,
    // }


}