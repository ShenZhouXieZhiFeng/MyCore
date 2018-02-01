using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecPanel : UIBase {

    Button btnClose;

	void Start ()
    {
        Bind(UIEventCode.SEC_SHOW);

        btnClose = transform.Find("btnClose").GetComponent<Button>();
        btnClose.onClick.AddListener(onBtnClose);

        gameObject.SetActive(false);
    }

    public override void Execute(uint eventCode, object message)
    {
        Debug.Log("收到消息+" + eventCode);
        switch (eventCode)
        {
            case UIEventCode.SEC_SHOW:
                gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }

    void onBtnClose()
    {
        gameObject.SetActive(false);
        Debug.Log("发出消息+" + UIEventCode.FIR_SHOW);
        Dispatch(UIEventCode.FIR_SHOW, null);
    }
	
}
