using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUseable
{
    void UseItem(GameObject infoScreen);

    void CloseScreen(GameObject infoScreen);
}
