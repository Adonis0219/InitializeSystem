본 패키지는 초기화(Init())가 가능한(IInitializable) 모든 객체를 찾아 InitOrder 순으로 자동 초기화 하고,
CoreManager를 통해 각 매니저들을 반환 받아 instance 객체의 개수를 줄이기 위해 설계 되었습니다.

사용법
1. (중요) Edit -> Project Settings -> Script Execution Order 화면에서 CoreManager가 Initializer보다 상위에 있도록 설정해주세요.

2. 자동 초기화를 사용할 객체 추가 방법
- Manager
1) TestManager 스크립트에 BaseManager를 상속 받습니다
	자동으로 생성되는 Init() 함수에 초기화 로직을 작성합니다
2) InitOrderAttribute.cs의 InitOrder 클래스에서 순서에 맞도록 TestManager를 추가합니다
3) TestManager.cs의 클래스 명 위에 [InitOrder(InitOrder.TestManager)] 어트리뷰트를 추가해 순서를 지정해줍니다

- Player 등 다른 객체
1) TestPlayer 스크립트에 IInitializable을 상속 받습니다
	자동으로 생성되는 Init() 함수에 초기화 로직을 작성합니다
2) InitOrderAttribute.cs의 InitOrder 클래스에서 순서에 맞도록 TestPlayer를 추가합니다
3) TestPlayer.cs의 클래스 명 위에 [InitOrder(InitOrder.TestPlayer)] 어트리뷰트를 추가해 순서를 지정해줍니다

자동 초기화 완료~