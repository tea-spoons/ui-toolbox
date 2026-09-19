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

## Planned changes

- [ ] Tag and publish `v0.5.2` with the Release workflow.
- [ ] Write a new UI line renderer as original code.

## Notes and ideas

_Add your own here._
