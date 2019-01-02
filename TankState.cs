using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    /// <summary>
    /// 待机
    /// </summary>
    public class IdleState : StateBase1
    {
        public IdleState(StateMachine1 sm) : base(sm) { }
        public override void EndState()
        {
          
        }

        public override void EnterState()
        {
            
        }

    public override void UpdateState(GameObject player, GameObject enemy)
    {
       
    }
}
    /// <summary>
    /// 运动
    /// </summary>
    public class RunState : StateBase1
    {
        public RunState(StateMachine1 sm) : base(sm) { }
        public override void EndState()
        {
           
        }

        public override void EnterState()
        {
           
        }

    public override void UpdateState(GameObject player, GameObject enemy)
    {
        enemy.transform.LookAt(player.transform);
        if (Vector3.Distance(player.transform.position, enemy.transform.position) >= 5)
        {
            enemy.transform.Translate(0, 0, Time.deltaTime * 5, Space.Self);
        }
        else
        {
            stateMachine.ChangeState(State.attack);
        }

    }
}
    /// <summary>
    /// 死亡
    /// </summary>
    public class DeathState : StateBase1
    {
        public DeathState(StateMachine1 sm) : base(sm) { }
        public override void EndState()
        {
           
        }

        public override void EnterState()
        {
           
        }

    public override void UpdateState(GameObject player, GameObject enemy)
    {
        
    }
}
/// <summary>
/// 攻击
/// </summary>
    public class AttackState : StateBase1
    {
        private float CD=1;
        private float nextFire;//几秒后可以进行下一发攻击
        GameObject Shell=(GameObject)Resources.Load("Shell");
        public AttackState(StateMachine1 sm) : base(sm) { }
        public override void EndState()
        {
           
        }

        public override void EnterState()
        {
            
        }

    public override void UpdateState(GameObject player, GameObject enemy)
    {
        enemy.transform.LookAt(player.transform);
        if (Vector3.Distance(player.transform.position, enemy.transform.position) <= 5)
        {
            if (Time.time > nextFire && player)//play不为空
            {
                //设置炮弹生成及各项属性
                ShellKK.Shells(Shell, enemy.transform.Find("fashedian").transform);
                nextFire = Time.time + CD;//更新计时器
            }
        }
        else
            stateMachine.ChangeState(State.run);
           
      
       
    }
   
}
class ShellKK : MonoBehaviour {
    public static void  Shells(GameObject shell,Transform fashedian) {
        Instantiate(shell,fashedian.position,fashedian.rotation);
    }
}
    public enum State {idle,run,death,attack }

