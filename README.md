# KEPLAIR

Working Unity project for **KEPLAIR LO*OP Center** — the codebase that powers interactive experiments, prototypes, and production builds.

> This repository is a Unity project (standard layout with `Assets/`, `Packages/`, and `ProjectSettings/`).

---

## ✨ Highlights

- **Unity-based** project with C# gameplay code and shaders (ShaderLab/HLSL)  
- Organized with a conventional Unity structure for easy import and build  
- Cross-platform friendly

---

## 🧰 Requirements

- **Unity Editor** (use the exact version recorded by the project)  
  - Find it in `ProjectSettings/ProjectVersion.txt` after cloning.
- Platform SDKs as needed:
  - **Windows**: Visual Studio with .NET + Unity workloads  
  - **macOS/iOS**: Xcode (for iOS/macOS builds)  
  - **Android**: Android SDK + NDK + OpenJDK (configure via Unity Hub)

> Tip: If the exact Unity version isn’t installed, add it via **Unity Hub → Installs → Add** and re-open the project with that version.

---

## 🚀 Quick Start

1. **Clone**
   ```bash
   git clone https://github.com/Ballomizzy2/KEPLAIR.git
   cd KEPLAIR
   ```
2. **Open in Unity**
   - Open **Unity Hub → Projects → Add** and select the repo root.
   - Unity will auto-import packages on first open.
3. **Play**
   - Open the primary scene (e.g., `Assets/Scenes/Main.unity`) and press **Play**.
   - If scenes are organized differently, check `Assets/` for a `Scenes/` or `Samples/` folder.

---

## 📦 Project Layout

```
KEPLAIR/
├─ Assets/               # Game code, scenes, prefabs, materials, shaders
├─ Packages/             # Package manifest & lock (UPM)
├─ ProjectSettings/      # Unity project/editor settings (incl. ProjectVersion)
└─ README.md
```

> The key Unity directories (`Assets/`, `Packages/`, `ProjectSettings/`) define the project; opening the repo root in Unity should “just work.”

---

## 🏗️ Building

### General
1. **Switch Platform**: `File → Build Settings… → [Select Target] → Switch Platform`
2. **Add Scenes**: Make sure the required scenes are in **Scenes In Build** (top of Build Settings).
3. **Player Settings**: Set product name, bundle identifier, icons, and resolution in `Project Settings → Player`.
4. **Build**: Click **Build** (or **Build And Run**).

### Platform Notes
- **Windows/macOS/Linux**: No extra setup beyond standard Unity desktop profiles.
- **Android**: Install SDK/NDK/JDK via **Unity Hub → Installs → Add modules** or set custom paths in `Preferences → External Tools`.
- **iOS**: Build an Xcode project from Unity; open in Xcode and archive/sign there.

---

## 🔧 Development Notes

- **Packages**: Managed via Unity Package Manager (see `Packages/manifest.json`).
- **Scripting Runtime**: C# (version depends on Unity version).  
- **Shaders**: ShaderLab + HLSL; verify render pipeline (Built-in/URP/HDRP) in Graphics settings.
- **Source Control**: Unity-friendly `.gitignore` recommended; Library/Temp are regenerated on import.

---

## 🎮 Scenes

- **Entry Scene**: Sample Scene

> If you use a bootstrap loader, note the script & asset references here for quick onboarding.

---

## 🤝 Contributing

1. Fork and create a feature branch.
2. Follow existing C# style (e.g., **PascalCase** for public APIs, **camelCase** for fields).
3. Keep prefabs and scenes modular; avoid massive scene-wide changes in a single PR.
4. Test in Editor and (if applicable) on device for platform-specific code.

---

## 📦 Release & Versioning (optional)

- Tag releases as `vMAJOR.MINOR.PATCH` (e.g., `v1.2.0`).
- Optionally publish platform builds under **GitHub Releases**.

---

### Maintainers

- **@Ballomizzy2** — primary maintainer and project owner.
