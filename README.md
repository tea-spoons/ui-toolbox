# UI Toolbox
A collection of handy things for UGUI.

## Gradient Component
A very simple and performant UGUI component for drawing a gradient between two colors.

Create one via `GameObject/Create/Gradient` or add a `Gradient` component to a GameObject.

## UI Blend Shaders
The project contains shaders and matching materials that are based on the default UI shader (`UI/Default`).
However, they are updated with different blend modes:
- `UI/Default (Multiply)`: Multiply blending (a x b)
- `UI/Default (Screen)`: Additive blending (a + b)

You can find the shaders for your own materials, or unpack the `Blending Materials` sample to get materials that use these shader.

## Installation

In Unity: **Window > Package Manager > + > Add package from git URL**, then enter:

```
https://github.com/tea-spoons/ui-toolbox.git
```

Pin a release by appending a tag, for example `#v0.5.2`.

## License

Copyright (c) 2026 Bigpoint. Authored by Muhammad Tarek Abdou.

Available for research, education and other noncommercial use under the [PolyForm Noncommercial 1.0.0](LICENSE.md)
license. Commercial use is not permitted.
