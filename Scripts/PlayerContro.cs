using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerContro : MonoBehaviour
{



    Animator anim;
    [SerializeField]
    public float KarakterHiz;
    public Image kitapBilgiEkranı;
    public Image bilgiEkranı;
    public Text taskContent;
    public Image envanter;
   //public Image tebrikEkranı;
   // public Image levelBilgiEkranı;
    public RawImage RawImageAnimal;
    public RawImage keyImage;
    private bool isOpened = false;
    public Transform cam;
    public GameObject oliver;
    public int speed;
    float turnSmootVelocity;
    public float turnSmoothTime = 0.3f;
    public CharacterController characterController;
    float timeLeft = 5.0f;
    float finishTime = 3.0f;
    bool anahtarAlındıMı = false;
    bool oyunBittiMi = false;
    bool doktorunEviBulunduMu = false;
    public GameObject ilaclar;
    public Text kafesTamamlandi;
    public Text ilacTamamlandi;
    





    // Start is called before the first frame update
    void Start()
    {

        anim = this.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        Hareket();
      
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (envanter.gameObject.activeInHierarchy)
            {
                envanter.gameObject.SetActive(false);
            }
            else
            {
                envanter.gameObject.SetActive(true);
            }
            

        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmootVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * speed * Time.deltaTime);


        }
        if (bilgiEkranı.gameObject.activeInHierarchy)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 1)
            {
                bilgiEkranı.gameObject.SetActive(false);
                timeLeft = 3.0f;
            }
        }

        if (oyunBittiMi)
        {
            finishTime -= Time.deltaTime;
            if (finishTime < 0)
            {
                //tebrikEkranı.gameObject.SetActive(true);
                SceneManager.LoadScene(3);
                finishTime = 3.0f;
            }
        }

    }
    void Hareket()
    {
        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");
        anim.SetFloat("Horizontal", yatay);
        anim.SetFloat("Vertical", dikey);
        this.gameObject.transform.Translate(yatay * KarakterHiz * Time.deltaTime, 0, dikey * KarakterHiz * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "book")
        {
            kitapBilgiEkranı.gameObject.SetActive(true);
            TaskTextContent.textContent = "Mutasyona uğramış hayvanların kapatıldığı evi bul.";
            //BilgiText.textBilgi = "Dr. Brandon'ın hayvanlar üzerinde deneyler yaptığı adaya düştün. Dikkat et hayvanlar mutasyona uğradı. Senden onları iyileştirip kurtarmanı bekliyoruz. Daha sonra Dr. Brandon'ın evini bulduğunda ona yakalanmadan anahtarları alıp evinin üst katındaki hayvanı kurtarmanı bekliyoruz. İyi şanslar..";




        }
        if (other.gameObject.tag == "kafes" && MedicineText.counter < 2)
        {


            bilgiEkranı.gameObject.SetActive(true);
            BilgiText.textBilgi = "Hayvanları kurtarmak için önce dışardan ilaçları toplamalısın.";
           


        }
        if (other.gameObject.tag == "doctorDoor" && !doktorunEviBulunduMu)
        {
            
            bilgiEkranı.gameObject.SetActive(true);
            BilgiText.textBilgi = "Tebrikler doktorun evini buldun!";
            TaskTextContent.textContent = "Doktora yakalanmadan anahtaları al.";
            doktorunEviBulunduMu = true;

        }
       



        if (other.gameObject.tag == "key")
        {


            keyImage.gameObject.SetActive(true);
            anahtarAlındıMı = true;

            Destroy(other.gameObject);
            TaskTextContent.textContent = "Üst kattaki hayvanları kurtar.";

        }

        if (other.gameObject.tag == "doctorBird" && MedicineText.counter >= 4 && anahtarAlındıMı)

        {
           
            other.gameObject.transform.localScale = new Vector3(4f, 4f, 4f);
            oyunBittiMi = true;



        }
        else if(other.gameObject.tag == "doctorBird" && (MedicineText.counter < 4 || !anahtarAlındıMı))
        {
            bilgiEkranı.gameObject.SetActive(true);
            BilgiText.textBilgi = "Hayvanı kurtarmak için önce ilaçları toplamalısın ve anahtarı doktordan almalısın.";
        }
        




        else if(other.gameObject.tag == "kafes" && MedicineText.counter >= 2)
        {
            MedicineText.counter -= 2;
            AnimalText.counterAnimal += 1;
            Destroy(other.gameObject);
            

            bilgiEkranı.gameObject.SetActive(true);
            BilgiText.textBilgi = "Tebrikler! Hayvanı kurtardın...";

            if (AnimalText.counterAnimal > 5)
            {


                TaskTextContent.textContent = "Şimdi Doktorun evini bul.";
                kafesTamamlandi.gameObject.SetActive(true);
               // ilacTamamlandi.gameObject.SetActive(true);


            }





        }
        else if (other.gameObject.tag == "doorLevel1")
        {
            if (isOpened == false)
            {
                // levelBilgiEkranı.gameObject.SetActive(true);
                bilgiEkranı.gameObject.SetActive(true);
                BilgiText.textBilgi = "Tebrikler evi buldun!\nŞimdi hayvanları kurtarma zamanı!";
                isOpened = true;
                ilaclar.gameObject.SetActive(true);
                RawImageAnimal.gameObject.SetActive(true);
                TaskTextContent.textContent = "Mutasyona uğramış hayvanları kurtar.\nUnutma her mutasyona uğramış hayvanı iyileştirmek için iki ilaca ihtiyacın var.\nTopladığın ilaç miktarını Envanter(E'ye bas)'de görebilirsin.";
            }
            

        }

    }
    public void Close()
    {
        
       //  kafesBilgiEkranı.gameObject.SetActive(false);
       //tebrikEkranı.gameObject.SetActive(false);
       // levelBilgiEkranı.gameObject.SetActive(false);
        
        kitapBilgiEkranı.gameObject.SetActive(false);


    }
}
