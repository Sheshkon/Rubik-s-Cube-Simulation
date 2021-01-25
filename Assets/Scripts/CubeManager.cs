using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoveLogic;
using Random = UnityEngine.Random;
using System.Diagnostics;
using UnityEngine.UI;

public class CubeManager : MonoBehaviour
{
    public GameObject[] SpeedPanel;
    public GameObject CubePiecePref;
    private GameObject CubeCenterPiece;
    public static Queue<Move> moves = new Queue<Move>();
    private List<GameObject> AllCubePieces = new List<GameObject>();
    public Text SolvesAmount;
    public Text LastTime;
    public Text BestTime;
    public Text LastScramble;



    private static readonly float[] speed = { 1, 2, 3, 6, 9, 15, 18, 22.5F, 30, 45, 90 };

    public static bool isShuffled = false;
    private static bool canRotate = true;
    private static bool toRestart = false;
    private static bool toShuffle = false;
    private static bool is_shuffling = false;

    public int solvesAmount = 0;
   
    private int count = 0;
    private static bool end = false;
    private static string time = "";
    private static string scramble = "";
    private int amount_of_moves_in_queue;
    private const int scramble_amount = 24;

   

    public  int current_speed = (int)(speed.Length * 0.7f);
    private  int animation_speed = 0;
    private  int speed_before_end = (int)(speed.Length * 0.7f);
    
    List<GameObject> GetLayer(Layers layer)
    {
        if (layer == Layers.U)
            return AllCubePieces.FindAll(x => Mathf.Round(x.transform.localPosition.y) == 0);

        else if (layer == Layers.R)
            return AllCubePieces.FindAll(x => Mathf.Round(x.transform.localPosition.z) == 2);

        else if (layer == Layers.D)
            return AllCubePieces.FindAll(x => Mathf.Round(x.transform.localPosition.y) == -2);

        else if (layer == Layers.B)
            return AllCubePieces.FindAll(x => Mathf.Round(x.transform.localPosition.x) == -2);

        else if (layer == Layers.L)
            return AllCubePieces.FindAll(x => Mathf.Round(x.transform.localPosition.z) == 0);

        else if (layer == Layers.F)
            return AllCubePieces.FindAll(x => Mathf.Round(x.transform.localPosition.x) == 0);

        else if (layer == Layers.M)
            return AllCubePieces.FindAll(x => Mathf.Round(x.transform.localPosition.z) == 1);

        else if (layer == Layers.LMR)
            return AllCubePieces;

        else if (layer == Layers.Rw)
            return AllCubePieces.FindAll(x => Mathf.Round(x.transform.localPosition.z) == 1 || Mathf.Round(x.transform.localPosition.z) == 2);

        else if (layer == Layers.Lw)
            return AllCubePieces.FindAll(x => Mathf.Round(x.transform.localPosition.z) == 1 || Mathf.Round(x.transform.localPosition.z) == 0);

        else if (layer == Layers.Uw)
            return AllCubePieces.FindAll(x => Mathf.Round(x.transform.localPosition.y) == -1 || Mathf.Round(x.transform.localPosition.y) == 0);

        else if (layer == Layers.Dw)
            return AllCubePieces.FindAll(x => Mathf.Round(x.transform.localPosition.y) == -1 || Mathf.Round(x.transform.localPosition.y) == -2);

        return null;
    }

    void Start()
    {
       // SavePlayer();
        LoadPlayer();
        InitSpeedPanel();
        CreateCube();
    }

    void Update()
    {
        if (Time.timeScale == 0) return;
        if (!toRestart)
            CheckInput();
        if (canRotate)
            StartCoroutine(Rotate());
    }

    void CreateCube()
    {
        for (int x = 0; x < 3; x++)
            for (int y = 0; y < 3; y++)
                for (int z = 0; z < 3; z++)
                {
                    GameObject go = Instantiate(CubePiecePref, null, false);
                    go.transform.localPosition = new Vector3(-x, -y, z);
                    go.GetComponent<CubePieceScr>().SetColor(-x, -y, z);
                    AllCubePieces.Add(go);
                }
        CubeCenterPiece = AllCubePieces[13];
    }

