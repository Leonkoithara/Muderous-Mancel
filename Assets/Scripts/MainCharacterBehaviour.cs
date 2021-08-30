using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterBehaviour : MonoBehaviour
{
    float max_movement;
    SpriteRenderer character_sprite;

	public Sprite right;
    public Sprite left;
    public Sprite up;
    public Sprite down;

    public GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        max_movement = 1.5f;
        character_sprite = GetComponent<SpriteRenderer>();

		/* 0 : +x direction
		   1 : +y direction
		   2 : -x direction
		   3 : -y direction
		 */
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10.0f;
        var wantedPosition = Camera.main.ScreenToWorldPoint (mousePos);

		set_sprite(wantedPosition - transform.position);

        Vector3 move_dir = x * Time.deltaTime * Vector3.right + y * Time.deltaTime * Vector3.up;

        transform.Translate(max_movement * move_dir);
    }

	void set_sprite(Vector3 mousePosition)
	{
        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        WeaponBehaviour wb = weapon.GetComponent<WeaponBehaviour>();

        if(-45 < angle && angle < 45)
		{
            wb.set_sprite(0);
            character_sprite.sprite = right;
		}
		if(45 < angle && angle < 135)
		{
            wb.set_sprite(1);
            character_sprite.sprite = up;
		}
		if(135 < angle || angle < -135)
		{
            wb.set_sprite(2);
            character_sprite.sprite = left;
		}
		if(-135 < angle && angle < -45)
		{
            wb.set_sprite(3);
            character_sprite.sprite = down;
		}
    }
}
