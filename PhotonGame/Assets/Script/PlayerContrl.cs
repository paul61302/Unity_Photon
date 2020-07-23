using UnityEngine;
using UnityEngine.UI;

public class PlayerContrl : MonoBehaviour
{
   
    public Sprite glasses1, glasses2, glasses3, glasses4, glasses5, glasses6;

    public Image wear;

    public GameObject player;

    private void Start()
    {

        wear = player.transform.GetChild(5).GetComponent<Image>();
        print(wear.name);
        
    }

    public void WearGlasses1()
    {
        wear = player.transform.GetChild(5).GetComponent<Image>();
        wear.color = new Color(1, 1, 1, 1);
        wear.sprite = glasses1;
        print("戴1號眼鏡");
    }
    public void WearGlasses2()
    {
        wear.color = new Color(1, 1, 1, 1);
        wear.sprite = glasses2;
        print("戴2號眼鏡");
    }
    public void WearGlasses3()
    {
        wear.color = new Color(1, 1, 1, 1);
        wear.sprite = glasses3;
        print("戴3號眼鏡");
    }
    public void WearGlasses4()
    {
        wear.color = new Color(1, 1, 1, 1);
        wear.sprite = glasses4;
        print("戴4號眼鏡");
    }
    public void WearGlasses5()
    {
        wear.color = new Color(1, 1, 1, 1);
        wear.sprite = glasses5;
        print("戴5號眼鏡");
    }
    public void WearGlasses6()
    {
        wear.color = new Color(1, 1, 1, 1);
        wear.sprite = glasses6;
        print("戴6號眼鏡");
    }
    public void WearGlasses7()
    {
        wear.color = new Color(1, 1, 1,0);
        print("戴7號眼鏡");
    }
}