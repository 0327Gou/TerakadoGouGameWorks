// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "MagicBase.h"
#include "ArtifactChangeBulletRegeneration.generated.h"

/**
 * 
 */
UCLASS()
class MAGICGUNNER_API AArtifactChangeBulletRegeneration : public AMagicBase
{
	GENERATED_BODY()
	
public:
	// Sets default values for this actor's properties
	AArtifactChangeBulletRegeneration();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:
	// Called every frame
	virtual void Tick(float DeltaTime) override;

// ïœêî
public:
private:

// ä÷êî
public:
	void MagicStart();

private:
	void MagicEnd();
	void LevelSettingCustom();
};
