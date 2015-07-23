using UnityEngine;
using System.Collections;

public class ShipAssignment : MonoBehaviour {

    public void AssignFuselage(GameObject fuselage)
    {
        PlayerEquipped playerEquipped = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEquipped>();
        playerEquipped.fuselage = fuselage;

    }

    public void AssignWeapon1(GameObject weapon)
    {
        PlayerEquipped playerEquipped = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEquipped>();
        playerEquipped.weapon1 = weapon;
    }

    public void AssignWeapon2(GameObject weapon)
    {
        PlayerEquipped playerEquipped = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEquipped>();
        playerEquipped.weapon2 = weapon;
    }
}
