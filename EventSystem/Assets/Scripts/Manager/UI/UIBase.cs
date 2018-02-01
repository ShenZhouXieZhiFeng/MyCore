using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBase
{
    private List<uint> selfEventList = new List<uint>();

    protected void Bind(params uint[] eventCodes)
    {
        selfEventList.AddRange(eventCodes);
        UIManager.Instance.Add(selfEventList.ToArray(), this);
    }

    protected void UnBind()
    {
        UIManager.Instance.Remove(selfEventList.ToArray(), this);
        selfEventList.Clear();
    }

    private void OnDestroy()
    {
        if (selfEventList != null)
            UnBind();
    }

    protected void Dispatch(uint eventCode,object message)
    {
        MsgCenter.Instance.Dispatch(AreaCode.UI, eventCode, message);
    }

    public override void Execute(uint eventCode, object message)
    {
        
    }
}
