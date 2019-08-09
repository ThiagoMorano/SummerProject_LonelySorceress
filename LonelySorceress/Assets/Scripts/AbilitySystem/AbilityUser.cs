using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUser : MonoBehaviour
{
    // List of abilities player currently has
    public List<Ability> abilitySlots;

    // Dictionary that holds current amount of charges for each ability
    private Dictionary<Ability, int> abilityCurrentCharges;

    // Ability currently selected
    [SerializeField] private Ability currentAbility;



    // Start is called before the first frame update
    void Start()
    {
        RefreshAbilitySlots();
    }


    // Update is called once per frame
    void Update()
    {
        // Temporary casting method. Just used this to not mess with player control scripts
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseAbility();
            Debug.Log(abilityCurrentCharges[currentAbility]);
        }
    }

    /// <summary>
    /// Use ability that is currently selected
    /// </summary>
    /// Checks if has enough charges and activates the selected ability
    public void UseAbility()
    {
        if (abilityCurrentCharges[currentAbility] > 0)
        {
            currentAbility.CastAbility(this.transform);
            abilityCurrentCharges[currentAbility]--;
        }
    }


    /// <summary>
    /// Updates the values of abilities and their max charges
    /// </summary>
    /// Mostly used to populate the maxCharge dictionary, but should be used 
    /// after getting a new ability to synchronize the slots and their max charges
    void RefreshAbilitySlots()
    {
        if (abilityCurrentCharges == null)
        {
            abilityCurrentCharges = new Dictionary<Ability, int>();
            RefreshAbilitySlots();
        }
        else
        {
            foreach (Ability _ability in abilitySlots)
            {
                if (!abilityCurrentCharges.ContainsKey(_ability))
                {
                    abilityCurrentCharges.Add(_ability, _ability.maxCharges);
                }
            }
        }
    }
}
