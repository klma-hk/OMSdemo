
# **Enterprise Trading OMS Front-End Reference Architecture**

## **Overview**

This project is a streamlined Windows Presentation Foundation (WPF) reference application demonstrating an institutional Order Management System (OMS) front-end. It serves a dual purpose: comparing modern desktop design patterns and showcasing the high-efficiency user workflows required on fast-paced trading desks.

**Key Features**

• Dual-Paradigm MVVM Comparison: The codebase contains parallel ViewModel implementations, contrasting legacy traditional MVVM boilerplate (INotifyPropertyChanged) with CommunityToolkit.Mvvm to demonstrate how modern Roslyn source generators reduce technical debt and maximize code maintainability.
• Keyboard-Driven Institutional UX: Engineered specifically for rapid, keyboard-only data entry to eliminate operational latency. The UI features optimized focus management, precise tab-indexing, and dedicated input bindings to support fast manual order placement without requiring a mouse.
