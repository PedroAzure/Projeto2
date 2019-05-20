using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupTrigger : MonoBehaviour
{
    //public Dialog dialog;

    public void TriggerDialog(){
        FindObjectOfType<PopupManager>().StartDialog();
    }
}
