//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public static class UIManager /*: MonoBehaviour*/
//{
//    public static bool isInitialized { get; private set; }
//    public static GameObject inGame, mainMenu, pause, winMenu, loseMenu;
//    public static void Init()
//    {
//        isInitialized = true;
//        Time.timeScale = 0f;
//        GameObject canvas = GameObject.Find("Canvas");
//        inGame = canvas.transform.Find("Ingame").gameObject;
//        mainMenu = canvas.transform.Find("MainMenu").gameObject;
//        pause = canvas.transform.Find("Pause").gameObject;
//        winMenu = canvas.transform.Find("Winning").gameObject;
//        loseMenu = canvas.transform.Find("Losing").gameObject;
//    }
//    public static void OpenMenu(UIEnum uIEnum, GameObject gameObject)
//    {
//        if (!isInitialized)
//        {
//            Init();
//        }
//        switch (uIEnum)
//        {
//            case (UIEnum.IN_GAME):
//                inGame.SetActive(true);
//                break;
//            case (UIEnum.MAIN_MENU):
//                mainMenu.SetActive(true);
//                break;
//            case (UIEnum.PAUSE):
//                pause.SetActive(true);
//                break;
//            case (UIEnum.WIN):
//                winMenu.SetActive(true);
//                break;
//            case (UIEnum.LOSE):
//                loseMenu.SetActive(true);
//                break;

//        }
//    }

















//    //public Canvas canvas;
//    //public static UIManager instance { get; private set; }
//    ////public List<IndicatorController> targetIndicators = new List<IndicatorController>();

//    //[SerializeField] GameObject mainMenu;
//    //[SerializeField] GameObject pausePanel;
//    //[SerializeField] GameObject endGame;
//    //[SerializeField] GameObject shop;

//    //private void Awake()
//    //{
//    //    if(instance == null)
//    //    {
//    //        instance = this;
//    //    }
//    //    else
//    //    {
//    //        Destroy(this.gameObject);
//    //    }
//    //}
//    //// Start is called before the first frame update
//    //void Start()
//    //{

//    //}

//    //// Update is called once per frame
//    //void Update()
//    //{

//    //}



//}
