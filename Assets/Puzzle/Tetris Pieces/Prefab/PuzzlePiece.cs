using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    private bool _dragging, _placed;


    Vector2 _offset, _originalPos;

    public PuzzleSlot _slot;

    public PuzzleSlot nextPuzzleSlot;

    public Canvas canvas;

    public void Init(PuzzleSlot slot) {
        _slot = slot;
    }

    void awake() {
        _originalPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if(_placed) {
            return;
        }
        if(!_dragging) {
            return;
        }

        var mousePosition = GetMousePos();
        transform.position = mousePosition - _offset;

    }

    private void OnMouseDown() {
        _dragging = true;
        _offset = GetMousePos() - (Vector2)transform.position;
    }

    private void OnMouseUp() {
        if(Vector2.Distance(transform.position, _slot.transform.position) < 3) {
            transform.position = _slot.transform.position;
            if(nextPuzzleSlot != null){
                nextPuzzleSlot.gameObject.SetActive(true);
            }
            else{
                canvas.gameObject.SetActive(true);
                _slot.PlayAudio();
                //sleep 5 seconds
                StartCoroutine(LoadNextSceneAfterDelay(5));

            }
            _placed = true;
        }
        else {
            transform.position = _originalPos;
            _dragging = false;
        }

    }

    Vector2 GetMousePos() {
        return (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    IEnumerator LoadNextSceneAfterDelay(int delay)
    {
        yield return new WaitForSeconds(delay);

        // Load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
