using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    //if click sphere
    bool m_isHit = false;
    Vector3 m_startPos;
    SpriteRenderer m_spriteRenderer;

    private void Start() {
        m_spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0) && IsHit()) 
            m_startPos = Input.mousePosition;
        if(Input.GetMouseButtonUp(0) && m_isHit) {
            Vector3 endPos = Input.mousePosition;

            Vector3 v = (m_startPos - endPos) * 3.0f;
            this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            this.GetComponent<Rigidbody2D>().AddForce(v);
        }
    }

    bool IsHit() {
        m_isHit = false;

        Vector3 ms = Input.mousePosition;
        ms = Camera.main.ScreenToWorldPoint(ms);    //this is useful

        Vector3 pos = this.transform.position;

        //get mask w&h
        float w = m_spriteRenderer.bounds.extents.x;
        float h = m_spriteRenderer.bounds.extents.y;

        if (IsMouseHitSphere(ms, pos, w, h)) {
            m_isHit = true;
            return true;
        }
        return m_isHit;

    }



    private static bool IsMouseHitSphere(Vector3 ms, Vector3 pos, float w, float h) {
        return ms.x > pos.x - w && ms.x < pos.x + w && ms.y > pos.y - h && ms.y < pos.y + h;
    }
}
