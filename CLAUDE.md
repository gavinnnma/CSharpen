# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What this is

CSharpen is a gated ("闯关式") learning project that teaches C# to someone with a solid C++ background. It is **12 progressive levels**; the learner fills in a single source file per level and runs xUnit tests to verify. **All 12 levels are implemented** as blank templates (every `Solution.cs` ships with `// TODO`s for the learner to fill in; tests are red until then). Roadmap and per-level main types are in `progress.md`.

The learner content (level READMEs, code comments) is intentionally written in **Simplified Chinese**, and every level explicitly contrasts each C# concept with its C++ equivalent — that contrast is the core pedagogical feature and must be preserved when authoring new levels.

`progress.md` is the source of truth for status, roadmap, and the level-authoring spec. Read it before adding levels.

## Commands

Run tests for a single level (the learner's normal workflow):
```bash
cd levels/01-basics && dotnet test
```

Progress management tool (cross-platform, run from repo root; replace `01` with the level number):
```bash
dotnet run --project tools -- save 01      # snapshot current Solution.cs as "last save"
dotnet run --project tools -- restore 01   # revert to last save (asks to confirm)
dotnet run --project tools -- reset 01     # revert to the original blank template (asks to confirm)
dotnet run --project tools -- submit 01    # run the level's tests; if green, save as "passing submission"
dotnet run --project tools -- solution 01  # load the last passing submission (asks to confirm)
dotnet run --project tools -- list         # list levels (marks [已通过] passing / [有存档] saved)
```
Commands that **overwrite** `Solution.cs` (`restore`/`reset`/`solution`) prompt for `y/N` confirmation; pass `--yes`/`-y` to skip (used for scripting/automation). `submit` shells out to `dotnet test` for that level and only archives on exit code 0.

`dotnet --version` here is 7.0.x. `global.json` pins SDK 7.0 with `rollForward: latestMajor`, so newer SDKs (8/9) also work.

## Architecture

**Each level is a self-contained xUnit test project** under `levels/NN-topic/`:
- `Solution.cs` — the **only** file the learner edits. Contains method stubs with `// TODO` markers throwing `NotImplementedException`. Types live in namespace `CSharpen.LevelNN`.
- `LevelNNTests.cs` — xUnit tests that reference the solution types directly (same namespace). **Never modified by the learner.** Cover normal + boundary cases, using `[Theory]` + `[InlineData]` where sensible.
- `LevelNN.csproj` — compiles `Solution.cs` and the tests together into one test assembly. Targets `net7.0` with `ImplicitUsings` and `Nullable` enabled.

Because solution code and tests compile into the same project, there is no separate "library" project — tests call e.g. `Basics.Add(...)` directly.

**The `tools/` console app** implements save/restore/reset/submit/solution. It keeps **three independent per-level archives** under `.csharpen/`, none of which overwrites another:
- `templates/NN/` — immutable original blank template, snapshotted on the first command touching a level; `reset` restores from here.
- `saves/NN/` — manual checkpoint; `save` writes, `restore` reads.
- `passing/NN/` — last test-passing code; `submit` writes (only when `dotnet test` exits 0), `solution` reads.

Other details: `submit` runs `dotnet test` in the level dir via `Process` (inherits the console). Confirmation is a `y/N` prompt (`--yes`/`-y` skips; non-interactive/EOF input is treated as "cancel"). The tool finds the repo root by walking up to the directory containing `global.json`, and resolves a level number like `01`/`1`/`level01` to the `levels/01-*` folder.

**`.csharpen/`** (templates + saves + passing) is deliberately **not** gitignored — it travels with the project so progress syncs across machines. `bin/`/`obj/` are ignored.

## Authoring new levels (02–12)

Follow Level 01 as the template and the spec in `progress.md`. Key conventions:
- Namespace `CSharpen.LevelNN`; test file `LevelNNTests.cs`; managed file always named `Solution.cs` (the tool assumes this name).
- 4–6 TODOs per level, difficulty increasing per level. Each TODO gets a comment explaining the requirement and, where relevant, the C++ contrast.
- Reuse Level 01's `.csproj` package versions: `Microsoft.NET.Test.Sdk` 17.8.0, `xunit` 2.6.2, `xunit.runner.visualstudio` 2.5.4.
- Level `README.md` structure: 目标 → 你要做什么 → 概念(含 C++ 对照) → 运行测试 → 卡住/改坏了(重置命令) → 过关提示.
