/*------------------------------------------------------------------
* �t�@�C�����FCarAngler.cs
* �T�v�@�@�@�F��p�̕ύX���s���X�N���v�g
* �S���ҁ@�@�F�k���đ�
* �쐬���@�@�F9/12
-------------------------------------------------------------------*/
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;


namespace AIM
{
    [Serializable]
    public class CarAngler : MonoBehaviour
    {
        // ����Ώۂ̃J����
        private CinemachineVirtualCamera _virtualCamera;

        // �C���v�b�g�֌W���i�[����ׂ̕�
        public WheelInput WheelInput;

        // �g�����X�~�b�V�����̃N���X�擾�̂��ߐ錾
        public Transmission transmission;

        // �ԂɕK�v�ȋ@�\�������Ă���X�N���v�g
        private VehicleController vc;

        //�Ԃ�object
        private GameObject Car;

        // ��p�ύX���g�����ǂ���
        public bool UseCheck;

        // �C���X�y�N�^�[�ŕύX�o���鐔���̕ύX
        // ����p�̕ς�鑬�x��ύX�ł���
        public float SpeedKeisu;

        // Update�O�ɌĂ΂�鏈��
        void Start()
        {
            //�Ԃ�object�Ƃ���ɗp���Ă���X�N���v�g�̎擾
            Car = GameObject.Find("bmw2022");

            // �ϐ��⃁�\�b�h���g�p�ł���悤�ɂ���B
            vc = Car.GetComponent<VehicleController>();

            // �z�C�[���C���v�b�g�̏����ƕϐ����g���������߂ɑ��
            WheelInput = vc.GetWheelInput;
            // �g�����X�~�b�V�����̏����ƕϐ����g���������߂ɑ��
            transmission = vc.GetTransmission;
            // �o�[�`�����J�����𓮂����ׂ̑��
            _virtualCamera = GetComponent<CinemachineVirtualCamera>();
            // ��p�ύX���g�����g��Ȃ����̊m��
            UseCheck = false;
        }

        //���t���[���Ă΂�鏈��
        void Update()
        {
            // T�ŕύX
            // �^�]���ɉ�p�̕ύX�����邩���Ȃ����̐؂�ւ�
            if(Input.GetKeyDown(KeyCode.T))
            {
                // ��p�������Ă��鎞
                if(UseCheck == false)
                {
                    UseCheck = true;
                    // �����l��45�Ȃ̂Ŗ߂�
                    _virtualCamera.m_Lens.FieldOfView = 45;
                }

                // ��p�������Ă��Ȃ���
                else if (UseCheck == true)
                {
                    UseCheck = false;
                }
            }

            // ��p�𓮂����������̂ݏ�������
            if(UseCheck == false)
            {
                TextSpeed();
            }
        }

        // �X�s�[�h�ˑ�
        // �^�]���ɃJ�����̉�p��ύX���鏈��
        public void TextSpeed()
        {
            _virtualCamera.m_Lens.FieldOfView = 45 + (vc.SpeedKPH * SpeedKeisu);
        }
    }
}