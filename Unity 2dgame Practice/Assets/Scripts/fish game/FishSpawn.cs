using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawn : MonoBehaviour {

    public float timer = 0;
    public int max_fish = 30;
    public int fish_count = 0;

	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            timer = 2.0f;
            if (fish_count >= max_fish)
                return;
            int index = 1 + (int)(Random.value * 3.0f);
            if (index > 3)
                index = 3;
            fish_count++;
            GameObject fishprefab = (GameObject)Resources.Load("fish" + index);
            float cameraz = Camera.main.transform.position.z;

            Vector3 randpos = new Vector3(Random.value, Random.value, -cameraz);
            randpos = Camera.main.ViewportToWorldPoint(randpos);

            Fish.Dir dir = Random.value > 0.5f ? Fish.Dir.Right : Fish.Dir.Left;
            Fish f = Fish.Create(fishprefab, dir, randpos);

            f.OnDeath += OnDeath;
        }
	}
    void OnDeath(Fish fish) {
        fish_count--;
    }
}
