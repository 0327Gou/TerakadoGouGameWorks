// �C���N���[�h�K�[�h
#pragma once

// �C���N���[�h
#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "MagicBase.generated.h"

// �O���錾
class APlayerChara;

UCLASS()
class MAGICGUNNER_API AMagicBase : public AActor
{
	GENERATED_BODY()

public:
	// �ϐ��̏�����
	AMagicBase();

protected:
	// �������ɌĂяo�����
	virtual void BeginPlay() override;

public:
	// ���t���[���Ăяo�����
	virtual void Tick(float DeltaTime) override;


// �ϐ�
public:
	APlayerChara* m_pPlayer;	// �v���C���[
	int m_iLevel;	// ���@�̃��x��

protected:
	UPROPERTY(EditAnywhere)float m_fMagicCool = 4.0f;		// ���@�̃N�[���_�E��
	UPROPERTY(EditAnywhere)float m_fDestroyTime = 3.0f;		// ���@�̎�������
	UPROPERTY(EditAnywhere)int m_iMagicCost = 10.0f;		// ���@�̏���R�X�g

private:
	float m_fDestroyTimer;		// �������Ԃ̃^�C�}�[

// �֐�
public:
	void SetiLevel(int _iLevel);
	void SetPlayer(APlayerChara* _p);
	float GetfMagicCool();
	int GetiMagicCost();

	// 
	virtual void LevelSetting(int _iLevel);
	virtual void LevelSettingCustom();
	virtual void MagicStart();
	virtual void MagicEnd();
};
