// インクルード
#include "BulletSatellite.h"

// コンストラクタ
ABulletSatellite::ABulletSatellite()
{
 	// ティックを呼ぶかどうか
	PrimaryActorTick.bCanEverTick = true;
}

// 生成された時の処理
void ABulletSatellite::BeginPlay()
{
	Super::BeginPlay();
}

// 毎フレームの処理
void ABulletSatellite::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

	// 弾の位置を更新
	SetActorLocation(m_pPlayer->GetActorLocation() + Satellite(m_fBulletSpeed, m_fRadius, m_fAngle));
}

// 周回起動を計算する関数
FVector ABulletSatellite::Satellite(float _fSpeed, float _fRadius, float _fAngle) {
	// 値保存用
	FVector fvResult(0.0, 0.0, 0.0);

	// 周波数の測定(補正)
	float fFrequency = _fSpeed / 100; 

	// 回転座標を求める処理
	fvResult.X = _fRadius * sinf(GetGameTimeSinceCreation() * 2 * PI * fFrequency + _fAngle);      // X軸の設定
	fvResult.Y = _fRadius * cosf(GetGameTimeSinceCreation() * 2 * PI * fFrequency + _fAngle);      // Y軸の設定

	return fvResult;
}

// 弾の初期角度とプレイヤー（回転元）を設定する関数
void ABulletSatellite::SettingsSatellite(float _fAngle, APlayerChara* _pPlayer) {
	// 角度の設定
	m_fAngle = _fAngle;
	
	// プレイヤーの設定
	m_pPlayer = _pPlayer;
}

// 敵に当たったら弾を削除する
void ABulletSatellite::EnemyHit(AActor* OtherActor) {
	// 球を削除する
	this->Destroy();
}