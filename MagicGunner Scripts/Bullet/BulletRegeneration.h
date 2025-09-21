// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "BulletBase.h"
#include "BulletRegeneration.generated.h"

UCLASS()
class MAGICGUNNER_API ABulletRegeneration : public ABulletBase
{
	GENERATED_BODY()

public:
	// Sets default values for this actor's properties
	ABulletRegeneration();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:
	// Called every frame
	virtual void Tick(float DeltaTime) override;

// •Ï”
private:
	UPROPERTY(EditAnywhere)float fRegeneMagnification = 2;		// Ä¶”{—¦

// ŠÖ”
private:
	// “–‚½‚Á‚½‚Ìˆ—
	void EnemyHit(AActor* OtherActor);
};
