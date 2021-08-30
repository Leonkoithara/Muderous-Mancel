using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    SpriteRenderer weapon_sprite;
	float firing_delay;
    bool fire;

    public GameObject crosshair;
    public GameObject fire_point;
    public GameObject bullet_prefab;

    public Sprite weapon_down;
    public Sprite weapon_right;
    public Sprite weapon_left;

    // Start is called before the first frame update
    void Start()
    {
        fire = true;
        firing_delay = 3.0f;
        weapon_sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
		Vector2 lookdir = crosshair.transform.position - transform.position;
		float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg;
		Quaternion gun_rot = Quaternion.AngleAxis(angle, Vector3.forward);

        Quaternion bullet_rot = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = gun_rot;
        if(Input.GetMouseButton(0) && fire)
		{
            StartCoroutine(disable_firing());
            Transform bullet_pos = fire_point.GetComponent<Transform>();
            GameObject bullet = Instantiate(bullet_prefab, bullet_pos.position, bullet_rot);
            bullet.GetComponent<BulletBehaviour>().set_properties(10.0f, 3.0f);
            Destroy(bullet, 10);
        }
    }

	IEnumerator disable_firing()
	{
		fire = false;
		yield return new WaitForSeconds(firing_delay);
        fire = true;
    }

	public void set_sprite(int direction)
	{
        weapon_sprite.color = new Color(1, 1, 1, 1);
        if(direction == 0)
			weapon_sprite.sprite = weapon_right;
		if(direction == 1)
            weapon_sprite.color = new Color(1, 1, 1, 0);
        if(direction == 2)
			weapon_sprite.sprite = weapon_left;
		if(direction == 3)
			weapon_sprite.sprite = weapon_down;
	}
}
