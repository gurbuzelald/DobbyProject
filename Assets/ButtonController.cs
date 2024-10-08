using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private MenuInput menuInput;


    //Game Scene Buttons
    private bool pauseButton;
    private bool playAgainButton;

    private bool menuButton;
    private bool defaultButton;


    //Menu SceneButtons
    private bool playButton;
    private bool levelsButton;
    private bool settingButton;
    private bool quitButton;
    private bool languageButton;
    private bool menuDefaultButton;
    private bool pickCharacterButton;
    private bool pickWeaponButton;
    private bool continueButton;
    private bool resetGameButton;

    //Levels Scene Buttons
    private bool levelsMenuButton;
    private bool level1;
    private bool level2;
    private bool level3;
    private bool level4;
    private bool level5;
    private bool level6;
    private bool level7;
    private bool level8;
    private bool level9;
    private bool level10;

    //Pick Character Scene Buttons
    private bool pickCharacterMenuButton;
    private bool openPickWeaponSceneByPickCharacterSceneButton;
    public static bool Dobby;
    public static bool Joleen;
    public static bool Glassy;
    public static bool Lusth;
    public static bool Guard;
    public static bool Michelle;
    public static bool Eve;
    public static bool Aj;
    public static bool Boss;
    public static bool Ty;
    public static bool Mremireh;

    //Pick Weapon Scene Buttons
    private bool pickWeaponMenuButton;
    private bool openPickCharacterSceneByPickWeaponSceneButton;

    public static bool Pistol;
    public static bool Axe;
    public static bool Bulldog;
    public static bool Cow;
    public static bool Crystal;
    public static bool Demon;
    public static bool Ice;
    public static bool Electro;
    public static bool Ak47;
    public static bool M4A4;

    //End Scene Buttons
    public bool endSceneMenuButton;
    public bool endScenePlayAgainButton;
    public bool endSceneQuitButton;

    //Win Scene Buttons
    public bool winSceneMenuButton;
    public bool winScenePlayAgainButton;
    public bool winSceneQuitButton;

    [SerializeField] SceneController sceneController;
    [SerializeField] SettingController settingController;
    [SerializeField] LevelUpButtonController levelUpButtonController;

    public float buttonTime;

    void Awake()
    {
        buttonTime = 0;

        menuInput = new MenuInput();
    }
    private void OnEnable()
    {
        if (menuInput != null)
        {
            menuInput.Enable();
        }        
    }
    private void OnDisable()
    {
        if (menuInput != null)
        {
            menuInput.Disable();
        }        
    }

    // Update is called once per frame
    void Update()
    {
        GameSceneButtons();
        MenuSceneButtons();
        LevelsSceneButtons();
        PickCharacterSceneButtons();
        PickWeaponSceneButtons();
        EndSceneButtons();
        WinSceneButtons();

        DelayButton();
        //Debug.Log(buttonTime);

    }
    

    void DelayButton()
    {
        buttonTime += Time.deltaTime;
    }


    #region WinScene Button Events
    void WinSceneButtons()
    {
        if (SceneController.CheckSceneName() == SceneController.Scenes.Win.ToString())
        {
            winSceneMenuButton = menuInput.WinSceneButtons.MenuButton.IsPressed();
            winScenePlayAgainButton = menuInput.WinSceneButtons.PlayAgainButton.IsPressed();
            winSceneQuitButton = menuInput.WinSceneButtons.QuitButton.IsPressed();

            WinSceneEvents();
        }
    }

    void WinSceneEvents()
    {
        if (winSceneMenuButton && buttonTime >= .2f && sceneController)
        {
            SceneController.LoadMenuScene();

            buttonTime = 0;
        }
        if (winScenePlayAgainButton && buttonTime >= .2f && sceneController)
        {
            sceneController.PlayAgain();

            buttonTime = 0;
        }
        if (winSceneQuitButton && buttonTime >= .2f && sceneController)
        {
            sceneController.QuitGame();

            buttonTime = 0;
        }
    }
    #endregion


    #region End Scene Button Events
    void EndSceneButtons()
    {
        if (SceneController.CheckSceneName() == SceneController.Scenes.End.ToString())
        {
            endSceneMenuButton = menuInput.EndSceneButttons.MenuButton.IsPressed();
            endScenePlayAgainButton = menuInput.EndSceneButttons.PlayAgainButton.IsPressed();
            endSceneQuitButton = menuInput.EndSceneButttons.QuitButton.IsPressed();

            EndSceneEvents();
        }        
    }

    void EndSceneEvents()
    {
        if (endSceneMenuButton && buttonTime >= .2f && sceneController)
        {
            SceneController.LoadMenuScene();

            buttonTime = 0;
        }
        if (endScenePlayAgainButton && buttonTime >= .2f && sceneController)
        {
            sceneController.PlayAgain();

            buttonTime = 0;
        }
        if (endSceneQuitButton && buttonTime >= .2f && sceneController)
        {
            sceneController.QuitGame();

            buttonTime = 0;
        }
    }
    #endregion

    #region Pick Weapon Scene Button Events
    void PickWeaponSceneButtons()
    {
        if (SceneController.CheckSceneName() == SceneController.Scenes.PickWeapon.ToString())
        {
            pickWeaponMenuButton = menuInput.PickWeaponSceneButtons.MenuButton.IsPressed();
            openPickCharacterSceneByPickWeaponSceneButton = menuInput.PickWeaponSceneButtons.PickCharacterButton.IsPressed();

            Pistol = menuInput.PickWeaponSceneButtons.Pistol.IsPressed();
            Axe = menuInput.PickWeaponSceneButtons.Axe.IsPressed();
            Bulldog = menuInput.PickWeaponSceneButtons.Bulldog.IsPressed();
            Cow = menuInput.PickWeaponSceneButtons.Cow.IsPressed();
            Crystal = menuInput.PickWeaponSceneButtons.Crystal.IsPressed();
            Demon = menuInput.PickWeaponSceneButtons.Demon.IsPressed();
            Ice = menuInput.PickWeaponSceneButtons.Ice.IsPressed();
            Electro = menuInput.PickWeaponSceneButtons.Electro.IsPressed();
            Ak47 = menuInput.PickWeaponSceneButtons.Ak47.IsPressed();
            M4A4 = menuInput.PickWeaponSceneButtons.M4A4.IsPressed();

            PickWeaponEvents();
        }
    }

    void PickWeaponEvents()
    {
        if (pickWeaponMenuButton && buttonTime >= .2f && sceneController)
        {
            SceneController.LoadMenuScene();

            buttonTime = 0;
        }

        if (openPickCharacterSceneByPickWeaponSceneButton && buttonTime >= .2f && sceneController)
        {
            SceneController.LoadCharacterChoosingScene();

            buttonTime = 0;
        }
    }
    #endregion

    #region Pick Character Scene Events

    void PickCharacterSceneButtons()
    {
        if (SceneController.CheckSceneName() == SceneController.Scenes.PickCharacter.ToString())
        {
            pickCharacterMenuButton = menuInput.PickCharacterSceneButtons.MenuButton.IsPressed();
            openPickWeaponSceneByPickCharacterSceneButton = menuInput.PickCharacterSceneButtons.PickWeaponButton.IsPressed();

            Dobby = menuInput.PickCharacterSceneButtons.Dobby.IsPressed();
            Joleen = menuInput.PickCharacterSceneButtons.Joleen.IsPressed();
            Glassy = menuInput.PickCharacterSceneButtons.Glassy.IsPressed();
            Lusth = menuInput.PickCharacterSceneButtons.Lusth.IsPressed();
            Guard = menuInput.PickCharacterSceneButtons.Guard.IsPressed();
            Michelle = menuInput.PickCharacterSceneButtons.Michelle.IsPressed();
            Eve = menuInput.PickCharacterSceneButtons.Eve.IsPressed();
            Aj = menuInput.PickCharacterSceneButtons.Aj.IsPressed();
            Boss = menuInput.PickCharacterSceneButtons.Boss.IsPressed();
            Ty = menuInput.PickCharacterSceneButtons.Ty.IsPressed();
            Mremireh = menuInput.PickCharacterSceneButtons.Mremireh.IsPressed();


            PickCharacterEvents();
        }    
    }

    void PickCharacterEvents()
    {
        if (pickCharacterMenuButton && buttonTime >= .2f && sceneController)
        {
            SceneController.LoadMenuScene();

            buttonTime = 0;
        }

        if (openPickWeaponSceneByPickCharacterSceneButton && buttonTime >= .2f && sceneController)
        {
            sceneController.LoadWeaponChoosingScene();

            buttonTime = 0;
        }
    }
    #endregion

    #region Levels Scene Events
    void LevelsSceneButtons()
    {
        if (SceneController.CheckSceneName() == SceneController.Scenes.Levels.ToString())
        {
            levelsMenuButton = menuInput.LevelsSceneButtons.LevelsMenubutton.IsPressed();

            level1 = menuInput.LevelsSceneButtons.Level1.IsPressed();
            level2 = menuInput.LevelsSceneButtons.Level2.IsPressed();
            level3 = menuInput.LevelsSceneButtons.Level3.IsPressed();
            level4 = menuInput.LevelsSceneButtons.Level4.IsPressed();
            level5 = menuInput.LevelsSceneButtons.Level5.IsPressed();
            level6 = menuInput.LevelsSceneButtons.Level6.IsPressed();
            level7 = menuInput.LevelsSceneButtons.Level7.IsPressed();
            level8 = menuInput.LevelsSceneButtons.Level8.IsPressed();
            level9 = menuInput.LevelsSceneButtons.Level9.IsPressed();
            level10 = menuInput.LevelsSceneButtons.Level10.IsPressed();

            LevelsEvents();
        }
    }

    void LevelsEvents()
    {
        if (levelsMenuButton && buttonTime >= .2f && sceneController)
        {
            SceneController.LoadMenuScene();

            buttonTime = 0;
        }

        if (level1 && buttonTime >= .2f && levelUpButtonController)
        {
            levelUpButtonController.Level1();

            buttonTime = 0;
        }
        if (level2 && buttonTime >= .2f && levelUpButtonController)
        {
            levelUpButtonController.Level2();

            buttonTime = 0;
        }
        if (level3 && buttonTime >= .2f && levelUpButtonController)
        {
            levelUpButtonController.Level3();

            buttonTime = 0;
        }
        if (level4 && buttonTime >= .2f && levelUpButtonController)
        {
            levelUpButtonController.Level4();

            buttonTime = 0;
        }
        if (level5 && buttonTime >= .2f && levelUpButtonController)
        {
            levelUpButtonController.Level5();

            buttonTime = 0;
        }
        if (level6 && buttonTime >= .2f && levelUpButtonController)
        {
            levelUpButtonController.Level6();

            buttonTime = 0;
        }
        if (level7 && buttonTime >= .2f && levelUpButtonController)
        {
            levelUpButtonController.Level7();

            buttonTime = 0;
        }
        if (level8 && buttonTime >= .2f && levelUpButtonController)
        {
            levelUpButtonController.Level8();

            buttonTime = 0;
        }
        if (level9 && buttonTime >= .2f && levelUpButtonController)
        {
            levelUpButtonController.Level9();

            buttonTime = 0;
        }
        if (level10 && buttonTime >= .2f && levelUpButtonController)
        {
            levelUpButtonController.Level10();

            buttonTime = 0;
        }
    }
    #endregion

    #region Menu Scene Events
    void MenuSceneButtons()
    {
        if (SceneController.CheckSceneName() == SceneController.Scenes.Menu.ToString())
        {
            playButton = menuInput.MenuSceneButtons.PlayButton.IsPressed();
            levelsButton = menuInput.MenuSceneButtons.LevelsButton.IsPressed();
            settingButton = menuInput.MenuSceneButtons.SettingButton.IsPressed();
            quitButton = menuInput.MenuSceneButtons.QuitButton.IsPressed();
            languageButton = menuInput.MenuSceneButtons.LanguageButton.IsPressed();
            menuDefaultButton = menuInput.MenuSceneButtons.MenuDefaultButton.IsPressed();
            pickCharacterButton = menuInput.MenuSceneButtons.PickCharacterButton.IsPressed();
            pickWeaponButton = menuInput.MenuSceneButtons.PickWeaponButton.IsPressed();
            continueButton = menuInput.MenuSceneButtons.ContinueButton.IsPressed();
            resetGameButton = menuInput.MenuSceneButtons.ResetGameButton.IsPressed();

            MenuSceneEvents();
        }
    }

    void MenuSceneEvents()
    {
        if (playButton && AudioManager.buttonDelayTimer >= .2f && sceneController)
        {
            sceneController.PlayAgain();

            AudioManager.buttonDelayTimer = 0;
        }
        if (levelsButton && AudioManager.buttonDelayTimer >= .2f && sceneController)
        {
            sceneController.LoadLevelsScene();

            AudioManager.buttonDelayTimer = 0;
        }
        if (settingButton && settingController && AudioManager.buttonDelayTimer >= .2f)
        {
            settingController.ClickSettingButton();

            AudioManager.buttonDelayTimer = 0;
        }
        if (quitButton && AudioManager.buttonDelayTimer >= .2f && sceneController)
        {
            sceneController.QuitGame();

            AudioManager.buttonDelayTimer = 0;
        }
        if (languageButton && AudioManager.buttonDelayTimer >= .2f && sceneController)
        {
            sceneController.ClickChangeLanguageButton();

            AudioManager.buttonDelayTimer = 0;
        }
        if (menuDefaultButton && settingController && AudioManager.buttonDelayTimer >= .2f)
        {
            if (settingController)
            {
                settingController.SetDefaulth();
            }               

            AudioManager.buttonDelayTimer = 0;
        }
        if (pickCharacterButton && AudioManager.buttonDelayTimer >= .2f && sceneController)
        {
            SceneController.LoadCharacterChoosingScene();

            AudioManager.buttonDelayTimer = 0;
        }
        if (pickWeaponButton && AudioManager.buttonDelayTimer >= .2f && sceneController)
        {
            sceneController.LoadWeaponChoosingScene();

            AudioManager.buttonDelayTimer = 0;
        }
        if (continueButton && AudioManager.buttonDelayTimer >= .2f && sceneController)
        {
            sceneController.ContinueLastLevel();

            AudioManager.buttonDelayTimer = 0;
        }
        if (resetGameButton && AudioManager.buttonDelayTimer >= .2f && sceneController)
        {
            sceneController.CheckNeedResetWeaponsAndCharacters();

            AudioManager.buttonDelayTimer = 0;
        }
    }

    #endregion

    #region Game Button Events

    void GameSceneButtons()
    {
        if (SceneController.CheckSceneName() == SceneController.Scenes.Game.ToString())
        {
            TopPanelButtons();
            PausePanelButtons();
        }
    }

    void TopPanelButtons()
    {
        pauseButton = menuInput.TopPanelButtons.PauseButton.IsPressed();
        playAgainButton = menuInput.TopPanelButtons.PlayAgainButton.IsPressed();

        TopPanelEvents();
    }

    void PausePanelButtons()
    {
        menuButton = menuInput.PausePanelButtons.MenuButton.IsPressed();
        defaultButton = menuInput.PausePanelButtons.DefaultButton.IsPressed();

        PausePanelEvents();
    }


    void TopPanelEvents()
    {
        if (pauseButton && buttonTime >= .2f && sceneController)
        {
            sceneController.PauseGame();

            buttonTime = 0;
        }
        if (playAgainButton && buttonTime >= .2f)
        {
            sceneController.PlayAgainInLevel();

            buttonTime = 0;
        }
    }

    void PausePanelEvents()
    {
        if (menuButton && buttonTime >= .2f)
        {
            SceneController.LoadMenuScene();

            buttonTime = 0;
        }
        if (defaultButton && buttonTime >= .2f && settingController)
        {
            settingController.SetDefaulth();

            buttonTime = 0;
        }
    }
    #endregion

}
