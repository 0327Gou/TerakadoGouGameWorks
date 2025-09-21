// �C���N���[�h
#include "MagicAcceleration.h"
#include "PlayerChara.h"
#include "GameFramework/Actor.h"

// ������
AMagicAcceleration::AMagicAcceleration()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;
}

// �������ɌĂяo�����
void AMagicAcceleration::BeginPlay()
{
	Super::BeginPlay();
}

// ���t���[���Ăяo�����
void AMagicAcceleration::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
}

// ���@���J�n�����Ƃ��ɌĂяo�����
void AMagicAcceleration::MagicStart() {
	// ���̃X�s�[�h��ۑ�
	m_fDefaultSpeed = m_pPlayer->PlayerParam.fSpeed;
	
	// �X�s�[�h���㏸
	m_pPlayer->PlayerParam.fSpeed = m_pPlayer->PlayerParam.fSpeed * (1 + m_fBoostSpeed * m_iLevel);
}

// ���@���I�������Ƃ��ɌĂяo�����
void AMagicAcceleration::MagicEnd() {
	// ���̃X�s�[�h�ɖ߂�
	m_pPlayer->PlayerParam.fSpeed = m_fDefaultSpeed;
}



