// インクルードガード
#pragma once

// インクルード
#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "MagicBase.generated.h"

// 前方宣言
class APlayerChara;

UCLASS()
class MAGICGUNNER_API AMagicBase : public AActor
{
	GENERATED_BODY()

public:
	// 変数の初期化
	AMagicBase();

protected:
	// 生成時に呼び出される
	virtual void BeginPlay() override;

public:
	// 毎フレーム呼び出される
	virtual void Tick(float DeltaTime) override;


// 変数
public:
	APlayerChara* m_pPlayer;	// プレイヤー
	int m_iLevel;	// 魔法のレベル

protected:
	UPROPERTY(EditAnywhere)float m_fMagicCool = 4.0f;		// 魔法のクールダウン
	UPROPERTY(EditAnywhere)float m_fDestroyTime = 3.0f;		// 魔法の持続時間
	UPROPERTY(EditAnywhere)int m_iMagicCost = 10.0f;		// 魔法の消費コスト

private:
	float m_fDestroyTimer;		// 持続時間のタイマー

// 関数
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
