# 🚀 Space Explorer: Chicken Invaders Edition

[![Unity Version](https://img.shields.io/badge/Unity-2021.3%20LTS-blue.svg)](https://unity.com/)
[![Language](https://img.shields.io/badge/Language-C%23-239120.svg)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Platform](https://img.shields.io/badge/Platform-Windows%20%7C%20Mac%20%7C%20Linux-lightgrey.svg)]()
[![Status](https://img.shields.io/badge/Status-Completed-success.svg)]()

> **Dự án Lab môn PRU213 / Lập trình Game 2D với Unity.**  
> Trò chơi 2D Arcade Space Shooter kết hợp cơ chế né tránh chướng ngại vật, bắn hạ các đợt gà vũ trụ và thu thập đùi gà tính điểm, lấy cảm hứng từ tựa game huyền thoại *Chicken Invaders*.

---

## 📸 Demo & Giao diện Game

| Main Menu | Gameplay (Wave System) | Game Over |
| :---: | :---: | :---: |
| ![Main Menu](Screenshots/main_menu.png) | ![Gameplay](Screenshots/gameplay.png) | ![End Game](Screenshots/end_game.png) |

*(Bạn có thể chụp 3 bức ảnh màn hình lưu vào thư mục `Screenshots/` để hiển thị trên GitHub)*

---

## 🎮 Cách Điều Khiển (Controls)

| Phím điều khiển | Hành động |
| :--- | :--- |
| **Phím Mũi tên** hoặc **W, A, S, D** | Di chuyển tàu vũ trụ 8 hướng trong màn hình |
| **Phím Space (Cách)** *(Giữ phím)* | Xả 2 nòng đạn Laser đỏ liên thanh |
| **Chuột trái (UI)** | Tương tác các nút Menu, Mở Hướng dẫn, Chơi lại |

---

## ✨ Tính Năng Nổi Bật (Key Features)

### 1. Cơ Chế Gameplay (Core Mechanics)
- **Tàu chiến hạm (Player):** Di chuyển mượt mà dựa trên vận tốc vật lý `Rigidbody2D`, tự động bị giới hạn trong khung nhìn camera (`Mathf.Clamp`).
- **Hệ thống Đạn kép (Dual Lasers):** Đạn phóng liên thanh từ 2 cánh tàu, tự hủy sau thời gian nhất định để tối ưu bộ nhớ.
- **Đàn gà chiến binh (Enemy):** Bay ziczac lượn sóng tự nhiên bằng hàm `Mathf.Sin`. Gà có thanh máu tăng theo từng Wave, chớp đỏ khi trúng đạn.
- **Vật lý Đùi gà (Bouncing Pickups):** Khi tiêu diệt gà, đùi gà văng nảy ngược lên trời trước khi rơi chậm bồng bềnh nhờ lực cản `drag`, tạo cơ hội cho người chơi bay tới đón.
- **Hệ thống Đợt liên hoàn (Infinite Wave Progression):** Mỗi đợt tiếp theo sẽ sinh nhiều gà hơn và gà trâu máu hơn.

### 2. Âm Thanh & Hiệu Ứng (VFX & SFX)
- **Hiệu ứng hạt nổ (Particle System):** Gà nổ tung tóe thành các tia lửa cam vàng hoành tráng khi bị bắn hạ.
- **Âm thanh sống động:** Tích hợp âm thanh bắn đạn (`Laser`), âm thanh nổ tung (`Explosion`) và âm thanh nhặt đùi gà (`Pickup/Coin`).

### 3. Hệ Thống Scene & Giao Diện UI
- **MainMenu Scene:** Tiêu đề, nút Chơi Mới, Thoát và **Bảng Hướng Dẫn Popup (Instructions Panel)**.
- **Gameplay Scene:** Hiển thị HUD điểm số thời gian thực (`SCORE`) và đợt hiện tại (`WAVE`).
- **EndGame Scene:** Tổng kết điểm số người chơi đạt được, cung cấp tùy chọn Chơi lại, về Menu hoặc Thoát.
- **GameManager (Singleton Pattern):** Sử dụng `DontDestroyOnLoad` để bảo toàn dữ liệu điểm số xuyên suốt giữa các Scene.

---

## 🏗️ Cấu Trúc Dự Án (Project Structure)

```text
Assets/
├── _Game/ (hoặc trực tiếp trong Assets)
│   ├── Prefabs/
│   │   ├── Asteroid.prefab      # Prefab Con Gà
│   │   ├── Laser.prefab         # Prefab Tia đạn
│   │   ├── Star.prefab          # Prefab Đùi gà
│   │   └── Explosion.prefab     # Hiệu ứng nổ Particle
│   ├── Scenes/
│   │   ├── MainMenu.unity       # Scene 0: Menu bắt đầu
│   │   ├── Gameplay.unity       # Scene 1: Màn chơi chính
│   │   └── EndGame.unity        # Scene 2: Màn kết thúc
│   ├── Scripts/
│   │   ├── GameManager.cs       # Quản lý điểm & vòng đời game (Singleton)
│   │   ├── PlayerController.cs  # Điều khiển tàu & bắn laser
│   │   ├── Laser.cs             # Logic đạn bay & va chạm
│   │   ├── Asteroid.cs          # Logic kẻ địch, máu, chớp đỏ & nổ
│   │   ├── Star.cs              # Vật lý rơi nảy của đùi gà
│   │   ├── Spawner.cs           # Bộ điều phối các Wave đợt gà
│   │   ├── GameplayUI.cs        # Hiển thị HUD điểm và wave
│   │   ├── MainMenuUI.cs        # Điều khiển nút bấm Menu & Hướng dẫn
│   │   └── EndGameUI.cs         # Xử lý tổng kết điểm & chơi lại
│   ├── Sprites/                 # Chứa Texture và Sprite Sheet
│   └── Audio/                   # Chứa các file SFX âm thanh .wav# 🚀 Space Explorer: Chicken Invaders Edition

[![Unity Version](https://img.shields.io/badge/Unity-2021.3%20LTS-blue.svg)](https://unity.com/)
[![Language](https://img.shields.io/badge/Language-C%23-239120.svg)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Platform](https://img.shields.io/badge/Platform-Windows%20%7C%20Mac%20%7C%20Linux-lightgrey.svg)]()
[![Status](https://img.shields.io/badge/Status-Completed-success.svg)]()

> **Dự án Lab môn PRU213 / Lập trình Game 2D với Unity.**  
> Trò chơi 2D Arcade Space Shooter kết hợp cơ chế né tránh chướng ngại vật, bắn hạ các đợt gà vũ trụ và thu thập đùi gà tính điểm, lấy cảm hứng từ tựa game huyền thoại *Chicken Invaders*.

---

## 📸 Demo & Giao diện Game

| Main Menu | Gameplay (Wave System) | Game Over |
| :---: | :---: | :---: |
| ![Main Menu](Screenshots/main_menu.png) | ![Gameplay](Screenshots/gameplay.png) | ![End Game](Screenshots/end_game.png) |

*(Bạn có thể chụp 3 bức ảnh màn hình lưu vào thư mục `Screenshots/` để hiển thị trên GitHub)*

---

## 🎮 Cách Điều Khiển (Controls)

| Phím điều khiển | Hành động |
| :--- | :--- |
| **Phím Mũi tên** hoặc **W, A, S, D** | Di chuyển tàu vũ trụ 8 hướng trong màn hình |
| **Phím Space (Cách)** *(Giữ phím)* | Xả 2 nòng đạn Laser đỏ liên thanh |
| **Chuột trái (UI)** | Tương tác các nút Menu, Mở Hướng dẫn, Chơi lại |

---

## ✨ Tính Năng Nổi Bật (Key Features)

### 1. Cơ Chế Gameplay (Core Mechanics)
- **Tàu chiến hạm (Player):** Di chuyển mượt mà dựa trên vận tốc vật lý `Rigidbody2D`, tự động bị giới hạn trong khung nhìn camera (`Mathf.Clamp`).
- **Hệ thống Đạn kép (Dual Lasers):** Đạn phóng liên thanh từ 2 cánh tàu, tự hủy sau thời gian nhất định để tối ưu bộ nhớ.
- **Đàn gà chiến binh (Enemy):** Bay ziczac lượn sóng tự nhiên bằng hàm `Mathf.Sin`. Gà có thanh máu tăng theo từng Wave, chớp đỏ khi trúng đạn.
- **Vật lý Đùi gà (Bouncing Pickups):** Khi tiêu diệt gà, đùi gà văng nảy ngược lên trời trước khi rơi chậm bồng bềnh nhờ lực cản `drag`, tạo cơ hội cho người chơi bay tới đón.
- **Hệ thống Đợt liên hoàn (Infinite Wave Progression):** Mỗi đợt tiếp theo sẽ sinh nhiều gà hơn và gà trâu máu hơn.

### 2. Âm Thanh & Hiệu Ứng (VFX & SFX)
- **Hiệu ứng hạt nổ (Particle System):** Gà nổ tung tóe thành các tia lửa cam vàng hoành tráng khi bị bắn hạ.
- **Âm thanh sống động:** Tích hợp âm thanh bắn đạn (`Laser`), âm thanh nổ tung (`Explosion`) và âm thanh nhặt đùi gà (`Pickup/Coin`).

### 3. Hệ Thống Scene & Giao Diện UI
- **MainMenu Scene:** Tiêu đề, nút Chơi Mới, Thoát và **Bảng Hướng Dẫn Popup (Instructions Panel)**.
- **Gameplay Scene:** Hiển thị HUD điểm số thời gian thực (`SCORE`) và đợt hiện tại (`WAVE`).
- **EndGame Scene:** Tổng kết điểm số người chơi đạt được, cung cấp tùy chọn Chơi lại, về Menu hoặc Thoát.
- **GameManager (Singleton Pattern):** Sử dụng `DontDestroyOnLoad` để bảo toàn dữ liệu điểm số xuyên suốt giữa các Scene.

---

## 🏗️ Cấu Trúc Dự Án (Project Structure)

```text
Assets/
├── _Game/ (hoặc trực tiếp trong Assets)
│   ├── Prefabs/
│   │   ├── Asteroid.prefab      # Prefab Con Gà
│   │   ├── Laser.prefab         # Prefab Tia đạn
│   │   ├── Star.prefab          # Prefab Đùi gà
│   │   └── Explosion.prefab     # Hiệu ứng nổ Particle
│   ├── Scenes/
│   │   ├── MainMenu.unity       # Scene 0: Menu bắt đầu
│   │   ├── Gameplay.unity       # Scene 1: Màn chơi chính
│   │   └── EndGame.unity        # Scene 2: Màn kết thúc
│   ├── Scripts/
│   │   ├── GameManager.cs       # Quản lý điểm & vòng đời game (Singleton)
│   │   ├── PlayerController.cs  # Điều khiển tàu & bắn laser
│   │   ├── Laser.cs             # Logic đạn bay & va chạm
│   │   ├── Asteroid.cs          # Logic kẻ địch, máu, chớp đỏ & nổ
│   │   ├── Star.cs              # Vật lý rơi nảy của đùi gà
│   │   ├── Spawner.cs           # Bộ điều phối các Wave đợt gà
│   │   ├── GameplayUI.cs        # Hiển thị HUD điểm và wave
│   │   ├── MainMenuUI.cs        # Điều khiển nút bấm Menu & Hướng dẫn
│   │   └── EndGameUI.cs         # Xử lý tổng kết điểm & chơi lại
│   ├── Sprites/                 # Chứa Texture và Sprite Sheet
│   └── Audio/                   # Chứa các file SFX âm thanh .wav
