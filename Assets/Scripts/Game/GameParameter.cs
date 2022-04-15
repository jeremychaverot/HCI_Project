using System;
using UnityEngine;

// Static class to store the game parameters
public static class GameParameter
{
    // Default timer
    public static float gameTimer = 2f; 
    // Default player inputs
    public static MoveWithKeyboardBehavior.InputKeyboard[] inputs = { MoveWithKeyboardBehavior.InputKeyboard.wasd,
                                                                        MoveWithKeyboardBehavior.InputKeyboard.arrows };
    // Default colors
    public static Color[] colors = { Color.blue, Color.magenta };
    private static Color[] colorList = { Color.black, Color.blue, Color.cyan,
                                            Color.green, Color.grey, Color.magenta,
                                            Color.red, Color.white, Color.yellow };
    private static String[] colorNames = { "black", "blue", "cyan",
                                            "green", "grey", "purple",
                                            "red", "white", "yellow" };

    // Our own mod function since % with negative integer does not work
    private static int mod(int x, int m)
    {
        return (x % m + m) % m;
    }

    public static void SetGameTimer(float timer)
    {
        gameTimer = timer;
    }

    public static void SetPlayerInput(GameManager.Players player, MoveWithKeyboardBehavior.InputKeyboard input)
    {
        inputs[(int) player] = input;
    }

    public static String getColorName(Color color)
    {
        return colorNames[Array.IndexOf(colorList, color)];
    }

    public static void PlayerNextColor(GameManager.Players player)
    {
        colors[(int)player] = colorList[(Array.IndexOf(colorList, colors[(int)player]) + 1) % colorList.Length];
    }

    public static void PlayerPreviousColor(GameManager.Players player)
    {
        colors[(int)player] = colorList[mod((Array.IndexOf(colorList, colors[(int)player]) - 1), colorList.Length)];
    }

    // To reset the game parameters
    public static void ResetGameParameter()
    {
        gameTimer = 2f;

        inputs[0] = MoveWithKeyboardBehavior.InputKeyboard.wasd;
        inputs[1] = MoveWithKeyboardBehavior.InputKeyboard.arrows;

        colors[0] = Color.blue;
        colors[1] = Color.magenta;
    }
}