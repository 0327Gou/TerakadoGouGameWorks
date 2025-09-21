// Fill out your copyright notice in the Description page of Project Settings.

#include "MagicRapidFire.h"
#include "PlayerChara.h"

// Sets default values
AMagicRapidFire::AMagicRapidFire()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;
}

// Called when the game starts or when spawned
void AMagicRapidFire::BeginPlay()
{
	Super::BeginPlay();
}

// Called every frame
void AMagicRapidFire::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
}

void AMagicRapidFire::MagicStart() {
	m_pPlayer->PlayerParam.fShotCool = m_pPlayer->PlayerParam.fShotCool / (1 + m_fShotCool * m_iLevel);
}

void AMagicRapidFire::MagicEnd() {
	m_pPlayer->PlayerParam.fShotCool = m_fDefaultShotCool;
}

