using System.Collections;
using Svelto.Tasks;
using UnityEngine;
using System;

public class ExamplePhysicTasks : MonoBehaviour 
{
    void OnEnable () 
	{
        Time.fixedDeltaTime = 0.5f;

        TaskRunner.Instance.RunOnSchedule(StandardSchedulers.physicScheduler, PrintTime);
	}

    void OnDisable()
    {
        StandardSchedulers.physicScheduler.StopAllCoroutines();
    }

    IEnumerator PrintTime()
	{
        var timeNow = DateTime.Now;
        while (true)
        {
            Debug.Log("FixedUpdate time :" + (DateTime.Now - timeNow).TotalSeconds);
            timeNow = DateTime.Now;
            yield return null;
        }
	}
}