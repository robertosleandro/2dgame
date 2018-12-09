using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Spell{
    void execute(Dictionary<string, object> context);
}
