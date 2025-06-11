# NeglectingRPG
스파르타 방치형 RPG 가 되고 싶었던 인벤토리 구현
인벤토리 구현에서 여러가지 방식을 시험해보다가 시간을 너무 많이 투자해서 미쳐 FSM기반 자동사냥 게임은 만들지 못했습니다...!

1) 우상단 흰색 아이콘을 통해 UI 뷰어 오픈
   
![1](https://github.com/user-attachments/assets/32f81cdb-a45d-41b3-9a9c-1d809b047e12)

2) 해당 버튼을 통해 인벤토리 오픈
   
![2](https://github.com/user-attachments/assets/e3d91271-872b-449e-aca9-46d2f7d1051f)


3) Drag&Drop으로 장착가능(추후 우클릭으로도 장착가능하게 할 예정)
 
![3](https://github.com/user-attachments/assets/e2733d85-f37a-4860-b567-0b60391b3d0e)


4) 초기에 테스트용 랜덤 10개의 아이템이 주어지며, 해당 메소드(InventoryManager 내부에 있습니다)를 통해 랜덤 아이템을 추가 획득가능합니다
   
![4](https://github.com/user-attachments/assets/3da9c32c-fe17-40c4-a662-e74ad6575752)

5) ALL 탭은 최소 12칸의 슬롯을 기본적으로 확보하며, 아이템 위치를 플레이어가 직접 커스터마이징 할 수 있습니다.
   그 외의 탭들은 해당 장비 타입을 보유한 갯수만큼 만 슬롯을 동적으로 생성합니다.(자동 정렬 / 위치 이등은 되지만 탭 전환시 변환 위치 초기화)
   
![5](https://github.com/user-attachments/assets/b97ac051-e4aa-46af-bbb1-607aac1df3a2)
![6](https://github.com/user-attachments/assets/ed4b8657-ddd7-404b-b325-1b52a7467852)
