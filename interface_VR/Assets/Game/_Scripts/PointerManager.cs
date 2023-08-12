using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerManager : MonoBehaviour
{

    [SerializeField] private GameObject pointer;
    [SerializeField] private float maxDistancePointer = 4.5f;
    [SerializeField] private float disPointerObject = 0.95f;

    [SerializeField] private GameObject loaderObj;
    [SerializeField] private Image loaderImg;
    private RaycastHit hit;
    private bool isInteracting;
    // Start is called before the first frame update
    void Start()
    {
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
                    isInteracting=true;
                    StartCoroutine(StartInteracting());
                }
            }
        }
        else
        {   
            isInteracting = false;
            loaderImg.fillAmount = 0;
            StopCoroutine(StartInteracting());
            loaderObj.SetActive(false);
        }
    }


    IEnumerator StartInteracting(){
        float num = 0;
        while(isInteracting){
            yield return new WaitForSeconds(0.05f);
            if(loaderImg.fillAmount + 0.03f > 1){
                if(isInteracting){
                    hit.collider.gameObject.GetComponent<ButtonVR>().Execute();
                }
                loaderImg.fillAmount = 0;
            }
            
            loaderImg.fillAmount += 0.03f;

        }
    }
}
