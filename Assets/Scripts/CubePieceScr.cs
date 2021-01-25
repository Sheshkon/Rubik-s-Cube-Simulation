using UnityEngine;
public class CubePieceScr : MonoBehaviour
{
    public GameObject Up, Down, Front, Back, Left, Right;
    public void SetColor(int x, int y , int z)
    {
        if (y == 0)
            Up.SetActive(true);
        else if (y == -2)
            Down.SetActive(true);

        if (z == 0)
            Left.SetActive(true);
        else if (z == 2)
            Right.SetActive(true);

        if (x == 0)
            Front.SetActive(true);
        else if (x == -2)
            Back.SetActive(true);
    }
}
