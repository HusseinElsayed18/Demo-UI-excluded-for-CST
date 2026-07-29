# Demo UI System (matching game)

> "I designed and implemented a fully event-driven matching game UI architecture from scratch in just 16 hours. Despite the rapid turnaround, I prioritized mobile-first optimization practices—such as event decoupling and component caching—allowing the project to run at a rock-solid 120 FPS with minimal frame times."

A highly optimized, decoupled, and event-driven architecture built for a Unity-based Matching Game. This repository demonstrates how to separate core grid logic, matching evaluations, and state validation from the visual UI layer using scalable C# patterns.

## 🎯 Architectural Highlights
* **Strict Decoupling:** The matching algorithms and grid states do not hold rigid references to UI components, allowing the core game logic to be fully testable and modular.
* **Event-Driven UI Updates:** Utilizes standard C# Actions and Delegates to trigger animations, flip cards, clear matches, and update scores instantly without costly polling loops.
* **Performance-First UI Layout:** Designed to prevent constant Unity Canvas rebuilding when managing multiple grid elements dynamically.

* ## 🎥 Gameplay & Interface Demo
▶️ [**Click Here to Watch the Gameplay Demo Video on Google Drive**]([YOUR_GOOGLE_DRIVE_LINK_HERE](https://drive.google.com/file/d/1O-DCytYk9GGdMy8PONb0Mei79_FAo3uU/view?usp=drive_link))

