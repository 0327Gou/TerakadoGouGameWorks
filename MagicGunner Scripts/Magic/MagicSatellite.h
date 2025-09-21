// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "MagicBase.h"
#include "MagicSatellite.generated.h"

class PlayerChara;

UCLASS()
class MAGICGUNNER_API AMagicSatellite : public AMagicBase
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	AMagicSatellite();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

public:
	// �ϐ�
	UPROPERTY(EditAnywhere)TSubclassOf<AActor> Bullet_BP = NULL;		// �e��BP

	// �֐�
	void MagicStart();

private:
	// �ϐ�
	TArray<AActor*> SateBullet;
	float fAngle;

	// �֐�
};
