using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellbook{
    public List<Spell> spells = new List<Spell>();

    static Dictionary<string, Spell> initialSpells()
    {
        Dictionary<string, Spell> initialSpells = new Dictionary<string, Spell>();

        fireball fireInstance = Resources.Load("fireball", typeof(fireball)) as fireball;
        gasball gasInstance = Resources.Load("aoe", typeof(gasball)) as gasball;
        HealBall healball = Resources.Load("healthball", typeof(HealBall)) as HealBall;

        initialSpells.Add("fireball", fireInstance);
        initialSpells.Add("gasball", gasInstance);
        initialSpells.Add("healball", healball);

        return initialSpells;
    }

    public Spellbook(List<string> inputedSpells)
    {
        for (int i = 0; i< inputedSpells.Count; i++)
        {
 //           Spell iSpell = Spellbook.initialSpells()[inputedSpells[i]];
         //   iSpell.setTargetAndCaster(target, caster);

            spells.Add(Spellbook.initialSpells()[inputedSpells[i]]);
            Debug.Log("Spell " + inputedSpells[i] + ": " + Spellbook.initialSpells()[inputedSpells[i]]);
        }
    }


}