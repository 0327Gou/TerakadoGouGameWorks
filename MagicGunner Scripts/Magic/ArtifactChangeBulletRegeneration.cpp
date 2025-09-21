// Fill out your copyright notice in the Description page of Project Settings.

#include "ArtifactChangeBulletRegeneration.h"
#include "PlayerChara.h"

// Sets default values
AArtifactChangeBulletRegeneration::AArtifactChangeBulletRegeneration()
{
	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;
}

// Called when the game starts or when spawned
void AArtifactChangeBulletRegeneration::BeginPlay()
{
	Super::BeginPlay();
}

// Called every frame
void AArtifactChangeBulletRegeneration::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
}

void AArtifactChangeBulletRegeneration::MagicStart() {
	m_pPlayer->SetBullet(FString("Regeneration"));
}

void AArtifactChangeBulletRegeneration::MagicEnd() {
	m_pPlayer->SetBullet(FString(""));
}

void AArtifactChangeBulletRegeneration::LevelSettingCustom() {
	m_fMagicCool += m_iLevel;
	m_fDestroyTime += m_iLevel;
}