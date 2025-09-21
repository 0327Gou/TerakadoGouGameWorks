// Fill out your copyright notice in the Description page of Project Settings.

#include "MagicBase.h"

// Sets default values
AMagicBase::AMagicBase()
	: m_pPlayer(NULL)
	, m_fDestroyTimer(0.0f)
	, m_iLevel(1)
{
	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;
}

// Called when the game starts or when spawned
void AMagicBase::BeginPlay()
{
	Super::BeginPlay();

	// タイマーの初期化
	m_fDestroyTimer = 0.0f;
}

// Called every frame
void AMagicBase::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

	// 時間経過で自身を消す
	m_fDestroyTimer += DeltaTime;
	if (m_fDestroyTimer > m_fDestroyTime) {
		MagicEnd();
		this->Destroy();
	}
}

// レベルの設定
void AMagicBase::SetiLevel(int _iLevel) {
	m_iLevel = _iLevel; 
	LevelSettingCustom();
}

// プレイヤーを設定する関数
void AMagicBase::SetPlayer(APlayerChara* _p) {	m_pPlayer = _p; }

// 魔法のクールダウンを返す関数
float AMagicBase::GetfMagicCool() {	return m_fMagicCool; }

// コストを取得する関数
int AMagicBase::GetiMagicCost() { return m_iMagicCost; }
void AMagicBase::MagicStart(){}
void AMagicBase::MagicEnd(){}
void AMagicBase::LevelSetting(int _iLevel){}
void AMagicBase::LevelSettingCustom(){}