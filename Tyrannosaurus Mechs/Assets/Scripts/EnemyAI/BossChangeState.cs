using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChangeState : EnemyHealth
{
    public enum Stage
    {
        WaitingToStart,
        Stage_1,
        Stage_2,
        Stage_3,
    }

    private Stage stage;

    private void Awake()
    {
        stage = Stage.WaitingToStart;
    }

    private void StartNextStage()
    {
        switch (stage)
        {
            case Stage.WaitingToStart:
                stage = Stage.Stage_1;
                break;
            case Stage.Stage_1:
                stage = Stage.Stage_2;
                break;
            case Stage.Stage_2:
                stage = Stage.Stage_3;
                break;
        }
        Debug.Log("Starting next stage: " + stage);
    }

    private void BossBattle(object sender, System.EventArgs e)
    {
        switch (stage)
        {
            case Stage.Stage_1:
                if (currentHealth <= 175f)
                {
                    StartNextStage();
                }
                break;
            case Stage.Stage_2:
                if (currentHealth <= 100f)
                {
                    StartNextStage();
                }
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
