using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TypeButton
{
    NEXT, PREVIOUS, SELECT, CHANGEMODE
}

public class ButtonVR : MonoBehaviour
{
    [SerializeField] private TypeButton tb; 
    
    private UIManager uimanager;
    private void Start(){
        uimanager = UIManager.Instance;
    }

    public void Execute(){
        if(tb == TypeButton.NEXT){
            if(uimanager.isDive){
                uimanager.NextIndexDiv();
            }
            else{
                uimanager.NextIndexEnt();
            }
        }
        if(tb == TypeButton.PREVIOUS){
            if(uimanager.isDive){
                uimanager.PreIndexDiv();
            }
            else{
                uimanager.PreIndexEnt();
            }

        }
        if(tb == TypeButton.SELECT){

        }
        if(tb == TypeButton.CHANGEMODE){
            uimanager.ChangeMode();
        }
    
    }
}
