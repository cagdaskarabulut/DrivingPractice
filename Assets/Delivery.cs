using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);
    bool hasPackage;
    float destroyDelay = 0.5f;

    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Delivery trigger enter");
        if(other.tag == "Package" && !hasPackage) {
            Debug.Log("Package picked!");
            hasPackage = true;
            spriteRenderer.color = other.GetComponent<SpriteRenderer>().color;
            Destroy(other.gameObject, destroyDelay);
        } else if (other.tag == "Customer" && hasPackage) {
            Debug.Log("Package delivered!");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
