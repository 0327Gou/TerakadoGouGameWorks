// Fill out your copyright notice in the Description page of Project Settings.
#include "PlayerChara.h"
#include "Components/InputComponent.h"
#include "GameFramework/PlayerInput.h"
#include "GameFramework/PlayerController.h"
#include "GameFramework/CharacterMovementComponent.h"
#include "Engine/World.h"

// Sets default values
APlayerChara::APlayerChara()
	: m_fShotTimer(0.0f)		// �ˌ��^�C�}�[
	, m_fMagic1Cool(0.0f)		// ���@1�N�[���_�E��
	, m_fMagic1Timer(0.0f)		// ���@1�^�C�}�[
	, m_fMagic2Cool(0.0f)		// ���@2�N�[���_�E��
	, m_fMagic2Timer(0.0f)		// ���@2�^�C�}�[
	, m_fMagic3Cool(0.0f)		// ���@3�N�[���_�E��
	, m_fMagic3Timer(0.0f)		// ���@3�^�C�}�[
	, m_fMagicPoint(0.0f)		// MP
	, m_fInvincibleTimer(0.0f)	// ���G���Ԃ̃^�C�}�[
	, m_iMagicCost1(0)			// ���@1�̃R�X�g
	, m_iMagicLevel1(1)			// ���@1�̃��x��
	, m_iMagicCost2(0)			// ���@2�̃R�X�g
	, m_iMagicLevel2(1)			// ���@2�̃��x��
	, m_iMagicCost3(0)			// ���@3�̃R�X�g
	, m_iMagicLevel3(1)			// ���@3�̃��x��
	, m_iOldHP(0)				// �t���[���O��HP
	, m_bCanControl(true)
	, m_bDamageInvincibleFlag(false)
	, Bullet(NULL)
	, Magic1(NULL)
	, Magic2(NULL)
	, Magic3(NULL)
{
 	// Set this character to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

	// �f�t�H���g�v���C���[�Ƃ��Đݒ�
	AutoPossessPlayer = EAutoReceiveInput::Player0;
}

// Called when the game starts or when spawned
void APlayerChara::BeginPlay()
{
	Super::BeginPlay();

	// ----------
	Init();
	// ----------
}

// Called every frame
void APlayerChara::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);	

	// ����n��
	if (m_bCanControl) {
		UpdateMove(DeltaTime);			// �ړ�	
		Shooting(DeltaTime);			// �ˌ�	
		Magic1RMouse(DeltaTime);		// ���@1
		Magic2LCtrl(DeltaTime);			// ���@2
		Magic3LShift(DeltaTime);		// ���@3
	}

	// �펞����
	DamageChecker(DeltaTime);			// �_���[�W���̔���Ɩ��G�̐���
	EXPChangeToLevel();					// �o���l�����x���ɕϊ�

	//CorrectionPitch();					// ?
}

// Called to bind functionality to input
void APlayerChara::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);

	check(PlayerInputComponent);

	// Mouse��X���W�X�V�ł̃C�x���g�o�^���邽�߂̏��Q
	FInputAxisKeyMapping Yaw("Yaw", EKeys::MouseX, YawAmount);

	// Mouse��Y���W�X�V�ł̃C�x���g�o�^���邽�߂̏��Q
	FInputAxisKeyMapping Pitch("Pitch", EKeys::MouseY, PitchAmount);

	// ���ۂɓo�^
	GetWorld()->GetFirstPlayerController()->PlayerInput->AddAxisMapping(Yaw);
	GetWorld()->GetFirstPlayerController()->PlayerInput->AddAxisMapping(Pitch);

	// Yaw()��Pitch()���o�C���h
	PlayerInputComponent->BindAxis("Yaw", this, &APlayerChara::Yaw);
	PlayerInputComponent->BindAxis("Pitch", this, &APlayerChara::Pitch);
}

