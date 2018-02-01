using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirPanel : UIBase {

    Button btnClose;

    void Start()
    {
        Bind(UIEventCode.FIR_SHOW);

        btnClose = transform.Find("btnClose").GetComponent<Button>();
        btnClose.onClick.AddListener(onBtnClose);
    }

    public override void Execute(uint eventCode, object message)
    {
        Debug.Log("收到消息+" + eventCode);
        switch (eventCode)
        {
            case UIEventCode.FIR_SHOW:
                gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }

    void onBtnClose()
    {
        gameObject.SetActive(false);
        Debug.Log("发出消息+" + UIEventCode.SEC_SHOW);
        Dispatch(UIEventCode.SEC_SHOW, null);
    }
}
