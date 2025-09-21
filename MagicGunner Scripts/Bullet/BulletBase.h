// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "BulletBase.generated.h"

UCLASS()
class MAGICGUNNER_API ABulletBase : public AActor
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	ABulletBase();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:
	// Called every frame
	virtual void Tick(float DeltaTime) override;

// •Ï”
public:
	UPROPERTY(EditAnywhere)int m_iDamage = 1;					// UŒ‚—Í
	UPROPERTY(EditAnywhere)float m_fBulletSpeed = 100.0f;		// ’e‘¬
	UPROPERTY(EditAnywhere)float m_timeDestroy = 5.0f;			// Á–ÅŠÔ
	float m_timerDestroy;		// Á–ÅŠÔ‚ÌŒv‘ª—p

// ŠÖ”
public:
	// ˆÚ“®
	virtual void UpdateMove(float _deltaTime);

	// “–‚½‚Á‚½‚Ìˆ—
	virtual void EnemyHit(AActor* OtherActor);
	virtual void BulletHit(AActor* OtherActor);

	// “–‚½‚è”»’è
	void NotifyActorBeginOverlap(AActor* OtherActor);
};
