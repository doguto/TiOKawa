# TiOKawa

## OverView

TiOKawa is a Unity framework that provides a structured approach to Unity development using the MVP (Model-View-Presenter) architectural pattern. The framework is designed to help developers create maintainable and scalable Unity projects by separating concerns and providing reactive programming capabilities through UniRx integration.

Key features:
- MVP architectural pattern implementation for Unity
- Scene scaffolding tools for rapid project setup
- Reactive UI components with UniRx integration
- Modular assembly structure with clear separation of concerns
- Unity Editor tools for automated project structure generation

## Architecture

TiOKawa implements the MVP (Model-View-Presenter) pattern with the following structure:

### Core Components

- **Model**: Data layer handling business logic and state management
- **View**: UI layer containing MonoBehaviour-based components that handle user interactions
- **Presenter**: Mediator layer that connects Models and Views, managing the flow of data and user interactions

### Key Classes

- `MonoView`: Abstract base class for all View components, providing initialization lifecycle
- `MonoPresenter`: Abstract base class for Presenter components with setup hooks for Model, View, and subscriptions
- `ButtonBase`: Reactive button implementation using UniRx for event handling
- `SceneScaffold`: Unity Editor tool for automatic generation of MVP folder structures and assembly references

### Project Structure

```
Assets/TiOKawa/
├── Editor/
│   └── SceneScaffold.cs        # Editor tool for scaffolding
├── Scripts/
│   ├── Model/                  # Business logic layer
│   ├── Presenter/              # Mediator layer
│   │   └── MonoPresenter.cs
│   └── VIew/                   # UI layer
│       ├── MonoView.cs
│       ├── ButtonBase.cs
│       └── SimpleButton.cs
└── Scenes/                     # Scene-specific implementations
    ├── Battle/
    └── Title/
```

### Dependencies

- **UniRx**: For reactive programming and event handling
- **UniTask**: For async/await support in Unity

## COntributers

- **kuto** - Project creator and main developer
- **copilot-swe-agent[bot]** - Automated contributions
