Get-Module 

Get-AzResourceGroup | Select-Object ResourceGroupName, Location

New-AzStorageAccount -ResourceGroupName "738-28948c54-deploying-azure-infrastructure-using" -Name "acglearnmyothetstorageaccount" -Location "East US" -SkuName "Standard_LRS"

New-AzStorageAccount `
  -ResourceGroupName "738-28948c54-deploying-azure-infrastructure-using" `
  -Name "acglearnmyothetstorageaccount" `
  -Location "East US" `
  -SkuName "Standard_LRS"

$StorageAccountParams = @{
  ResourceGroupName = "738-28948c54-deploying-azure-infrastructure-using"
  Name              = "acglearnmyothetstorageaccount"
  Location          = "East US"
  SkuName           = "Standard_LRS"
}

New-AzStorageAccount @StorageAccountParams