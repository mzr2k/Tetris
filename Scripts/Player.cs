//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;
//using Mirror;

//public class Player : MonoBehaviour
//{
//    public Board board;
//    public GameObject FloatingScore;
//    // Start is called before the first frame update
//    void Start()
//    {
//        board = FindObjectOfType<Board>(); // Assuming there's only one instance of Board in the scene
//        if (board != null)
//        {
//            Debug.Log("Board found successfully.");
//        }
//        else
//        {
//            Debug.LogError("Board not found!");
//        }
//    }


//    public void ShowFloatingScore()
//{
//    Debug.Log("FLOATING SCORE CALLED");

//    if (FloatingScore == null)
//    {
//        Debug.LogError("FloatingScore prefab is not assigned!");
//        return;
//    }

//    var go = Instantiate(FloatingScore, transform.position, Quaternion.identity, transform);

//    // Find the TMP_Text component in the child object
//    TMP_Text tmpText = go.GetComponentInChildren<TMP_Text>();
//    if (tmpText != null)
//    {
//        tmpText.text = board.scoreNumber.text;  // Get the text from the scoreNumber TMP_Text component
//    }
//    else
//    {
//        Debug.LogError("TMP_Text component is missing on the child object of the instantiated FloatingScore prefab!");
//    }
//}


//    // Update is called once per frame
//    void Update()
//    {

//    }
//}


using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    public Board board;
    public GameObject FloatingScore;

    void Start()
    {
        if (!isLocalPlayer) return;

        board = FindObjectOfType<Board>(); // Assuming there's only one instance of Board in the scene
        if (board != null)
        {
            Debug.Log("Board found successfully.");
        }
        else
        {
            Debug.LogError("Board not found!");
        }
    }

    // This method is called to show the floating score.
    public void ShowFloatingScore()
    {
        if (!isLocalPlayer) return;

        Debug.Log("FLOATING SCORE CALLED");

        if (FloatingScore == null)
        {
            Debug.LogError("FloatingScore prefab is not assigned!");
            return;
        }

        CmdShowFloatingScore(board.scoreNumber.text, transform.position);
    }

    // Command to run on the server, invoked by the client
    [Command]
    void CmdShowFloatingScore(string scoreText, Vector3 position)
    {
        RpcShowFloatingScore(scoreText, position);
    }

    // ClientRpc to run on all clients
    [ClientRpc]
    void RpcShowFloatingScore(string scoreText, Vector3 position)
    {
        var go = Instantiate(FloatingScore, position, Quaternion.identity, transform);

        // Find the TMP_Text component in the child object
        TMP_Text tmpText = go.GetComponentInChildren<TMP_Text>();
        if (tmpText != null)
        {
            tmpText.text = scoreText;  // Set the text for all clients
        }
        else
        {
            Debug.LogError("TMP_Text component is missing on the child object of the instantiated FloatingScore prefab!");
        }
    }

    void Update()
    {
        // This is where you could handle input or other per-frame logic
        // if needed, but make sure to wrap it in an isLocalPlayer check.
    }
}
