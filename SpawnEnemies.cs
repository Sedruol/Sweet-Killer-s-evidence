using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;

public class SpawnEnemies : MonoBehaviour
{
    public Player player;
    public GameObject CaraBombaPrefab;
    public GameObject CaramelinPrefab;
    public GameObject GalletaPrefab;
    public GameObject GelatinaPrefab;
    public GameObject GusanoPrefab;
    public GameObject PegajosoPrefab;
    private float RespawnTime;
    private Vector2 ScreenBounds;
    public Sprite gela0;
    public Sprite gela1;
    public Sprite gela2;
    public Sprite gela3;
    public Sprite gela4;
    public Sprite gela5;
    int n;
    int n_cb;
    int Enem;
    float EnemSpeedX;
    private Rigidbody2D RBEnemy;
    private SkeletonAnimation SAEnemy;
    private float RT;
    public int dash = 0;
    public List<GameObject> ListaEnems = new List<GameObject>();
    

    // Start is called before the first frame update
    void Start()
    {
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        RespawnTime = Globales.instance.RespawnTime;
        RT = RespawnTime;
    }
    private void SpawnEnemy(int n)
    {
        if (player.isActiveAndEnabled == true)
        {
            switch (n)
            {
                //CarameloBomba
                case 0:
                    GameObject CB;
                    n_cb = Random.Range(0, 3);
                    CB = Instantiate(CaraBombaPrefab) as GameObject;
                    CB.transform.position = new Vector2(ScreenBounds.x * 1.2f, Random.Range(100.0f, ScreenBounds.y - 100.0f));
                    ListaEnems.Add(CB);
                    SAEnemy = CB.GetComponent<SkeletonAnimation>();
                    if (n_cb == 0)
                        SAEnemy.AnimationState.SetAnimation(0, "Movimiento_Bomba_Amarillo", true);
                    else if (n_cb == 1)
                        SAEnemy.AnimationState.SetAnimation(0, "Movimiento_Bomba_Azul", true);
                    else
                        SAEnemy.AnimationState.SetAnimation(0, "Movimiento_Bomba_rosa", true);
                    break;
                //Caramelin
                case 1:
                    n_cb = Random.Range(0, 3);
                    GameObject C = Instantiate(CaramelinPrefab) as GameObject;
                    C.transform.position = new Vector2(ScreenBounds.x * 1.5f, Random.Range(100.0f, ScreenBounds.y - 100.0f));
                    ListaEnems.Add(C);
                    SAEnemy = C.GetComponent<SkeletonAnimation>();
                    if (n_cb == 0)
                        SAEnemy.AnimationState.SetAnimation(0, "Movimiento_Azul", true);
                    else if (n_cb == 1)
                        SAEnemy.AnimationState.SetAnimation(0, "Movimiento_Rojo", true);
                    else
                        SAEnemy.AnimationState.SetAnimation(0, "Movimiento_Verde", true);
                    break;
                //Galleta
                case 2:
                    n_cb = Random.Range(0, 2);
                    GameObject G = Instantiate(GalletaPrefab) as GameObject;
                    G.transform.position = new Vector2(ScreenBounds.x * 1.5f, Random.Range(100.0f, ScreenBounds.y) - 100.0f);
                    ListaEnems.Add(G);
                    SAEnemy = G.GetComponent<SkeletonAnimation>();
                    if (n_cb == 0)
                        SAEnemy.AnimationState.SetAnimation(0, "Abre Boca_chocolate", true);
                    else
                        SAEnemy.AnimationState.SetAnimation(0, "Abre_Boca_vainilla", true);
                    break;
                //Gelatina
                case 3:
                    n_cb = Random.Range(0, 6);
                    GameObject Ge = Instantiate(GelatinaPrefab) as GameObject;
                    Ge.transform.position = new Vector2(ScreenBounds.x * 1.5f, Random.Range(100.0f, ScreenBounds.y - 100.0f));
                    if (n_cb == 0)
                    {
                        Ge.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = gela0;
                        Ge.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = gela0;
                        Ge.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = gela0;
                    }
                    if (n_cb == 1)
                    {
                        Ge.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = gela1;
                        Ge.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = gela1;
                        Ge.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = gela1;
                    }
                    if (n_cb == 2)
                    {
                        Ge.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = gela2;
                        Ge.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = gela2;
                        Ge.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = gela2;
                    }
                    if (n_cb == 3)
                    {
                        Ge.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = gela3;
                        Ge.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = gela3;
                        Ge.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = gela3;
                    }
                    if (n_cb == 4)
                    {
                        Ge.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = gela4;
                        Ge.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = gela4;
                        Ge.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = gela4;
                    }
                    if (n_cb == 5)
                    {
                        Ge.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = gela5;
                        Ge.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = gela5;
                        Ge.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = gela5;
                    }
                    ListaEnems.Add(Ge);
                    SAEnemy = Ge.GetComponent<SkeletonAnimation>();
                    break;
                //Gusano
                case 4:
                    GameObject Gu = Instantiate(GusanoPrefab) as GameObject;
                    Gu.transform.position = new Vector2(ScreenBounds.x * 1.5f, Random.Range(100.0f, ScreenBounds.y - 100.0f));
                    ListaEnems.Add(Gu);
                    SAEnemy = Gu.GetComponent<SkeletonAnimation>();
                    break;
                //Pegajoso
                case 5:
                    GameObject P = Instantiate(PegajosoPrefab) as GameObject;
                    P.transform.position = new Vector2(ScreenBounds.x * 1.5f, Random.Range(100.0f, ScreenBounds.y - 100.0f));
                    ListaEnems.Add(P);
                    SAEnemy = P.GetComponent<SkeletonAnimation>();
                    break;
            }
        }
    }
    IEnumerator EnemyWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(RespawnTime);
            if (Enem < 50)
            {
                if (Globales.instance.Invocar != 6) { n = Globales.instance.Invocar; }
                else { n = Random.Range(0, 6); }
                SpawnEnemy(n);
                Enem++;
            }
        }
    }
    private void Update()
    {
        for (int i = 0; i < ListaEnems.Count; i++)
        {
            if (ListaEnems[i] == null) { ListaEnems.Remove(ListaEnems[i]); Enem--; }
        }
        if (Globales.instance.dash)
        {

            if (dash == 0)
            {
                RespawnTime = RespawnTime / Globales.instance.DashSpeed;
                dash = 1;
            }
        } else {RespawnTime = RT; dash = 0;}
    }
}
