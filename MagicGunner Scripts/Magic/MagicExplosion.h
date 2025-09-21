// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "MagicBase.h"
#include "MagicExplosion.generated.h"

class PlayerChara;

UCLASS()
class MAGICGUNNER_API AMagicExplosion : public AMagicBase
{
	GENERATED_BODY()

public:
	// Sets default values for this actor's properties
	AMagicExplosion();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

// ïœêî
private:
	UPROPERTY(EditAnywhere)TSubclassOf<AActor> Explosion_BP = NULL;		// îöî≠ÇÃBP
};