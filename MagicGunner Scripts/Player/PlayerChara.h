// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "MagicBase.h"
#include "GameFramework/Character.h"
#include "InventoryC/InventoryCharacterBase.h"
#include "PlayerChara.generated.h"

// プレイヤーのパラメータ
USTRUCT()
struct FPlayerParam {
	GENERATED_BODY()

	UPROPERTY(EditAnywhere)	float fSpeed = 500.0f;				// 移動速度
	UPROPERTY(EditAnywhere)	float fShotCool = 0.5f;				// 射撃クールダウン
	UPROPERTY(EditAnywhere) float fInvincibleTime = 0.1f;		// 無敵時間

	UPROPERTY(EditAnywhere)	int32 iHP = 100;					// 体力
	UPROPERTY(EditAnywhere)	int32 iMP = 100;					// 魔力量
	UPROPERTY(EditAnywhere) int32 iMPCharge = 2;				// 魔力回復量
	UPROPERTY(EditAnywhere)	int32 iAT = 1;						// 攻撃力
	UPROPERTY(EditAnywhere) int32 iPlayerLevel = 1;				// プレイヤーのレベル
	UPROPERTY(EditAnywhere) int32 iPlayerEXP = 0;				// プレイヤーの経験値

	UPROPERTY(EditAnywhere) bool bInvincibleFlag = false;		// 無敵フラグ
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

	// Inputに処理を割り当てるためのセットアップメソッド
	void Yaw(const float amount);
	void Pitch(const float amount);

// 変数
public:
	UPROPERTY(EditAnywhere)FPlayerParam PlayerParam;						// プレイヤーパラメータ
	UPROPERTY(EditAnywhere)TSubclassOf<AActor> Bullet_BP = NULL;			// 弾のBP
	UPROPERTY(EditAnywhere)TSubclassOf<AMagicBase> Magic1_BP = NULL;		// 魔法1のBP
	UPROPERTY(EditAnywhere)TSubclassOf<AMagicBase> Magic2_BP = NULL;		// 魔法2のBP
	UPROPERTY(EditAnywhere)TSubclassOf<AMagicBase> Magic3_BP = NULL;		// 魔法3のBP

private:
	UPROPERTY(EditAnywhere)int m_iLevelUpEXP = 6;			// レベルアップに必要な経験値

	float m_fShotTimer;										// 射撃タイマー
	float m_fMagic1Cool;									// 魔法1クールダウン
	float m_fMagic1Timer;									// 魔法1タイマー
	float m_fMagic2Cool;									// 魔法2クールダウン
	float m_fMagic2Timer;									// 魔法2タイマー
	float m_fMagic3Cool;									// 魔法3クールダウン
	float m_fMagic3Timer;									// 魔法3タイマー
	float m_fMagicPoint;									// MP
	float m_fInvincibleTimer;								// 無敵時間のタイマー

	int m_iMagicCost1;										// 魔法1のコスト
	int m_iMagicLevel1;										// 魔法1のレベル
	int m_iMagicCost2;										// 魔法2のコスト
	int m_iMagicLevel3;										// 魔法2のレベル
	int m_iMagicCost3;										// 魔法3のコスト
	int m_iMagicLevel2;										// 魔法3のレベル
	int m_iOldHP;											// 前のHP保存用

	bool m_bCanControl;										// 操作可能か
	bool m_bDamageInvincibleFlag = false;					// ダメージ無敵フラグ

	static constexpr float YawAmount = 1.0f;
	static constexpr float PitchAmount = -1.0f;
	static constexpr float MouseSensitivity = 40.0f;

	int rerollCount = 3;

	AActor* Bullet;
	AMagicBase* Magic1;
	AMagicBase* Magic2;
	AMagicBase* Magic3;

// 関数
public:
	UFUNCTION(BlueprintCallable)float GetPlayerHP();
	UFUNCTION(BlueprintCallable)float GetMagicCoolTime(int idx);
	UFUNCTION(BlueprintCallable)float GetMagicCool(int idx);
	UFUNCTION(BlueprintCallable)void SetArtifact(int _iSlot, FName _sName, int _iLevel);		// アーティファクトを設定する関数
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

	void UpdateMove(float _deltaTime);				// 移動	
	void Shooting(float _deltaTime);				// 射撃
	void Magic1RMouse(float _deltaTime);			// 魔法1	
	void Magic2LCtrl(float _deltaTime);				// 魔法2	
	void Magic3LShift(float _deltaTime);			// 魔法3
	void Init();
	void CorrectionPitch();
	void DamageChecker(float _deltaTime);
	void EXPChangeToLevel();						// 経験値をレベルに変換
};
