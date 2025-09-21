// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "Explosion.generated.h"

UCLASS()
class MAGICGUNNER_API AExplosion : public AActor
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	AExplosion();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

// 変数
public:
	UPROPERTY(EditAnywhere)int m_iLevel = 1;				// 魔法のレベル
	UPROPERTY(EditAnywhere)int m_iDamage = 1;				// 与えるダメージ
	UPROPERTY(EditAnywhere)float m_timeDestroy = 2.0f;		// 消滅時間

private:
	float m_timerDestroy;									// 消滅時間の計測用

// 関数
public:
	void NotifyActorBeginOverlap(AActor* OtherActor);

private:

};
