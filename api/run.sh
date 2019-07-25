#!/bin/bash

dotnet restore
dotnet build

dotnet run --launch-profile "Payroll.Api" --project ./Payroll.Api/Payroll.Api.csproj