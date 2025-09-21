// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "MagicBase.h"
#include "ArtifactProtection.generated.h"

class PlayerChara;

UCLASS()
class MAGICGUNNER_API AArtifactProtection : public AMagicBase
{
	GENERATED_BODY()

public:
	// Sets default values for this actor's properties
	AArtifactProtection();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:
	// Called every frame
	virtual void Tick(float DeltaTime) override;

// �֐�
public:
	void MagicStart();

private:
	void MagicEnd();
	void LevelSettingCustom();
};