// �ړ�����
void APlayerChara::UpdateMove(float _deltaTime)
{
	// �R���g���[���\�ȏꍇ�̂�
	if (m_bCanControl == false) { return; }

	GetCharacterMovement()->MaxWalkSpeed = PlayerParam.fSpeed;

	// �ړ��x�N�g���̕ϐ�
	FVector vMove = FVector(0.0, 0.0, 0.0);

	// WASD�ړ�
	if (GetWorld()->GetFirstPlayerController()->IsInputKeyDown(EKeys::W)) {
		vMove += GetActorForwardVector();

		//UE_LOG(LogTemp, Warning, TEXT("W key is pressed"));
	}
	if (GetWorld()->GetFirstPlayerController()->IsInputKeyDown(EKeys::A)) {
		vMove -= GetActorRightVector();

		//UE_LOG(LogTemp, Warning, TEXT("A key is pressed"));
	}
	if (GetWorld()->GetFirstPlayerController()->IsInputKeyDown(EKeys::S)) {
		vMove -= GetActorForwardVector();

		//UE_LOG(LogTemp, Warning, TEXT("S key is pressed"));
	}
	if (GetWorld()->GetFirstPlayerController()->IsInputKeyDown(EKeys::D)) {
		vMove += GetActorRightVector();

		//UE_LOG(LogTemp, Warning, TEXT("D key is pressed"));
	}

	// ���K��
	vMove.Normalize();

	// �ړ��̔��f
	AddMovementInput(vMove, 1.0f, true);
}

void APlayerChara::Yaw(const float amount)
{
	auto YawValue = MouseSensitivity * amount * GetWorld()->GetDeltaSeconds();
	AddControllerYawInput(YawValue);
}

void APlayerChara::Pitch(const float amount)
{
	//auto PitchValue = MouseSensitivity * amount * GetWorld()->GetDeltaSeconds();
	//AddControllerPitchInput(PitchValue);
}

void APlayerChara::Shooting(float _deltaTime) 
{
	m_fShotTimer += _deltaTime;

	if (GetWorld()->GetFirstPlayerController()->IsInputKeyDown(EKeys::LeftMouseButton)) {
		if (m_fShotTimer > PlayerParam.fShotCool) {
			if (GetActorRotation().Pitch > 10.0f) {
				SetActorRotation(FRotator(10.0f, GetActorRotation().Yaw, GetActorRotation().Roll));
			}
			else if (GetActorRotation().Pitch < -10.0f) {
				SetActorRotation(FRotator(-10.0f, GetActorRotation().Yaw, GetActorRotation().Roll));
			}

			Bullet = GetWorld()->SpawnActor<AActor>(Bullet_BP, FVector(GetActorLocation().X, GetActorLocation().Y, GetActorLocation().Z + 30.0), GetActorRotation());

			if (Bullet != nullptr) {
				Bullet->SetOwner(this);
			}
			m_fShotTimer = 0.0f;
		}
		//UE_LOG(LogTemp, Warning, TEXT("LMouse key is pressed"));
	}
}

// ���@1
void APlayerChara::Magic1RMouse(float _deltaTime) {
	if (Magic1_BP == nullptr) { return; }

	m_fMagic1Timer += _deltaTime;

	if (GetWorld()->GetFirstPlayerController()->IsInputKeyDown(EKeys::RightMouseButton)) {
		if (m_fMagic1Timer > m_fMagic1Cool && m_fMagicPoint >= (float)m_iMagicCost1) {
			Magic1 = GetWorld()->SpawnActor<AMagicBase>(Magic1_BP, GetActorLocation(), GetActorRotation());
			Magic1->SetPlayer(this);
			Magic1->SetiLevel(m_iMagicLevel1);
			Magic1->MagicStart();
			m_fMagicPoint -= (float)m_iMagicCost1;
			m_fMagic1Timer = 0.0f;
		}
		//UE_LOG(LogTemp, Warning, TEXT("RMouse key is pressed"));
	}
}

// ���@2
void APlayerChara::Magic2LCtrl(float _deltaTime) {
	if (Magic2_BP == nullptr) { return; }

	m_fMagic2Timer += _deltaTime;

	if (GetWorld()->GetFirstPlayerController()->IsInputKeyDown(EKeys::LeftControl)) {
		if (m_fMagic2Timer > m_fMagic2Cool && m_fMagicPoint >= (float)m_iMagicCost2) {
			Magic2 = GetWorld()->SpawnActor<AMagicBase>(Magic2_BP, GetActorLocation(), GetActorRotation());
			Magic2->SetPlayer(this);
			Magic2->SetiLevel(m_iMagicLevel1);
			Magic2->MagicStart();
			m_fMagicPoint -= (float)m_iMagicCost2;
			m_fMagic2Timer = 0.0f;
		}
		//UE_LOG(LogTemp, Warning, TEXT("LCtrl key is pressed"));
	}
}

