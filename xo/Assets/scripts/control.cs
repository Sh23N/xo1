using UnityEngine.SceneManagement;
using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;


public class control : MonoBehaviour
{
    public int whoturn;
    public GameObject[] turnIcons;
    public Sprite[] playerIcons;
    public Button[] spaces;
    public static char Winer;// winner 
  

 
    private float T=5.0f;// this is period of every turn
    private float t=0.0f;//this is time

    public Image board;
    
    public TMP_Text timer;

    private int index;//how many buttons marked

    public TMP_Text winer_is;

    public Canvas winerCsnvas;

    public Button retry;

    private int Xforget;// how many times x is forget to mark in its turn
    private int Oforget;// how many times o is forget to mark in its turn

    private bool end;//when end game -> end=true

    // Start is called before the first frame update
    void Start()
    {   
        setup();
    }

    // Update is called once per frame
    void Update()
    {
        T -= Time.deltaTime;
        t = T % 60;//convert to seccond
        if (!end)
        {
            if (t <= 0)  //when 
            {
                if (whoturn == 0)
                    Xforget++;
                else
                    Oforget++;
                T = 5.0f;

                turnToggle();
            }
        }
        timer.text = Math.Round(t).ToString();
        if (Xforget == 3)// if x forget for 3 time -> o is winner
            showWiner('o');
        if (Oforget == 3)
            showWiner('x');// if o forget for 3 time -> x is winner

    }
    void setup()
    {
        whoturn = 0;
        turnIcons[0].SetActive(true);
        turnIcons[1].SetActive(false);
        for (int i = 0; i < spaces.Length; i++)
        {
                spaces[i].interactable = true;
                spaces[i].GetComponent<Image>().sprite = null;
        }
  

    }
    public void button(int k)//when player press buttons(3*3)
    { 
        spaces[k].image.sprite = playerIcons[whoturn];
        spaces[k].interactable = false;
        Winer = winer(k);
        if(Winer=='o' || Winer=='x')
            end = true;
        showWiner(Winer);
       
        turnToggle();
        T = 5.0f;
      
        index++;
        if (index == 9)
        {
            winer_is.text = "dont any winner";
        }

        /* i cant access hit with unity 2D !!!
        RaycastHit2d hit;
        if(Physics2D.Raycast(spaces[i].transform.position, spaces[i].transform.right,out hit,800) ) 
        {
            print("found...........");
        }*/
    }
    public void turnToggle()//x->o , o->x
    {
        if (whoturn == 0)
        {
            whoturn=1;
            turnIcons[1].SetActive(true);
            turnIcons[0].SetActive(false);
            board.transform.Rotate(new Vector3(0,0,-180));//rotate board to o player

        }
        else
        {
            whoturn=0;
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
            board.transform.Rotate(new Vector3(0, 0, 180));//rotate board to x player

        }
     
        
    }
    public char winer(int k)
    {
        int j = k / 3;//j=row
        int i = k % 3;//i==column

        if (j == 0)
        {
            if ((spaces[0].image.sprite == spaces[1].image.sprite) && (spaces[1].image.sprite == spaces[2].image.sprite))
            {
                if (whoturn == 0)
                    return 'x'; //xwin
                else
                    return 'o'; //oxin
            }
        }
        if (j == 1)
        {
            if ((spaces[3].image.sprite == spaces[4].image.sprite) && (spaces[4].image.sprite == spaces[5].image.sprite))
            {
                if (whoturn == 0)
                    return 'x';  //xwin
                else
                    return 'o';//oxin
            }
        }
        if (j == 2)
        {
            if ((spaces[6].image.sprite == spaces[7].image.sprite) && (spaces[7].image.sprite == spaces[8].image.sprite))
            {
                if (whoturn == 0)
                    return 'x'; //xwin
                else
                    return 'o';//oxin
            }
        }

        if (i == 0)
        {
            if ((spaces[0].image.sprite == spaces[3].image.sprite) && (spaces[3].image.sprite == spaces[6].image.sprite))
            {
                if (whoturn == 0)
                    return 'x'; //xwin
                else
                    return 'o';//oxin
            }
        }
        if (i == 1)
        {
            if ((spaces[1].image.sprite == spaces[4].image.sprite) && (spaces[4].image.sprite == spaces[7].image.sprite))
            {
                if (whoturn == 0)
                    return 'x'; //xwin
                else
                    return 'o';//oxin
            }
        }
        if (i == 2)
        {
            if ((spaces[2].image.sprite == spaces[5].image.sprite) && (spaces[5].image.sprite == spaces[8].image.sprite))
            {
                if (whoturn == 0)
                    return 'x'; //xwin
                else
                    return 'o';//oxin
            }
        }
        if (i == j)
        {
            if ((spaces[0].image.sprite == spaces[4].image.sprite) && (spaces[4].image.sprite == spaces[8].image.sprite))
            {
                if (whoturn == 0)
                    return 'x'; //xwin
                else
                    return 'o'; //oxin
            }
        }
        //must perivius
        if (i + j == 2)
        {
            if ((spaces[2].image.sprite == spaces[4].image.sprite) && (spaces[4].image.sprite == spaces[6].image.sprite))
            {
                if (whoturn == 0)
                    return 'x'; //xwin
                else
                    return 'o';//oxin
            }
        }
        return 'n';//there is no winner in this time
    }
    void showWiner(char Winer)
    {
        if (Winer != 'n')//when x or o is winner (ther is a winner)
        {
            winerCsnvas.gameObject.SetActive(true);
            for (int i = 0; i < spaces.Length; i++)
            {
                spaces[i].interactable = false;
            }

            if (whoturn == 0)
                winer_is.text = "X is winner";
            else
                winer_is.text = "O is winner";
            timer.gameObject.SetActive(false);
        }
        
       

    }
    public void retryOnClick()
    {
        SceneManager.LoadScene("Game");
    }
}
