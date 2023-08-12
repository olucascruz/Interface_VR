using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private int indexEnt = 1;
    [SerializeField] private int indexDiv = 1;
    [SerializeField] private GameObject dive;
    [SerializeField] private GameObject entreteriment;
    public bool isDive = true;
    [SerializeField] private TextMeshProUGUI ent1;
    [SerializeField] private TextMeshProUGUI ent2;
    [SerializeField] private TextMeshProUGUI ent3;
    [SerializeField] private TextMeshProUGUI div1;
    [SerializeField] private TextMeshProUGUI div2;
    [SerializeField] private TextMeshProUGUI div3;

    private static UIManager instance;
    public static UIManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start(){
        UpdateDiv();
        UpdateEnt();
    }

    public void PreIndexDiv(){
        indexDiv -= 1;
        if(indexDiv < 1){
            indexDiv = 3;
        }

        UpdateDiv();
    }

    public void PreIndexEnt(){
        indexEnt -= 1;
        if(indexEnt < 1){
            indexEnt = 3;
        }
        UpdateEnt();
    }
    public void NextIndexEnt(){
        
        indexEnt += 1;
        if(indexEnt > 3){
            indexEnt = 1;
        }
        UpdateEnt();
    }

    private void UpdateEnt(){
        
        if(indexEnt == 1){
            ent1.text = "Video1";
            ent2.text = "Video2";
            ent3.text = "Video3";
        }

        if(indexEnt == 2){
            ent1.text = "Video4";
            ent2.text = "Video5";
            ent3.text = "Video6";
        }

        if(indexEnt == 3){
            ent1.text = "Video7";
            ent2.text = "Video8";
            ent3.text = "Video9";
        }
    }
    public void NextIndexDiv(){
        indexDiv += 1;
        if(indexDiv > 3){
            indexDiv = 1;
        }
        UpdateDiv();
    }

    private void UpdateDiv(){
        if(indexDiv == 1){
            div1.text = "Google";
            div2.text = "Youtube";
            div3.text = "Netflix";
        }

        if(indexDiv == 2){
            div1.text = "Amazon";
            div2.text = "Disney";
            div3.text = "Cartoon";
        }

        if(indexDiv == 3){
            div1.text = "Nick";
            div2.text = "Roblox";
            div3.text = "Steam";
        }
    }

    

    public void ChangeMode(){
        if (dive.activeSelf)
            {   
                isDive = false;
                dive.SetActive(false);
                entreteriment.SetActive(true);
            }
            else
            {
                isDive = true;
                dive.SetActive(true);
                entreteriment.SetActive(false);
            }
    
    }
}
