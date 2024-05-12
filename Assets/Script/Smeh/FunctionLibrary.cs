using System;
using System.Diagnostics.Tracing;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//PlayerSignals.Instance.onPlayerDie?.Invoke();


// To adjust a players points, use PlayerSignals.Instance.onPlayerGainPoint?.Invoke(amount). 
// Amount determines what happens to the value: To add an amount, just type a number. To decreese it type a negative number;
// To double the amount put in any number bigger than 4000....To set it to zero just type zero

public class FunctionLibrary: MonoBehaviour
{
    bool f2shotNext = false;
    int f6num = 1;
    int f6num2 = 6;
    bool f17shooter = true;
    bool f10Restart = false;
    int f10Alive = 0;
    bool f15Skip = false;
    int f15Chosen;
    int f15PlayerNum = 0;
    int f21Chosen;
    int f21PLayerNum = 0;
    bool f20IsDead = false;
    int count = 0;

    private void Awake()
    {
        f21Chosen = UnityEngine.Random.Range(1, 4);
        f15Chosen = UnityEngine.Random.Range(1, 4);
    }
    private void OnEnable()
    {
        CoreGameSignals.Instance.onResetFunction += RestartFunc6;
        CoreGameSignals.Instance.onResetPerTurn += RestartPerTurn;
    }

    public void Function1()
    {
        Debug.Log("Function 1");
        int shot = UnityEngine.Random.Range(1, 6); 
        if(shot == 1 || shot ==2){
            PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
            PlayerSignals.Instance.onPlayerGainPoint?.Invoke(250);
        } else PlayerSignals.Instance.onPlayerDie?.Invoke();
    }

    public void Function2()
    {
        UnityEngine.Debug.Log("Function 2");
        
        int shot = UnityEngine.Random.Range(1,4); 
        if(shot == 1){
            PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
            PlayerSignals.Instance.onPlayerGainPoint?.Invoke(150);
        } else PlayerSignals.Instance.onPlayerDie?.Invoke();
    }

    public void Function3()
    {
        Console.WriteLine("Function 3");
        
        int shot = UnityEngine.Random.Range(1, 6); 
        if(shot == 1 || shot == 2 || shot == 3 || shot == 4){
            PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
            PlayerSignals.Instance.onPlayerGainPoint?.Invoke(100);
        } else PlayerSignals.Instance.onPlayerDie?.Invoke();
    }

    public void Function4()
    {
        Console.WriteLine("Function 4");

        int shot = UnityEngine.Random.Range(1, 6);
        if(shot != 1){
            shot = UnityEngine.Random.Range(1, 5);
            if(shot == 1){
                PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
                PlayerSignals.Instance.onPlayerGainPoint?.Invoke(250);
            } else PlayerSignals.Instance.onPlayerDie?.Invoke(); 
        }  else {
            PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
            PlayerSignals.Instance.onPlayerGainPoint?.Invoke(250);
        }
    }

    public void Function5()
    {
        Console.WriteLine("Function 5");

        if(f2shotNext){
            f2shotNext = false;
            return;
        } 

        // shoot next player
        int shot = UnityEngine.Random.Range(1, 6); 
        if(shot != 1){
            f2shotNext = true;
            PlayerSignals.Instance.onPlayerGainPoint?.Invoke(250);
        } else PlayerSignals.Instance.onPlayerGainPoint?.Invoke(-100);;
    }

    public void Function6()
    {
        GunSignals.Instance.onPlayAnimation?.Invoke(); 
        Debug.LogWarning(f6num + " " + f6num2);

        int shot = UnityEngine.Random.Range(f6num, f6num2);
        if (shot == 5 || shot == 6)
        {
            PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
            PlayerSignals.Instance.onPlayerGainPoint?.Invoke(450);
            f6num2--;
        }
        else
        {
            PlayerSignals.Instance.onPlayerDie?.Invoke();
            f6num++;
        }
    }

    private void RestartFunc6()
    {
        f6num = 1;
        f6num2 = 6;
    }

    private void RestartPerTurn()
    {
        count = 0;
        Debug.LogWarning("Function Restarted");
    }

    public void Function7()
    {
        Console.WriteLine("Function 7");

        int ran = UnityEngine.Random.Range(1, 5);
        int shot = UnityEngine.Random.Range(1, 6);
        switch(ran){
            case 1:
            if(shot == 1){
                PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
                PlayerSignals.Instance.onPlayerGainPoint?.Invoke(500);
                } else PlayerSignals.Instance.onPlayerDie?.Invoke();   
                break;
            case 2:
            if(shot == 1 || shot == 2){
                PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
                PlayerSignals.Instance.onPlayerGainPoint?.Invoke(200);
                } else PlayerSignals.Instance.onPlayerDie?.Invoke();   
                break;
            case 3:
            if(shot == 1 || shot == 2 || shot == 3){
                PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
                PlayerSignals.Instance.onPlayerGainPoint?.Invoke(150);
                } else PlayerSignals.Instance.onPlayerDie?.Invoke();   
                break;
            case 4:
            if(shot == 1 || shot == 2|| shot == 3 || shot == 4){
                PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
                PlayerSignals.Instance.onPlayerGainPoint?.Invoke(100);
                } else PlayerSignals.Instance.onPlayerDie?.Invoke();   
                break;
            case 5:
            if(shot == 1 || shot == 2 || shot == 3 || shot == 4 || shot == 5){
                PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
                PlayerSignals.Instance.onPlayerGainPoint?.Invoke(50);
                } else PlayerSignals.Instance.onPlayerDie?.Invoke();
                break;
            default:
                Console.WriteLine("Invalid function ID.");
                break;
        }
    }

