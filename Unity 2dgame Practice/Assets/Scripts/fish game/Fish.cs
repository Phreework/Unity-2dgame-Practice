using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour {

    protected float m_moveSpeed = 2.0f;
    protected int m_life = 10;
    public enum Dir {
        Left = 0,
        Right = 1
    }
    public Dir m_dir = Dir.Right;
    public Vector3 m_targetPos;

    public delegate void VoidDelegate(Fish fish);
    public VoidDelegate OnDeath;

    public static Fish Create(GameObject prefab, Dir dir, Vector3 pos) {
        GameObject go = (GameObject)Instantiate(prefab, pos, Quaternion.identity);
        Fish fish = go.AddComponent<Fish>();
        fish.m_dir = dir;

        return fish;
    }

    public void SetDamage(int damage) {
        m_life -= damage;
        if(m_life <= 0) {
            GameObject prefab = Resources.Load<GameObject>("explosion");
            GameObject explosion = (GameObject)Instantiate(prefab, this.transform.position, this.transform.rotation);
            Destroy(explosion, 1.0f);
            OnDeath(this);
            Destroy(this.gameObject);
        }
    }

    private void Start() {
        SetTarget();
    }

    void SetTarget() {
        float rand = Random.value;
        Vector3 scale = this.transform.localScale;
        scale.x = Mathf.Abs(scale.x) * (m_dir == Dir.Right ? 1 : -1);
        this.transform.localScale = scale;

        float cameraz = Camera.main.transform.position.z;
        m_targetPos = Camera.main.ViewportToWorldPoint(new Vector3((int)m_dir, 1 * rand, -cameraz));
    }

    private void Update() {
        UpdatePosition();
    }

    void UpdatePosition() {
        Vector3 pos = Vector3.MoveTowards(this.transform.position, m_targetPos, m_moveSpeed * Time.deltaTime);
        if(Vector3.Distance(pos,m_targetPos) < 0.1f) {
            m_dir = m_dir == Dir.Left ? Dir.Right : Dir.Left;
            SetTarget();
        }
        this.transform.position = pos;
    }
}

