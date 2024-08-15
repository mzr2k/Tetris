using Mirror;

public class NetworkPlayer : NetworkBehaviour
{
    // SyncVar to synchronize player-specific data, such as scores or controls
    [SyncVar]
    public int playerScore;

    void Update()
    {
        if (isLocalPlayer)
        {
            // Handle input and game control for the local player
            HandleInput();
        }
    }

    void HandleInput()
    {
        // Your code to handle player input (e.g., moving tetrominoes)
    }
}
