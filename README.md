
# unity(2d)



\# 🎮 Sprite Quest 



> 一款基于 Unity 引擎独立开发的 2D 横版动作冒险游戏。包含完整的游戏循环、战斗系统与 Boss 战。

\## 📸 游戏截图 

<img width="848" height="527" alt="屏幕截图 2026-10-20 175316" src="https://github.com/user-attachments/assets/c68d002c-abf5-4c64-a141-1ae008e8497a" />
<img width="841" height="530" alt="屏幕截图 2026-10-20 175511" src="https://github.com/user-attachments/assets/359c70ad-6a73-4985-a70d-65733cea2355" />
<img width="1253" height="794" alt="屏幕截图 2026-10-20 175647" src="https://github.com/user-attachments/assets/fde9409a-3971-4449-b893-a99fdcdadb52" />
<img width="1255" height="794" alt="屏幕截图 2026-10-20 175700" src="https://github.com/user-attachments/assets/1cf64c9f-b95e-4477-a455-81e10fd314ca" />

\## 🎮 核心玩法与操作

\*   `A / D` 或 `左右方向键`：角色移动

\*   `Space`：跳跃

\*   `J`：近战攻击

\*   `E`：暂停/恢复游戏

\*   `ESC`：退出游戏



\## 🚀 如何下载与运行 

1\. 点击本页面右侧的 “Releases" 标签页。

2\. 下载最新版本的 `My First Game.zip` 压缩包。

3\. 解压后，双击 `my first game(2d).exe` 即可开始游玩。（无需安装 Unity）



\## 🛠️ 技术栈与核心亮点

本项目在开发中实践了以下核心技术：

\*   "架构设计"：采用模块化设计，将玩家、敌人 AI、UI、GameManager 解耦。

\*   "状态机与动画"：基于 Animator 实现玩家与怪物的状态流转，解决了动画打断与抽搐问题。

\*   "物理与战斗"：自定义物理移动、脚底矩形框检测防连跳；实现了受击无敌帧（i-frames）与卡肉顿帧（HitStop）机制提升打击感。

\*   "敌人 AI"：基于距离检测实现怪物的巡逻、追击与攻击有限状态机。Boss 具备登场无敌与规律出招。



\## 📁 目录结构

\*   `Assets/Scripts`：包含所有核心 C# 脚本（玩家控制、敌人 AI、UI 管理等）。

\*   `Assets/Prefabs`：游戏中的预制体（怪物、子弹、UI 面板等）。



\## ⚙️ 开发环境

\*   \*\*引擎\*\*：Unity 6.3 LTS

\*   \*\*语言\*\*：C#

\*   \*\*IDE\*\*：Visual Studio

