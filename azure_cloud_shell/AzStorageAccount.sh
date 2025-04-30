curl -sL https://aka.ms/InstallAzureCLIDeb | sudo bash

az login

MyResourceGroup="740-e171121d-deploying-azure-infrastructure-on-lin"
MyLocation="eastus"

az storage account create -g $MyResourceGroup -n myothet2024storageacc -l eastus --sku Standard_LRS