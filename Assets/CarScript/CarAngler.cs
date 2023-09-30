/*------------------------------------------------------------------
* ファイル名：CarAngler.cs
* 概要　　　：画角の変更を行うスクリプト
* 担当者　　：北村翔太
* 作成日　　：9/12
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
        // 制御対象のカメラ
        private CinemachineVirtualCamera _virtualCamera;

        // インプット関係を格納する為の物
        public WheelInput WheelInput;

        // トランスミッションのクラス取得のため宣言
        public Transmission transmission;

        // 車に必要な機能が入っているスクリプト
        private VehicleController vc;

        //車のobject
        private GameObject Car;

        // 画角変更を使うかどうか
        public bool UseCheck;

        // インスペクターで変更出来る数字の変更
        // 視野角の変わる速度を変更できる
        public float SpeedKeisu;

        // Update前に呼ばれる処理
        void Start()
        {
            //車のobjectとそれに用いているスクリプトの取得
            Car = GameObject.Find("bmw2022");

            // 変数やメソッドを使用できるようにする。
            vc = Car.GetComponent<VehicleController>();

            // ホイールインプットの処理と変数を使いたいために代入
            WheelInput = vc.GetWheelInput;
            // トランスミッションの処理と変数を使いたいために代入
            transmission = vc.GetTransmission;
            // バーチャルカメラを動かす為の代入
            _virtualCamera = GetComponent<CinemachineVirtualCamera>();
            // 画角変更を使うか使わないかの確定
            UseCheck = false;
        }

        //毎フレーム呼ばれる処理
        void Update()
        {
            // Tで変更
            // 運転中に画角の変更をするかしないかの切り替え
            if(Input.GetKeyDown(KeyCode.T))
            {
                // 画角が動いている時
                if(UseCheck == false)
                {
                    UseCheck = true;
                    // 初期値が45なので戻す
                    _virtualCamera.m_Lens.FieldOfView = 45;
                }

                // 画角が動いていない時
                else if (UseCheck == true)
                {
                    UseCheck = false;
                }
            }

            // 画角を動かしたい時のみ処理する
            if(UseCheck == false)
            {
                TextSpeed();
            }
        }

        // スピード依存
        // 運転中にカメラの画角を変更する処理
        public void TextSpeed()
        {
            _virtualCamera.m_Lens.FieldOfView = 45 + (vc.SpeedKPH * SpeedKeisu);
        }
    }
}