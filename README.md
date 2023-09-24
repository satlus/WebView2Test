# WPF WebView2Testing
Test WPF tabbed Desktop Window UX that renders multiple webview2 instances as TabItem chidren.

## Considerations
  - Performance: CPU, Memory, and overall responsiveness for non-trivial DOM based UIs (Grids, Animation, WebGL)
  - UX: loading, resizing and tabswitching "perception" of snappiness


## Test Methodology
  - WPF window with three tabs, and custom UX so the title bar contains tabItems (similar to vscode's UX)
  - Load 4 instances of webview2 renderes within each tab. Make sure they are non-trivial
  - Load, tab switch, and resize to measure and assess performance and UX

