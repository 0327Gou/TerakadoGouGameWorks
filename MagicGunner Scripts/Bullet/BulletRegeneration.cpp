// Fill out your copyright notice in the Description page of Project Settings.

#include "BulletRegeneration.h"
#include "EnemyBase.h"
#include "PlayerChara.h"

// Sets default values
ABulletRegeneration::ABulletRegeneration()
{
	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;
}

// Called when the game starts or when spawned
void ABulletRegeneration::BeginPlay()
{
	Super::BeginPlay();
}

// Called every frame
void ABulletRegeneration::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
}

void ABulletRegeneration::EnemyHit(AActor* OtherActor) {
	APlayerChara* _Owner = Cast<APlayerChara>(GetOwner());
	if (_Owner != nullptr) {
		_Owner->AddHP(m_iDamage * fRegeneMagnification);
	}
	// ‹…‚ðíœ‚·‚é
	this->Destroy();
}