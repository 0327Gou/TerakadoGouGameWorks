// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "MagicBase.h"
#include "GameFramework/Character.h"
#include "InventoryC/InventoryCharacterBase.h"
#include "PlayerChara.generated.h"

// �v���C���[�̃p�����[�^
USTRUCT()
struct FPlayerParam {
	GENERATED_BODY()

	UPROPERTY(EditAnywhere)	float fSpeed = 500.0f;				// �ړ����x
	UPROPERTY(EditAnywhere)	float fShotCool = 0.5f;				// �ˌ��N�[���_�E��
	UPROPERTY(EditAnywhere) float fInvincibleTime = 0.1f;		// ���G����

	UPROPERTY(EditAnywhere)	int32 iHP = 100;					// �̗�
	UPROPERTY(EditAnywhere)	int32 iMP = 100;					// ���͗�
	UPROPERTY(EditAnywhere) int32 iMPCharge = 2;				// ���͉񕜗�
	UPROPERTY(EditAnywhere)	int32 iAT = 1;						// �U����
	UPROPERTY(EditAnywhere) int32 iPlayerLevel = 1;				// �v���C���[�̃��x��
	UPROPERTY(EditAnywhere) int32 iPlayerEXP = 0;				// �v���C���[�̌o���l

	UPROPERTY(EditAnywhere) bool bInvincibleFlag = false;		// ���G�t���O
};

UCLASS()
class MAGICGUNNER_API APlayerChara : public ACharacter
{
	GENERATED_BODY()

public:
	// Sets default values for this character's properties
	APlayerChara();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

	// Called to bind functionality to input
	virtual void SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent) override;

	// Input�ɏ��������蓖�Ă邽�߂̃Z�b�g�A�b�v���\�b�h
	void Yaw(const float amount);
	void Pitch(const float amount);

// �ϐ�
public:
	UPROPERTY(EditAnywhere)FPlayerParam PlayerParam;						// �v���C���[�p�����[�^
	UPROPERTY(EditAnywhere)TSubclassOf<AActor> Bullet_BP = NULL;			// �e��BP
	UPROPERTY(EditAnywhere)TSubclassOf<AMagicBase> Magic1_BP = NULL;		// ���@1��BP
	UPROPERTY(EditAnywhere)TSubclassOf<AMagicBase> Magic2_BP = NULL;		// ���@2��BP
	UPROPERTY(EditAnywhere)TSubclassOf<AMagicBase> Magic3_BP = NULL;		// ���@3��BP

private:
	UPROPERTY(EditAnywhere)int m_iLevelUpEXP = 6;			// ���x���A�b�v�ɕK�v�Ȍo���l

	float m_fShotTimer;										// �ˌ��^�C�}�[
	float m_fMagic1Cool;									// ���@1�N�[���_�E��
	float m_fMagic1Timer;									// ���@1�^�C�}�[
	float m_fMagic2Cool;									// ���@2�N�[���_�E��
	float m_fMagic2Timer;									// ���@2�^�C�}�[
	float m_fMagic3Cool;									// ���@3�N�[���_�E��
	float m_fMagic3Timer;									// ���@3�^�C�}�[
	float m_fMagicPoint;									// MP
	float m_fInvincibleTimer;								// ���G���Ԃ̃^�C�}�[

	int m_iMagicCost1;										// ���@1�̃R�X�g
	int m_iMagicLevel1;										// ���@1�̃��x��
	int m_iMagicCost2;										// ���@2�̃R�X�g
	int m_iMagicLevel3;										// ���@2�̃��x��
	int m_iMagicCost3;										// ���@3�̃R�X�g
	int m_iMagicLevel2;										// ���@3�̃��x��
	int m_iOldHP;											// �O��HP�ۑ��p

	bool m_bCanControl;										// ����\��
	bool m_bDamageInvincibleFlag = false;					// �_���[�W���G�t���O

	static constexpr float YawAmount = 1.0f;
	static constexpr float PitchAmount = -1.0f;
	static constexpr float MouseSensitivity = 40.0f;

	int rerollCount = 3;

	AActor* Bullet;
	AMagicBase* Magic1;
	AMagicBase* Magic2;
	AMagicBase* Magic3;

// �֐�
public:
	UFUNCTION(BlueprintCallable)float GetPlayerHP();
	UFUNCTION(BlueprintCallable)float GetMagicCoolTime(int idx);
	UFUNCTION(BlueprintCallable)float GetMagicCool(int idx);
	UFUNCTION(BlueprintCallable)void SetArtifact(int _iSlot, FName _sName, int _iLevel);		// �A�[�e�B�t�@�N�g��ݒ肷��֐�
	UFUNCTION(BlueprintCallable)float GetMagicPoint();
	void AddDamage(int _iDamage);
	void AddMagicPoint(float _mp);
	void AddHP(int _iHP);
	void SetBullet(FString _sName);
	void SetEXP(int _iEXP);

	UFUNCTION(BlueprintCallable)int GetRerollCount() { return rerollCount; }
	UFUNCTION(BlueprintCallable)void DecreaseRerollCount() { --rerollCount; }
	UFUNCTION(BlueprintCallable)void ChangeStatus() { /*m_bCanControl = !m_bCanControl;*/ }

private:
	UFUNCTION(BlueprintCallable)float GetShotInterval();

	void UpdateMove(float _deltaTime);				// �ړ�	
	void Shooting(float _deltaTime);				// �ˌ�
	void Magic1RMouse(float _deltaTime);			// ���@1	
	void Magic2LCtrl(float _deltaTime);				// ���@2	
	void Magic3LShift(float _deltaTime);			// ���@3
	void Init();
	void CorrectionPitch();
	void DamageChecker(float _deltaTime);
	void EXPChangeToLevel();						// �o���l�����x���ɕϊ�
};
