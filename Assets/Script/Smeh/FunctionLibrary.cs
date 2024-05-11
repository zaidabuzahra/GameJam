using System;
using UnityEngine;

//PlayerSignals.Instance.onPlayerDie?.Invoke();


// To adjust a players points, use PlayerSignals.Instance.onPlayerGainPoint?.Invoke(amount). 
// Amount determines what happens to the value: To add an amount, just type a number. To decreese it type a negative number;
// To double the amount put in any number bigger than 4000....To set it to zero just type zero

public class FunctionLibrary : MonoBehaviour
{
    public static void Function1()
    {
        Debug.Log("Function 1");
        GunSignals.Instance.onPlayAnimation?.Invoke();
        int shot = UnityEngine.Random.Range(1, 6); 
        if(shot == 1 || shot ==2){
            PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
            PlayerSignals.Instance.onPlayerGainPoint?.Invoke(250);
        } else PlayerSignals.Instance.onPlayerDie?.Invoke();
    }

    public static void Function2()
    {
        UnityEngine.Debug.Log("Function 2");
        
        int shot = UnityEngine.Random.Range(1, 6); 
        if(shot == 1 || shot == 2 || shot == 3){
            PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
            // +150 to current player
        } else PlayerSignals.Instance.onPlayerDie?.Invoke();
    }

    public static void Function3()
    {
        Console.WriteLine("Function 3");
        
        int shot = UnityEngine.Random.Range(1, 6); 
        if(shot == 1 || shot == 2 || shot == 3 || shot == 4){
            PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
            // +100 to current player
        } else PlayerSignals.Instance.onPlayerDie?.Invoke();
    }

    public static void Function4()
    {
        Console.WriteLine("Function 4");

        int shot = UnityEngine.Random.Range(1, 6); 

        // pick a player
        // if(self){
        //     if (shot == 1)
        //     PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
        //     // +250 
        //     else{
        //         shot = UnityEngine.Random.Range(1, 6);
        //         if (shot == 1)
        //         PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
        //     }
        // } else{
        //     if (shot == 1)
        //     PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
        //     // +750
        // }  else PlayerSignals.Instance.onPlayerDie?.Invoke();
    }

    public static void Function5()
    {
        Console.WriteLine("Function 5");

        // shoot next player
        // +250 on kill
    }

    public static void Function6()
    {
        Console.WriteLine("Function 6");

        int shot = UnityEngine.Random.Range(1, 6); 
        if(shot == 1 || shot ==2){
            PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
            // +450 to current player
        }  else PlayerSignals.Instance.onPlayerDie?.Invoke();
        // pass to next player with picked number removed
    }

    public static void Function7()
    {
        Console.WriteLine("Function 7");

        int ran = UnityEngine.Random.Range(1, 4);
        int input = Convert.ToInt32(Console.ReadLine());
        int shot = UnityEngine.Random.Range(1, 6);
        switch(input){
            case 1:
            if(shot == 1 || shot ==2 || shot == 3 || shot == 4 || shot == 5){
                PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
                // +50 to current player
                } else PlayerSignals.Instance.onPlayerDie?.Invoke();
                break;
            case 2:
            if(shot == 1 || shot ==2|| shot == 3 || shot == 4){
                PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
                // +100 to current player
                } else PlayerSignals.Instance.onPlayerDie?.Invoke();   
                break;
            case 3:
            if(shot == 1 || shot ==2 || shot == 3){
                PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
                // +150 to current player
                } else PlayerSignals.Instance.onPlayerDie?.Invoke();   
                break;
            case 4:
            if(shot == 1 || shot ==2){
                PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
                // +200 to current player
                } else PlayerSignals.Instance.onPlayerDie?.Invoke();   
                break;
            case 5:
            if(shot == 1){
                PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
                // +500 to current player
                } else PlayerSignals.Instance.onPlayerDie?.Invoke();   
                break;
            default:
                Console.WriteLine("Invalid function ID.");
                break;
        }
    }

    public static void Function8()
    {
        Console.WriteLine("Function 8");

        // if 1 player dies everyone dies
    }

    public static void Function9()
    {
        Console.WriteLine("Function 9");

        int shot = UnityEngine.Random.Range(1, 6); 
        if(shot == 1){
            shot = UnityEngine.Random.Range(1, 6);
            if(shot == 1){
                PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
                // +2000
            } else PlayerSignals.Instance.onPlayerDie?.Invoke(); 
        } else PlayerSignals.Instance.onPlayerDie?.Invoke();
    }

    public static void Function10()
    {
        Console.WriteLine("Function 10");

        // find out how many alive players
        // if all alive kill everyone
        // if one dead alive players get +500
    }