// ���@3
void APlayerChara::Magic3LShift(float _deltaTime) {
	if (Magic3_BP == nullptr) { return; }

	m_fMagic3Timer += _deltaTime;

	if (GetWorld()->GetFirstPlayerController()->IsInputKeyDown(EKeys::LeftShift)) {
		if (m_fMagic3Timer > m_fMagic3Cool && m_fMagicPoint >= (float)m_iMagicCost3) {
			Magic3 = GetWorld()->SpawnActor<AMagicBase>(Magic3_BP, GetActorLocation(), GetActorRotation());
			Magic3->SetPlayer(this);
			Magic3->SetiLevel(m_iMagicLevel1);
			Magic3->MagicStart();
			m_fMagicPoint -= (float)m_iMagicCost3;
			m_fMagic3Timer = 0.0f;
		}
		//UE_LOG(LogTemp, Warning, TEXT("LShift key is pressed"));
	}
}

void APlayerChara::SetArtifact(int _iSlot, FName _sName, int _iLevel) {
	// Path�̐ݒ�
	FString sPathBP = TEXT("/Game/BP/Artifact/BP_Artifact" + _sName.ToString() + ".BP_Artifact" + _sName.ToString() + "_c");
	TSubclassOf<AActor> ArtifactBP = TSoftClassPtr<AActor>(FSoftObjectPath(*sPathBP)).LoadSynchronous();

	// null�`�F�b�N
	if (ArtifactBP == nullptr)
	{
		UE_LOG(LogTemp, Error, TEXT("Failed o load class at path:%s"), *sPathBP);
	}

	// ���x���̐ݒ�
	int m_iLevel = _iLevel + 1;
	if (m_iLevel > 5) { m_iLevel = 5; }

	// �ǂ̘g������
	switch (_iSlot)
	{
	case 0:
		// �A�[�e�B�t�@�N�g�̐ݒ�
		Magic1_BP = ArtifactBP;
		m_iMagicLevel1 = _iLevel;

		// �N�[���_�E���擾
		Magic1 = GetWorld()->SpawnActor<AMagicBase>(Magic1_BP, GetActorLocation(), GetActorRotation());
		if (Magic1 != nullptr) {
			Magic1->SetPlayer(this);
			Magic1->SetiLevel(m_iMagicLevel1);
			m_fMagic1Cool = Magic1->GetfMagicCool();
			m_iMagicCost1 = Magic1->GetiMagicCost();
			Magic1->Destroy();
		}
	case 1:
		// �A�[�e�B�t�@�N�g�̐ݒ�
		Magic2_BP = ArtifactBP;
		m_iMagicLevel2 = _iLevel;

		// �N�[���_�E���擾
		Magic2 = GetWorld()->SpawnActor<AMagicBase>(Magic2_BP, GetActorLocation(), GetActorRotation());
		if (Magic2 != nullptr) {
			Magic2->SetPlayer(this);
			Magic2->SetiLevel(m_iMagicLevel1);
			m_fMagic2Cool = Magic2->GetfMagicCool();
			m_iMagicCost2 = Magic2->GetiMagicCost();
			Magic2->Destroy();
		}
	case 2:
		// �A�[�e�B�t�@�N�g�̐ݒ�
		Magic3_BP = ArtifactBP;
		m_iMagicLevel3 = _iLevel;

		// �N�[���_�E���擾
		Magic3 = GetWorld()->SpawnActor<AMagicBase>(Magic3_BP, GetActorLocation(), GetActorRotation());
		if (Magic3 != nullptr) {
			Magic3->SetPlayer(this);
			Magic3->SetiLevel(m_iMagicLevel1);
			m_fMagic3Cool = Magic3->GetfMagicCool();
			m_iMagicCost3 = Magic3->GetiMagicCost();
			Magic3->Destroy();
		}
	}
}

void APlayerChara::AddDamage(int _iDamage){
	PlayerParam.iHP -=_iDamage;
}

//------------------------------------------------------
float APlayerChara::GetPlayerHP() {
	return PlayerParam.iHP;
}

float APlayerChara::GetMagicCoolTime(int idx) {
	float coolTime = 0.0f;
	if (idx == 0) {
		coolTime = m_fMagic1Timer;
	}
	else if (idx == 1) {
		coolTime = m_fMagic2Timer;
	}
	else if (idx == 2) {
		coolTime = m_fMagic3Timer;
	}
	return coolTime;
}

float APlayerChara::GetMagicCool(int idx) {
	float coolTime = 0.0f;
	if (idx == 0) {
		coolTime = m_fMagic1Cool;
	}
	else if (idx == 1) {
		coolTime = m_fMagic2Cool;
	}
	else if (idx == 2) {
		coolTime = m_fMagic3Cool;
	}
	return coolTime;
}

