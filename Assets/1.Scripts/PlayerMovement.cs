using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public AudioSource mySfx;
    public AudioClip eatSfx;
    public AudioClip barkSfx;

    public GameObject eatEffect;

    public CameraMovement cameraMovement;
    public Corgicollder corgicollder;
    public HungerController hungerController;
    GameObject nearObject;
    public int nearfood;
    public GameObject[] food;
    public GameObject[] putdownfood;
    public GameObject[] Images;
    public GameObject CreatePoint;


    Camera _camera;
    Animator _animator;
    CharacterController _controller;
    [Range(0, 50)]
    public float speed = 5f;
    public float runSpeed = 8f;
    public float finalSpeed;
    public bool toggleCameraRotation;
    public bool run;

    public float transformHeightLimit;
    public float jumpHeightLimit;

    
    [SerializeField]
    public float jumpPower;
    public float jumptime, jumpSpeed;
    public bool jumping = false;

    public float jumpVelocity;

    public float smoothness = 10f;

    public float percent;
    public float fpercent;
    public float spercent;

    public bool stops = false;
    public bool bites = false;

    public int foodIndexs = -1;

    public float IdleRandom, IRandom;
    public bool isDelay = false;
    public float delayTime = 8.4f;

    public float layernum = 1f;


    

    void Start()
    {
        // playeffect = false;
        // eatEffect.Play();
        eatEffect.SetActive(false);
        _animator = this.GetComponent<Animator>();
        _camera = Camera.main;
        _controller = this.GetComponent<CharacterController>();
        cameraMovement = GameObject.Find("Cameras").GetComponent<CameraMovement>();
        corgicollder = GameObject.Find("CorgiCollder").GetComponent<Corgicollder>();
        hungerController = GameObject.Find("Corgi_RM").GetComponent<HungerController>();
    }

    // Update is called once per frame
    void Update()
    {  
        // if(playeffect)
        // {
        //     eatEffect.Play();
        // }
        // else if(!playeffect)
        // {
        //     eatEffect.Stop();
        // }


        ImageOnOff();
        nearObject = corgicollder.nearObject;
        nearfood = corgicollder.nearfood;
        if(Input.GetKey(KeyCode.LeftAlt))
        {
            toggleCameraRotation = true;
        }
        else
        {
            toggleCameraRotation = false;
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            run = true;
        }
        else
        {
            run = false;
        }
    }

    void LateUpdate()
    {
        if(!stops)
        {
            bite();
            bark();
            putdown();
            eat();
        }

        if(toggleCameraRotation != true)
        {
            Vector3 playerRotate = Vector3.Scale(_camera.transform.forward, new Vector3(1,0,1));
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerRotate), Time.deltaTime * smoothness);
        }
    }

    void FixedUpdate()
    {
        InputMovement();
    }

    void stop()
    {
        stops = false;
    }

    void bite2()
    {
        if(nearObject != null)
        {
            foodIndexs = nearfood - 1;
            food[foodIndexs].SetActive(true);
            Destroy(nearObject);
        }
    }

    void putdown2()
    {
        food[foodIndexs].SetActive(false);
        Instantiate(putdownfood[foodIndexs], CreatePoint.transform.position, Quaternion.identity);
        _animator.SetLayerWeight(1, 0f);
        foodIndexs = -1;
    }

    void eat2()
    {
        // playeffect = false;
        eatEffect.SetActive(false);
        food[foodIndexs].SetActive(false);
        _animator.SetLayerWeight(1, 0f);
        foodIndexs = -1;
    }
    
    void bite()
    {
        if(_controller.isGrounded && Input.GetButtonDown("bite") && nearObject != null && bites == false && foodIndexs == -1)
        {
            stops = true;
            bites = true;
            _animator.SetTrigger("doBite");
            _animator.SetLayerWeight(1, 1f);
        }
        else if(_controller.isGrounded && Input.GetButtonDown("bite") && nearObject == null && bites == false && foodIndexs == -1)
        {
            stops = true;
            _animator.SetTrigger("doBite");
        }
        else if(bites == true && foodIndexs == -1)
        {
            bites = false;
            _animator.SetLayerWeight(1, 0f);
        }
    }

    void putdown()
    {
        if(_controller.isGrounded && bites == true && Input.GetButtonDown("bite") && foodIndexs != -1)
        {
            stops = true;
            bites = false;
            _animator.SetTrigger("doPutDown");
        }
    }

    void eat()
    {
        if(_controller.isGrounded && Input.GetButtonDown("eat") && bites == true)
        {
            EatSound();
            eatEffect.SetActive(true);
 
            stops = true;
            bites = false;
            _animator.SetTrigger("doEat");
            _animator.SetLayerWeight(1, 0.65f);
        }
    }

    void bark()
    {
        if(_controller.isGrounded && Input.GetButtonDown("bark"))
        {
            stops = true;
            _animator.SetTrigger("doBark");
            if(bites == true)
            {
                bites = false;
                putdown2();
            }
        }
    }

    void jump()
    {

    }


    void InputMovement()
    {
        if(!stops)
        {
            float v = Input.GetAxisRaw("Vertical");
            float h = Input.GetAxisRaw("Horizontal");
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            Vector3 moveDirection = forward * v + right * h;
            moveDirection = moveDirection.normalized;

            if(run == true && hungerController.Hunger >= 30)
            {
                finalSpeed = runSpeed / 10f;
            }
            else
            {
                finalSpeed = speed / 10f;
            }

            if(cameraMovement.ch == true)
            {
                percent = 0.0f;
                _animator.SetLayerWeight(2, layernum);

                if(v < 0)
                {
                    fpercent = 0.0f;
                    finalSpeed = finalSpeed / 3;
                }
                else if(v == 0)
                {
                    fpercent = 0.0f;
                }
                else
                {
                    fpercent = ((run) ? 1 : 0.5f) * moveDirection.magnitude;
                }

                _animator.SetFloat("MoveSpeed", fpercent, 0.1f, Time.deltaTime);

            }
            else
            {
                _animator.SetLayerWeight(2, 0f);
                if(v < 0)
                {
                    percent = -1.0f;
                    finalSpeed = finalSpeed / 3;
                }
                else if(v == 0)
                {
                    percent = 0.0f;

                }
                else
                {
                    if(run && hungerController.Hunger >= 30)
                    {
                        percent = moveDirection.magnitude;
                    }
                    else
                    {
                        percent = moveDirection.magnitude * 0.45f;
                    }
                }

                if(h > 0)
                {
                    spercent =  0.5f;
                }
                else if(h < 0)
                {
                    spercent =  -0.5f;
                }
                else
                {
                    spercent = 0.0f;
                }
            }


            if(_controller.isGrounded)
            {
                transformHeightLimit = transform.position.y + jumpHeightLimit;
                jumpVelocity = 0f;

                if(Input.GetButtonDown("Jump") && !jumping)
                {
                    jumptime += Time.deltaTime * jumpSpeed * 3;
                    jumping = true;
                    if(cameraMovement.ch == false)
                    {
                        _animator.SetTrigger("doJump");
                    }
                }
            }
            else
            {
                //중력, 하강애니메이션
            }


            if(jumping)
            {
                jumptime -= Time.deltaTime * jumpSpeed;
                jumptime = Mathf.Clamp(jumptime, 0.1f, 2.0f);
                jumpVelocity = Mathf.Lerp(transform.position.y, transformHeightLimit, Time.deltaTime * jumpPower);
                moveDirection.y += jumpVelocity;

                if(transform.position.y >= transformHeightLimit || jumptime<=0.1f)
                {
                    jumping = false;
                    transformHeightLimit = 0.0f;
                }
            }

            if(!isDelay)
            {
                IRandom =  UnityEngine.Random.Range(0, 16);
                isDelay = true;
                if(IRandom >= 15 && cameraMovement.ch == false)
                {
                    IdleRandom = 0f;
                }
                else if(IRandom <= 15 && cameraMovement.ch == false)
                {
                    IdleRandom = UnityEngine.Random.Range(1.0f, 2.0f);
                }
                else if(cameraMovement.ch == true)
                {
                    IdleRandom = 1f;
                }
                StartCoroutine(idleRan());
            }

            _animator.SetFloat("Side", IdleRandom, 0.1f, Time.deltaTime/10.0f);
            _animator.SetFloat("Blend", percent, 0.1f, Time.deltaTime);
            _animator.SetFloat("LR", spercent, 0.1f, Time.deltaTime);

            _controller.Move(moveDirection * finalSpeed * Time.deltaTime);
        }

    }

    IEnumerator idleRan()
    {
        yield return new WaitForSecondsRealtime(delayTime);
        isDelay = false;
    }

    void ImageOnOff()
    {
        if(foodIndexs == -1)
        {
            Images[0].SetActive(false);
            Images[1].SetActive(false);
            //Images[2].SetActive(false);
            //Images[3].SetActive(false);
            //Images[4].SetActive(false);
        }
        else if(foodIndexs == 0)
        {
            Images[foodIndexs].SetActive(true);
            Images[1].SetActive(false);
            //Images[2].SetActive(false);
            //Images[3].SetActive(false);
            //Images[4].SetActive(false);
        }
        else if(foodIndexs == 1)
        {
            Images[foodIndexs].SetActive(true);
            Images[0].SetActive(false);
            //Images[2].SetActive(false);
            //Images[3].SetActive(false);
            //Images[4].SetActive(false);
        }
        /*else if(foodIndexs == 2)
        {
            Images[foodIndexs].SetActive(true);
            Images[0].SetActive(false);
            Images[1].SetActive(false);
            Images[3].SetActive(false);
            Images[4].SetActive(false);
        }
        else if(foodIndexs == 3)
        {
            Images[foodIndexs].SetActive(true);
            Images[0].SetActive(false);
            Images[1].SetActive(false);
            Images[2].SetActive(false);
            Images[4].SetActive(false);
        }
        else if(foodIndexs == 4)
        {
            Images[foodIndexs].SetActive(true);
            Images[0].SetActive(false);
            Images[1].SetActive(false);
            Images[2].SetActive(false);
            Images[3].SetActive(false);
        }*/
    }

    public void HeadOnOff()
    {
        if(layernum == 1)
        {
            layernum = 0;
        }
        else
        {
            layernum = 1;
        }
    }

    public void EatSound()
    {
        mySfx.PlayOneShot(eatSfx);
    }

    public void BarkSound()
    {
        mySfx.PlayOneShot(barkSfx);
    }
}
