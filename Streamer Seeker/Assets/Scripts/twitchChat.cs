using System.Collections;
using System.Collections.Generic;
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
    public Text chatBox;
    // Start is called before the first frame update
    void Start()
    {
        Connect();
    }

    // Update is called once per frame
    void Update()
    {
        if(!twitchClient.Connected)
        {
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
                chatBox.text = chatBox.text + "\n" + string.Format("{0}: {1}", chatName, message);
            }
        }
    }
}
