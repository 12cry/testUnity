namespace testUnity
{
    
    public enum GameState
    {
        HumanRuning,
        Paused,
        AIRuning,
        GameOver,
    }

    public enum AIState
    {
        Ready,
        Building,
        Builded,
        Playing,
        Played,
        Finish,
    }

    public enum PlayerState
    {
        Ready,
        Playing,
        Moving,
        AfterMove,
        Attacking,
        Finish,
    }


}