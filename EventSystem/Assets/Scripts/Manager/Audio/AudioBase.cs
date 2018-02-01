using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBase : MonoBase
{

    private List<uint> selfEventList = new List<uint>();

    protected void Bind(params uint[] eventCodes)
    {
        selfEventList.AddRange(eventCodes);
        AudioManager.Instance.Add(selfEventList.ToArray(), this);
    }

    protected void UnBind()
    {
        AudioManager.Instance.Remove(selfEventList.ToArray(), this);
        selfEventList.Clear();
    }

    private void OnDestroy()
    {
        if (selfEventList != null)
            UnBind();
    }

    protected void Dispatch(uint eventCode, object message)
    {
        MsgCenter.Instance.Dispatch(AreaCode.AUDIO, eventCode, message);
    }

    public override void Execute(uint eventCode, object message)
    {

    }
}
