# ![teams](https://img.icons8.com/fluency/microsoft-teams-2019.png) Microsoft Teams Fix

[![Download](https://img.shields.io/github/v/release/vpess/teams-fix?color=%237B83EB&style=plastic)](https://github.com/vpess/teams-fix/releases/download/1.0/TeamsFix.exe)

Projeto baseado em [um script Powershell escrito por mim](https://github.com/vpess/Powershell-Scripts/blob/main/teams-fix.ps1).

Corrige problemas genéricos do Microsoft Teams, como foto de perfil desatualizada e afins. Caso haja a necessidade, também realiza a reinstalação do software, baixando o instalador no site oficial da Microsoft.

O log de execução fica em `%localappdata%\teams_fix.log`.

Interface feita com **WPF**. Utiliza o **.NET Framework 4.7**, e compila um executável único com [Costura](https://www.nuget.org/packages/Costura.Fody/).

![c-sharp](https://img.icons8.com/color/1x/c-sharp-logo.png)