    public void Function8()
    {
        Console.WriteLine("Function 8");

        // if 1 player dies everyone dies
        int shot = UnityEngine.Random.Range(1, 6); 
        if(shot != 1){
            PlayerSignals.Instance.onPlayerDie?.Invoke();
            // end turn
        } else PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
    }

    public void Function9()
    {
        Console.WriteLine("Function 9");

        int shot = UnityEngine.Random.Range(1, 6); 
        if(shot == 1){
            shot = UnityEngine.Random.Range(1, 6);
            if(shot == 1){
                PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
                PlayerSignals.Instance.onPlayerGainPoint?.Invoke(2000);
            } else PlayerSignals.Instance.onPlayerDie?.Invoke(); 
        } else PlayerSignals.Instance.onPlayerDie?.Invoke();
    }

    public void Function10()
    {
        Console.WriteLine("Function 10");

        if(f10Restart) SceneManager.LoadScene("Sample Scene");
        if(f10Alive == 4) f10Restart = true;

        int shot = UnityEngine.Random.Range(1, 6); 
        if(shot == 1){
            f10Alive ++;
            PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
        } else PlayerSignals.Instance.onPlayerDie?.Invoke();
    }

    public void Function11()
    {
        Debug.LogWarning(count);

        int shot = UnityEngine.Random.Range(1, 6); 
        if(shot != 1){
            PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
            PlayerSignals.Instance.onPlayerGainPoint?.Invoke(200);
        } else PlayerSignals.Instance.onPlayerDie?.Invoke();
    }

    public void Function12()
    {
        Console.WriteLine("Function 12");

        int shot = UnityEngine.Random.Range(1, 6); 
        if(shot == 1){
            PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
            PlayerSignals.Instance.onPlayerGainPoint?.Invoke(250);
        } else {
            shot = UnityEngine.Random.Range(1, 6); 
            if(shot == 1){
            PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
            PlayerSignals.Instance.onPlayerGainPoint?.Invoke(250);
        }else PlayerSignals.Instance.onPlayerDie?.Invoke();
        }
    }

    public void Function13()
    {
        Console.WriteLine("Function 13");

        // repeat for each player
        int bullets = UnityEngine.Random.Range(1, 6);
        int shot = UnityEngine.Random.Range(1, 6);
        switch(bullets){
            case 1:
            if(shot == 1 || shot ==2 || shot == 3 || shot == 4 || shot == 5){
                PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
                PlayerSignals.Instance.onPlayerGainPoint?.Invoke(400);
                } else PlayerSignals.Instance.onPlayerDie?.Invoke();
                break;
            case 2:
            if(shot == 1 || shot ==2|| shot == 3 || shot == 4){
                PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
                PlayerSignals.Instance.onPlayerGainPoint?.Invoke(400);
                } else PlayerSignals.Instance.onPlayerDie?.Invoke();   
                break;
            case 3:
            if(shot == 1 || shot ==2 || shot == 3){
                PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
                PlayerSignals.Instance.onPlayerGainPoint?.Invoke(400);
                } else PlayerSignals.Instance.onPlayerDie?.Invoke();   
                break;
            case 4:
            if(shot == 1 || shot ==2){
                PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
                PlayerSignals.Instance.onPlayerGainPoint?.Invoke(400);
                } else PlayerSignals.Instance.onPlayerDie?.Invoke();   
                break;
            case 5:
            if(shot == 1){
                PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
                PlayerSignals.Instance.onPlayerGainPoint?.Invoke(400);
                } else PlayerSignals.Instance.onPlayerDie?.Invoke();   
                break;
            default:
                Console.WriteLine("Invalid function ID.");
                break;
        }
    }

    public void Function14()
    {
        Console.WriteLine("Function 14");

        int shot = UnityEngine.Random.Range(1, 6); 
        if(shot == 1 || shot == 2 || shot == 3){
            PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
            PlayerSignals.Instance.onPlayerGainPoint?.Invoke(4000);
        } else {
            PlayerSignals.Instance.onPlayerDie?.Invoke();
            PlayerSignals.Instance.onPlayerGainPoint?.Invoke(0);
            }
    }

