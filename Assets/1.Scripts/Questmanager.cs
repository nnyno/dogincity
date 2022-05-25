using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Questmanager : MonoBehaviour
{
    public Text questtext1, questtext2;
    public int count = 0;
    public PlayerMovement PlayerMovement;
    public Corgicollder Corgicollder;
    public int questdelayTime = 1;
    public bool questdelay = false;

    void Start()
    {
        PlayerMovement = GameObject.Find("Corgi_RM").GetComponent<PlayerMovement>();
        Corgicollder = GameObject.Find("CorgiCollder").GetComponent<Corgicollder>();
    }

    void Update()
    {
        
        if(!questdelay)
        {
            quest();
            questcount();
            questtext2.text = questtext1.text;
        }
    }

    void quest()
    {
        
        if(count == 0)
        {
            questtext1.text = "(튜토리얼)w를 눌러 앞으로 이동하세요(" + count + "/1)";
        }
        else if(count == 1)
        {
            questtext1.text = "(튜토리얼)s를 눌러 뒤로 이동하세요(" + (count - count) + "/1)";
        }
        else if(count == 2)
        {
            questtext1.text = "(튜토리얼)a를 눌러 좌로 이동하세요(" + (count - count) + "/1)";
        }
        else if(count == 3)
        {
            questtext1.text = "(튜토리얼)d를 눌러 우로 이동하세요(" + (count - count) + "/1)";
        }
        else if(count == 4)
        {
            questtext1.text = "(튜토리얼)Shift를 눌러 달리세요(" + (count - count) + "/1)";
        }
        else if(count == 5)
        {
            questtext1.text = "(튜토리얼)Space Bar를 눌러 점프하세요(" + (count - count) + "/1)";
        }
        else if(count == 6)
        {
            questtext1.text = "(튜토리얼)b를 눌러 짖으세요(" + (count - count) + "/1)";
        }
        else if(count == 7)
        {
            questtext1.text = "(튜토리얼)v를 눌러 음식을 집으세요(" + (count - count) + "/1)";
        }
        else if(count == 8)
        {
            questtext1.text = "(튜토리얼)c를 눌러 음식을 내려 놓으세요(" + (count - count) + "/1)";
        }
        else if(count == 9)
        {
            questtext1.text = "(튜토리얼)x를 눌러 음식을 먹으세요(" + (count - count) + "/1)";
        }
        else if(count == 10)
        {
            questtext1.text = "공원으로 이동하세요";
        }
        else if(count == 11 || count == 12 || count == 13)
        {
            questtext1.text = "3명의 사람에게 짖으세요(" + (count - 10) + "/3)";
        }
        else if(count == 14)
        {
            questtext1.text = "공원퀘스트";
            //추상적으로
        }
        else if(count == 15)
        {
            questtext1.text = "공원퀘스트";
        }
        else if(count == 16 || count == 17 || count == 18)
        {
            questtext1.text = "공원퀘스트";
        }
        else if(count == 19)
        {
            questtext1.text = "시장으로 이동하세요";
        }
        else if(count == 22 || count == 20 || count == 21)
        {
            questtext1.text = "시장 직원을 피해 도망다니면서 음식을 3개이상 먹으세요(" + (count - 20) + "/3)";
        }
        else if(count == 23 || count == 24 || count == 25)
        {

        }
        else if(count == 26 || count == 27 || count == 28)
        {

        }
        else if(count == 50)
        {
            questtext1.text = "퀘스트 완료";
        }
        else if(count == 51 || count == 52)
        {

        }
        else if(count == 53)
        {
            questtext1.text = "집으로 돌아가세요!";
        }
    }

    void questcount()
    {
        if(PlayerMovement.foodIndexs == 0 && PlayerMovement.stops == false && count == 100)
        {
            if(Input.GetButtonDown("eat"))
            {
                countquest();
            }
        }
        else if(Input.GetKeyDown(KeyCode.W) && count == 0)
        {
            countquest();
        }        
        else if(Input.GetKeyDown(KeyCode.S) && count == 1)
        {
            countquest();
        }
        else if(Input.GetKeyDown(KeyCode.A) && count == 2)
        {
            countquest();
        }
        else if(Input.GetKeyDown(KeyCode.D) && count == 3)
        {
            countquest();
        }
        else if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && count == 4)
        {
            countquest();
        }
        else if(Input.GetKeyDown(KeyCode.Space) && count == 5)
        {
            countquest();
        }
        else if(PlayerMovement.stops == false && Input.GetKeyDown(KeyCode.B) && count == 6)
        {
            countquest();
        }
        else if(PlayerMovement.stops == false && Corgicollder.nearfood != 0 && Input.GetKeyDown(KeyCode.V) && count == 7)
        {
            countquest();
        }
        else if(PlayerMovement.foodIndexs != -1 && PlayerMovement.stops == false && Input.GetKeyDown(KeyCode.C) && count == 8)
        {
            countquest();
        }
        else if(PlayerMovement.foodIndexs != -1 && PlayerMovement.stops == false && Input.GetKeyDown(KeyCode.X) && count == 9)
        {
            countquest();
        }
        else if(Corgicollder.park == true && count == 10)
        {
            countquest();
        }
        else if(PlayerMovement.stops == false && Input.GetKeyDown(KeyCode.B))
        {
            if(count == 11 || count == 12)
            {
                count++;
            }
            else if(count == 13)
            {
                countquest();
            }
        }
        else if(count == 14)
        {
            countquest();
        }
        else if(count == 15)
        {
            countquest();
        }
        else if(count == 16 || count == 17 || count == 18)
        {
            countquest();
        }
        else if (Corgicollder.market == true && count == 19)
        {
            countquest();
        }
        else if (Corgicollder.market == true && PlayerMovement.foodIndexs != -1 && Input.GetKeyDown(KeyCode.X))
        {
            if(count == 20 || count == 21)
            {
                count++;
            }
            else if(count == 22)
            {
                countquest();
            }
        }
        else if(Corgicollder.printflyers == true && count == 50)
        {
            countquest();
        }
        else if(Corgicollder.home == true && count == 53)
        {

        }
    }

    public void countquest()
    {
        count++;
        questdelay = true;
        questtext1.text = "";
        StartCoroutine(QuestDelay());
    }

    IEnumerator QuestDelay()
    {
        yield return new WaitForSecondsRealtime(questdelayTime);
        questdelay = false;
    }
}
