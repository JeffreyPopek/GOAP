# Goal-Oriented Action Planning (GOAP) in Unity

This project showcases the implementation of the Goal-Oriented Action Planning (GOAP) algorithm within a Unity environment. The primary objective was to research, dissect, and demonstrate the GOAP technique through a functional Unity demo, highlighting its versatility across various scenarios.

## Overview

GOAP enables AI agents in games to make intelligent decisions by formulating action plans based on defined goals. Unlike traditional behavior scripting, GOAP allows agents to dynamically determine the most efficient sequence of actions to achieve their objectives, resulting in more adaptive and lifelike behaviors.

## Key Features

- **Dynamic Action Planning**: Agents assess their current state and autonomously devise a sequence of actions to fulfill specific goals.
- **Action Cost Evaluation**: Each potential action is assigned a cost, guiding the agent to select the most resource-effective path.
- **Adaptive Decision Making**: Agents can re-evaluate and adjust their plans in response to environmental changes or unforeseen obstacles.

## Implementation Highlights

- **World State Management**: Developed a centralized system to monitor and update the game's world state, providing agents with real-time environmental data.
- **Action Framework**: Established a modular action class structure, allowing for straightforward creation and integration of new agent behaviors.
- **Custom Planning Algorithm**: Crafted a bespoke planner that evaluates available actions and assembles an optimal sequence to achieve the agent's goals.

For a comprehensive breakdown of the GOAP technique and detailed implementation insights, please visit the project page on my portfolio:

[Jeffrey Popek Portfolio GOAP Project](https://jeffreypopek.dev/goap.html)
