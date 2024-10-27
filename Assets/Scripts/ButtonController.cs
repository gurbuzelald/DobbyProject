using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private MenuInput menuInput;

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

            weaponButtonBools[0] = menuInput.PickWeaponSceneButtons.Pistol.IsPressed();
            weaponButtonBools[1] = menuInput.PickWeaponSceneButtons.Axe.IsPressed();
            weaponButtonBools[2] = menuInput.PickWeaponSceneButtons.Bulldog.IsPressed();
            weaponButtonBools[3] = menuInput.PickWeaponSceneButtons.Cow.IsPressed();
            weaponButtonBools[4] = menuInput.PickWeaponSceneButtons.Crystal.IsPressed();
            weaponButtonBools[5] = menuInput.PickWeaponSceneButtons.Demon.IsPressed();
            weaponButtonBools[6] = menuInput.PickWeaponSceneButtons.Ice.IsPressed();
            weaponButtonBools[7] = menuInput.PickWeaponSceneButtons.Electro.IsPressed();
            weaponButtonBools[8] = menuInput.PickWeaponSceneButtons.Shotgun.IsPressed();
            weaponButtonBools[9] = menuInput.PickWeaponSceneButtons.Machine.IsPressed();
            PickWeaponEvents();
        }
    }
    /*public bool GetButton(string weaponName)
    {
        if (weaponName == bulletData.weaponStruct[0].weaponName)
        {
            return Pistol;
        }
        else if (weaponName == bulletData.weaponStruct[1].weaponName)
        {
            return Axe;
        }
        else if (weaponName == bulletData.weaponStruct[2].weaponName)
        {
            return Bulldog;
        }
        else if (weaponName == bulletData.weaponStruct[3].weaponName)
        {
            return Cow;
        }
        else if (weaponName == bulletData.weaponStruct[4].weaponName)
        {
            return Crystal;
        }
        else if (weaponName == bulletData.weaponStruct[5].weaponName)
        {
            return Demon;
        }
        else if (weaponName == bulletData.weaponStruct[6].weaponName)
        {
            return Ice;
        }
        else if (weaponName == bulletData.weaponStruct[7].weaponName)
        {
            return Electro;
        }
        else if (weaponName == bulletData.weaponStruct[8].weaponName)
        {
            return ShotGun;
        }
        else if (weaponName == bulletData.weaponStruct[9].weaponName)
        {
            return Machine;
        }
        else
        {
            return false;
        }
    }*/

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


            characterButtonBools[0] = menuInput.PickCharacterSceneButtons.A.IsPressed();
            characterButtonBools[1] = menuInput.PickCharacterSceneButtons.B.IsPressed();
            characterButtonBools[2] = menuInput.PickCharacterSceneButtons.C.IsPressed();
            characterButtonBools[3] = menuInput.PickCharacterSceneButtons.D.IsPressed();
            characterButtonBools[4] = menuInput.PickCharacterSceneButtons.E.IsPressed();
            characterButtonBools[5] = menuInput.PickCharacterSceneButtons.F.IsPressed();
            characterButtonBools[6] = menuInput.PickCharacterSceneButtons.G.IsPressed();
            characterButtonBools[7] = menuInput.PickCharacterSceneButtons.I.IsPressed();
            characterButtonBools[8] = menuInput.PickCharacterSceneButtons.J.IsPressed();
            characterButtonBools[9] = menuInput.PickCharacterSceneButtons.K.IsPressed();
            characterButtonBools[10] = menuInput.PickCharacterSceneButtons.L.IsPressed();
            

            PickCharacterEvents();
        }    
    }
    public bool GetButtonState(int characteID)
    {
        if (characteID == playerData.characterStruct[0].id)
        {
            return characterButtonBools[0];
        }
        else if (characteID == playerData.characterStruct[1].id)
        {
            return characterButtonBools[1];
        }
        else if (characteID == playerData.characterStruct[2].id)
        {
            return characterButtonBools[2];
        }
        else if (characteID == playerData.characterStruct[3].id)
        {
            return characterButtonBools[3];
        }
        else if (characteID == playerData.characterStruct[4].id)
        {
            return characterButtonBools[4];
        }
        else if (characteID == playerData.characterStruct[5].id)
        {
            return characterButtonBools[5];
        }
        else if (characteID == playerData.characterStruct[6].id)
        {
            return characterButtonBools[6];
        }
        else if (characteID == playerData.characterStruct[7].id)
        {
            return characterButtonBools[7];
        }
        else if (characteID == playerData.characterStruct[8].id)
        {
            return characterButtonBools[8];
        }
        else if (characteID == playerData.characterStruct[9].id)
        {
            return characterButtonBools[9];
        }
        else if (characteID == playerData.characterStruct[10].id)
        {
            return characterButtonBools[10];
        }
        else
        {
            return false;
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
