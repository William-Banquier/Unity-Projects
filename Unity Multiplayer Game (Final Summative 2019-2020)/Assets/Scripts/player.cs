using Mirror;
using UnityEngine;

public class player : NetworkBehaviour
{

    [SerializeField] private Vector3 movement = new Vector3();

    [Client]
    void Update()
    {
        if(!hasAuthority){return;}

        if(!Input.GetKeyDown(KeyCode.Space)){return;}

        transform.Translate(movement);
    }
}
