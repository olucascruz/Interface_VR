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

    [Header("Title")]
    [SerializeField] private TextMeshProUGUI titleInterface;


    [Header("Entertaiment image")]
    [SerializeField] private Image ent1Img;
    [SerializeField] private Image ent2Img;
    [SerializeField] private Image ent3Img;

    [SerializeField] private Sprite ent1Sprite;
    [SerializeField] private Sprite ent2Sprite;
    [SerializeField] private Sprite ent3Sprite;
    [SerializeField] private Sprite ent4Sprite;
    [SerializeField] private Sprite ent5Sprite;
    [SerializeField] private Sprite ent6Sprite;
    [SerializeField] private Sprite ent7Sprite;

    [Header("Dive image")]
    [SerializeField] private Image div1Img;
    [SerializeField] private Image div2Img;
    [SerializeField] private Image div3Img;

    [SerializeField] private Sprite div1Sprite;
    [SerializeField] private Sprite div2Sprite;
    [SerializeField] private Sprite div3Sprite;
    [SerializeField] private Sprite div4Sprite;
    [SerializeField] private Sprite div5Sprite;
    [SerializeField] private Sprite div6Sprite;
    [SerializeField] private Sprite div7Sprite;


    [Header("Navegation point")]
    [SerializeField] private Image nav1Img;
    [SerializeField] private Image nav2Img;
    [SerializeField] private Image nav3Img;
    private Color colorDefault;
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

    private void UpdateNavImg(){
        Color black = new Color(0f, 0f, 0f, 0.6f);
        if(isDive){
            if(indexDiv == 1){
                nav1Img.color = black;
                nav2Img.color = colorDefault;
                nav3Img.color = colorDefault;
            }
            if(indexDiv == 2){
                nav1Img.color = colorDefault;
                nav2Img.color = black;
                nav3Img.color = colorDefault;
            
            }
            if(indexDiv == 3){
                nav1Img.color = colorDefault;
                nav2Img.color = colorDefault;
                nav3Img.color = black;
            }

        }else{
            if(indexEnt == 1){
                nav1Img.color = black;
                nav2Img.color = colorDefault;
                nav3Img.color = colorDefault;
            
            }
            if(indexEnt == 2){
                nav1Img.color = colorDefault;
                nav2Img.color = black;
                nav3Img.color = colorDefault;
            
            }
            if(indexEnt == 3){
                nav1Img.color = colorDefault;
                nav2Img.color = colorDefault;
                nav3Img.color = black;
            
            }
        
        }
    }

    private void Start(){
        
        colorDefault = nav1Img.color;
        if(isDive){
            titleInterface.text = "Dive";
            UpdateDiv();
            dive.SetActive(true);
            entreteriment.SetActive(false);
        }
        else{
            titleInterface.text = "Entreterimento";
            UpdateEnt();
            dive.SetActive(false);
            entreteriment.SetActive(true);
        }

        UpdateNavImg();
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
        UpdateNavImg();
        if(indexEnt == 1){
            ent1.text = "App1";
            ent2.text = "App2";
            ent3.text = "App3";
            ent1Img.sprite = ent1Sprite;
            ent2Img.sprite = ent2Sprite;
            ent3Img.sprite = ent3Sprite;
        }

        if(indexEnt == 2){
            ent1.text = "App4";
            ent2.text = "App5";
            ent3.text = "App6";

            ent1Img.sprite = ent4Sprite;
            ent2Img.sprite = ent5Sprite;
            ent3Img.sprite = ent6Sprite;
        }

        if(indexEnt == 3){
            ent1.text = "App7";
            ent2.text = "App8";
            ent3.text = "App9";

            ent1Img.sprite = ent7Sprite;
            ent2Img.sprite = ent7Sprite;
            ent3Img.sprite = ent7Sprite;
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
        UpdateNavImg();
        if(indexDiv == 1){
            div1.text = "Video1";
            div2.text = "Video2";
            div3.text = "Video3";

            div1Img.sprite = div1Sprite;
            div2Img.sprite = div2Sprite;
            div3Img.sprite = div3Sprite;
        }

        if(indexDiv == 2){
            div1.text = "Video4";
            div2.text = "Video5";
            div3.text = "Video6";

            div1Img.sprite = div4Sprite;
            div2Img.sprite = div5Sprite;
            div3Img.sprite = div6Sprite;
        }

        if(indexDiv == 3){
            div1.text = "Video7";
            div2.text = "Video8";
            div3.text = "Video9";

            div1Img.sprite = div7Sprite;
            div2Img.sprite = div7Sprite;
            div3Img.sprite = div7Sprite;
        }
    }

    

    public void ChangeMode(){
        if (dive.activeSelf)
            {   
                titleInterface.text = "Entreterimento";
                isDive = false;
                dive.SetActive(false);
                entreteriment.SetActive(true);
                UpdateEnt();
            }
            else
            {   
                titleInterface.text = "Dive";
                isDive = true;
                dive.SetActive(true);
                entreteriment.SetActive(false);
                UpdateDiv();
            }
    
    }
}
