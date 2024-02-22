using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilities : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction ability1Action;
    private Player player;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        player = GetComponent<Player>();
        ability1Action = playerInput.actions["UseAbility1"];
    }

    private void OnEnable()
    {
        ability1Action.performed += UseAbility1;
    }

    private void OnDisable()
    {
        ability1Action.performed -= UseAbility1;
    }

    private void UseAbility1(InputAction.CallbackContext context)
    {
        player.Elements[0].Abilities[0].UseAbility();
        player.Elements[0].Abilities[0].Log();
    }


}
