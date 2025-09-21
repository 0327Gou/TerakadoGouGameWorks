// Fill out your copyright notice in the Description page of Project Settings.
#include "MagicExplosion.h"
#include "GameFramework/Actor.h"

// Sets default values
AMagicExplosion::AMagicExplosion()
{
	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;
}

// Called when the game starts or when spawned
void AMagicExplosion::BeginPlay()
{
	Super::BeginPlay();
	GetWorld()->SpawnActor<AActor>(Explosion_BP, GetActorLocation(), GetActorRotation());
}