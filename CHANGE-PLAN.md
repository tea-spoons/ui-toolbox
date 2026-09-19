# Change plan

> Draft. This file tracks what changed on the way to this repo and what I plan to change next. Edit freely.

## Origin

Originally developed at Bigpoint. Published here with Bigpoint's permission for research, education and other noncommercial use. Copyright (c) 2026 Bigpoint; see [LICENSE.md](LICENSE.md).

## Changes made before publishing

- Namespaces are now `TeaSpoons.*` and the package id is `com.tea-spoons.ui-toolbox` (assemblies renamed to match).
- Internal build, registry and tracker references were removed; the repo uses GitHub Actions (`CI` and `Release`) built on `unity-ci-kit`.
- Added `LICENSE.md` (PolyForm Noncommercial 1.0.0), an install section in the README, and package metadata (author, license and documentation URLs).
- The samples folder now uses Unity's hidden `Samples~` layout and is registered in `package.json`.
- Removed the UI Line Renderer (adapted from community forum and gist code without a stated license).
- The two UI shaders are based on Unity's built-in shaders (MIT); the notice is in `THIRD-PARTY-NOTICES.md`.
- Made standalone: the runtime and editor assemblies are compiled only when uGUI is in the project.
- Restored the `.meta` files inside `Samples~`: the first migration dropped them, which breaks the links between sample assets when a sample is imported.

## Planned changes

- [x] Tag and publish `v0.6.1` with the Release workflow.
- [ ] Write a new UI line renderer as original code.
<!-- review-items:start -->
- [ ] **P0** Rename `Gradient` (for example `UIGradient`) and move it out of `UnityEngine.UI` into `TeaSpoons.UIToolbox`. This is a breaking change, so bump the minor version and note it in the changelog.
- [ ] **P0** `package.json` has no `unity` field. Set it to the lowest Unity version that is actually tested (only 6000.3.8f1 was tested in this review).
- [ ] **P1** Turn `colorB` and `direction` into properties that call `SetVerticesDirty()` (keeping the serialized field names).
- [ ] **P1** Add tests: vertex colors per direction for `Gradient`, and `ScrollingImage` offset math.
- [ ] **P2** Add a `CHANGELOG.md`. Unity's package layout lists one next to `README.md`, and the `unity-ci-kit` validator warns without it.
- [ ] **P2** The README is only 44 lines. Add a short example for each public type.
<!-- review-items:end -->

<!-- review:start -->
## Review (September 2026)

Reviewed as a senior Unity engineer would: I read the code and compared the package with similar open-source projects (September 2026). Those projects are listed for ideas only. Nothing was copied from them, and their licenses are noted in case code is ever reused. Priorities: **P0** correctness bug or broken metadata, **P1** should be done soon, **P2** nice to have.

### Compared with

No close open-source comparable turned up in this pass, so the findings below come from reading the code.

### Findings from reading the code

- **[Naming]** `Gradient : MaskableGraphic` is declared in the `UnityEngine.UI` namespace (`Gradient.cs`), and `UnityEngine.Gradient` is a Unity type. Code that imports both namespaces and writes `Gradient` gets an ambiguous reference (CS0104).
- **[API]** `colorB` and `direction` are public fields. Changing them from a script at runtime does not mark the mesh dirty. Only the Inspector refreshes it, through `OnValidate` of the base class.
- **[Tests]** None.
- **[Provenance]** The shaders say they are based on Unity's built-in shader source (MIT, noted in `THIRD-PARTY-NOTICES.md`). Keep that notice with every release.
<!-- review:end -->

## Notes and ideas

_Add your own here._
