using TMPro;
using UnityEngine;

public class InfoDisplayGUI : MonoBehaviour
{
    public GameObject playerJet;
    public TMP_Text shieldStatusLbl;
    public TMP_Text shieldStatusTxt;
    public TMP_Text missleCountTxt;
    public TMP_Text goodLuckTxt;
    private float time;
    private PlayerController pController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pController = playerJet.GetComponent<PlayerController>();
        goodLuckTxt.SetText("");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        goodLuckTxt.SetText("Good Luck!");
        if (time >= 3f)
        {
            goodLuckTxt.SetText("");
        }
        SetupShieldsEquippedGUI();
        SetupShieldsActiveGUI();
        MissleCountGUI();
    }
    private void SetupShieldsEquippedGUI()
    {
        if(pController.GetShieldsEquippedStatus())
        {
            shieldStatusTxt.text = "Yes - Press R to activate shields |";
        }
        else
        {
            shieldStatusTxt.text = "No";
        }
    }
    private void SetupShieldsActiveGUI()
    {
        if(pController.GetShieldsActiveStatus())
        {
            shieldStatusLbl.text = "Shields Active";
            shieldStatusTxt.text = "Yes";
        }
        else
        {
            shieldStatusLbl.text = "Shields Equipped";
        }
    }
    private void MissleCountGUI()
    {
        missleCountTxt.text = pController.GetMissleCount().ToString();
    }
}
