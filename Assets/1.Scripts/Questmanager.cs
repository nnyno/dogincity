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
            questtext2.text = questtext1.text;
        }
    }

    void quest()
    {
        if(count == 0)
        {
            questtext1.text = "공원으로 이동하세요";
        }
        else if(count == 1 || count == 2 || count == 3)
        {
            questtext1.text = "3명의 사람을 놀라게 하세요(" + (count - 1) + "/3)";
        }
        else if(count == 4)
        {
            questtext1.text = "시장으로 이동하세요";
        }
        else if(count == 5 || count == 6)
        {
            questtext1.text = "시장 직원을 피해 도망다니면서 음식을 2개이상 먹으세요(" + (count - 20) + "/2)";
        }
        else if(count == 7 &&  stress.Stress == 0.0f)
        {
            questtext1.text = "집으로 돌아가세요!";
            home.enabled = false;
            home2.enabled = false;
        }
    }

    void questcount()
    {
        if(Corgicollder.park == true && count == 0)
        {
            countquest();
            stress.Stress -= 5.0f;
        }
        //1,2,3 aianim의 humango함수에서 증가
        else if (Corgicollder.market == true && count == 4)
        {
            stress.Stress -= 5.0f;
            countquest();
        }
        else if (Corgicollder.market == true && PlayerMovement.foodIndexs != -1 && Input.GetKeyDown(KeyCode.X))
        {
            if(count == 5)
            {
                count++;
            }
            else if(count == 6)
            {
                stress.Stress -= 10.0f;
                countquest();
            }
        }
        else if(Corgicollder.home == true && count == 7)
        {
            LoadingSceneManager.LoadScene("home");
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
