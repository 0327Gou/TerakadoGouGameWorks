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

	// �^�C�}�[�̏�����
	m_fDestroyTimer = 0.0f;
}

// Called every frame
void AMagicBase::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

	// ���Ԍo�߂Ŏ��g������
	m_fDestroyTimer += DeltaTime;
	if (m_fDestroyTimer > m_fDestroyTime) {
		MagicEnd();
		this->Destroy();
	}
}

// ���x���̐ݒ�
void AMagicBase::SetiLevel(int _iLevel) {
	m_iLevel = _iLevel; 
	LevelSettingCustom();
}

// �v���C���[��ݒ肷��֐�
void AMagicBase::SetPlayer(APlayerChara* _p) {	m_pPlayer = _p; }

// ���@�̃N�[���_�E����Ԃ��֐�
float AMagicBase::GetfMagicCool() {	return m_fMagicCool; }

// �R�X�g���擾����֐�
int AMagicBase::GetiMagicCost() { return m_iMagicCost; }
void AMagicBase::MagicStart(){}
void AMagicBase::MagicEnd(){}
void AMagicBase::LevelSetting(int _iLevel){}
void AMagicBase::LevelSettingCustom(){}