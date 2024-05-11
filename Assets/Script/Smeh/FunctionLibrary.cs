using System;
using System.Diagnostics;
using UnityEngine;

public class FunctionLibrary : MonoBehaviour
{
    public static void Function1()
    {
        Console.WriteLine("Function 1");  
    }

    public static void Function2()
    {
        Console.WriteLine("Function 2");
    }

    public static void Function3()
    {
        Console.WriteLine("Function 3");
    }

    public static void Function4()
    {
        Console.WriteLine("Function 4");
    }

    public static void Function5()
    {
        Console.WriteLine("Function 5");
    }

    public static void Function6()
    {
        Console.WriteLine("Function 6");
    }

    public static void Function7()
    {
        Console.WriteLine("Function 7");
    }

    public static void Function8()
    {
        Console.WriteLine("Function 8");
    }

    public static void Function9()
    {
        Console.WriteLine("Function 9");
    }

    public static void Function10()
    {
        Console.WriteLine("Function 10");
    }

    public static void Function11()
    {
        Console.WriteLine("Function 11");
    }

    public static void Function12()
    {
        Console.WriteLine("Function 12");
    }

    public static void Function13()
    {
        Console.WriteLine("Function 13");
    }

    public static void Function14()
    {
        Console.WriteLine("Function 14");
    }

    public static void Function15()
    {
        Console.WriteLine("Function 15");
    }

    public static void Function16()
    {
        Console.WriteLine("Function 16");
    }

    public static void Function17()
    {
        Console.WriteLine("Function 17");
    }

    public static void Function18()
    {
        Console.WriteLine("Function 18");
    }

    public static void Function19()
    {
        Console.WriteLine("Function 19");
    }

    public static void Function20()
    {
        Console.WriteLine("Function 20");
    }

    public static void Function21()
    {
        Console.WriteLine("Function 21");
    }

    public static void Function22()
    {
        Console.WriteLine("Function 22");
    }

    public static void Function23()
    {
        Console.WriteLine("Function 23");
    }

    public void cardActivation(int functionID)
    {
        UnityEngine.Debug.Log("Working just fin");
        switch (functionID)
        {
            case 1:
                FunctionLibrary.Function1();
                break;
            case 2:
                FunctionLibrary.Function2();
                break;
            case 3:
                FunctionLibrary.Function3();
                break;
            case 4:
                FunctionLibrary.Function4();
                break;
            case 5:
                FunctionLibrary.Function5();
                break;
            case 6:
                FunctionLibrary.Function6();
                break;
            case 7:
                FunctionLibrary.Function7();
                break;
            case 8:
                FunctionLibrary.Function8();
                break;
            case 9:
                FunctionLibrary.Function9();
                break;
            case 10:
                FunctionLibrary.Function10();
                break;
            case 11:
                FunctionLibrary.Function11();
                break;
            case 12:
                FunctionLibrary.Function12();
                break;
            case 13:
                FunctionLibrary.Function13();
                break;
            case 14:
                FunctionLibrary.Function14();
                break;
            case 15:
                FunctionLibrary.Function15();
                break;
            case 16:
                FunctionLibrary.Function16();
                break;
            case 17:
                FunctionLibrary.Function17();
                break;
            case 18:
                FunctionLibrary.Function18();
                break;
            case 19:
                FunctionLibrary.Function19();
                break;
            case 20:
                FunctionLibrary.Function20();
                break;
            case 21:
                FunctionLibrary.Function21();
                break;
            case 22:
                FunctionLibrary.Function22();
                break;
            case 23:
                FunctionLibrary.Function23();
                break;
            default:
                Console.WriteLine("Invalid function ID.");
                break;
        }
    }
}
