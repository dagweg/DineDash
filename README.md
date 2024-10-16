# Dine Dash

## Table of Contents

1. [Overview](#overview)
2. [Configuration](#configuration)

   i. [Environment Varialbes](#environment-variables)

## Overview

A robust REST API designed for a platform that connects food enthusiasts through shared dining experiences by allowing people to post dinner listings for customers to dine in their home. Built using Clean Architecture and Domain-Driven Design (DDD) principles, this project adheres to industry best practices to ensure maintainability and scalability

## Configuration

### Environment Variables

The `appsettings.json` in DineDash.Api is where all the application related variables are stored. For secrets,keys and other confidential information; you'll notice that they empty. You'll need to configure them this way

1. For first time env setup

   ```bash
   dotnet user-secrets init --project .\DineDash.Api\
   ```

2. For setting a variable
   ```bash
   dotnet user-secrets init --project .\DineDash.Api\ "SectionName:VariableName" "E3IJP9J8F80APERAPF4580VNMZM"
   ```
3. To see all set variables
   ```bash
   dotnet user-secrets list --project .\DineDash.Api\
   ```
