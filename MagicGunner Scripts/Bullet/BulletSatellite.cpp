// �C���N���[�h
#include "BulletSatellite.h"

// �R���X�g���N�^
ABulletSatellite::ABulletSatellite()
{
 	// �e�B�b�N���ĂԂ��ǂ���
	PrimaryActorTick.bCanEverTick = true;
}

// �������ꂽ���̏���
void ABulletSatellite::BeginPlay()
{
	Super::BeginPlay();
}

// ���t���[���̏���
void ABulletSatellite::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

	// �e�̈ʒu���X�V
	SetActorLocation(m_pPlayer->GetActorLocation() + Satellite(m_fBulletSpeed, m_fRadius, m_fAngle));
}

// ����N�����v�Z����֐�
FVector ABulletSatellite::Satellite(float _fSpeed, float _fRadius, float _fAngle) {
	// �l�ۑ��p
	FVector fvResult(0.0, 0.0, 0.0);

	// ���g���̑���(�␳)
	float fFrequency = _fSpeed / 100; 

	// ��]���W�����߂鏈��
	fvResult.X = _fRadius * sinf(GetGameTimeSinceCreation() * 2 * PI * fFrequency + _fAngle);      // X���̐ݒ�
	fvResult.Y = _fRadius * cosf(GetGameTimeSinceCreation() * 2 * PI * fFrequency + _fAngle);      // Y���̐ݒ�

	return fvResult;
}

// �e�̏����p�x�ƃv���C���[�i��]���j��ݒ肷��֐�
void ABulletSatellite::SettingsSatellite(float _fAngle, APlayerChara* _pPlayer) {
	// �p�x�̐ݒ�
	m_fAngle = _fAngle;
	
	// �v���C���[�̐ݒ�
	m_pPlayer = _pPlayer;
}

// �G�ɓ���������e���폜����
void ABulletSatellite::EnemyHit(AActor* OtherActor) {
	// �����폜����
	this->Destroy();
}