// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "BulletBase.h"
#include "PlayerChara.h"
#include "BulletSatellite.generated.h"

UCLASS()
class MAGICGUNNER_API ABulletSatellite : public ABulletBase
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	ABulletSatellite();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

// •Ï”
private:
	UPROPERTY(EditAnywhere)float m_fRadius = 150.0f;

	float m_fAngle;
	APlayerChara* m_pPlayer;

// ŠÖ”
public:
	void SettingsSatellite(float _fAngle, APlayerChara* _pPlayer);

private:
	// ‰q¯‹O“¹‚Ìˆ—
	FVector Satellite(float _fRadius, float _fSpeed, float _fPhi);
	// “–‚½‚Á‚½‚Ìˆ—
	void EnemyHit(AActor* OtherActor);
};
