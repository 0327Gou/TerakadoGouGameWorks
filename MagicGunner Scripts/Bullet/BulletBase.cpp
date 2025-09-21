// Fill out your copyright notice in the Description page of Project Settings.

#include "BulletBase.h"
#include "Engine/World.h"
#include "EnemyBase.h"
#include "PlayerChara.h"

// Sets default values
ABulletBase::ABulletBase()
	: m_timerDestroy(0.0f)		// ���Ŏ��Ԃ̌v���p
{
	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;
}

// Called when the game starts or when spawned
void ABulletBase::BeginPlay()
{
	Super::BeginPlay();
}

// Called every frame
void ABulletBase::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

	UpdateMove(DeltaTime);

	// �w��̕b���ŋ�������
	m_timerDestroy += DeltaTime;
	if (m_timerDestroy > m_timeDestroy)
	{
		this->Destroy();
	}
}

void ABulletBase::UpdateMove(float DeltaTime)
{
	// �ړ��x�N�g���̕ϐ�
	FVector vMove = GetActorForwardVector() * m_fBulletSpeed + GetActorLocation();

	SetActorLocation(vMove);
}

void ABulletBase::EnemyHit(AActor* OtherActor) {}
void ABulletBase::BulletHit(AActor* OtherActor) {}

void ABulletBase::NotifyActorBeginOverlap(AActor* OtherActor)
{
	if (!(OtherActor->ActorHasTag("Player"))) {

		APlayerChara* _Owner = Cast<APlayerChara>(GetOwner());
		if (_Owner != nullptr) {
			_Owner->AddMagicPoint(2.0f);
		}

		// �ڐG����Actor��Enemy�����肷��
		if (OtherActor->ActorHasTag("Enemy"))
		{
			// �G��ۑ�
			AEnemyBase* Enemy = Cast<AEnemyBase>(OtherActor);

			// �Ώۂ�Damage��^����
			Enemy->BeDamage(m_iDamage);
			UE_LOG(LogTemp, Display, TEXT("Damage:%i"), m_iDamage);

			EnemyHit(OtherActor);
		}
		BulletHit(OtherActor);
	}
}
