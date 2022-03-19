using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel;
using UnityWeld.Binding;

[Binding]
public class PlayerViewModel : MonoBehaviour, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private string stateName;

    [Binding]
    public string StateName
    {
        get { return this.stateName; }
        set { this.stateName = value; OnPropertyChanged("StateName"); }
    }

    private void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
