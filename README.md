# WPF WebView2Testing
WPF tabbed Desktop Window UX that renders multiple webview2 instances.

*This is proof-of-concept code, ugly, and shouldn't in any way be used in production*

![webview2-ux](WebView2Test/docs/webview2-wpf-test.gif)

## Observations
  - WebView2 renderering seems to use significantly less memory than chromium/electron
  - Initial loading of the webview content is reasonably fast, but may require UX treatment to feel seeamless in certain cases; this could be managed at the container level with the appropriate hooks
  - Resizing windows is jank, and does not feel smooth; other approaches (off screen rendering, transitions) may be needed
  - More complete tab switching UX (drag & drop), is not implemented. It needs to be implemented to assess performance impact

## Considerations
  - Performance: CPU, Memory, and overall responsiveness for non-trivial DOM based UIs (Grids, Animation, WebGL)
  - UX: loading, resizing and tabswitching "perception" of snappiness
  - Ease of implentation and maintenance

## Test Methodology
  - WPF window with three tabs, and custom UX so the title bar contains tabItems (similar to vscode's UX)
  - Load 4 instances of webview2 renderes within each tab that can auto-resize to parent window. Make sure they are non-trivial in terms of DOM/CPU
  - Load, tab switch, and resize to measure and assess performance and UX
  - Compare/contrst similar UX in electron, and potential WebView2 with win32/cpp or Maui bindings

## Test Plan
  - [x] Custom title bar with tab UX, min/max/close
  - [x] 4 WebView2 renders loaded per tab
  - [x] Resize and container window drag implemented 
  - [ ] Offscreen rendering on resize
  - [ ] Transitions on resize
  - [ ] Comparitive analysis vs
	- [ ] Electron
	- [ ] win32/cpp WV2
	- [ ] Maui WV2