    void CheckInput()
    {
        amount_of_moves_in_queue = current_speed;
        if (moves.Count <= amount_of_moves_in_queue &&!end)
        {
            if (Input.GetKeyDown(KeyCode.J))
                moves.Enqueue(Moves.U);

            else if (Input.GetKeyDown(KeyCode.F))
                moves.Enqueue(Moves.U_);

            else if (Input.GetKeyDown(KeyCode.I))
                moves.Enqueue(Moves.R);

            else if (Input.GetKeyDown(KeyCode.K))
                moves.Enqueue(Moves.R_);

            else if (Input.GetKeyDown(KeyCode.D))
                moves.Enqueue(Moves.L);

            else if (Input.GetKeyDown(KeyCode.E))
                moves.Enqueue(Moves.L_);

            else if (Input.GetKeyDown(KeyCode.H))
                moves.Enqueue(Moves.F);

            else if (Input.GetKeyDown(KeyCode.G))
                moves.Enqueue(Moves.F_);

            else if (Input.GetKeyDown(KeyCode.W))
                moves.Enqueue(Moves.B);

            else if (Input.GetKeyDown(KeyCode.O))
                moves.Enqueue(Moves.B_);

            else if (Input.GetKeyDown(KeyCode.L))
                moves.Enqueue(Moves.D_);

            else if (Input.GetKeyDown(KeyCode.S))
                moves.Enqueue(Moves.D);

            else if (Input.GetKeyDown(KeyCode.Period))
                moves.Enqueue(Moves.M);

            else if (Input.GetKeyDown(KeyCode.X))
                moves.Enqueue(Moves.M_);

            else if (Input.GetKeyDown(KeyCode.U))
                moves.Enqueue(Moves.Rw);

            else if (Input.GetKeyDown(KeyCode.M))
                moves.Enqueue(Moves.Rw_);

            else if (Input.GetKeyDown(KeyCode.R))
                moves.Enqueue(Moves.Lw);

            else if (Input.GetKeyDown(KeyCode.V))
                moves.Enqueue(Moves.Lw_);

            else if (Input.GetKeyDown(KeyCode.C))
                moves.Enqueue(Moves.Uw_);

            else if (Input.GetKeyDown(KeyCode.Comma))
                moves.Enqueue(Moves.Uw);

            else if (Input.GetKeyDown(KeyCode.Z))
                moves.Enqueue(Moves.Dw);

            else if (Input.GetKeyDown(KeyCode.Slash))
                moves.Enqueue(Moves.Dw_);

            else if (Input.GetKeyDown(KeyCode.A))
                moves.Enqueue(Moves.y);

            else if (Input.GetKeyDown(KeyCode.Semicolon))
                moves.Enqueue(Moves.y_);

            else if (Input.GetKeyDown(KeyCode.Q))
                moves.Enqueue(Moves.z_);

            else if (Input.GetKeyDown(KeyCode.P))
                moves.Enqueue(Moves.z);

            else if (Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.T))
                moves.Enqueue(Moves.x);

            else if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.N))
                moves.Enqueue(Moves.x_);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            toRestart = true;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isShuffled)
                toShuffle = true;
            if (end && isShuffled)
                toRestart = true;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
            if (current_speed < 10 && !end)
            {
                current_speed++;
                SpeedPanel[current_speed].SetActive(true);
                SavePlayer();
            }

        if (Input.GetKeyDown(KeyCode.DownArrow))
            if (current_speed - 1 >= 0 && !end)
            {
                SpeedPanel[current_speed].SetActive(false);
                current_speed--;
                SavePlayer();
            }
    }

    private void Shuffle()
    {
        Move[,] SCRAMBLE = {        { Moves.L, Moves.L_, Moves.L2},
                                    { Moves.U, Moves.U_, Moves.U2},
                                    { Moves.B, Moves.B_, Moves.B2},
                                    { Moves.F, Moves.F_, Moves.F2},
                                    { Moves.D, Moves.D_, Moves.D2},
                                    { Moves.R, Moves.R_, Moves.R2}        };
        int i = 0;
        int prev = 0;
        int current;
        scramble = "";
        while (i < scramble_amount)
        {
            if (i == 0)
                prev = Random.Range(0, 6);

            current = Random.Range(0, 6);

            while (current == prev || (current + prev) == 5)
                current = Random.Range(0, 6);

            prev = current;
            Move move = SCRAMBLE[current, Random.Range(0, 3)];
            moves.Enqueue(move);
            scramble += move.move_name + " ";
            i++;
        }
        UnityEngine.Debug.Log(scramble);
        is_shuffling = true;
        //isShuffled = true;
        toShuffle = false;
    }

    private IEnumerator Rotate()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        if (count == scramble_amount)
        {
            is_shuffling = false;
            isShuffled = true;
        }
        if (!isShuffled && toShuffle)
        {
            Clear();
            Start();
            Shuffle();
        }

        else if (toRestart)
        {
            Clear();
            Start();
            isShuffled = false;
            TImer.ResetTimer();
            count = 0;

        }
       
        else if (moves.Count != 0)
        {
            canRotate = false;
            Move move = moves.Dequeue();

            List<GameObject> layer = GetLayer(move.layer);
            float angle_speed = speed[current_speed];
            for (float i = 0; i < move.angle; i += angle_speed)
            {
                foreach (GameObject go in layer)
                    go.transform.RotateAround(CubeCenterPiece.transform.position, move.RotationVec, angle_speed);
                yield return null;
            }
            if(is_shuffling)
                 count++;
      
            if (isShuffled && !end)
            {
                bool check = Check(move.layer);

                if (check)
                {
                    //SavePlayer();
                    TImer.end = true;
                    LoadPlayer();
                    LastScramble.text = scramble;
                    solvesAmount++;
                    time = TImer.TimeToString();
                    LastTime.text = time;



                    MySesion.Save(new TimeSesion(time, scramble));
                       
                    if (TImer.CompareStringTime(LastTime.text, BestTime.text) == -1)
                        BestTime.text = LastTime.text;

                 
                   
                    UnityEngine.Debug.Log("MovesAmount: " + solvesAmount );
                    SavePlayer();
                    
                  
                    moves.Enqueue(new Move(Layers.LMR, new Vector3(1, 0, 0), 45,""));
                    moves.Enqueue(new Move(Layers.LMR, new Vector3(0, 0, 1), 90, ""));
                    moves.Enqueue(new Move(Layers.LMR, new Vector3(0, 1, 0), 15,""));
                    speed_before_end = current_speed;
                    for (int i = current_speed; i > animation_speed; i--)
                        SpeedPanel[i].SetActive(false);
                    
                    current_speed = animation_speed;
                    
                    end = true;
                }
            }
            if (end)
                if (moves.Count <= 2)
                    moves.Enqueue(new Move(Layers.LMR, new Vector3(0, 1, 0), 15,""));

            canRotate = true;
        }   
    }

    private void Clear()
    {
        foreach (GameObject go in AllCubePieces)
            Destroy(go);
        if(end)
            current_speed = speed_before_end;
        AllCubePieces.Clear();
        moves.Clear();

        toRestart = false;
        end = false;
    }

    private bool Check(Layers layer)
    {
        List<Transform> stickers = new List<Transform>();

        if (layer == Layers.LMR)
            return false;

            foreach (GameObject item in GetLayer(Layers.U))
                stickers.AddRange(item.GetComponentsInChildren<Transform>(false));

            if (!CheckLayer(stickers.FindAll(x => Mathf.Round(x.position.y * 10) == 5)))
                return false;

            //stickers.Clear();
            //foreach (GameObject item in GetLayer(Layers.D))
            //    stickers.AddRange(item.GetComponentsInChildren<Transform>(false));

            //if (!CheckLayer(stickers.FindAll(x => Mathf.Round(x.position.y * 10) == -5)))
            //    return false;
       

            stickers.Clear();
            foreach (GameObject item in GetLayer(Layers.F))
                stickers.AddRange(item.GetComponentsInChildren<Transform>(false));

            if (!CheckLayer(stickers.FindAll(x => Mathf.Round(x.position.x * 10) == 5)))
                return false;

            stickers.Clear();
            foreach (GameObject item in GetLayer(Layers.B))
                stickers.AddRange(item.GetComponentsInChildren<Transform>(false));

            if (!CheckLayer(stickers = stickers.FindAll(x => Mathf.Round(x.position.x * 10) == -5)))
                return false;
        
            stickers.Clear();
            foreach (GameObject item in GetLayer(Layers.R))
                stickers.AddRange(item.GetComponentsInChildren<Transform>(false));
               
            if (!CheckLayer(stickers.FindAll(x => Mathf.Round(x.position.z * 10) == 5)))
                return false;

            stickers.Clear();
            foreach (GameObject item in GetLayer(Layers.L))
                stickers.AddRange(item.GetComponentsInChildren<Transform>(false));

            if (!CheckLayer(stickers = stickers.FindAll(x => Mathf.Round(x.position.z * 10) == -5)))
                return false;
        
        return true;
    }

    private bool CheckLayer(List<Transform> stiker)
    {
        bool first = true;
        string name = "";

        foreach (Transform go in stiker)
        {
            if (first)
                name = go.name;
            else if (!name.Equals(go.name))
                return false;

            first = false;
        }

        return true;
    }

    private void InitSpeedPanel()
    {
        for (int i = 0; i < SpeedPanel.Length; i++)
        {
            if (i <= current_speed)
                SpeedPanel[i].SetActive(true);
            else
                SpeedPanel[i].SetActive(false);
        }
    }

    public void SavePlayer()
    {
        UnityEngine.Debug.Log("Saving MovesAmount: " + solvesAmount);
        SaveSystem.SavePlayer(this);
    }



    public void ResetStats()
    {
        MySesion.ResetSesion();
        solvesAmount = 0;
        BestTime.text = "";
        LastTime.text = "";
        LastScramble.text = "";
        SavePlayer();
        LoadPlayer();
    }


    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer(GetType().Name);
        UnityEngine.Debug.Log("MovesAmount after seri: " + data.solvesAmount);
        solvesAmount = data.solvesAmount;
        SolvesAmount.text = solvesAmount.ToString();
        LastTime.text = data.lastTime;
        BestTime.text = data.bestTime;
        LastScramble.text = data.lastScramble;
        current_speed = data.currentSpeed;
    }
}