# Plooto

## Overview and Core Features

Plooto is an application for handling Todo Items. 

Core Backend Architecture:
- Hexagonal Architecture - Core codes was designed to be modular and focuses on Domain Driven Design's Core domain approach.

Front-End Architecture:
- State Management - CQRS (Unidirectional Data Flow like) using Ngxs. - State Management was added to allow a scalable architecture for front-end.

Automated Unit Tests:
- Automated Core unit tests can be found in [here](https://github.com/keeed/Plooto/tree/master/tests/Plooto.Core.Tests).

Automated Integration Tests:
- Automated API end to end tests which runs several scenario can be found [here](https://github.com/keeed/Plooto/tree/master/tests/Plooto.App.Web.Tests).

Swagger:
- Swagger endpoint is added and can be accessed via **<base_url>/swagger**.

## High Level Architecture

![image](https://user-images.githubusercontent.com/11542472/67786638-314c9e80-faaa-11e9-8433-7f13b0f553ed.png)
