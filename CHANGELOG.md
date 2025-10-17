# 변경 기록 (Changelog)
버전별 모든 주요 변경 사항은 이 파일에 기록됩니다.

------------------------------------------------------------
## [1.0.0] - 2025-10-16
- 배포용 초기 버전 완성
- 패키지 폴더 구성
- gitignore 추가
- CHANGELOG.md 추가

### 🐛 Bug Fixes (버그 수정)
- **[UPM] Unity Package Manager 등록 오류 수정**
    - 'package.json'의 package name에 포함된 **하이픈 ('-')및 대문자가 UPM 규칙에 위배**되어 패키지 추가가 실패하는 문제를 해결
    - **'name' 필드 변경 : ** `com.Adonis.Initialize-System` → `com.adonis.initialize_system`

- **Assembly Definition 파일 추가**
    - 해당 파일이 없어 Script가 import되지 않던 문제 해결

------------------------------------------------------------
## [1.0.1] - 2025-10-16
### ✨ New Feature (새로운 기능)
- **[LICENSE] MIT 라이선스 추가**
    - 리포지토리에 'LICENSE.md' 파일을 추가하여 **MIT 라이선스**를 명시했습니다.
    - 이로써 상업적 이용을 포함한 패키지의 자유로운 사용 및 배포를 공식적으로 허가하고,
      사용상의 모든 책임은 사용자에게 있음을 명확히 했습니다.
    - package.json 폴더에 "lisence" 필드 추가

------------------------------------------------------------
## [1.0.2] - 2025-10-17
### ♻️ Code Improvement (코드 개선)
- **[Performance] 중복된 씬 검색 메서드(Find) 사용 비효율성 개성**
    - CoreManager.cs의 LinkToAction() 내에서 'Initializer' 컴포넌트 검색을 두 번 수행한 비효율적인 로직을 수정했습니다.
    - 검색 결과를 캐싱해둔 지역 변수를 사용하여 **한 번만 검색하도록 최적화**했습니다.
    - **코드 비교**
        - **변경 전 :** `if (initializer != null) FindFirstObjectByType<Initializer>().OnSortComplete += RegisterManagers;`
        - **변경 후 :** `if (initializer != null) initializer.OnSortComplete += RegisterManagers;`