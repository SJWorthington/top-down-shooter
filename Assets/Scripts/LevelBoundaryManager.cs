using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundaryManager : MonoBehaviour {
    [SerializeField] GameObject leftBound;
    [SerializeField] GameObject rightBound;
    [SerializeField] GameObject topBound;
    [SerializeField] GameObject bottomBound;
    private LevelBoundaries levelBoundaries;

    private void Awake() {
        var left = leftBound.transform.position.x + leftBound.transform.localScale.x;
        var right = rightBound.transform.position.x - rightBound.transform.localScale.x;
        var top = topBound.transform.position.y - topBound.transform.localScale.y;
        var bottom = bottomBound.transform.position.y + bottomBound.transform.localScale.y;
        levelBoundaries = new LevelBoundaries(left, right, top, bottom);
    }

    public LevelBoundaries getLevelBoundaries() {
        return levelBoundaries;
    }

    public class LevelBoundaries {
        public float leftBound;
        public float rightBound;
        public float topBound;
        public float bottomBound;

        public LevelBoundaries(float left, float right, float top, float bottom) {
            leftBound = left;
            rightBound = right;
            topBound = top;
            bottomBound = bottom;
        }
    }
}
