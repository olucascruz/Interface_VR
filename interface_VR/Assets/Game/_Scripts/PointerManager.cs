using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerManager : MonoBehaviour
{


    [SerializeField] private float maxDistancePointer = 4.5f;
    //[SerializeField] private float disPointerObject = 0.95f;

    [SerializeField] private GameObject loaderObj;
    [SerializeField] private Image loaderImg;
    private RaycastHit hit;
    private bool isInteracting;
    // Start is called before the first frame update
    void Start()
    {
        isInteracting = false;
        loaderImg.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {   

        if(Physics.Raycast(transform.position, transform.forward, out hit, maxDistancePointer)){
            if(hit.collider.gameObject.tag == "Interactable"){
                print(hit.collider.gameObject.tag);
                loaderObj.SetActive(true);
                if(!isInteracting){
                    
                    StartCoroutine(StartInteracting());
                }
            }
            else
            {   
                isInteracting = false;
                loaderImg.fillAmount = 0;
                loaderObj.SetActive(false);
            }
        }
        else
        {   
            isInteracting = false;
            loaderImg.fillAmount = 0;
            loaderObj.SetActive(false);
        }
    }


    IEnumerator StartInteracting(){
    if(isInteracting == true) yield break;
        isInteracting=true;
        while(isInteracting){
            yield return new WaitForSeconds(0.05f);
                print("loop");
            if(loaderImg.fillAmount + 0.03f > 1){
                if(isInteracting){
                    try
                    {
                        hit.collider.gameObject.GetComponent<ButtonVR>().Execute();
                    }
                    catch (System.Exception)
                    {
                        print("nao deu");
                    }
                }
                loaderImg.fillAmount = 0;
            }
            
            loaderImg.fillAmount += 0.03f;

        }
        loaderImg.fillAmount = 0;
        loaderObj.SetActive(false);
    
    }
}
