using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    float damage;
    float muzzle_velocity;

    // Update is called once per frame
    void Update()
    {
        Vector3 translate_vec = muzzle_velocity * Time.deltaTime * Vector3.right;
        transform.Translate(translate_vec);
    }

	public void set_properties(float dg, float mv)
	{
        damage = dg;
		muzzle_velocity = mv;
    }
}
