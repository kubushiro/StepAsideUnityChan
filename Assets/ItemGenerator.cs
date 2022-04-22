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
    private int startPos = 80;

    //�S�[���n�_
    private int goalPos = 360;

    //�A�C�e�����o���������͈̔�
    private float posRange = 3.4f;


    // Start is called before the first frame update
    void Start()
    {

        //���̋������ƂɃA�C�e��
        for (int i = startPos; i < goalPos; i += 15)
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
        
    }
}
