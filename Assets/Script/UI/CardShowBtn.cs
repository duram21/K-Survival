using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Button = UnityEngine.UI.Button;


public class CardShowBtn : MonoBehaviour
{
    [SerializeField] Sprite active;
    [SerializeField] Sprite inactive;
    [SerializeField] TMP_Text btnText;

    public bool isActive = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Setup(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(bool isActive)
    {
        GetComponent<Image>().sprite = isActive ? active : inactive;
        // GetComponent<Button>().interactable = isActive;
    }

    public void CardShowBtnClick () {
        isActive = !isActive;
        btnText.text = isActive ? "카드보기" : "카드접기";
        Setup(isActive);
    }
}
