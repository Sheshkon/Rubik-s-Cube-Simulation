using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AnimationGIf : MonoBehaviour
{
    private const float speedAnimation = 0.25F;
    public GameObject HowToPlayPanel;

    public Image UImage, U_Image, UwImage, Uw_Image,
                 RImage, R_Image, RwImage, Rw_Image,
                 LImage, L_Image, LwImage, Lw_Image,
                 BImage, B_Image, DImage, D_Image,
                 DwImage, Dw_Image, FImage, F_Image,
                 MImage, M_Image, xImage, x_Image,
                 yImage, y_Image, zImage, z_Image;

    public Sprite[] U, U_, Uw, Uw_, B, B_, D,
                    D_, Dw, Dw_, F, F_, M, M_,
                    R, R_, Rw, Rw_, L, L_, Lw,
                    Lw_, x, x_, y, y_, z, z_;

    float i = 0;
    // Update is called once per frame
    void Update()
    {
        if (i > B.Length -1)
            i = 0;

        BImage.sprite = B[Mathf.RoundToInt(i)];
        B_Image.sprite = B_[Mathf.RoundToInt(i)];

        DImage.sprite = D[Mathf.RoundToInt(i)];
        D_Image.sprite = D_[Mathf.RoundToInt(i)];
        DwImage.sprite = Dw[Mathf.RoundToInt(i)];
        Dw_Image.sprite = Dw_[Mathf.RoundToInt(i)];

        FImage.sprite = F[Mathf.RoundToInt(i)];
        F_Image.sprite = F_[Mathf.RoundToInt(i)];

        LImage.sprite = L[Mathf.RoundToInt(i)];
        L_Image.sprite = L_[Mathf.RoundToInt(i)];
        LwImage.sprite = Lw[Mathf.RoundToInt(i)];
        Lw_Image.sprite = Lw_[Mathf.RoundToInt(i)];

        MImage.sprite = M[Mathf.RoundToInt(i)];
        M_Image.sprite = M_[Mathf.RoundToInt(i)];

        RImage.sprite = R[Mathf.RoundToInt(i)];
        R_Image.sprite = R_[Mathf.RoundToInt(i)];
        RwImage.sprite = Rw[Mathf.RoundToInt(i)];
        Rw_Image.sprite = Rw_[Mathf.RoundToInt(i)];

        UImage.sprite = U[Mathf.RoundToInt(i)];
        U_Image.sprite = U_[Mathf.RoundToInt(i)];
        UwImage.sprite = Uw[Mathf.RoundToInt(i)];
        Uw_Image.sprite = Uw_[Mathf.RoundToInt(i)];

        xImage.sprite = x[Mathf.RoundToInt(i)];
        x_Image.sprite = x_[Mathf.RoundToInt(i)];

        yImage.sprite = y[Mathf.RoundToInt(i)];
        y_Image.sprite = y_[Mathf.RoundToInt(i)];

        zImage.sprite = z[Mathf.RoundToInt(i)];
        z_Image.sprite = z_[Mathf.RoundToInt(i)];

        if (Mathf.RoundToInt(i) == B.Length-1)
            i += speedAnimation/ 20f;
        else if (Mathf.RoundToInt(i) == 0)
            i += speedAnimation / 20f; 
        else
            i += speedAnimation;

        if (Input.GetKeyDown(KeyCode.Escape)) 
            HowToPlayPanel.SetActive(false);

    }

  
}
