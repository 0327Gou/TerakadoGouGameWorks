// Fill out your copyright notice in the Description page of Project Settings.
#include "MagicSatellite.h"
#include "GameFramework/Actor.h"
#include "BulletSatellite.h"

// Sets default values
AMagicSatellite::AMagicSatellite()
	: fAngle(0.0f)
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;
}

// Called when the game starts or when spawned
void AMagicSatellite::BeginPlay()
{
	Super::BeginPlay();
}

// Called every frame
void AMagicSatellite::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
}

void AMagicSatellite::MagicStart() {
	if (Bullet_BP == NULL) { return; }

	int iSatelliteNum = m_iLevel + 1;

	// ���x�����Ŋp�x�������Đ����p�x��ݒ�
	fAngle  = (360.0f / (float)iSatelliteNum) * (PI / 180);

	// ���x�����J��Ԃ��Ēe����
	for (int i = 0; i <= iSatelliteNum; i++) {
		ABulletSatellite* aaBullet = Cast<ABulletSatellite>(GetWorld()->SpawnActor<AActor>(Bullet_BP));
		aaBullet->SettingsSatellite(fAngle * i, m_pPlayer);
	}
}
