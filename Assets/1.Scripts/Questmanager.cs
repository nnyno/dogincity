using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Questmanager : MonoBehaviour
{
    public stress stress = null;
    public difficulty difficulty = null;
    public PlayerMovement PlayerMovement;
    public Corgicollder Corgicollder;
    public Text questtext1, questtext2;
    public int count = 0;
    public int questdelayTime = 1;
    public bool questdelay = false;
    public BoxCollider home, home2;

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
            if(count != 3)
            {
                questtext2.text = questtext1.text;
            }
            else
            {
                questtext2.text = "힌트 : 쓰레기통, 사람, 시장, 공원, 강아지";
            }
        }
    }

    void quest()
    {
        if(count == 0)
        {
            questtext1.text = "시장으로 이동하세요";
        }
        else if(count == 1)
        {
            questtext1.text = "사람을 놀라게 하세요" ;
        }
        else if(count == 2)
        {
            questtext1.text = "시장 직원을 피해 도망다니면서 음식을 먹으세요";
        }
        else if(count == 3)
        {
            if(stress.Stress == 0.0f)
            {
                questtext1.text = "지도를 찾아서 집으로 돌아가세요!";
            }
            else
            {
                questtext1.text = "스트레스가 너무 높아요";
            }
        }
    }

    void questcount()
    {
        if(Corgicollder.market == true && count == 0)
        {
            countquest();
            stress.Stress -= 20.0f;
        }
        //count 1 aianim의 humango함수에서 증가
        else if (Corgicollder.market == true && PlayerMovement.foodIndexs != -1 && Input.GetKeyDown(KeyCode.X))
        {
            if(count == 2)
            { 
                stress.Stress -= 30.0f;
                countquest();
            }
        }
        else if(Corgicollder.home == true && count == 3)
        {
            LoadingSceneManager.LoadScene("gameend");
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
