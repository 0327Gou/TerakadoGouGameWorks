// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "BulletBase.h"
#include "BulletExplosive.generated.h"

UCLASS()
class MAGICGUNNER_API ABulletExplosive : public ABulletBase
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	ABulletExplosive();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

// �ϐ�
private:
	UPROPERTY(EditAnywhere)TSubclassOf<AActor> Explosion_BP = NULL;		// ������BP
	FVector m_vLocation;
	FRotator m_rRotate;
	bool flag;

// �֐�
private:
	// �����������̏���
	void EnemyHit(AActor* OtherActor);
};
