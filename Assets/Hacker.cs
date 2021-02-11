using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game Configuration Data
    const string menuHint = "You may type menu at any time.";
    string[] level1Passwords = { "Worms", "Minecraft", "Arma", "Monaco", "Portal" };
    string[] level2Passwords = { "Rocket League", "Elite Dangerous", "Lethal League Blaze", "Killing Floor", "Hotline Miami" };
    string[] level3Passwords = { "Return of the Obra Dinn", "Risk of Rain", "Warhammer Vermintide", "A Hat in Time", "Crypt of the Necrodancer" };

    //Game state
    int level;
    enum Screen {MainMenu, Password, Win};
    Screen currentScreen;
    string password;
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu("Hello Aldym");
    }
    void ShowMainMenu(string greeting)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("What game should you decipher now?");
        Terminal.WriteLine("Press 1 for a easy game to decipher.");
        Terminal.WriteLine("Press 2 for a medium game to decipher.");
        Terminal.WriteLine("Press 3 for a hard game to decipher.");
        Terminal.WriteLine("Enter your selection:");
     }

    void OnUserInput(string input)
    {
        if (input == "menu") // zawsze można uciec do menu
        {
            ShowMainMenu("");
        }
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("If on the web close the tab.");
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "69") //easter eggs
        {
            Terminal.WriteLine("Nice");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint:" + password.Anagram());
        Terminal.WriteLine(menuHint);
    }
    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }
    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
            Terminal.WriteLine(menuHint);
        }
        else
        {
            AskForPassword();
        }
        void DisplayWinScreen()
        {
            currentScreen = Screen.Win;
            Terminal.ClearScreen();
            Terminal.WriteLine("Well done!");

        }
    }
}
