using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemDestroy : MonoBehaviour
{


    //�J�����̈ʒu
    private GameObject Camera;

    public float ConeDifference { get; private set; }

    //�A�C�e���̈ʒu�ƃJ�����̈ʒu�̍�
    private GameObject ItemDifference;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //�J�����I�u�W�F�N�g�̎擾
        this.Camera = GameObject.Find("Main Camera");

        //�A�C�e���̈ʒu�ƃJ�����̈ʒu�̍�
        this.ConeDifference = this.transform.position.z - this.Camera.transform.position.z;

        //�A�C�e����Z���W����J������Z���W���������l�����̎�
        if(ConeDifference < 0)
        {
            //�I�u�W�F�N�g��j��
            Destroy(this.gameObject);
        }
    }
}