    public void Function15()
    {
        Console.WriteLine("Function 15");

        if(f15Skip) return;
        f15PlayerNum ++;

        int shot = UnityEngine.Random.Range(1, 6);
        if(f15PlayerNum == f15Chosen){
            if(shot == 1){
                f15Skip = true;
                PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
                PlayerSignals.Instance.onPlayerGainPoint?.Invoke(400);
            } else PlayerSignals.Instance.onPlayerDie?.Invoke();
        }
        if(shot == 1){
            f15Skip = true;
            PlayerSignals.Instance.onPlayerSUrvive?.Invoke();

        } else PlayerSignals.Instance.onPlayerDie?.Invoke();
    }

    public void Function16()
    {
        Console.WriteLine("Function 16");

        int shot = UnityEngine.Random.Range(1, 6); 
        if(shot == 1){
            PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
            PlayerSignals.Instance.onPlayerGainPoint?.Invoke(500);
        } else PlayerSignals.Instance.onPlayerDie?.Invoke();
    }

    public void Function17()
    {
        Console.WriteLine("Function 17");

        if(!f17shooter) return;
        int shot = UnityEngine.Random.Range(1, 100); 
        if(shot == 1){
            f17shooter = false;
            PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
            PlayerSignals.Instance.onPlayerGainPoint?.Invoke(5000);
        } else PlayerSignals.Instance.onPlayerDie?.Invoke();
    }

    public void Function18()
    {
        Console.WriteLine("Function 18");

        int i = 6;
        int shot = UnityEngine.Random.Range(1, i); 
        while(shot != 1){
            PlayerSignals.Instance.onPlayerGainPoint?.Invoke(-100);
            i --;
            shot = UnityEngine.Random.Range(1, i);
            if(shot == 1){
                PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
                return;
            }
        }
        PlayerSignals.Instance.onPlayerDie?.Invoke();
    }

    public void Function19()
    {
        count++;
        if (count > 6) return;
        // flipped survive and death since we want to die 6 times in a row
        int shot = UnityEngine.Random.Range(1, 6);
        if (shot == 1)
        {
            Debug.LogWarning(count);
            PlayerSignals.Instance.onPlayerDie?.Invoke();
            return;
        }
        Debug.Log(count);
        PlayerSignals.Instance.onPlayerCanSHoot?.Invoke();
        //shot = UnityEngine.Random.Range(1, 6);
        if (count == 6)
        {
            PlayerSignals.Instance.onPlayerGainPoint?.Invoke(750);
            PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
        }
    }

    public void Function20()
    {
        Console.WriteLine("Function 20");

        if(f20IsDead){
            f20IsDead = false;
            return;
        }
        int shot = UnityEngine.Random.Range(1, 6); 
        if(shot == 1){
            PlayerSignals.Instance.onPlayerSUrvive?.Invoke();
            shot = UnityEngine.Random.Range(1, 6);
            // shoot next player
            if(shot!=1){
                f20IsDead = true;
                PlayerSignals.Instance.onPlayerGainPoint?.Invoke(500);
            }
        } else PlayerSignals.Instance.onPlayerDie?.Invoke();
    }


    public void Function21()
    {
        Console.WriteLine("Function 21");

        int ran = UnityEngine.Random.Range(1, 4);
        f21PLayerNum ++;
        if(f21PLayerNum == f21Chosen) PlayerSignals.Instance.onPlayerGainPoint?.Invoke(300);
        else PlayerSignals.Instance.onPlayerGainPoint?.Invoke(-100);
    }

    public void Function22()
    {
        Console.WriteLine("Function 22");

        int ran = UnityEngine.Random.Range(1, 22);
        cardActivation(ran);
    }

    public void cardActivation(int functionID)
    {
        UnityEngine.Debug.Log("Working just fin");
        switch (functionID)
        {
            case 1:
                Function1();
                break;
            case 2:
                Function2();
                break;
            case 3:
                Function3();
                break;
            case 4:
                Function6();
                break;
            case 5:
                Function7();
                break;
            case 6:
                Function13();
                break;
            case 7:
                Function14();
                break;
            case 8:
                Function16();
                break;
            case 9:
                Function19();
                break;
            // case 10:
            //     Function10();
            //     break;
            // case 11:
            //     Function11();
            //     break;
            // case 12:
            //     Function12();
            //     break;
            // case 13:
            //     Function13();
            //     break;
            // case 14:
            //     Function14();
            //     break;
            // case 15:
            //     Function15();
            //     break;
            // case 16:
            //     Function16();
            //     break;
            // case 17:
            //     Function17();
            //     break;
            // case 18:
            //     Function18();
            //     break;
            // case 19:
            //     Function19();
            //     break;
            // case 20:
            //     Function20();
            //     break;
            // case 21:
            //     Function21();
            //     break;
            // case 22:
            //     Function22();
            //     break;
            default:
                Console.WriteLine("Invalid function ID.");
                break;
        }
    }
}
