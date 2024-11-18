using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private GameInput gameInput;

    public PlayerData playerData;
    public BulletData bulletData;

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

    public static bool[] characterButtonBools = new bool[11];

    //Pick Weapon Scene Buttons
    private bool pickWeaponMenuButton;
    private bool openPickCharacterSceneByPickWeaponSceneButton;

    public static bool[] weaponButtonBools = new bool[10];

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

    public static float buttonTimeFlow;

    private bool buttonClickable;

    void Awake()
    {
        buttonClickable = true;

        buttonTimeFlow = 0;

        gameInput = new GameInput();
    }
    private void OnEnable()
    {
        if (gameInput != null)
        {
            gameInput.Enable();
        }        
    }
    private void OnDisable()
    {
        if (gameInput != null)
        {
            gameInput.Disable();
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

        ButtonTimeFlow();
    }
    

    void ButtonTimeFlow()
    {
        buttonTimeFlow += Time.deltaTime;
    }


    #region WinScene Button Events
    void WinSceneButtons()
    {
        if (SceneController.CheckSceneName() == SceneController.Scenes.Win.ToString())
        {
            winSceneMenuButton = gameInput.WinSceneButtons.MenuButton.IsPressed();
            winScenePlayAgainButton = gameInput.WinSceneButtons.PlayAgainButton.IsPressed();
            winSceneQuitButton = gameInput.WinSceneButtons.QuitButton.IsPressed();

            WinSceneEvents();
        }
    }

    void WinSceneEvents()
    {
        if (winSceneMenuButton && buttonTimeFlow >= .2f && sceneController)
        {
            SceneController.LoadMenuScene();

            buttonTimeFlow = 0;
        }
        if (winScenePlayAgainButton && buttonTimeFlow >= .2f && sceneController)
        {
            sceneController.PlayAgain();

            buttonTimeFlow = 0;
        }
        if (winSceneQuitButton && buttonTimeFlow >= .2f && sceneController)
        {
            sceneController.QuitGame();

            buttonTimeFlow = 0;
        }
    }
    #endregion


    #region End Scene Button Events
    void EndSceneButtons()
    {
        if (SceneController.CheckSceneName() == SceneController.Scenes.End.ToString())
        {
            endSceneMenuButton = gameInput.EndSceneButttons.MenuButton.IsPressed();
            endScenePlayAgainButton = gameInput.EndSceneButttons.PlayAgainButton.IsPressed();
            endSceneQuitButton = gameInput.EndSceneButttons.QuitButton.IsPressed();

            EndSceneEvents();
        }        
    }

    void EndSceneEvents()
    {
        if (endSceneMenuButton && buttonTimeFlow >= .2f && sceneController)
        {
            SceneController.LoadMenuScene();

            buttonTimeFlow = 0;
        }
        if (endScenePlayAgainButton && buttonTimeFlow >= .2f && sceneController)
        {
            sceneController.PlayAgain();

            buttonTimeFlow = 0;
        }
        if (endSceneQuitButton && buttonTimeFlow >= .2f && sceneController)
        {
            sceneController.QuitGame();

            buttonTimeFlow = 0;
        }
    }
    #endregion

    #region Pick Weapon Scene Button Events
    void PickWeaponSceneButtons()
    {
        if (SceneController.CheckSceneName() == SceneController.Scenes.PickWeapon.ToString())
        {
            pickWeaponMenuButton = gameInput.PickWeaponSceneButtons.MenuButton.IsPressed();
            openPickCharacterSceneByPickWeaponSceneButton = gameInput.PickWeaponSceneButtons.PickCharacterButton.IsPressed();

            weaponButtonBools[0] = gameInput.PickWeaponSceneButtons.A.IsPressed();
            weaponButtonBools[1] = gameInput.PickWeaponSceneButtons.B.IsPressed();
            weaponButtonBools[2] = gameInput.PickWeaponSceneButtons.C.IsPressed();
            weaponButtonBools[3] = gameInput.PickWeaponSceneButtons.D.IsPressed();
            weaponButtonBools[4] = gameInput.PickWeaponSceneButtons.E.IsPressed();
            weaponButtonBools[5] = gameInput.PickWeaponSceneButtons.F.IsPressed();
            weaponButtonBools[6] = gameInput.PickWeaponSceneButtons.G.IsPressed();
            weaponButtonBools[7] = gameInput.PickWeaponSceneButtons.H.IsPressed();
            weaponButtonBools[8] = gameInput.PickWeaponSceneButtons.I.IsPressed();
            weaponButtonBools[9] = gameInput.PickWeaponSceneButtons.J.IsPressed();
            PickWeaponEvents();
        }
    }

    void PickWeaponEvents()
    {
        if (pickWeaponMenuButton && buttonTimeFlow >= .2f && sceneController)
        {
            SceneController.LoadMenuScene();

            buttonTimeFlow = 0;
        }

        if (openPickCharacterSceneByPickWeaponSceneButton && buttonTimeFlow >= .2f && sceneController)
        {
            SceneController.LoadCharacterChoosingScene();

            buttonTimeFlow = 0;
        }
    }
    #endregion

    #region Pick Character Scene Events

    void PickCharacterSceneButtons()
    {
        if (SceneController.CheckSceneName() == SceneController.Scenes.PickCharacter.ToString())
        {
            pickCharacterMenuButton = gameInput.PickCharacterSceneButtons.MenuButton.IsPressed();
            openPickWeaponSceneByPickCharacterSceneButton = gameInput.PickCharacterSceneButtons.PickWeaponButton.IsPressed();


            characterButtonBools[0] = gameInput.PickCharacterSceneButtons.A.IsPressed();
            characterButtonBools[1] = gameInput.PickCharacterSceneButtons.B.IsPressed();
            characterButtonBools[2] = gameInput.PickCharacterSceneButtons.C.IsPressed();
            characterButtonBools[3] = gameInput.PickCharacterSceneButtons.D.IsPressed();
            characterButtonBools[4] = gameInput.PickCharacterSceneButtons.E.IsPressed();
            characterButtonBools[5] = gameInput.PickCharacterSceneButtons.F.IsPressed();
            characterButtonBools[6] = gameInput.PickCharacterSceneButtons.G.IsPressed();
            characterButtonBools[7] = gameInput.PickCharacterSceneButtons.H.IsPressed();
            characterButtonBools[8] = gameInput.PickCharacterSceneButtons.I.IsPressed();
            characterButtonBools[9] = gameInput.PickCharacterSceneButtons.J.IsPressed();
            characterButtonBools[10] = gameInput.PickCharacterSceneButtons.K.IsPressed();
            

            PickCharacterEvents();
        }    
    }
    public bool GetCharacterButtonState(int characterID)
    {
        if (buttonTimeFlow >= .2f)
        {
            for (int i = 1; i < playerData.characterStruct.Length; i++)
            {
                if (characterID == playerData.characterStruct[i].id)
                {
                    return characterButtonBools[i];
                }
                
            }
            if (characterID == playerData.characterStruct[0].id)
            {
                return characterButtonBools[0];
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    void PickCharacterEvents()
    {
        if (pickCharacterMenuButton && buttonTimeFlow >= .2f && sceneController)
        {
            SceneController.LoadMenuScene();

            buttonTimeFlow = 0;
        }

        if (openPickWeaponSceneByPickCharacterSceneButton && buttonTimeFlow >= .2f && sceneController)
        {
            sceneController.LoadWeaponChoosingScene();

            buttonTimeFlow = 0;
        }
    }
    #endregion

    #region Levels Scene Events
    void LevelsSceneButtons()
    {
        if (SceneController.CheckSceneName() == SceneController.Scenes.Levels.ToString())
        {
            levelsMenuButton = gameInput.LevelsSceneButtons.LevelsMenuButton.IsPressed();

            level1 = gameInput.LevelsSceneButtons.Level1.IsPressed();
            level2 = gameInput.LevelsSceneButtons.Level2.IsPressed();
            level3 = gameInput.LevelsSceneButtons.Level3.IsPressed();
            level4 = gameInput.LevelsSceneButtons.Level4.IsPressed();
            level5 = gameInput.LevelsSceneButtons.Level5.IsPressed();
            level6 = gameInput.LevelsSceneButtons.Level6.IsPressed();
            level7 = gameInput.LevelsSceneButtons.Level7.IsPressed();
            level8 = gameInput.LevelsSceneButtons.Level8.IsPressed();
            level9 = gameInput.LevelsSceneButtons.Level9.IsPressed();
            level10 = gameInput.LevelsSceneButtons.Level10.IsPressed();

            LevelsEvents();
        }
    }

    

    void LevelsEvents()
    {
        if (levelsMenuButton && buttonTimeFlow >= .2f && sceneController)
        {
            SceneController.LoadMenuScene();

            buttonTimeFlow = 0;
        }

        if (level1 && buttonTimeFlow >= .2f && levelUpButtonController)
        {
            levelUpButtonController.Level1();

            buttonTimeFlow = 0;
        }
        if (level2 && buttonTimeFlow >= .2f && levelUpButtonController)
        {
            levelUpButtonController.Level2();

            buttonTimeFlow = 0;
        }
        if (level3 && buttonTimeFlow >= .2f && levelUpButtonController)
        {
            levelUpButtonController.Level3();

            buttonTimeFlow = 0;
        }
        if (level4 && buttonTimeFlow >= .2f && levelUpButtonController)
        {
            levelUpButtonController.Level4();

            buttonTimeFlow = 0;
        }
        if (level5 && buttonTimeFlow >= .2f && levelUpButtonController)
        {
            levelUpButtonController.Level5();

            buttonTimeFlow = 0;
        }
        if (level6 && buttonTimeFlow >= .2f && levelUpButtonController)
        {
            levelUpButtonController.Level6();

            buttonTimeFlow = 0;
        }
        if (level7 && buttonTimeFlow >= .2f && levelUpButtonController)
        {
            levelUpButtonController.Level7();

            buttonTimeFlow = 0;
        }
        if (level8 && buttonTimeFlow >= .2f && levelUpButtonController)
        {
            levelUpButtonController.Level8();

            buttonTimeFlow = 0;
        }
        if (level9 && buttonTimeFlow >= .2f && levelUpButtonController)
        {
            levelUpButtonController.Level9();

            buttonTimeFlow = 0;
        }
        if (level10 && buttonTimeFlow >= .2f && levelUpButtonController)
        {
            levelUpButtonController.Level10();

            buttonTimeFlow = 0;
        }
    }
    #endregion

    #region Menu Scene Events
    void MenuSceneButtons()
    {
        if (SceneController.CheckSceneName() == SceneController.Scenes.Menu.ToString())
        {
            playButton = gameInput.MenuSceneButtons.PlayButton.IsPressed();
            levelsButton = gameInput.MenuSceneButtons.LevelsButton.IsPressed();
            settingButton = gameInput.MenuSceneButtons.SettingButton.IsPressed();
            quitButton = gameInput.MenuSceneButtons.QuitButton.IsPressed();
            languageButton = gameInput.MenuSceneButtons.LanguageButton.IsPressed();
            menuDefaultButton = gameInput.MenuSceneButtons.MenuDefaultButton.IsPressed();
            pickCharacterButton = gameInput.MenuSceneButtons.PickCharacterButton.IsPressed();
            pickWeaponButton = gameInput.MenuSceneButtons.PickWeaponButton.IsPressed();
            continueButton = gameInput.MenuSceneButtons.ContinueButton.IsPressed();
            resetGameButton = gameInput.MenuSceneButtons.ResetGameButton.IsPressed();

            MenuSceneEvents();
        }
    }
    void MenuSceneEvents()
    {
        if (playButton && buttonTimeFlow >= .2f)
        {
            sceneController?.PlayAgain();

            buttonTimeFlow = 0;
        }
        if (levelsButton && buttonTimeFlow >= .2f)
        {
            sceneController?.LoadLevelsScene();

            buttonTimeFlow = 0;
        }
        if (settingButton && buttonClickable && buttonTimeFlow >= .2f)
        {
            settingController?.ClickSettingButton();

            buttonTimeFlow = 0;
        }
        if (quitButton && buttonTimeFlow >= .2f)
        {
            sceneController?.QuitGame();

            buttonTimeFlow = 0;
        }
        if (languageButton && buttonTimeFlow >= .2f)
        {
            sceneController?.ClickChangeLanguageButton();

            buttonTimeFlow = 0;
        }
        if (menuDefaultButton && buttonTimeFlow >= .2f)
        {
            settingController?.SetDefaulth();

            buttonTimeFlow = 0;
        }
        if (pickCharacterButton && buttonTimeFlow >= .2f)
        {
            SceneController.LoadCharacterChoosingScene();

            buttonTimeFlow = 0;
        }
        if (pickWeaponButton && buttonTimeFlow >= .2f)
        {
            sceneController?.LoadWeaponChoosingScene();

            buttonTimeFlow = 0;
        }
        if (continueButton && buttonTimeFlow >= .2f)
        {
            sceneController?.ContinueLastLevel();

            buttonTimeFlow = 0;
        }
        if (resetGameButton && buttonTimeFlow >= .2f)
        {
            sceneController?.CheckNeedResetWeaponsAndCharacters();

            buttonTimeFlow = 0;
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
        pauseButton = gameInput.TopPanelButtons.PauseButton.IsPressed();
        playAgainButton = gameInput.TopPanelButtons.PlayAgainButton.IsPressed();

        TopPanelEvents();
    }

    void PausePanelButtons()
    {
        menuButton = gameInput.PausePanelButtons.MenuButton.IsPressed();
        defaultButton = gameInput.PausePanelButtons.DefaultButton.IsPressed();

        PausePanelEvents();
    }


    void TopPanelEvents()
    {
        if (pauseButton && buttonTimeFlow >= .2f && sceneController)
        {
            sceneController.PauseGame();

            buttonTimeFlow = 0;
        }
        if (playAgainButton && buttonTimeFlow >= .2f)
        {
            sceneController.PlayAgainInLevel();

            buttonTimeFlow = 0;
        }
    }

    void PausePanelEvents()
    {
        if (menuButton && buttonTimeFlow >= .2f)
        {
            SceneController.LoadMenuScene();

            buttonTimeFlow = 0;
        }
        if (defaultButton && buttonTimeFlow >= .2f && settingController)
        {
            settingController.SetDefaulth();

            buttonTimeFlow = 0;
        }
    }
    #endregion

}
