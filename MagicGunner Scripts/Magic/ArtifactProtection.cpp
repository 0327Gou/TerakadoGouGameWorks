// Fill out your copyright notice in the Description page of Project Settings.

#include "ArtifactProtection.h"
#include "PlayerChara.h"
#include "GameFramework/Actor.h"

// Sets default values
AArtifactProtection::AArtifactProtection()
{
	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;
}

// Called when the game starts or when spawned
void AArtifactProtection::BeginPlay()
{
	Super::BeginPlay();
}

// Called every frame
void AArtifactProtection::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
}

void AArtifactProtection::MagicStart() {
	m_pPlayer->PlayerParam.bInvincibleFlag = true;
}

void AArtifactProtection::MagicEnd() {
	m_pPlayer->PlayerParam.bInvincibleFlag = false;
}

void AArtifactProtection::LevelSettingCustom() {
	m_fMagicCool += m_iLevel;
	m_fDestroyTime += m_iLevel;
}