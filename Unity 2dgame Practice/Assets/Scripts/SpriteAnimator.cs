using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour {

    //sprite renderer
    protected SpriteRenderer m_sprite;
    //sprite clips
    public Sprite[] m_clips;
    //ani timer
    protected float m_aniTimer = 0.1f;
    //frame
    protected int m_frame = 0;

	void Start () {
        //add sprite renderer
        m_sprite = this.gameObject.GetComponent<SpriteRenderer>();
        //set first frame's sprite
        m_sprite.sprite = m_clips[m_frame];
	}
	

	void Update () {
        m_aniTimer -= Time.deltaTime;

        if (m_aniTimer <= 0) {
            m_aniTimer = 0.1f;
            m_frame++;
            if (m_frame >= m_clips.Length)
                m_frame = 0;
            //renew
            m_sprite.sprite = m_clips[m_frame];
        }
	}
}
