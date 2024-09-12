using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : BaseUIButton
{
    protected override void Click()
    {
        try
        {
            API.OnInvokeNavAction("exit");
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
        finally
        {
            Application.Quit();
        }
    }

}
