using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilities : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction ability1Action;
    private InputAction ability2Action;
    private InputAction ability3Action;
    private Player player;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        player = GetComponent<Player>();
        ability1Action = playerInput.actions["UseAbility1"];
        ability2Action = playerInput.actions["UseAbility2"];
        ability3Action = playerInput.actions["UseAbility3"];
    }

    private void OnEnable()
    {
        ability1Action.performed += UseAbility1;
        ability2Action.performed += UseAbility2;
        ability3Action.performed += UseAbility3;
    }

    private void OnDisable()
    {
        ability1Action.performed -= UseAbility1;
        ability2Action.performed -= UseAbility2;
        ability3Action.performed -= UseAbility3;
    }

    private void UseAbility1(InputAction.CallbackContext context)
    {
        player.Elements[0].Abilities[0].UseAbility();
    }

    private void UseAbility2(InputAction.CallbackContext context)
    {
        player.Elements[0].Abilities[1].UseAbility();
    }

    private void UseAbility3(InputAction.CallbackContext context)
    {
        player.Elements[0].Abilities[2].UseAbility();
    }


}