void APlayerChara::Init() {
	if (Magic1_BP != nullptr) { 
		Magic1 = GetWorld()->SpawnActor<AMagicBase>(Magic1_BP, GetActorLocation(), GetActorRotation());
		m_fMagic1Cool = Magic1->GetfMagicCool();
		m_iMagicCost1 = Magic1->GetiMagicCost();
		Magic1->Destroy();
	}
	if (Magic2_BP != nullptr) {
		Magic2 = GetWorld()->SpawnActor<AMagicBase>(Magic2_BP, GetActorLocation(), GetActorRotation());
		m_fMagic2Cool = Magic2->GetfMagicCool();
		m_iMagicCost2 = Magic2->GetiMagicCost();
		Magic2->Destroy();
	}
	if (Magic2_BP != nullptr) {
		Magic3 = GetWorld()->SpawnActor<AMagicBase>(Magic3_BP, GetActorLocation(), GetActorRotation());
		m_fMagic3Cool = Magic3->GetfMagicCool();
		m_iMagicCost3 = Magic3->GetiMagicCost();
		Magic3->Destroy();
	}
}

void APlayerChara::AddMagicPoint(float _mp) {
	if (m_fMagicPoint < 100.0f) {
		m_fMagicPoint += _mp;
	}
}

float APlayerChara::GetMagicPoint() {
	return m_fMagicPoint;
}

// Pitch�̕␳
void APlayerChara::CorrectionPitch() {
	if (GetActorRotation().Pitch < -10.0f) {
		SetActorRotation(FRotator(-10.0f, GetActorRotation().Yaw, GetActorRotation().Roll));
	}

	if (GetActorRotation().Pitch > 10.0f) {
		SetActorRotation(FRotator(10.0f, GetActorRotation().Yaw, GetActorRotation().Roll));
	}
}

float APlayerChara::GetShotInterval() {
	return PlayerParam.fShotCool;
}
//------------------------------------------------------

void APlayerChara::DamageChecker(float _deltaTime) {
	// �^�C�}�[�Ɏ��Ԃ𑫂�
	if (m_fInvincibleTimer <= PlayerParam.fInvincibleTime){
		m_fInvincibleTimer += _deltaTime;
	}

	// HP���������疳�G��Ԃɂ���
	if (PlayerParam.iHP < m_iOldHP) {
		// ���G��ԂȂ�HP�����炳�Ȃ�
		if (m_bDamageInvincibleFlag || PlayerParam.bInvincibleFlag) {
			PlayerParam.iHP = m_iOldHP;
		}
		// ��莞�Ԗ��G��Ԃɂ���
		m_bDamageInvincibleFlag = true;
		m_fInvincibleTimer = 0.0f;
	}

	// ���Ԃ��������疳�G����������
	if (m_fInvincibleTimer >= PlayerParam.fInvincibleTime) {
		m_bDamageInvincibleFlag = false;
	}

	// ����HP��ۑ�����
	m_iOldHP = PlayerParam.iHP;
}

void APlayerChara::AddHP(int _iHP) {
	if (PlayerParam.iHP < 100) {
		PlayerParam.iHP += _iHP;
	}
}

void APlayerChara::SetBullet(FString _sName) {
	// Path�̐ݒ�
	FString sPathBP = TEXT("/Game/BP/Bullet/BP_Bullet" + _sName + ".BP_Bullet" + _sName + "_c");
	TSubclassOf<AActor> BP_PathBullet = TSoftClassPtr<AActor>(FSoftObjectPath(*sPathBP)).LoadSynchronous();
	// null�`�F�b�N
	if (BP_PathBullet == nullptr)
	{
		UE_LOG(LogTemp, Error, TEXT("Failed o load class at path:%s"), *sPathBP);
	}
	Bullet_BP = BP_PathBullet;
	UE_LOG(LogTemp, Log, TEXT("Complete load class at %s"), *_sName);
}

void APlayerChara::EXPChangeToLevel() {
	if (PlayerParam.iPlayerEXP > m_iLevelUpEXP) {
		++PlayerParam.iPlayerLevel;
		++rerollCount;
		m_iLevelUpEXP += m_iLevelUpEXP / 6;
	}
}

void APlayerChara::SetEXP(int _iEXP) {
	PlayerParam.iPlayerEXP += _iEXP;
}
