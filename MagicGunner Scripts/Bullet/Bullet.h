
#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "BulletBase.h"
#include "Bullet.generated.h"

class APlayerChara;

UCLASS()
class MAGICGUNNER_API ABullet : public ABulletBase
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	ABullet();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:
	// Called every frame
	virtual void Tick(float DeltaTime) override;

// ïœêî
private:

// ä÷êî
private:
	// ìñÇΩÇ¡ÇΩéûÇÃèàóù
	void EnemyHit(AActor* OtherActor);
	
// -------------------------------------------------
	//APlayerChara* _Owner;
//public:
	//oid SetBulletOwner(APlayerChara* _owner);
// -------------------------------------------------
};
