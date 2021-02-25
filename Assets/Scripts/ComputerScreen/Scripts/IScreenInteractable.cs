using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScreenInteractable
{
    /// <summary>
    /// Called frame user clicks on the interactable object.
    /// </summary>
    public void OnInitClick();

    /// <summary>
    /// Called every frame after the user clicks for a certain period of time,
    /// </summary>
    public void OnLongClick();

    /// <summary>
    /// Called after a click; also called after the end of OnLongClick().
    /// </summary>
    public void OnShortClick();
}
