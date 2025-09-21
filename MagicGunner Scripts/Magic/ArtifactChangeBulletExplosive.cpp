// Fill out your copyright notice in the Description page of Project Settings.

#include "ArtifactChangeBulletExplosive.h"
#include "PlayerChara.h"

// Sets default values
AArtifactChangeBulletExplosive::AArtifactChangeBulletExplosive()
{
	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;
}

// Called when the game starts or when spawned
void AArtifactChangeBulletExplosive::BeginPlay()
{
	Super::BeginPlay();
}

// Called every frame
void AArtifactChangeBulletExplosive::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
}

void AArtifactChangeBulletExplosive::MagicStart() {
	m_pPlayer->SetBullet(FString("Explosive"));
}

void AArtifactChangeBulletExplosive::MagicEnd() {
	m_pPlayer->SetBullet(FString(""));
}

void AArtifactChangeBulletExplosive::LevelSettingCustom() {
	m_fMagicCool += m_iLevel;
	m_fDestroyTime += m_iLevel;
}