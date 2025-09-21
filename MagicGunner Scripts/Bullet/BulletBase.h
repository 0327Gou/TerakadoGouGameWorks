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

// �ϐ�
public:
	UPROPERTY(EditAnywhere)int m_iDamage = 1;					// �U����
	UPROPERTY(EditAnywhere)float m_fBulletSpeed = 100.0f;		// �e��
	UPROPERTY(EditAnywhere)float m_timeDestroy = 5.0f;			// ���Ŏ���
	float m_timerDestroy;		// ���Ŏ��Ԃ̌v���p

// �֐�
public:
	// �ړ�
	virtual void UpdateMove(float _deltaTime);

	// �����������̏���
	virtual void EnemyHit(AActor* OtherActor);
	virtual void BulletHit(AActor* OtherActor);

	// �����蔻��
	void NotifyActorBeginOverlap(AActor* OtherActor);
};
