using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityWeld.Binding;

[Binding]
public class PlayerViewModel : ViewModel
{
    private string stateName;

    [Binding]
    public string StateName
    {
        get { return this.stateName; }
        set { this.stateName = value; OnPropertyChanged("StateName"); }
    }
}
