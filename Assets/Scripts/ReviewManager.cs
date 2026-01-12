using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ReviewManager : MonoBehaviour
{
    public Transform contentRoot;
    public GameObject rowPrefab;

    public void Populate()
    {
        foreach (Transform c in contentRoot)
            Destroy(c.gameObject);

        foreach (var d in DefectStore.Instance.defects)
        {
            var row = Instantiate(rowPrefab, contentRoot);

            var note = row.transform.Find("Note").GetComponent<TMP_Text>();
            var photo = row.transform.Find("Photo").GetComponent<RawImage>();

            note.text = d.note;
            photo.texture = d.photo;
        }
    }
}
