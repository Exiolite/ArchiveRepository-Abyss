using UnityEngine.Events;

namespace System.Controller
{
    public static class EBot
    {
        public static readonly StartBotAttackPlayer StartBotAttackPlayer = new StartBotAttackPlayer(); 
        public static readonly StopBotAttackPlayer StopBotAttackPlayer = new StopBotAttackPlayer(); 
    }
    public class StartBotAttackPlayer : UnityEvent {}
    public class StopBotAttackPlayer : UnityEvent {}
}