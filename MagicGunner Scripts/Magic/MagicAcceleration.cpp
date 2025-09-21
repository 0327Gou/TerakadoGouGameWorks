// インクルード
#include "MagicAcceleration.h"
#include "PlayerChara.h"
#include "GameFramework/Actor.h"

// 初期化
AMagicAcceleration::AMagicAcceleration()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;
}

// 生成時に呼び出される
void AMagicAcceleration::BeginPlay()
{
	Super::BeginPlay();
}

// 毎フレーム呼び出される
void AMagicAcceleration::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
}

// 魔法が開始したときに呼び出される
void AMagicAcceleration::MagicStart() {
	// 元のスピードを保存
	m_fDefaultSpeed = m_pPlayer->PlayerParam.fSpeed;
	
	// スピードを上昇
	m_pPlayer->PlayerParam.fSpeed = m_pPlayer->PlayerParam.fSpeed * (1 + m_fBoostSpeed * m_iLevel);
}

// 魔法が終了したときに呼び出される
void AMagicAcceleration::MagicEnd() {
	// 元のスピードに戻す
	m_pPlayer->PlayerParam.fSpeed = m_fDefaultSpeed;
}



