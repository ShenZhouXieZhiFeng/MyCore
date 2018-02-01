using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsgCenter : MonoBehaviour
{
    public static MsgCenter Instance = null;

    UIManager ui;
    AudioManager audio;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("存在两个消息中心");
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        addManagerComponent();
    }

    void addManagerComponent()
    {
        ui = gameObject.AddComponent<UIManager>();
        audio = gameObject.AddComponent<AudioManager>();
    }

    /// <summary>
    /// 分发消息
    /// </summary>
    public void Dispatch(uint areaCode, uint eventCode,object message)
    {
        switch (areaCode)
        {
            case AreaCode.UI:
                ui.Execute(eventCode, message);
                break;
            case AreaCode.AUDIO:
                audio.Execute(eventCode, message);
                break;
            default:
                break;
        }
    }

}
