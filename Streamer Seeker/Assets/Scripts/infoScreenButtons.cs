using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class infoScreenButtons : MonoBehaviour
{
    public InputField usernameF, channelNameF, passwordF;
    public Button submitButton;
    // Start is called before the first frame update
    void Start()
    {
        submitButton.onClick.AddListener(saveFields);
    }

    void saveFields()
    {
        dataSaver.Instance.username = usernameF.text;
        dataSaver.Instance.channelName = channelNameF.text;
        dataSaver.Instance.password = passwordF.text;
        SceneManager.LoadScene("ChatTest");
    }
}
