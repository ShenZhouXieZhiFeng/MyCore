using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerBase : MonoBase
{
    private Dictionary<uint, List<MonoBase>> dict = new Dictionary<uint, List<MonoBase>>();

    /// <summary>
    /// 添加事件
    /// </summary>
    public void Add(uint eventCode,MonoBase mono)
    {
        List<MonoBase> list = null;

        if (!dict.ContainsKey(eventCode))
        {
            list = new List<MonoBase>();
            list.Add(mono);
            dict.Add(eventCode, list);
            return;
        }

        list = dict[eventCode];
        list.Add(mono);
    }

    /// <summary>
    /// 同时添加多个事件
    /// </summary>
    public void Add(uint[] eventCodes, MonoBase mono)
    {
        for (int i = 0; i < eventCodes.Length; i++)
        {
            Add(eventCodes[i], mono);
        }
    }

    /// <summary>
    /// 移除一个事件
    /// </summary>
    /// <param name="eventCode"></param>
    /// <param name="mono"></param>
    public void Remove(uint eventCode,MonoBase mono)
    {
        if (!dict.ContainsKey(eventCode))
        {
            return;
        }
        List<MonoBase> list = dict[eventCode];

        if (list.Count == 1)
            dict.Remove(eventCode);
        else
            list.Remove(mono);
    }

    /// <summary>
    /// 移除多个事件
    /// </summary>
    public void Remove(uint[] eventCodes, MonoBase mono)
    {
        for (int i = 0; i < eventCodes.Length; i++)
        {
            Remove(eventCodes[i], mono);
        }
    }

    public override void Execute(uint eventCode, object message)
    {
        if (!dict.ContainsKey(eventCode))
        {
            Debug.LogWarningFormat("事件未注册{0}", eventCode);
            return;
        }
        List<MonoBase> list = dict[eventCode];
        for (int i = 0; i < list.Count; i++)
        {
            list[i].Execute(eventCode, message);
        }
    }
}
