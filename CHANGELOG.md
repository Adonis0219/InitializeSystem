# 변경 기록 (Changelog)
버전별 모든 주요 변경 사항은 이 파일에 기록됩니다.

------------------------------------------------------------
## [1.0.0] - 2025-10-16
- 배포용 초기 버전 완성
- 패키지 폴더 구성
- gitignore 추가
- CHANGELOG.md 추가

- **[UPM] Unity Package Manager 등록 오류 수정**
    - 'package.json'의 package name에 포함된 **하이픈 ('-')및 대문자가 UPM 규칙에 위배**되어 패키지 추가가 실패하는 문제를 해결
    - **'name' 필드 변경 : ** `com.Adonis.Initialize-System` → `com.adonis.initialize_system`

- **Assembly Definition 파일 추가**
    - 해당 파일이 없어 Script가 import되지 않던 문제 해결

------------------------------------------------------------