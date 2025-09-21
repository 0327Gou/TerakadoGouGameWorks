// Fill out your copyright notice in the Description page of Project Settings.

#include "Explosion.h"
#include "EnemyBase.h"

// Sets default values
AExplosion::AExplosion()
	: m_timerDestroy(0.0f)		// Á–ÅŽžŠÔ‚ÌŒv‘ª—p
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;
}

// Called when the game starts or when spawned
void AExplosion::BeginPlay()
{
	Super::BeginPlay();
}

// Called every frame
void AExplosion::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

	// Žw’è‚Ì•b”‚Å‹…‚ðÁ‚·
	m_timerDestroy += DeltaTime;
	if (m_timerDestroy > m_timeDestroy)
	{
		this->Destroy();
	}
}

void AExplosion::NotifyActorBeginOverlap(AActor* OtherActor)
{
	// ÚG‚µ‚½Actor‚ªEnemy‚©”»’è‚·‚é
	if (OtherActor->ActorHasTag("Enemy"))
	{
		// “G‚ð•Û‘¶
		AEnemyBase* Enemy = Cast<AEnemyBase>(OtherActor);

		// ‘ÎÛ‚ÉDamage‚ð—^‚¦‚é
		Enemy->BeDamage(m_iDamage);
		UE_LOG(LogTemp, Display, TEXT("Damage:%i"), m_iDamage);
	}
}