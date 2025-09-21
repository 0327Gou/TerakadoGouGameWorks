// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "MagicBase.h"
#include "MagicAcceleration.generated.h"

class PlayerChara;

UCLASS()
class MAGICGUNNER_API AMagicAcceleration : public AMagicBase
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	AMagicAcceleration();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

// ïœêî
public:
private:
	UPROPERTY(EditAnywhere)float m_fBoostSpeed = 0.2f;
	UPROPERTY(EditAnywhere)float m_fDefaultSpeed;

// ä÷êî
public:
	void MagicStart();
private:
	void MagicEnd();
};
