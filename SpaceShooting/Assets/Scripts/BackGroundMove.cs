using UnityEditor;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    private GameManager manager;
    private RectTransform rect;

    private RectTransform pairBackPanel;    //‚à‚¤ˆê–‡‚Ì”wŒi
    private float speed; //”wŒi‚ÌˆÚ“®‘¬“x

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //‰Šú‰»
        manager = GameManager.instance;
        rect = this.gameObject.GetComponent<RectTransform>();
        speed = manager.publicBackGroundSpeed;

        //ƒfƒoƒbƒO
        //if (rect == null) Debug.LogError("error");
        //else if (rect != null) Debug.Log("not null");
    }

    /// <summary>
    /// ‚à‚¤ˆê–‡‚Ì”wŒi‚ğİ’è‚·‚éŠÖ”
    /// </summary>
    /// <param name="pair"></param>
    public void SetPairBackGroundPanel(RectTransform pair)
    {
        pairBackPanel = pair;
    }

    /// <summary>
    /// ”wŒiˆÚ“®ŠÖ”
    /// </summary>
    private void MoveBackGround()
    {
        if (manager == null || manager.SetPause) return;

        //”wŒi‚ÌˆÚ“®
        rect.anchoredPosition += Vector2.down.normalized * speed * Time.deltaTime;

        //‰æ–ÊŠO‚É‚È‚Á‚½‚çƒŠƒZƒbƒgƒ|ƒWƒVƒ‡ƒ“‚ÉˆÚ“®
        if (rect.anchoredPosition.y <= -rect.rect.height)
        {
            //XÀ•W‚Í•Ï‚¦‚¸AYÀ•W‚Í(Œ»İ‚Ì‚‚³ + ”wŒi‚Ì‚‚³ -1)‚ÅŒ„ŠÔ‚ğ–h‚®
            rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, 
                pairBackPanel.anchoredPosition.y + rect.rect.height - 1);
        }
    }

    private void Update()
    {
        MoveBackGround();
    }
}
