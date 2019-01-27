using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Sockets;
using System.IO;

public class twitchChat : MonoBehaviour
{
    private TcpClient twitchClient;
    private StreamReader reader;
    private StreamWriter writer;
    
    public string username, password, channelName;
    //public Text chatBox;
    public static ArrayList inGamePlayers;
    public static bool connnected = false;
    //public GameObject viewerParent;
    // Start is called before the first frame update
    void Start()
    {
        username = dataSaver.Instance.username;
        channelName = dataSaver.Instance.channelName;
        password = dataSaver.Instance.password;
        Connect();
        inGamePlayers = new ArrayList();
    }

    // Update is called once per frame
    void Update()
    {
        if(!twitchClient.Connected)
        {
            connnected = false;
            Connect();
        }
        readChat();
    }

    private void Connect()
    {
        twitchClient = new TcpClient("irc.chat.twitch.tv", 6667);
        reader = new StreamReader(twitchClient.GetStream());
        writer = new StreamWriter(twitchClient.GetStream());

        writer.WriteLine("PASS " + password);
        writer.WriteLine("Nick " + username);
        writer.WriteLine("User " + username + " 8 * :" + username);
        writer.WriteLine("Join #" + channelName);
        writer.Flush();
        connnected = true;
    }

    private void readChat()
    {
        if(twitchClient.Available > 0)
        {
            var message = reader.ReadLine();
            if (message.Contains("PRIVMSG"))
            {
                //username
                var splitPoint = message.IndexOf("!", 1);
                var chatName = message.Substring(0, splitPoint);
                chatName = chatName.Substring(1);

                //get message
                splitPoint = message.IndexOf(":", 1);
                message = message.Substring(splitPoint + 1);
                //parse for !join
                if (message.ToLower() == "!join" && !inGamePlayers.Contains(chatName))
                {
                    inGamePlayers.Add(chatName);
                    bool foundMatch = false;
                    foreach(GameObject created in GameObject.FindGameObjectsWithTag("Viewer"))
                    {
                        if(!foundMatch)
                        {
                            if (created.name.Contains(" "))
                            {
                                created.name = chatName;
                                created.GetComponent<viewerInfo>().viewerName = chatName;
                                foundMatch = true;
                            }
                        }
                    }
                   // chatBox.text = chatBox.text + "\n" + string.Format("{0}", chatName);
                }
                //parse for choosing door/window if player is already in
                Match matchWindow = Regex.Match(message, "^!w[1-7]$");
                Match matchDoor = Regex.Match(message, "^!d[1-2]$");
                if (matchWindow.Success || matchDoor.Success) 
                {
                    if(inGamePlayers.Contains(chatName))
                    {
                       GameObject thisViewer = GameObject.Find(chatName);
                        viewerInfo info = thisViewer.GetComponent<viewerInfo>();
                       if(info.chosenWindow == "NA")
                        {
                            info.chosenWindow = message.Substring(1);
                        }
                    }
                }
            }
        }
    }
}
