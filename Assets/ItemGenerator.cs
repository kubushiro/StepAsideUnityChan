using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{

    //carPrefab������
    public GameObject carPrefab;

    //coinPrefab������
    public GameObject coinPrefab;

    //cornPrefab������
    public GameObject conePrefab;

    //�X�^�[�g�n�_
    private int startPos = 40;

    //�S�[���n�_
    private int goalPos = 360;

    //�A�C�e�����o���������͈̔�
    private float posRange = 3.4f;

    //���W�ۑ�
    //Unity�����I�u�W�F�N�g
    private GameObject unitychan;

    //�A�C�e�������ʒu
    private float ZDifference;

    //�Ō�ɃA�C�e���𐶐������ۂ�Z���W���L�����邽�߂̕ϐ�
    private float lastGeneratePosZ;

    // Start is called before the first frame update
    void Start()
    {

        //���W�ۑ�
        //Unity�����̃I�u�W�F�N�g���擾
        this.unitychan = GameObject.Find("unitychan");
        this.lastGeneratePosZ = 50;

        //���̋������ƂɃA�C�e���𐶐�
        for (int i = startPos; i < startPos + 50; i += 15)
        {
            //��������A�C�e���������_���Ō���
            int num = Random.Range(1, 11);
            if(num <= 2)
            {
                //�R�[�������������ɂP�����ɐ���
                for (float j = -1; j <= 1; j += 0.4f)
                {

                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);

                }
            }
            else
            {
                //���[�����ƂɃA�C�e���̐���
                for(int j = -1; j <= 1; j++)
                {
                    //�A�C�e���̎�ނ�����
                    int item = Random.Range(1, 11);
                    //�A�C�e����u�������W�̃I�t�Z�b�g�������_���ɐݒ�
                    int offsetZ = Random.Range(-5, 6);
                    //60%�R�C���z�u�F30%�Ԕz�u�F10%�����Ȃ�
                    if(1 <= item && item <= 6)
                    {
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                    }
                    else if(7 <= item && item <= 9)
                    {
                        //�Ԑ���
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                    }
                }
            }

        }

    }

    // Update is called once per frame
    void Update()
    {

        //���W�ۑ�
        this.ZDifference = this.unitychan.transform.position.z + 50; 

        //���̋������ƂɃA�C�e���𐶐�
        if (this.unitychan.transform.position.z - lastGeneratePosZ >= 15 && this.ZDifference < goalPos )
        { 
            //��������A�C�e���������_���Ō���
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //�R�[�������������ɂP�����ɐ���
                for (float i = -1; i <= 1; i += 0.4f)
                {

                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * i, cone.transform.position.y, ZDifference);

                }
            }
            else
            {
                //���[�����ƂɃA�C�e���̐���
                for (int i = -1; i <= 1; i++)
                {
                    //�A�C�e���̎�ނ�����
                    int item = Random.Range(1, 11);
                    //�A�C�e����u�������W�̃I�t�Z�b�g�������_���ɐݒ�
                    int offsetZ = Random.Range(-5, 6);
                    //60%�R�C���z�u�F30%�Ԕz�u�F10%�����Ȃ�
                    if (1 <= item && item <= 6)
                    {
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * i, coin.transform.position.y, ZDifference + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //�Ԑ���
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * i, car.transform.position.y, ZDifference + offsetZ);
                    }
                }
            }
            //�Ō�ɃA�C�e���𐶐������ۂ�Unity������Z���W
            this.lastGeneratePosZ = this.unitychan.transform.position.z;

        }
    }
}