    public static void Function11()
    {
        Console.WriteLine("Function 11");

        int shot = UnityEngine.Random.Range(1, 6); 
        if(shot != 1){
            PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
            // +200 to current player
        } else PlayerSignals.Instance.onPlayerDie?.Invoke();
    }

    public static void Function12()
    {
        Console.WriteLine("Function 12");

        int shot = UnityEngine.Random.Range(1, 6); 
        if(shot == 1){
            PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
            // +250 to current player
        } else {
            shot = UnityEngine.Random.Range(1, 6); 
            if(shot == 1){
            PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
            // +250 to current player
        }else PlayerSignals.Instance.onPlayerDie?.Invoke();
        }
    }

    public static void Function13()
    {
        Console.WriteLine("Function 13");

        // repeat for each player
        int bullets = UnityEngine.Random.Range(1, 6);
        int shot = UnityEngine.Random.Range(1, 6);
        switch(bullets){
            case 1:
            if(shot == 1 || shot ==2 || shot == 3 || shot == 4 || shot == 5){
                PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
                // +400 to current player
                } else PlayerSignals.Instance.onPlayerDie?.Invoke();
                break;
            case 2:
            if(shot == 1 || shot ==2|| shot == 3 || shot == 4){
                PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
                // +400 to current player
                } else PlayerSignals.Instance.onPlayerDie?.Invoke();   
                break;
            case 3:
            if(shot == 1 || shot ==2 || shot == 3){
                PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
                // +400 to current player
                } else PlayerSignals.Instance.onPlayerDie?.Invoke();   
                break;
            case 4:
            if(shot == 1 || shot ==2){
                PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
                // +400 to current player
                } else PlayerSignals.Instance.onPlayerDie?.Invoke();   
                break;
            case 5:
            if(shot == 1){
                PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
                // +400 to current player
                } else PlayerSignals.Instance.onPlayerDie?.Invoke();   
                break;
            default:
                Console.WriteLine("Invalid function ID.");
                break;
        }
    }

    public static void Function14()
    {
        Console.WriteLine("Function 14");

        int shot = UnityEngine.Random.Range(1, 6); 
        if(shot == 1 || shot == 2 || shot == 3){
            PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
            // double points
        } else {
            PlayerSignals.Instance.onPlayerDie?.Invoke();
            // set points to 0
            }
    }

    public static void Function15()
    {
        Console.WriteLine("Function 15");

        int shot = UnityEngine.Random.Range(1, 6); 
        if(shot == 1 || shot ==2){
            PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
            // +500 to current player
        } else PlayerSignals.Instance.onPlayerDie?.Invoke();
        // do same for next player until only one survives
    }

    public static void Function16()
    {
        Console.WriteLine("Function 16");

        int shot = UnityEngine.Random.Range(1, 6); 
        if(shot == 1){
            PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
            // +500 to current player
        } else PlayerSignals.Instance.onPlayerDie?.Invoke();
    }

    public static void Function17()
    {
        Console.WriteLine("Function 17");

        int shot = UnityEngine.Random.Range(1, 100); 
        if(shot == 1){
            PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
            // win game
        } else PlayerSignals.Instance.onPlayerDie?.Invoke();
    }

    public static void Function18()
    {
        Console.WriteLine("Function 18");

        int shot = UnityEngine.Random.Range(1, 6); 
        while(shot != 1){
            // shoot 
            PlayerSignals.Instance.onPlayerDie?.Invoke();
            // -100 points
            if(shot == 1){
                PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
                break;
            }
        }
    }

    public static void Function19()
    {
        Console.WriteLine("Function 19");

        // flipped survive and death since we want to die 6 times in a row
        int shot = UnityEngine.Random.Range(1, 6); 
        for(int i=0; i<7; i++){
            if(shot == 1){
                PlayerSignals.Instance.onPlayerDie?.Invoke();
                break;
            }
            PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
            shot = UnityEngine.Random.Range(1, 6); 
        }
    }

    public static void Function20()
    {
        Console.WriteLine("Function 20");

        int shot = UnityEngine.Random.Range(1, 6); 
        if(shot == 1){
            PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
            shot = UnityEngine.Random.Range(1, 6);
            // shoot someone else
            if(shot!=1){
                // next player dies
                // +500 to current player
            }
        } else PlayerSignals.Instance.onPlayerDie?.Invoke();
    }

    public static void Function21()
    {
        Console.WriteLine("Function 21");

        int ran = UnityEngine.Random.Range(1, 4);
        // player number random -300
        // other players +100
    }

    public static void Function22()
    {
        Console.WriteLine("Function 22");

        // each player random quirk
        int ran = UnityEngine.Random.Range(1, 23);
        //FunctionLibrary.cardActivation(ran);
    }

    public static void Function23()
    {
        Console.WriteLine("Function 23");

        // each player can rewind one result
        // idk how 
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
