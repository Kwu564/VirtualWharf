using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item : MonoBehaviour {
    public string MyName;
    public string MyType;
    public string Description;
    public int Price;
    public GameObject ObjectPrefab;
    public Texture2D Icon;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public Item Clone()
    {
        Item clone = new Item();
        clone.MyName = this.MyName;
        clone.MyType = this.MyType;
        clone.Description = this.Description;
        clone.Price = this.Price;
        clone.ObjectPrefab = this.ObjectPrefab;
        clone.Icon = this.Icon;
        return clone;
    }
}
