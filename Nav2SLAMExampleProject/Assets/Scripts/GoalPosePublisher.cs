using System;
using RosMessageTypes.Geometry;
using RosMessageTypes.Std;
using Unity.Robotics.Core;
using UnityEngine;
using UnityEngine.UI;

public class GoalPosePublisher : PosePublisher
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        m_Ros.RegisterPublisher<PoseStampedMsg>(m_Topic);
        m_Button = GameObject.Find("Canvas/Panel/GoalButton").GetComponent<Button>();
    }

    protected override bool ReleaseClick()
    {
        if (base.ReleaseClick())
        {
            m_Ros.Send(m_Topic, new PoseStampedMsg()
            {
                header = new HeaderMsg(new TimeStamp(Clock.time), "odom"),
                pose = CalculatePose()
            });
            return true;
        }

        return false;
    }
}